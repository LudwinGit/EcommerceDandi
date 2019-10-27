using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practica4.Tests.Controllers
{
    [TestClass]
    public class WSTest
    {
        [TestMethod]
        public void conexionCreada()
        {
            WSBanguat.TipoCambioSoapClient ws = new WSBanguat.TipoCambioSoapClient();
            string estado = ws.State.ToString();
            Assert.IsTrue(estado == "Created");
        }

        [TestMethod]
        public void fechaCorrectaDelDiaCambioTasa()
        {
            WSBanguat.TipoCambioSoapClient ws = new WSBanguat.TipoCambioSoapClient();
            string fechaServicio = ws.TipoCambioDia().CambioDolar[0].fecha;
            Assert.IsTrue(fechaServicio == DateTime.UtcNow.Date.ToString("dd/MM/yyyy"));
        }

        [TestMethod]
        public void cambioTasaMayoraCero()
        {
            WSBanguat.TipoCambioSoapClient ws = new WSBanguat.TipoCambioSoapClient();
            float cambio = ws.TipoCambioDia().CambioDolar[0].referencia;
            Assert.IsTrue(cambio > 0f);
        }

        [TestMethod]
        public void cambioTasaMayoraCerod()
        {
            WSBanguat.TipoCambioSoapClient ws = new WSBanguat.TipoCambioSoapClient();
            float cambio = ws.TipoCambioDia().CambioDolar[0].referencia;
            Assert.IsTrue(cambio > 0f);
        }

    }
}
