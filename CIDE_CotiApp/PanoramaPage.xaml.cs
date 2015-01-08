using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using Microsoft.Phone.Tasks;

namespace CIDE_CotiApp
{
    public partial class PanoramaPage : PhoneApplicationPage
    {
        private Popup popup;
        public PanoramaPage()
        {
            InitializeComponent();
            
            
        }

        


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
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=trabajo", UriKind.Relative));
        }

        private void tileJFamilia_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=familia", UriKind.Relative));
        }

        private void tileJVecinal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=vecinal", UriKind.Relative));
        }

        private void tileJFuncionarios_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=funcionarios", UriKind.Relative));
        }

        private void tileJEmprendedores_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=emprendedores", UriKind.Relative));
        }

        private void tileMapa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
            
        }

        private void iconAcerca1_Click(object sender, EventArgs e)
        {
            
        }

        private void iconAcerca2_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Code Samples";
            shareLinkTask.LinkUri = new Uri("http://code.msdn.com/wpapps", UriKind.Absolute);
            shareLinkTask.Message = "Here are some great code samples for Windows Phone.";

            shareLinkTask.Show();

        }

        private void mnuAcerca_Click(object sender, EventArgs e)
        {

        }

        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        {
            Console.WriteLine("Swipe");



        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void pivotQue_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(@"/imgs/FONDO_QUE_ES_JC1.png",UriKind.Absolute));

            ImageBrush b = new ImageBrush();
            b.ImageSource = image;
            panoramaMenu.Background = b;

        }

        private void pivotEs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(@"/imgs/FONDO_QUE_ES_JC2.png", UriKind.Absolute));

            ImageBrush b = new ImageBrush();
            b.ImageSource = image;
            panoramaMenu.Background = b;

        }

        private void pivotJusticia_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(@"/imgs/FONDO_QUE_ES_JC3.png", UriKind.Absolute));

            ImageBrush b = new ImageBrush();
            b.ImageSource = image;
            panoramaMenu.Background = b;

        }

        private void pivotCotidiana_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(@"/imgs/FONDO_QUE_ES_JC4.png", UriKind.Absolute));

            ImageBrush b = new ImageBrush();
            b.ImageSource = image;
            panoramaMenu.Background = b;

        }

        private void pivotGral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Storyboard sbFadeIn = new Storyboard();
            sbFadeIn.Completed += new EventHandler(sb_Completed);

            FadeInOut(this.panoramaMenu.Background, sbFadeIn, true);

        }

        void sb_Completed(object sender, EventArgs e)
        {

            BitmapImage image = new BitmapImage(new Uri(@"/imgs/FONDO_QUE_ES_JC" + "1" + ".png", UriKind.Absolute));

            ImageBrush b = new ImageBrush();
            b.ImageSource = image;
            panoramaMenu.Background = b;
            Storyboard sbFadeOut = new Storyboard();

            FadeInOut(this.panoramaMenu.Background, sbFadeOut, false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));

        }

        private void FadeInOut(DependencyObject target, Storyboard sb, bool isFadeIn)
        {
            Duration d = new Duration(TimeSpan.FromSeconds(1));
            DoubleAnimation daFade = new DoubleAnimation();
            daFade.Duration = d;
            if (isFadeIn)
            {
                daFade.From = 1.00;
                daFade.To = 0.00;
            }
            else
            {
                daFade.From = 0.00;
                daFade.To = 1.00;
            }

            sb.Duration = d;
            sb.Children.Add(daFade);
            Storyboard.SetTarget(daFade, target);
            Storyboard.SetTargetProperty(daFade, new PropertyPath("Opacity"));

            sb.Begin();
        }

    }
}