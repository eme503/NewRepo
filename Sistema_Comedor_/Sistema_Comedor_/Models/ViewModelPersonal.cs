using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Comedor_.Models
{
    public class ViewModelPersonal
    {
        //Modelo de datos de la tabla Personal
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public string Confirmar { get; set; }
    }
}