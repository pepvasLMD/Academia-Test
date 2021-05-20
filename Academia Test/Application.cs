using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia_Test
{
    class Application
    {
        private string student;
        private string pathFile;
        private int numberQuestions;
        private Test test;

        public Application()
        {
            student = "";
            pathFile = "";
            numberQuestions = 0;
            test = new Test();
        }

        public void init()
        {
            int counter = 0;
            string seguir = "";

            Console.WriteLine("======== Bienvenido al test para alumno ======== \n");

            AskNameStudent();

            do
            {
                AskPathFile();
                AskNumberQuestions();
                test.ObtainQuestions(pathFile, numberQuestions);

                Console.WriteLine("Numero de preguntas: {0}", test.NumberQuestions());

                while (counter < test.NumberQuestions()){
                    makeQuestion(counter);
                    counter++;
                }

                if(test.NumberQuestions() > 0)
                    ShowResults();

                Console.Write("Desea hacer otro test?: ");
                seguir = Console.ReadLine().ToLower().Trim();

            }
            while (seguir == "si");
            
        }

        private void AskNameStudent()
        {
            do
            {
                Console.Write("Escribe tu nombre: ");
                student = Console.ReadLine();
            }
            while (student == "");

            Console.WriteLine();
        }

        private void AskPathFile()
        {
            do
            {
                Console.Write("Escribe la ubicación del archivo: ");
                pathFile = Console.ReadLine();
            }
            while (pathFile == "");

            Console.WriteLine();
        }

        private void AskNumberQuestions()
        {
            do
            {
                Console.Write("Escribe el numero de preguntas: ");
                int.TryParse(Console.ReadLine(), out numberQuestions);
            }
            while (numberQuestions <= 0);

            Console.WriteLine();
        }

        private void makeQuestion(int index)
        {
            Question question = test.getQuestion(index);

            Console.WriteLine("{0}.- {1}",(index + 1), question.Description);

            if (question.AnswerType.GetType() == typeof(AnswerChoice))
            {
                var answerChoicedd = question.AnswerType as AnswerChoice;

                List<string> choices = answerChoicedd.Choices;

                foreach(string choice in choices)
                {
                    Console.WriteLine(choice);
                }
            }

            Console.Write("Escribe tu respuesta: ");
            question.AnswerUser = Console.ReadLine();

            Console.WriteLine();
        }



        private void ShowResults()
        {

            Console.WriteLine();
            Console.WriteLine("Numero de aciertos: {0}", test.NumberGoodAnswer());
            Console.WriteLine("Numero de malas: {0}", test.NumberBadAnswer());
            Console.WriteLine("Puntos obtenidos {0} de {1}", test.GoodQuestions().Aggregate(0, (x, y) => x + y.Value), test.MaxScore());

            if(test.NumberBadAnswer() > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Preguntas Malas");

                foreach (Question question in test.BadQuestions())
                {
                    Console.WriteLine(question.Description);
                }

                Console.WriteLine();
            }
            
        }
    }
}
