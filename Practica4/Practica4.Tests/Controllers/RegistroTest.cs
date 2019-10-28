using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica4.Controllers;
using System.Web.Mvc;

namespace Practica4.Tests.Controllers
{
    [TestClass]
    public class RegistroTest
    {
        [TestMethod]
        public void TestView()
        {
            RegistroController controlller = new RegistroController();
            ViewResult result = controlller.RegistroView() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCampos()
        {
            RegistroController controller = new RegistroController();
            bool test = controller.validarCAmpos("Rick", "Alvarez", 13344554, 34345665, "1234");
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestUserLength()
        {
            RegistroController con = new RegistroController();
            bool result = con.verificarUsuario(1234567);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUserLengthF()
        {
            RegistroController con = new RegistroController();
            bool result = con.verificarUsuario(12345657);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPasswordLength()
        {
            RegistroController controller = new RegistroController();
            bool result = controller.verificarPassword("usuaio1234");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPasswordLengthF()
        {
            RegistroController controller = new RegistroController();
            bool result = controller.verificarPassword("usuaio1234");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNumeroUsuario()
        {
            RegistroController con = new RegistroController();
            bool result = con.validarNoUsuario(1243454534);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNumeroUsuarioF()
        {
            RegistroController con = new RegistroController();
            bool result = con.validarNoUsuario(1243454534);
            Assert.IsTrue(result);
        }
    }
}
