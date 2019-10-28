using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class ConsultarSaldoController : Controller
    {
        public static float saldo;
        // GET: ConsultarSaldo
        public ActionResult ConsultarView()
        {
            ViewData["Saldo"] = saldo;
            //Session["CUENTA"] = "356452343";
            return View();
        }

        [HttpPost]
        public ActionResult consultar()
        {
            //if (consulta(356452343) == true)
            if (consulta(Convert.ToDouble(Session["CUENTA"].ToString())))
            {
                //return Content("<script language='javascript' type='text/javascript'>alert('Usuario Encontrado "+saldo+" ');</script>");
                dato();
                return RedirectToAction("ConsultarView", "ConsultarSaldo");
            }
            return RedirectToAction("ConsultarView", "ConsultarSaldo");
        }

        [HttpGet]
        public ActionResult dato()
        {
            return Content("<script language='javascript' type='text/javascript'>alert('Usuario Encontrado " + saldo + " ');</script>");
        }
        /*
         * string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica2;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT nombre FROM empleado WHERE cod_empleado=@cod AND password=@pass";
            command.Parameters.AddWithValue("cod",txtUsuario.Text);
            command.Parameters.AddWithValue("@pass", txtPassword.Text);

            try
            {
                con.Open();
                //Response.Write("Conexion Establecida");
                SqlDataReader dr = command.ExecuteReader();
                
                if (dr.Read())
                {
                    Response.Redirect("/Home/Index");
                }
                else
                {
                    Response.Write("Usuario o Contrasena Invalida");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
         */

        public bool consulta(double cuenta)
        {
            saldo = 0;
            string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica3y4;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT saldo FROM usuario WHERE no_cuenta=@cuenta";
            command.Parameters.AddWithValue("cuenta", cuenta);

            try
            {
                con.Open();
                //Response.Write("Conexion Establecida");
                saldo = Convert.ToInt32(command.ExecuteScalar());
                con.Close();

                ViewData["Saldo"] = saldo;

                if (saldo != 0)
                {
                    //Content("<script language='javascript' type='text/javascript'>alert('Cuenta Encontrada');</script>");
                    return true;
                }
                else
                {
                    //Content("<script language='javascript' type='text/javascript'>alert('Cuenta no Encontrada');</script>");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return false;
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