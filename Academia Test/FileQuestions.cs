using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.Linq;

namespace Academia_Test
{
    class FileQuestions : ObtainQuestions
    {
        private XLWorkbook file;
        private int numberQuestions;
        private List<Question> questions;
        private string path;

        public FileQuestions(string path, int numberQuestions)
        {
            this.path = path;
            this.numberQuestions = numberQuestions;
            questions = new List<Question>();

            
        }

        private void init()
        {
            try
            {
                file = new XLWorkbook(path);

                var ws = file.Worksheet(1);
                var firstRowUsed = ws.FirstRowUsed();
                var dataRow = firstRowUsed.RowUsed();


                while (!dataRow.Cell(2).IsEmpty())
                {
                    var cell = dataRow.Cell(2);

                    if (cell.GetString().ToLower().Equals("abierta"))
                    {
                        readQuestionOpen(dataRow);
                    }
                    else if (cell.GetString().ToLower().Equals("cerrada"))
                    {
                        readQuestionClose(dataRow);
                    }

                    dataRow = dataRow.RowBelow();

                    if (dataRow.Cell(2).IsEmpty())
                        dataRow = dataRow.RowBelow();

                }

            }
            catch(Exception e)
            {}
        }

        private void readQuestionOpen(IXLRangeRow dataRow)
        {
            dataRow = dataRow.RowBelow();
            string question = dataRow.Cell(2).GetString();

            dataRow = dataRow.RowBelow();
            int value = Convert.ToInt32(dataRow.Cell(2).GetString());

            dataRow = dataRow.RowBelow();
            List<string> keyWords = new List<string>(dataRow.Cell(2).GetString().Split(","));
            AnswerOpen answerOpen = new AnswerOpen(keyWords);
            Question objQuestion = new Question(question, value, answerOpen);
            questions.Add(objQuestion);
        }

        private void readQuestionClose(IXLRangeRow dataRow)
        {
            dataRow = dataRow.RowBelow();
            string question = dataRow.Cell(2).GetString();

            dataRow = dataRow.RowBelow();
            int value = Convert.ToInt32(dataRow.Cell(2).GetString());

            dataRow = dataRow.RowBelow();
            string rightChoice = dataRow.Cell(2).GetString();

            dataRow = dataRow.RowBelow();
            List<String> choices = new List<string>();

            while (!dataRow.Cell(2).IsEmpty())
            {
                choices.Add(dataRow.Cell(2).GetString());
                dataRow = dataRow.RowBelow();
            }

            AnswerChoice answerChoice = new AnswerChoice(choices, rightChoice);
            Question objQuestion = new Question(question, value, answerChoice);
            questions.Add(objQuestion);
        }

        public List<Question> getQuestions()
        {
            questions.Clear();
            init();

            if (questions.Count > numberQuestions)
            {
                Random randNum = new Random();
                List<Question> questionOutput = new List<Question>();

                while (questions.Count > 0)
                {
                    int val = randNum.Next(0, questions.Count - 1);
                    questionOutput.Add(questions[val]);
                    questions.RemoveAt(val);
                }

                return questionOutput.GetRange(0, numberQuestions);

            }
            else
            {
                return questions;
            }
        }
    }
}
