using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica3y4.Controllers
{
    public class TransferenciaMonetariaController : Controller
    {
        public string NombreCuenta { get; set; }
        public long NumeroCuenta { get; set; }

        public float Monto { get; set; }

        public float Saldo { get; set; }
        // GET: TransferenciaMonetaria
        public ActionResult Index()
        {
            return View();
        }

        public bool ValidarString()
        {
            if (NombreCuenta is string)
            {
                return true;
            }
            return false;
        }

        public bool ValidarMonto()
        {
            if (Monto is float)
            {
                return true;
            }
            return false;
        }

        public bool ValidarMayorCero()
        {
            if (Monto > 0)
            {
                return true;
            }
             
            return false;
        }

        public bool ValidarNoNulls()
        {
            if(NombreCuenta!=null && NumeroCuenta!=null && Monto!=null)
            {
                return true;
            }
            return false;  
        }

        public bool VerificarSaldoSuficiente()
        {
            if(Saldo>Monto)
            {
                return true;
            }
            return false;
        }
    }
}