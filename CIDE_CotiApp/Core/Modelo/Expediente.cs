using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIDE_CotiApp.Core.Modelo
{
    class Expediente
    {

        public Expediente()
        {
            dispositivo= "WindowsPhone";
        }

        public string id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string categoria { get; set; }
        public string explicacion { get; set; }
        public string entidad { get; set; }
        public string edad { get; set; }
        public string genero { get; set; }
        public string escolaridad { get; set; }
        public string fecha_add { get; set; }
        public string dispositivo { get; set; }

        
    }
}
