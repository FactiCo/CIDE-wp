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
        string paramType;

        public ClasTestimonio()
        {
            InitializeComponent();
            loadTestimonios(this.lstExp);

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
            foreach (Expediente exp in objRespExpedientes.items)
            {
                
                if (exp.gender=="Hombre")
                {
                    exp.gender = @"/imgs/ICONO_HOMBRE.png";
                }
                else if (exp.gender == "Mujer")
                {
                    exp.gender = @"/imgs/ICONO_MUJER.png";
                }
                else
                {
                    exp.gender = @"/imgs/NEW_LOGO.png";
                }
                
            }
            
            if (objRespExpedientes.count > 0)
            {
                
                listaSource.ItemsSource = objRespExpedientes.items.Where(p => p.category==currCategory).OrderByDescending(p=>p.created).Take(3).ToList();

                if (listaSource.Items.Count > 0)
                {
                    rtbRecientes.Visibility = Visibility.Collapsed;
                    btnVer.Visibility = Visibility.Visible;
                    lstExp.Visibility = Visibility.Visible;
                }
                else
                {
                    rtbRecientes.Visibility = Visibility.Visible;
                    btnVer.Visibility = Visibility.Collapsed;
                    lstExp.Visibility = Visibility.Collapsed;
                 
                }
                
            }
            
        }

        private void decideJusticia(string tipo)
        {
            paramType = tipo;
            switch(tipo)
            {
                case "trabajo":
                    currCategory = "Justicia en el trabajo";
                    txtJusticia.Text = "Justicia en el Trabajo";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_TRABAJO_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"Trabajadores, empleadores y sindicatos requieren una justicia rápida, transparente y eficaz para resolver conflictos que suceden en los espacios de trabajo. Despidos injustificados, prestaciones no entregadas, legislación laboral no aplicada, son algunos temas que se abordan en el Foro “Justicia en el trabajo”.

Aguascalientes / 22 de enero de 2015 / 
";
                    break;
                case "familia":
                    currCategory="Justicia en las familias";
                    txtJusticia.Text = "Justicia en las Familias";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_FAMILIA_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"Divorcios, herencias, pensiones, tutelas o violencia familiar son temas complejos, pues entran en juego sentimientos y relaciones de poder. El Foro “Justicia para familias” busca identificar en qué casos se deben rediseñar políticas públicas, simplificar legislación o utilizar sistemas alternativos de solución de conflictos. 

Tijuana / 4 de febrero / 
";
                    break;
                case "vecinal":
                    currCategory="Justicia vecinal y comunitaria";
                    txtJusticia.Text = "Justicia Vecinal y Comunitaria";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_VECINAL_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"Los espacios de convivencia, sean urbanos o rurales, suelen generar distintos tipos de conflictos. Un barrio, un condominio, una comunidad tienen diversos actores, reglas y normas de entendimiento. Temas como contaminación ambiental, usos de suelo y prevención de la violencia se tratan en el Foro “Justicia vecinal y comunitaria”. 

Tuxtla Gutiérrez / 19 de febrero / 
";
                    break;
                case "ciudadanos":
                    currCategory = "Justicia para ciudadanos";
                    txtJusticia.Text = "Justicia para ciudadanos";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_CIUDADANOS_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"Los ciudadanos pueden combatir abusos cometidos por las autoridades por medio de la justicia administrativa. Una multa injusta, una licitación alejada de la ley o el mal mantenimiento de las calles son ejemplos de actos de autoridad que se combaten ante un tribunal. Estos temas se tratan en el Foro “Justicia para ciudadanos”. 

Guanajuato / 29 de enero / 
";
                    break;
                case "emprendedores":
                    currCategory = "Justicia para emprendedores";
                    txtJusticia.Text = "Justicia para  Emprendedores (PyMes)s";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_EMPRENDEDORES_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"La debilidad del sistema de justicia frena el crecimiento económico y el potencial de los emprendedores. Para las empresas es arriesgado invertir cuando no cuentan con las instituciones de justicia adecuadas para dirimir conflictos o sancionar autoridades. Estos temas se discuten en el Foro “Justicia para emprendedores”. 

Monterrey / 12 de febrero / 
";
                    break;
                case "otros":
                    currCategory = "Otros";
                    txtJusticia.Text = "Otros temas de justicia cotidiana";
                    imgJusticia.Source = new BitmapImage(new Uri(@"/imgs/ICONO_JUSTICIA_OTROS_TRANS.png", UriKind.Relative));
                    txtExplicacion.Text = @"Desde la resolución de conflictos agrarios, la necesidad de mejorar la capacitación de jueces y defensores, hasta la protección a consumidores y a usuarios del sistema bancario son otros temas de justicia cotidiana que requieren especial atención y consulta. Conoce las materias que se abordan en el Foro “Otras Justicias”. 

Ciudad de México / 26 de febrero / 
";
                    break;

            }
        }

        private void lnkAddTestimonio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AgregaExpediente.xaml",UriKind.Relative));

        }

        private void lnkVerTestimonios_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnIngresa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AgregaExpediente.xaml?tipo=" + paramType, UriKind.Relative));
        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Testimonios.xaml?tipo=" + paramType, UriKind.Relative));
        }

        private void grdTexto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CatDesc.xaml?tipo=" + paramType, UriKind.Relative));

        }
    }
}