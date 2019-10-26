using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class ConsultarSaldoController : Controller
    {
        // GET: ConsultarSaldo
        public ActionResult Index()
        {
            return View();
        }

        public bool consulta(int cuenta)
        {
            throw new NotImplementedException();
            /*if (cuenta == 12345678)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public bool verificarCuenta(int cuenta)
        {
            throw new NotImplementedException();
            /*if(cuenta == 12345678)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public bool Respuesta(int cuenta)
        {
            throw new NotImplementedException();
            /*if (cuenta == 1234456677)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }
    }
}