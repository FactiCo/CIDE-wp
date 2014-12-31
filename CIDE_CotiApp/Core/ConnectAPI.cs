using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIDE_CotiApp.Core.Modelo;

namespace CIDE_CotiApp.Core
{
    class ConnectAPI
    {
        private HttpClient objHTTP;
        private HttpMessageHandler hndMsg;
        public ConnectAPI()
        {
            objHTTP = new HttpClient();

        }

        public async System.Threading.Tasks.Task getExpedientes()
        {
            string rawJSON;
            rawJSON = await objHTTP.GetStringAsync(new Uri("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList"));

            List<Expediente> lstExpedientes = JsonConvert.DeserializeObject<List<Expediente>>(rawJSON);

        }

        public async System.Threading.Tasks.Task postExpediente(Expediente objExpSource)
        {
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("nombre", objExpSource.nombre),
                new KeyValuePair<string, string>("correo", objExpSource.correo),
                new KeyValuePair<string, string>("categoria", objExpSource.categoria),
                new KeyValuePair<string, string>("explicacion", objExpSource.explicacion),
                new KeyValuePair<string, string>("entidad", objExpSource.entidad),
                new KeyValuePair<string, string>("edad", objExpSource.edad),
                new KeyValuePair<string, string>("genero", objExpSource.genero),
                new KeyValuePair<string, string>("escolaridad", objExpSource.escolaridad)

            });


            var result = await objHTTP.PostAsync(new Uri("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=add"), content);
            var rawJSON = result.Content.ReadAsStringAsync().ToString();
            
            var respExp =JsonConvert.DeserializeObject<responseJSON>(rawJSON);

            
            
        }



    }
}


