using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CIDE_CotiApp
{
    public partial class ClasTestimonio : PhoneApplicationPage
    {
        public ClasTestimonio()
        {
            InitializeComponent();
        }

        private void lnkAddTestimonio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AgregaExpediente.xaml",UriKind.Relative));

        }

        private void lnkVerTestimonios_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Testimonios.xaml", UriKind.Relative));
        }
    }
}