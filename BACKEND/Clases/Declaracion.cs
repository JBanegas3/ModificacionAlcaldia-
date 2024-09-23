using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACKEND.Clases
{
    public class Declaracion
    {
        public int id_sucursal { get; set; }
        public string txt_nombre_sucursal { get; set; }
        public string identificacion { get; set; }
        public string txt_calle { get; set; }
        public Double impuesto_anio { get; set; }
        public Double balance { get; set; }
        public Double multa { get; set; }
        public Double total { get; set; }
        
    }
}