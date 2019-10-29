using Practica4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica3y4.Controllers;

namespace Practica4.Controllers
{
    public class TransferenciaController : Controller
    {
        public string usuario_sesion = "2";
        public string no_cuenta_sesion = "1234567891024";


       public static string  nombre_transaccion = "";
       public static string apellido_transaccion = "";
       public static string no_cuenta_transaccion="";//no cuenta de la transaccion
        
       public static string usuario_t;//usuario de la transaccion


        //POST: Formualario
        
        public ActionResult vTransferencia()
        {
            
            nombre_transaccion = @TempData["nombre"].ToString();
            apellido_transaccion = @TempData["apellido"].ToString();
            no_cuenta_transaccion = @TempData["cuenta"].ToString();
            usuario_t = getUsuario();
           //insertarBD(monto);
            return View();
        }
        [HttpPost]
        public ActionResult vTransferencia(float monto)
        {

            float saldo = float.Parse(getsaldo());
            if(saldo<monto)
            {
                Response.Write("<script>alert('No tiene suficientes fondos para realizar esta transaccion');</script>");

            }
            else
            {
                insertarBD(monto);
                @TempData["message"] = "Transferencia exitoso";
            }
           
            return View();
        }
        //para obtener las cuentas bancarias
        [HttpGet]
        public string getsaldo()
        {
            string nuevo;
            
            string consulta = "select saldo from usuario where no_cuenta=" + no_cuenta_sesion;
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        nuevo = row["saldo"].ToString();

                        return nuevo;


                    }
                }
            }
            return "";
        }
        [HttpGet]
        public string getUsuario()
        {
            string nuevo;
            List<ObjectUsuario> lista = new List<ObjectUsuario>();
            string consulta = "select usuario from usuario where no_cuenta="+no_cuenta_transaccion ;
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        nuevo = row["usuario"].ToString();

                        return nuevo;

                        
                    }
                }
            }
            return "";
        }
        //consulta bd
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
        //insertar

        public  bool insertarBD(float monto)
        {
           
            string credenciales = "server=.; database=Practica3y4 ; integrated security = true";
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                conexion.Open();
                string sql = "insert into transferencia(usuario_usuario,usuario_no_cuenta,usuario_usuario1,usuario_no_cuenta1,monto,fecha) values(@param1,@param2,@param3,@param4,@param5,@param6)";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = Int16.Parse(usuario_sesion);
                    cmd.Parameters.Add("@param2", SqlDbType.BigInt).Value = long.Parse(no_cuenta_sesion);
                    cmd.Parameters.Add("@param3", SqlDbType.Int).Value = Int16.Parse(usuario_t);
                    cmd.Parameters.Add("@param4", SqlDbType.BigInt).Value = long.Parse(no_cuenta_transaccion);
                    cmd.Parameters.Add("@param5", SqlDbType.Decimal).Value = monto;
                    cmd.Parameters.Add("@param6", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    sql = "Update usuario Set saldo =saldo+@param1 Where usuario=@param2";
                    using (SqlCommand cmdU = new SqlCommand(sql, conexion))
                    {
                        cmdU.Parameters.Add("@param1", SqlDbType.Decimal).Value = monto;
                        cmdU.Parameters.Add("@param2", SqlDbType.Int).Value = Int16.Parse(usuario_t);
                        cmdU.CommandType = CommandType.Text;
                        cmdU.ExecuteNonQuery();
                    }

                    sql = "Update usuario Set saldo =saldo-@param1 Where usuario=@param2";
                    using (SqlCommand cmdU2 = new SqlCommand(sql, conexion))
                    {
                        cmdU2.Parameters.Add("@param1", SqlDbType.Decimal).Value = monto;
                        cmdU2.Parameters.Add("@param2", SqlDbType.Int).Value = Int16.Parse(usuario_sesion);
                        cmdU2.CommandType = CommandType.Text;
                        cmdU2.ExecuteNonQuery();
                    }
                }
                conexion.Close();

            }
            catch (Exception ex)
            {
                conexion.Close();
                Trace.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}