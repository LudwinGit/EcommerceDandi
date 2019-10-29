using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica4.Models
{
    public class ObjectUsuario
    {
        public string usuario{ get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dpi { get; set; }
        public string no_cuenta { get; set; }
        public string saldo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public ObjectUsuario()
        {
            usuario = "-";
            nombres = "-";
            apellidos = "-";
            dpi = "-";
            no_cuenta = "-";
            saldo = "-";
            email = "-";
            password = "-";
        }
    }
}