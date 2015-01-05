using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CIDE_CotiApp.Core;
using CIDE_CotiApp.Core.Modelo;
using Newtonsoft.Json;

using System.Threading;
using System.Threading.Tasks;
namespace CIDE_CotiApp
{
    public partial class Testimonios : PhoneApplicationPage
    {
        public Testimonios()
        {
            InitializeComponent();
            loadTestimonios(this.lstTestimonios);
        }

        private async void loadTestimonios(ListBox listaSource)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios");
            var responseString = await response.Content.ReadAsStringAsync();
            lst_Expedientes objRespExpedientes = JsonConvert.DeserializeObject<lst_Expedientes>(responseString);
            listaSource.ItemsSource = objRespExpedientes.items.ToList();
        }

    }
}