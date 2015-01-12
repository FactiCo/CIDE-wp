using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using CIDE_CotiApp.Core.Modelo;
using CIDE_CotiApp.Core;

namespace CIDE_CotiApp
{
    public partial class ClasTestimonio : PhoneApplicationPage
    {
        string parameterTipo;

        public ClasTestimonio()
        {
            InitializeComponent();
            loadTestimonios(this.lstExp);
            //Trabajo Familia Vecinal Funcionarios Emprendedores

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("tipo", out parameterTipo))
            {
                decideJusticia(parameterTipo);
            }
        }

        private string currCategory;

        private async void loadTestimonios(ListBox listaSource)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios");
            var responseString = await response.Content.ReadAsStringAsync();
            lst_Expedientes objRespExpedientes = JsonConvert.DeserializeObject<lst_Expedientes>(responseString);
            if (objRespExpedientes.count > 0)
            {
                listaSource.ItemsSource = objRespExpedientes.items.Where(p => p.category==currCategory).ToList();
            }
            else
            {
                btnVer.IsEnabled = false;    
            }
            
        }

        private void decideJusticia(string tipo)
        { 
            
            switch(tipo)
            {
                case "trabajo":
                    currCategory = "Justicia en el trabajo";
                    txtJusticia.Text = "Justicia en el Trabajo";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_TRABAJO.png", UriKind.Relative));
                    txtExplicacion.Text = "La Justicia Laboral es un tema pendiente en México. Actualmente, los procesos para obtener justicia en el trabajo son caros, complejos y las figuras de justicia alternativa se utilizan poco. ";
                    break;
                case "familia":
                    currCategory="Justicia en las familias";
                    txtJusticia.Text = "Justicia en las Familias";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_FAMILIA.png", UriKind.Relative));
                    txtExplicacion.Text = "Justicia en las Familias trata diversos temas y conflictos como el divorcio, sucesiones, pensiones alimenticias, entre otros. Es un tema complejo, pues intervienen relaciones de poder y vínculos afectivos. Las mujeres suelen ser las personas más desfavorecidas.  ";
                    break;
                case "vecinal":
                    currCategory="Justicia vecinal y comunitaria";
                    txtJusticia.Text = "Justicia Vecinal y Comunitaria";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_VECINAL.png", UriKind.Relative));
                    txtExplicacion.Text = "La convivencia vecinal y comunitaria es probablemente el mayor tema de conflictos diarios entre personas que habitan un mismo espacio o territorio. Conflictos derivados de los espacios públicos y uso de suelo se tratarán en este apartado. ";
                    break;
                case "funcionarios":
                    currCategory = "Justicia para funcionarios";
                    txtJusticia.Text = "Justicia para Funcionarios";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_FUNCIONARIOS.png", UriKind.Relative));
                    txtExplicacion.Text = "Los ciudadanos tienen la facultad de defenderse frente a actos injustos de las autoridades. Sin embargo, en muchas ocasiones estos procesos resultan mucho más largos y complejos que la reparación del daño. La responsabilidad patrimonial del Estado es un tema fundamental.";
                    break;
                case "emprendedores":
                    currCategory="Justicia para emprendedores";
                    txtJusticia.Text = "Justicia para  Emprendedores (PyMes)s";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_EMPRENDEDORES.png",UriKind.Relative));
                    txtExplicacion.Text = "Emprender es un reto constante en términos legales. Los micro, pequeños y medianos empresarios se enfrentan a numerosos obstáculos y las alternativas de justicia son pocas.";
                    break;

            }
        }

        private void lnkAddTestimonio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AgregaExpediente.xaml",UriKind.Relative));

        }

        private void lnkVerTestimonios_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Testimonios.xaml", UriKind.Relative));
        }

        private void btnIngresa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AgregaExpediente.xaml", UriKind.Relative));
        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}