using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            
        }


        private async void btnListar_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList");
            
            //lstTestimonios.ItemsSource = JsonConvert.DeserializeObject<List<Expediente>>("["+content+"]"); 

            //List<string> videogames = JsonConvert.DeserializeObject<List<string>>(content);

            JsonSerializer serializer = new JsonSerializer();
            var values = serializer.Deserialize(new StringReader(content),typeof(List<Expediente>));

            List<Expediente> items = JsonConvert.DeserializeObject<List<Expediente>>(content); 

        }

    }
}