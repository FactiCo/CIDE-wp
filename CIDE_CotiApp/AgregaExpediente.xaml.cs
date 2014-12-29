using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CIDE_CotiApp.Core.Modelo;
using CIDE_CotiApp.Core;

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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            objEndpoint.
        }
    }
}