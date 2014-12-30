using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;
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
    public partial class ListaExpedientes : PhoneApplicationPage
    {
        public ListaExpedientes()
        {
            InitializeComponent();
            loadExp(lstExp);
            
        }

        private async void loadExp(ListBox listaSource)
        {
            Core.ConnectAPI objAPI = new ConnectAPI();
            //ProgressBar pbrExpedientes = new ProgressBar();
            //ProgressIndicator progressIndicator = new ProgressIndicator() { IsIndeterminate = true, Text = "Obteniendo expedientes …" };

            //SystemTray.SetProgressIndicator(this, progressIndicator);

             //await objAPI.getExpedientes().RunSynchronously();
        }

    }
}