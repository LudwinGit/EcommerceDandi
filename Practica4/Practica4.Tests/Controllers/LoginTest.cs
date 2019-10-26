using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Practica4.Controllers;


namespace Practica4.Tests.Controllers
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void testLogueo_Fail()
        {
            LoginController controller = new LoginController();
            // Act
            var result = controller.Loguear("123@23", "password") as ActionResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void testLogueo_Sucess()
        {
            LoginController controller = new LoginController();
            // Act
            var result = controller.Loguear("30000003", "CCCC0000") as ActionResult;
            // Assert
            Assert.IsNotNull(result);
        }

    }
}
