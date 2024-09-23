using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACKEND.Clases
{
    public class LoginUsuarios
    {
       
            public int U_codigo { get; set; }
            public string U_usuario { get; set; }
            public string U_clave { get; set; }
            public string U_nombre { get; set; }
            public int U_estado { get; set; }
            public int U_fec_Crea { get; set; }
            public string U_usua_crea { get; set; }
            public string U_fec_ult_mod { get; set; }
            public string U_usua_ult_mod { get; set; }
            public int U_TipoU {  get; set; }    
        public string U_TipoUString {  get; set; }
        
    }
}
