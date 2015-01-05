using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CIDE_CotiApp.Core.Modelo;
using CIDE_CotiApp.Core;
using Newtonsoft.Json;
namespace CIDE_CotiApp
{
    public partial class ListaExpedientes : PhoneApplicationPage
    {
        public ListaExpedientes()
        {
            InitializeComponent();
            loadExp(lstExp);
            
        }

        private async void loadExp(ListBox listaSource)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            

            var response = await httpClient.GetAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios");

            var responseString = await response.Content.ReadAsStringAsync();

            var objResponse = JsonConvert.DeserializeObject(responseString, typeof(Expediente));

            
            

        }

    }
}