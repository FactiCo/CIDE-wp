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
using CIDE_CotiApp.Core.Modelo;
using CIDE_CotiApp.Core;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net.Mime;

namespace CIDE_CotiApp
{
    public partial class AgregaExpediente : PhoneApplicationPage
    {
        Expediente objExpediente;
        ConnectAPI objEndpoint;
        

        public AgregaExpediente()
        {
            InitializeComponent();
            objExpediente = new Expediente();
            objEndpoint = new ConnectAPI();
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            objExpediente = new Expediente();
            objExpediente.name = txtNombre.Text;
            objExpediente.email= txtCorreo.Text;
            objExpediente.category= txtCategoria.Text;
            objExpediente.explanation= txtExplicacion.Text;
            objExpediente.entidadFederativa = (lstEntidad.SelectedItem as ListBoxItem).Content.ToString();
            objExpediente.age = (lstEdad.SelectedItem as ListBoxItem).Content.ToString();
            objExpediente.gender = (lstGenero.SelectedItem as ListBoxItem).Content.ToString();
            objExpediente.grade= (lstEscolaridad.SelectedItem as ListBoxItem).Content.ToString();


            //await objEndpoint.postExpediente(objExpediente);
            /*
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList");

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var values = serializer.Deserialize<List<responseJSON>>(new JsonTextReader(new StringReader(responseString)));*/
            Expediente objExpSource = objExpediente;

            HttpContent content= new StringContent(JsonConvert.SerializeObject(objExpSource,Formatting.Indented));
            /*var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("nombre", objExpSource.nombre),
                new KeyValuePair<string, string>("correo", objExpSource.correo),
                new KeyValuePair<string, string>("categoria", objExpSource.categoria),
                new KeyValuePair<string, string>("explicacion", objExpSource.explicacion),
                new KeyValuePair<string, string>("entidad", objExpSource.entidad),
                new KeyValuePair<string, string>("edad", objExpSource.edad),
                new KeyValuePair<string, string>("genero", objExpSource.genero),
                new KeyValuePair<string, string>("escolaridad", objExpSource.escolaridad)

            });*/

            

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var values = serializer.Deserialize(new StringReader(responseString),typeof(responseJSON));
        }

    }
}