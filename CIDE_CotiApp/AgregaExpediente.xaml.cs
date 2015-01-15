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
using System.Windows.Controls.Primitives;
using Microsoft.Phone.Tasks;

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

            /*</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Chihuahua</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Distrito Federal</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Durango</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Guanajuato</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Guerrero</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Hidalgo</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Jalisco</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >México</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Michoacán de Ocampo</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Morelos</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Nayarit</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Nuevo León</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Oaxaca</toolkit:ListPickerItem>
                        <toolkit:ListPickerItem  >Puebla*/

            string[] lista = { "Aguascalientes","Baja California","Baja California Sur","Campeche","Coahuila de Zaragoza","Colima","Chiapas" };

        }

        string parameterTipo;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("tipo", out parameterTipo))
            {
                decideJusticia(parameterTipo);
            }
        }

        string currCategory;
        private void decideJusticia(string tipo)
        {

            switch (tipo)
            {
                case "trabajo":
                    currCategory = "Justicia en el trabajo";
                    txtCategoria.Text = "Justicia en el Trabajo";
                    break;
                case "familia":
                    currCategory = "Justicia en la familia";
                    txtCategoria.Text = "Justicia en las Familias";
                    break;
                case "vecinal":
                    currCategory = "Justicia vecinal y comunitaria";
                    txtCategoria.Text = "Justicia Vecinal y Comunitaria";
                    break;
                case "ciudadanos":
                    currCategory = "Justicia para ciudadanos";
                    txtCategoria.Text = "Justicia para ciudadanos";
                    break;
                case "emprendedores":
                    currCategory = "Justicia para emprendedores";
                    txtCategoria.Text = "Justicia para emprendedores";
                    break;
                case "otros":
                    currCategory = "Otros temas de Justicia Cotidiana";
                    txtCategoria.Text = "Otros temas de Justicia Cotidiana";
                    break;
            }
        }



        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
     

            Testimonio objTestimonio = new Testimonio();
            
            objTestimonio.name = txtNombre.Text;
            objTestimonio.email = txtCorreo.Text;
            //objTestimonio.category = txtCategoria.Text;

            objTestimonio.category = currCategory;
            objTestimonio.explanation = txtExplicacion.Text;
            //objTestimonio.state = lstEntidad.SelectedIndex.ToString();
            objTestimonio.state = (lstEntidad.SelectedIndex +1 ).ToString();
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

            Popup popup = new Popup();
            popup.Height = 300;
            popup.Width = 400;
            popup.VerticalOffset = 100;
            popup.HorizontalAlignment = HorizontalAlignment.Center;
            wpcPopup control = new wpcPopup();
            popup.Child = control;
            popup.IsOpen = true;


            var values = serializer.Deserialize(new StringReader(responseString),typeof(responseJSON));

            control.btnOK.Click += (s, args) =>
            {

                if (this.NavigationService.CanGoBack)
                {
                    popup.IsOpen = false;
                    this.NavigationService.GoBack();
                }

            };

            control.btnCompartir.Click += (s, args) =>
            {
                if (this.NavigationService.CanGoBack)
                {
                    ShareStatusTask shareStatusTask = new ShareStatusTask();

                    shareStatusTask.Status = "He enviado un testimonio sobre #JusticiaCotidiana desde www.justiciacotidiana.mx @JusCotidiana";
                    shareStatusTask.Show();
                    popup.IsOpen = false;

                    this.NavigationService.GoBack();

                }

            };

        }

    }
}