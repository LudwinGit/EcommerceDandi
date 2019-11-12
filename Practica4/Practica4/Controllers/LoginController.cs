using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        static string server = ".";
        // GET: Login
        public ActionResult vLogin()
        {
            if (Session["CUENTA"] != null)
            {
                return RedirectToAction("vPerfil", "Perfil");
            }

            return View();
        }

        public ActionResult Loguear(string user, string password)
        {
            string consulta = "select usuario, nombres, apellidos, saldo, no_cuenta, password from usuario where no_cuenta =" + user + " and password = '" + password + "'";
            DataTable dt = consultarBD(consulta);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                if (user.Equals(row["no_cuenta"].ToString()) && password.Equals(row["password"].ToString()))
                {
                    Session["ID"] = row["usuario"].ToString();
                    Session["CUENTA"] = row["no_cuenta"].ToString();
                    //Session["SALDO"] = row["saldo"].ToString();
                    Session["NOMBRE"] = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                    Session["Error"] = null;
                    return RedirectToAction("vPerfil", "Perfil");
                }
            }
            Session["Error"] = "Codigo de usuario o contraseña incorrecto..!!!";
            return RedirectToAction("vLogin", "Login");
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("vLogin", "Login");
        }
        public static DataTable consultarBD(string Consulta)
        {
            string credenciales = "server=" + server + "; database=Practica3y4; integrated security = true";
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                conexion.Open();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = Consulta;
                sql.CommandType = CommandType.Text;
                sql.Connection = conexion;

                adaptador.SelectCommand = sql;
                adaptador.Fill(ds);
                conexion.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(Consulta);
                return null;
            }
        }
    }
}