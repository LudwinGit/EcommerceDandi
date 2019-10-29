using Practica4.Models;
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
    public class TransMonetariaController : Controller
    {
        
        // GET: TransMonetaria
        public ActionResult vTransMonetaria()
        {
            return View();
        }

        
        //POST: Formualario
        [HttpPost]
        public ActionResult vTransMonetaria(string nombre, string apellido, long edad)
        {
            
            ViewBag.MeLlamo = nombre;
            ViewBag.Aficion = apellido;
            ViewBag.MiEdad = edad;
            List<ObjectUsuario> milista= getCuenta(nombre,apellido,edad);
            if(milista.Count==0)
            {
            Response.Write("<script>alert('Error: El usuario: "+nombre+" "+apellido+" no tiene cuenta,verifique los datos');</script>");
            }
            TempData["nombre"] = nombre;
            TempData["apellido"] = apellido;
            TempData["cuenta"] = edad;


            return RedirectToAction("vTransferencia", "Transferencia");
        }

        [HttpGet]
        public List<ObjectUsuario> getCuenta(string nombre, string apellido,long cuenta)
        {
            List<ObjectUsuario> lista = new List<ObjectUsuario>();
            string consulta = "select * from usuario where no_cuenta= "+cuenta+" and nombres= "+ "\'" + nombre+ "\'" + " and apellidos= "+ "\'" + apellido+ "\'";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjectUsuario nuevo = new ObjectUsuario();
                        nuevo.usuario = row["usuario"].ToString();
                        nuevo.nombres = row["nombres"].ToString();
                        nuevo.apellidos = row["apellidos"].ToString();
                        nuevo.dpi = row["dpi"].ToString();
                        nuevo.no_cuenta = row["no_cuenta"].ToString();
                        nuevo.saldo = row["saldo"].ToString();
                        nuevo.email = row["email"].ToString();
                        nuevo.password = row["password"].ToString();

                        lista.Add(nuevo);
                    }
                }
            }
            return lista;
        }
      

        public static DataTable consultarBD(string Consulta)
        {
            string credenciales = "server=.; database=Practica3y4 ; integrated security = true";
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