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
using System.Windows.Controls.Primitives;

namespace CIDE_CotiApp
{
    public partial class PanoramaPage : PhoneApplicationPage
    {
        private Popup popup;
        public PanoramaPage()
        {
            InitializeComponent();

            
            popup= App.Current.Resources["popup"] as Popup;
            App.Current.Resources.Remove("popup");  // remove the PopUp from the Resource and thus clear his Parent property
            imgLayout.Children.Add(popup);       // add the PopUp to a container inside your page visual tree
            //popup.IsOpen = true;
            
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

        private void tileJFamilia_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tileJVecinal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tileJFuncionarios_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tileJEmprendedores_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tileMapa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void iconAcerca1_Click(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }

        private void iconAcerca2_Click(object sender, EventArgs e)
        {

        }

        private void mnuAcerca_Click(object sender, EventArgs e)
        {

        }
    }
}