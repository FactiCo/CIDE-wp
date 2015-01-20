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
using Facebook;

namespace CIDE_CotiApp
{
    public partial class PanoramaPage : PhoneApplicationPage
    {

        private const string AppId = "654570061331636";
        private const string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        private readonly FacebookClient _fb = new FacebookClient();

        private Popup popup;
        public PanoramaPage()
        {
            InitializeComponent();
            currIndexFlick = 0;
            
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

        private void tileJCiudadanos_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=ciudadanos", UriKind.Relative));
        }

        private void tileJOtros_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClasTestimonio.xaml?tipo=otros", UriKind.Relative));
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

        private int currIndexFlick;
        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        {


            var uri1 = "/imgs/justicia-ciudadana-postal01.jpg";
            var uri2 = "/imgs/Justicia-Ciudadana-postal02.jpg";
            var uri3 = "/imgs/justicia-ciudadana-postal03.jpg";
            
            
            string currURI = "";
            switch (currIndexFlick)
            {
                case 0:
                    currURI = uri2;
                    currIndexFlick++;
                    break;
                case 1:
                    currURI = uri3;
                    currIndexFlick++;
                    break;
                case 2:
                    currURI = uri1;
                    currIndexFlick = 0;
                    break;
            }
   
            //imgCurrent.Source = new BitmapImage(new Uri(currURI, UriKind.Relative));

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

        private void lstScroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lstScroll.ScrollIntoView(lstScroll.SelectedIndex);
       }

        private void btnFB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void webBrowserFB_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                LoginSucceded(accessToken);
            }
            else
            {
                // user cancelled
                MessageBox.Show(oauthResult.ErrorDescription);
            }

        }

        private void LoginSucceded(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var id = (string)result["id"];

                var url = string.Format("/Pages/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);



                //Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
            };

            fb.GetAsync("me?fields=id");
        }

        private void webBrowserFB_Loaded(object sender, RoutedEventArgs e)
        {
            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);

            webBrowserFB.Navigate(loginUrl);

        }

        private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            //parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["redirect_uri"] = "https://m.facebook.com/dialog/return/ms";

        
            parameters["response_type"] = "token";
            parameters["display"] = "touch";

            // add the 'scope' only if we have extendedPermissions.
            if (!string.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }

            return _fb.GetLoginUrl(parameters);
        }

        private void mnuAcerca_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Acerca.xaml", UriKind.Relative));

        }

        private void mnuTerminos_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Terminos.xaml", UriKind.Relative));

        }

    }
}