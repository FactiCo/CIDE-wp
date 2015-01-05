using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CIDE_CotiApp
{
    public partial class PanoramaPage : PhoneApplicationPage
    {
        public PanoramaPage()
        {
            InitializeComponent();
            
            
        }

        ShellTileData tileimg;


        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lnkCat1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml",UriKind.Relative));

        }

        
        

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.popup.IsOpen = true;
        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tileJTrabajo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml", UriKind.Relative));

        }
    }
}