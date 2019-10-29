using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Practica4.Controllers;

namespace Practica4.Tests.Controllers
{
    [TestClass]
    public class PefilTest
    {
        [TestMethod]
        public void testIrA_Sucess()
        {
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            var result = controller.vPerfil() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void testIrA_Fail()
        {
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            var result = controller.IrA("@") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
