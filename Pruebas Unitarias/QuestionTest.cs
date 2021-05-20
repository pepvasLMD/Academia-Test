using System;
using System.Collections.Generic;
using Academia_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Pruebas_Unitarias
{
    [TestClass]
    public class QuestionTest
    {
        

        [TestMethod]
        public void testGoodAnswer()
        {
            string question = "¿Quién escribió La Odisea?";
            List<string> keyWords = new List<string> { "homero" };
            int value = 10;

            AnswerOpen answerOpen = new AnswerOpen(keyWords);
            Question objQuestion = new Question(question, value, answerOpen);

            objQuestion.AnswerUser = "Homero";

            Assert.AreEqual(true, objQuestion.GoodAnswer());
        }

        [TestMethod]
        public void testGoodAnswerFalse()
        {
            string question = "¿Quién es el actual presidente de Mexico?";
            List<string> choices = new List<string> { "homero", "Andres Manuel", "Marcos" };
            string rightAnswer = "Andres Manuel";
            int value = 5;

            AnswerChoice answerChoice = new AnswerChoice(choices, rightAnswer);
            Question objQuestion = new Question(question, value, answerChoice);

            objQuestion.AnswerUser = "Manuel";
            Assert.AreEqual(false, objQuestion.GoodAnswer());
        }
    }
}
