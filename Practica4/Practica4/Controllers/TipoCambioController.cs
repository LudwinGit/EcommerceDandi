using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class TipoCambioController : Controller
    {
        // GET: TipoCambio
        public ActionResult Index(String date)
        {
            WSBanguat.TipoCambioSoapClient ws = new WSBanguat.TipoCambioSoapClient();
            ViewBag.tipoCambio = ws.TipoCambioDia().CambioDolar[0].fecha ;
            ViewBag.referencia = ws.TipoCambioDia().CambioDolar[0].referencia;


            string fecha = (date == null) ? DateTime.Now.ToShortDateString().ToString() : (Convert.ToDateTime(date).ToShortDateString().ToString()) ;
            ViewBag.tabla = ws.TipoCambioFechaInicial(fecha).Vars;
            
            return View();
        }
    }
}