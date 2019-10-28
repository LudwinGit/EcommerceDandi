using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Practica4.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult RegistroView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registro(string nombre, string apellidos, double dpi, string mail, double cuenta, string password)
        {
            bool campos = validarCAmpos(nombre, apellidos, dpi, cuenta, password);
            if (campos == true)
            {
                if (validarNoUsuario(cuenta))
                {
                    if (verificarUsuario(cuenta))
                    {
                        if (verificarPassword(password))
                        {
                            accionRegistrar(nombre, apellidos, dpi, mail, cuenta, password);
                            //Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Debe llenar todos los campos');", true);
                        }
                    }
                }

            }
            return RedirectToAction("RegistroView", "Registro");
        }

        public void accionRegistrar(string nombre, string apellidos, double dpi, string mail, double cuenta, string password)
        {
            string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica3y4;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO usuario (nombres, apellidos, dpi, no_cuenta, saldo, email, password) VALUES(@nombre,@apellidos,@dpi,@cuenta,1000.00,@mail, @pass)";
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            command.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = apellidos;
            command.Parameters.Add("@dpi", SqlDbType.BigInt).Value = dpi;
            command.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            try
            {
                con.Open();
                //Response.Write("Conexion Establecida");
                int ok = command.ExecuteNonQuery();
                con.Close();

                if (ok > 0)
                {
                    Response.Write("Usuario Registrado");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        /*
         * string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica2;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO empleado (dpi,nombre,direccion,mail,cod_empleado,password,tipoempleado_tipoempleado) VALUES(@dpi,@nombre,@dir, @mail, @cod, @pass,1)";
            command.Parameters.Add("@dpi", SqlDbType.VarChar).Value = txtdpi.Text;
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text;
            command.Parameters.Add("@dir", SqlDbType.VarChar).Value = txtDireccion.Text;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = txtCorreo.Text;
            command.Parameters.Add("@cod", SqlDbType.VarChar).Value = txtUsuario.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;

            try {
                con.Open();
                //Response.Write("Conexion Establecida");
                int ok = command.ExecuteNonQuery();
                con.Close();

                if(ok > 0)
                {
                    Response.Write("Usuario Registrado");
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        */

        public bool validarCAmpos(string nombre, string apellidos, double dpi, double cuenta, string password)
        {
            if (nombre != "" && apellidos != "" && dpi != 0 && cuenta != 0 && password != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verificarUsuario(double user)
        {
            if (Math.Floor(Math.Log10(user)) > 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verificarPassword(string pass)
        {
            //throw new NotImplementedException();
            if (pass.Length >= 8 && pass.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validarNoUsuario(double num)
        {
            //throw new NotImplementedException();
            if (num is double)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}