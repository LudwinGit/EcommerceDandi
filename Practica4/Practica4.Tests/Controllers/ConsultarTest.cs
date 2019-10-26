using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica4.Controllers;

namespace Practica3y4.Tests.Controllers
{
    [TestClass]
    public class ConsultarTest
    {
        [TestMethod]
        public void TestConsultaSaldo()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool result = con.consulta(12345678);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestConsultaSaldoF()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool result = con.consulta(123456789);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestVerificaCuentaConsulta()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool resul = con.verificarCuenta(12345678);
            Assert.IsNotNull(resul);
        }

        [TestMethod]
        public void TestVerificaCuentaConsultaF()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool resul = con.verificarCuenta(123456789);
            Assert.IsNotNull(resul);
        }

        [TestMethod]
        public void TestRespuesta()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool result = con.Respuesta(1234456677);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestRespuestaF()
        {
            ConsultarSaldoController con = new ConsultarSaldoController();
            bool result = con.Respuesta(1234456697);
            Assert.IsNotNull(result);
        }
    }
}
