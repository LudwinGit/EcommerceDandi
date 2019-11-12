using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3y4.Controllers;

namespace Practica3y4.Tests.Controllers
{
    [TestClass]
    public class TransferenciaMonetariaTest
    {
        [TestMethod]
        public void ValidarDatosDePersona_CuentaSeaString()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.NombreCuenta = "Andrea Lissette Flores Aguilar";
            bool resultado = cuenta.ValidarString();
            Assert.IsTrue(resultado);

        }
        [TestMethod]
        public void ValidarNoCuentaSeaNumero()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.NumeroCuenta =2352473080117 ;
            bool resultado = cuenta.ValidarMonto();
            Assert.IsTrue(resultado);

        }
        [TestMethod]
        public void ValidarTipoMonto()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.Monto = 370;
            bool resultado = cuenta.ValidarMonto();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void MontoMayorCero()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.Monto = 5;
            bool resultado = cuenta.ValidarMayorCero();
            Assert.IsTrue(resultado);
        }
        
        [TestMethod]
        public void DiferenteNoNulls()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.NombreCuenta = "Xiomara Colindres";
            cuenta.NumeroCuenta = 2356897412356;
            cuenta.Monto = 475;
            bool resultado = cuenta.ValidarNoNulls();
            Assert.IsTrue(resultado);

        }
        [TestMethod]
        public void SaldoSuficiente()
        {
            TransferenciaMonetariaController cuenta = new TransferenciaMonetariaController();
            cuenta.Monto = 780;
            cuenta.Saldo = 1500;
            bool resultado = cuenta.VerificarSaldoSuficiente();
            Assert.IsTrue(resultado);

        }

    }
}
