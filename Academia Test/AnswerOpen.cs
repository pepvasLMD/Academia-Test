using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia_Test
{
    public class AnswerOpen : AnswerType
    {
        private List<String> keyWords;

        public AnswerOpen(List<String> keyWords)
        {
            this.keyWords = keyWords;
        }
        public bool CheckAnswer(string answer)
        {
            foreach(string keyWord in keyWords)
            {
                if (!answer.ToLower().Trim().Contains(keyWord.ToLower().Trim()))
                {
                    return false;
                }
            }

            return true;
        }

        public List<String> KeyWords
        {
            get;
        }
    }
}
