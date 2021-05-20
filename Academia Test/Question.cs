using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia_Test
{
    public class Question
    {
        private string description;
        private int value;
        private AnswerType answerType;
        private string answerUser;

        public Question(string description, int value, AnswerType answerType)
        {
            this.description = description;
            this.value = value;
            this.answerType = answerType;
            this.answerUser = "";
        }

        public string AnswerUser
        {
            get { return answerUser; }
            set { answerUser = value; }
        }

        public string Description
        {
            get { return description; }
        }

        public int Value
        {
            get
            { return value; }
        }

        public AnswerType AnswerType
        {
            get { return answerType; }
        }

        public bool GoodAnswer()
        {
            return answerType.CheckAnswer(this.answerUser);
        }
    }
}
