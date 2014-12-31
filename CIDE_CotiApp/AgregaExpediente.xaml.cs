using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            objExpediente.nombre = txtNombre.Text;
            objExpediente.correo= txtCorreo.Text;
            objExpediente.categoria = txtCategoria.Text;
            objExpediente.explicacion= txtExplicacion.Text;
            objExpediente.entidad= txtEntidad.Text;
            objExpediente.edad = lstEdad.SelectedValue.ToString();
            objExpediente.genero = lstEdad.SelectedValue.ToString();
            objExpediente.escolaridad = lstEdad.SelectedValue.ToString();

            //await objEndpoint.postExpediente(objExpediente);
            /*
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=getList");

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var values = serializer.Deserialize<List<responseJSON>>(new JsonTextReader(new StringReader(responseString)));*/
            Expediente objExpSource = objExpediente;
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("nombre", objExpSource.nombre),
                new KeyValuePair<string, string>("correo", objExpSource.correo),
                new KeyValuePair<string, string>("categoria", objExpSource.categoria),
                new KeyValuePair<string, string>("explicacion", objExpSource.explicacion),
                new KeyValuePair<string, string>("entidad", objExpSource.entidad),
                new KeyValuePair<string, string>("edad", objExpSource.edad),
                new KeyValuePair<string, string>("genero", objExpSource.genero),
                new KeyValuePair<string, string>("escolaridad", objExpSource.escolaridad)

            });

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://www.factico.com.mx/CIDE/APIBeta/expediente.php?q=add",content);

            var responseString = await response.Content.ReadAsStringAsync();
            var serializer = new JsonSerializer();
            var values = serializer.Deserialize(new StringReader(responseString),typeof(responseJSON));
            

        }

    }
}