using System;
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
using Newtonsoft.Json;
using JC_1_5.Code.Entities;
using Facebook.Client;
using Facebook;
using JC_1_5.Code;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Security.Cryptography;

namespace JC_1_5.Pages
{

    public class catPropuesta
    {
        public string Titulo { get; set; }
        public lstPropuestas itemsProp { get; set; }
    }

    public partial class Propuestas : PhoneApplicationPage
    {
        public List<catPropuesta> Data { get; set; }

        private async void loadTestimonios()
        {
            

            var session = SessionStorage.Load();
            if (null == session)
            {
                return;
            }

            try
            {

               
                var fb = new FacebookClient(session.AccessToken);

                await fb.PostTaskAsync(string.Format("me/feed?message={0}", this.Title), null);

                //this.UpdateStatusBox.Text = string.Empty;
            }
            catch (FacebookOAuthException exception)
            {
                MessageBox.Show("Error fetching user data: " + exception.Message);
            }

            /*this.ProgressText = string.Empty;
            this.ProgressIsVisible = false;
            this.UpdateStatusButton.IsEnabled = true;*/
        }


        public Propuestas()
        {
            InitializeComponent();
            loadPropuestas(lstPropuestas_Familiar, "Justicia en la familia");
            loadPropuestas(lstPropuestas_Trabajo, "Justicia en el trabajo");
            loadPropuestas(lstPropuestas_Empresarios, "Justicia en las empresas");
            loadPropuestas(lstPropuestas_Otros, "Justicia temas de Justicia Cotidiana");
            loadPropuestas(lstPropuestas_Ciudadanos, "Justicia para ciudadanos");
            loadPropuestas(lstPropuestas_Vecinal, "Justicia vecinal y comunitaria");

        }

        

        private async void loadPropuestas(ListBox lpicker, string cat)
        {
            

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Data = new List<catPropuesta>();

            string [] pivotCategoria = { "Trabajo", "Familiar", "Empresarios", "Otros", "Ciudadanos","Vecinal" };
                
            var response = await httpClient.GetAsync("http://justiciacotidiana.mx:8080/justiciacotidiana/api/v1/propuestas");

            var responseString = await response.Content.ReadAsStringAsync();
            lstPropuestas objRespPropuestas = JsonConvert.DeserializeObject<lstPropuestas>(responseString);
        

                
            if (objRespPropuestas.count > 0)
            {
                lpicker.ItemsSource = objRespPropuestas.items.Where(p => p.category == cat).ToList();
            }

        }

        private void Trabajo_Loaded(object sender, RoutedEventArgs e)
        {
         
        }

        private void lstPropuestas_Trabajo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PanoPropuestas.xaml?propID=" + lstPropuestas_Trabajo.SelectedIndex.ToString(), UriKind.Relative));
        }
    }
}