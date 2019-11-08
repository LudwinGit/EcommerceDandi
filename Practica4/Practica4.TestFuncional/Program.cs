using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Practica4.TestFuncional
{
    class Program
    {
        static void Main(string[] args)
        {
            //LOGIN
            //TestLoginSuccess();
            //TestLoginFail();

            //REGISTRO DE USUARIOS
            TestRegistroSuccess();
            //TestRegistroFail();

            //PERFIL
            //TestPerfilSuccess();

            //CONSULTAR SALDO
            //TestConsultarSuccess();

            //TIPO DE CAMBIO
            //TestTipoCambioFail();
            //TestTipoCambioSuccess();

            //TRANSFERENCIA MONETARIA
            //TestTransferenciaSuccess();
            //TestTransferenciaFail();

        }

        public static void TestLoginSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
        }
        public static void TestLoginFail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("00000000");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("password incorrecto");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
        }
        public static void TestRegistroSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement btnLogear = driver.FindElement(By.Id("registro"));
            btnLogear.Click();

            IWebElement nombres = driver.FindElement(By.Id("nombre"));
            nombres.SendKeys("Keylor");
            IWebElement apellidos = driver.FindElement(By.Id("apellidos"));
            apellidos.SendKeys("Navas");
            IWebElement dpi = driver.FindElement(By.Id("dpi"));
            dpi.SendKeys("1234567891011");
            IWebElement correo = driver.FindElement(By.Id("mail"));
            correo.SendKeys("keylor@gmail.com");
            IWebElement cuenta = driver.FindElement(By.Id("cuenta"));
            cuenta.SendKeys("12345678");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("PASS1234");

            IWebElement ingresar = driver.FindElement(By.Id("btn"));
            ingresar.Click();
        }
        public static void TestRegistroFail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement btnLogear = driver.FindElement(By.Id("registro"));
            btnLogear.Click();

            IWebElement nombres = driver.FindElement(By.Id("nombre"));
            nombres.SendKeys("Keylor");
            IWebElement apellidos = driver.FindElement(By.Id("apellidos"));
            apellidos.SendKeys("Navas");
            IWebElement dpi = driver.FindElement(By.Id("dpi"));
            dpi.SendKeys("12345");
            IWebElement correo = driver.FindElement(By.Id("mail"));
            correo.SendKeys("keylor@gmail.com");
            IWebElement cuenta = driver.FindElement(By.Id("cuenta"));
            cuenta.SendKeys("12345678");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("Paaa");

            IWebElement ingresar = driver.FindElement(By.Id("btn"));
            ingresar.Click();
        }
        public static void TestPerfilSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnTipoCambio = driver.FindElement(By.Id("tipoCambio"));
            btnTipoCambio.Click();
        }
        public static void TestConsultarSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnConsultar = driver.FindElement(By.Id("consultar"));
            btnConsultar.Click();
            IWebElement Consultar = driver.FindElement(By.Id("btn"));
            Consultar.Click();
        }
        public static void TestTipoCambioSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnConsultar = driver.FindElement(By.Id("tipoCambio"));
            btnConsultar.Click();
            IWebElement fecha = driver.FindElement(By.Id("date"));
            fecha.SendKeys("01-11-2019");
            IWebElement Consultar = driver.FindElement(By.Id("cambio"));
            Consultar.Click();
        }
        public static void TestTipoCambioFail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnConsultar = driver.FindElement(By.Id("tipoCambio"));
            btnConsultar.Click();
            IWebElement Consultar = driver.FindElement(By.Id("cambio"));
            Consultar.Click();
        }
        public static void TestTransferenciaSuccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnTipoCambio = driver.FindElement(By.Id("transferencia"));
            btnTipoCambio.Click();

            IWebElement txtNombres = driver.FindElement(By.Id("txtNombre"));
            txtNombres.SendKeys("Alma Amarilis");
            IWebElement txtApellidos = driver.FindElement(By.Id("txtDeporte"));
            txtApellidos.SendKeys("Lopez Fajardo");
            IWebElement txtCuenta = driver.FindElement(By.Id("txtEdad"));
            txtCuenta.SendKeys("30000003");
            IWebElement aprobar = driver.FindElement(By.Id("aprobar"));
            aprobar.Click();
            IWebElement monto = driver.FindElement(By.Id("txtNombre"));
            monto.SendKeys("2700");
            IWebElement transferir = driver.FindElement(By.Id("transferir"));
            transferir.Click();
        }
        public static void TestTransferenciaFail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:2243/");
            driver.Manage().Window.Maximize();
            IWebElement inputCuenta = driver.FindElement(By.Id("user"));
            inputCuenta.SendKeys("30000003");
            IWebElement inputPassword = driver.FindElement(By.Id("password"));
            inputPassword.SendKeys("CCCC0000");
            IWebElement btnLogear = driver.FindElement(By.Id("btn"));
            btnLogear.Click();
            IWebElement btnTipoCambio = driver.FindElement(By.Id("transferencia"));
            btnTipoCambio.Click();

            IWebElement txtNombres = driver.FindElement(By.Id("txtNombre"));
            txtNombres.SendKeys("Alma Amarilis");
            IWebElement txtApellidos = driver.FindElement(By.Id("txtDeporte"));
            txtApellidos.SendKeys("Lopez Fajardo");
            IWebElement txtCuenta = driver.FindElement(By.Id("txtEdad"));
            txtCuenta.SendKeys("30000003");
            IWebElement aprobar = driver.FindElement(By.Id("aprobar"));
            aprobar.Click();
            IWebElement monto = driver.FindElement(By.Id("txtNombre"));
            monto.SendKeys("500000");
            IWebElement transferir = driver.FindElement(By.Id("transferir"));
            transferir.Click();
        }
    }
}
