using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult RegistroView()
        {
            return View();
        }

        public bool validarCAmpos(string nombre, string apellidos, int dpi, int cuenta, string password)
        {
            throw new NotImplementedException();
            /*if(usuario != 0  && nombre != "" && apellidos!="" && dpi!=0 && cuenta!=0 && password!=""){
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public bool verificarUsuario(int user)
        {
            throw new NotImplementedException();
            /*if (Math.Floor(Math.Log10(user)) > 6)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public bool verificarPassword(string pass)
        {
            throw new NotImplementedException();
            /*if (pass.Length >= 5 && pass.Length <= 8)
            {
                return true;
            }else
            {
                return false;
            }*/
        }
        public bool validarNoUsuario(int num)
        {
            throw new NotImplementedException();
            /*if(num is int)
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