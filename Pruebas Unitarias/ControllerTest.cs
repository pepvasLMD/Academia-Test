using System;
using System.Collections.Generic;
using Academia_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void obtainQuestions()
        {
            Test objTest = new Test();
            string path = "C:\\Users\\Eduardo\\Documents\\Preguntas.xlsx";
            int numberQuestions = 3;


            objTest.ObtainQuestions(path, numberQuestions);

            Assert.AreEqual(3, objTest.NumberQuestions());

        }

        public void obtainQuestionsBadPath()
        {
            Test objTest = new Test();
            string path = "C:\\Users\\Eduardo\\Documents\\Prreguntas.xlsx";
            int numberQuestions = 3;


            objTest.ObtainQuestions(path, numberQuestions);

            Assert.AreEqual(0, objTest.NumberQuestions());

        }
    }
}
