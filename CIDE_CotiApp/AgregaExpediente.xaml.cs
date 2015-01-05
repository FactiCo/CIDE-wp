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

            Testimonio objTestimonio = new Testimonio();
            
            objTestimonio.name = txtNombre.Text;
            objTestimonio.email = txtCorreo.Text;
            objTestimonio.category = txtCategoria.Text;
            objTestimonio.explanation = txtExplicacion.Text;
            objTestimonio.entidadFederativa = (lstEntidad.SelectedItem as ListBoxItem).Content.ToString();
            objTestimonio.age = (lstEdad.SelectedItem as ListBoxItem).Content.ToString();
            objTestimonio.gender = (lstGenero.SelectedItem as ListBoxItem).Content.ToString();
            objTestimonio.grade = (lstEscolaridad.SelectedItem as ListBoxItem).Content.ToString();


            //await objEndpoint.postExpediente(objExpediente);
            /*
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList");

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var values = serializer.Deserialize<List<responseJSON>>(new JsonTextReader(new StringReader(responseString)));*/
            
            var sets = new JsonSerializerSettings();
            sets.ContractResolver = new interfaceExpediente(ExpedienteReveiceType.PostNG);
            

            Book book = new Book
 {
     BookName = "The Gathering Storm",
     BookPrice = 16.19m,
     AuthorName = "Brandon Sanderson",
     AuthorAge = 34,
     AuthorCountry = "United States of America"
 };

            string startingWithA = JsonConvert.SerializeObject(objTestimonio, Formatting.Indented,
    new JsonSerializerSettings { ContractResolver = new DynamicContractResolver('g') });

string startingWithB = JsonConvert.SerializeObject(book, Formatting.Indented,
    new JsonSerializerSettings { ContractResolver = new DynamicContractResolver('n') });

            //string strJSON = JsonConvert.SerializeObject(objExpediente, Formatting.Indented, setts);
    string strJSON = JsonConvert.SerializeObject(objTestimonio, Formatting.None);
            HttpContent content= new StringContent(strJSON);
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

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("http://www.justiciacotidiana.mx:8080/justiciacotidiana/api/v1/testimonios", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();

            

            var values = serializer.Deserialize(new StringReader(responseString),typeof(responseJSON));
        }

    }
}