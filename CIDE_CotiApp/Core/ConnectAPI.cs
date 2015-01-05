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
        public List<Expediente> lstExpedientes;
        public ConnectAPI()
        {
            objHTTP = new HttpClient();

        }

        public async System.Threading.Tasks.Task getExpedientes(List<Expediente> lstExp)
        {
            var result =await  objHTTP.GetAsync(new Uri("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList"));
            var rawJSON=await result.Content.ReadAsStringAsync();

            lstExp= JsonConvert.DeserializeObject<List<Expediente>>(rawJSON.ToString());

        }

        public async System.Threading.Tasks.Task postExpediente(Expediente objExpSource)
        {
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("name", objExpSource.name),

            });
            

            var result = await objHTTP.PostAsync(new Uri("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=add"), content);
            var rawJSON = result.Content.ReadAsStringAsync().ToString();
            
            var respExp =JsonConvert.DeserializeObject<responseJSON>(rawJSON);

            
            
        }



    }
}


