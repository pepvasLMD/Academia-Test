using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia_Test
{
    class AnswerChoice : AnswerType
    {
        private List<string> choices;
        private string rightChoice;

        public AnswerChoice(List<string> choices, string rightChoice)
        {
            this.choices = choices;
            this.rightChoice = rightChoice;
        }
        public bool CheckAnswer(string answer)
        {
            foreach(string choice in choices)
            {
                if (choice.ToLower().Trim().Equals(rightChoice.ToLower().Trim()))
                    return true;
            }

            return false;
        }

        public List<String> Choices
        {
            get { return choices; }
        }

        public string RightChoice
        {
            get { return rightChoice; }
        }
    }
}
