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
        string currCategory;
        string paramType;

        public Testimonios()
        {
            InitializeComponent();
            loadTestimonios(this.lstTestimonios);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("tipo", out currCategory))
            {
                decideJusticia(currCategory);
            }
        }

        private void decideJusticia(string tipo)
        {
            paramType = tipo;
            switch (tipo)
            {
                case "trabajo":
                    currCategory = "Justicia en el trabajo";
                    break;
                case "familia":
                    currCategory = "Justicia en las familias";
                    break;
                case "vecinal":
                    currCategory = "Justicia vecinal y comunitaria";
                    break;
                case "ciudadanos":
                    currCategory = "Justicia para ciudadanos";
                    break;
                case "emprendedores":
                    currCategory = "Justicia para emprendedores";
                    break;

            }
        }

        private async void loadTestimonios(ListBox listaSource)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            

            var response = await httpClient.GetAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios");
            //response.Content.Headers.Add("", "application/json");

            var responseString = await response.Content.ReadAsStringAsync();
            lst_Expedientes objRespExpedientes = JsonConvert.DeserializeObject<lst_Expedientes>(responseString);

            foreach (Expediente exp in objRespExpedientes.items)
            {

                if (exp.gender == "Hombre")
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
                listaSource.ItemsSource = objRespExpedientes.items.Where(p => p.category == currCategory).OrderByDescending(p => p.created).ToList();
            }
        }

    }
}