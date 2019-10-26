using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loguear(string v1, string v2)
        {
            if(v1.Equals("30000003") && v2.Equals("CCCC0000"))
            {
                return View();
            }
            return null;
        }
    }
}