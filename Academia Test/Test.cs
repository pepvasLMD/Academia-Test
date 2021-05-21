using System.Collections.Generic;
using System.Linq;

namespace Academia_Test
{
    public class Test
    {
        private List<Question> questions;

        public Test()
        {
            this.questions = new List<Question>();
        }

        public int NumberGoodAnswer()
        {
            return questions.FindAll(x => x.GoodAnswer()).Count();
        }

        public int NumberBadAnswer()
        {
            return questions.FindAll(x => !x.GoodAnswer()).Count();
        }

        public int NumberQuestions()
        {
            return questions.Count();
        }

        public List<Question> GoodQuestions()
        {
            return questions.FindAll(x => x.GoodAnswer()).ToList();
        }

        public List<Question> BadQuestions()
        {
            return questions.FindAll(x => !x.GoodAnswer()).ToList();
        }

        public Question getQuestion(int index)
        {
            return questions[index];
        }

        public int MaxScore()
        {
            return questions.Aggregate(0, (x, y) => x + y.Value);
        }

        public void ObtainQuestions(string path, int numberQuestions)
        {
            ObtainQuestions fileQuestions = new FileQuestions(path, numberQuestions);

            this.questions = fileQuestions.getQuestions();
        }
    }
}
