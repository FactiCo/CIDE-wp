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
            
        }

        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string category { get; set; }
        public string explanation { get; set; }
        public string entidadFederativa { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
        public string created { get; set; }

        
    }
}
