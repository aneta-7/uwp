using Newtonsoft.Json;
using ShopList.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShoppList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton6_Click(object sender, RoutedEventArgs e)
        {
            var data = App.Current as App;
            this.Frame.Navigate(typeof(Login));

        }

        //help
        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help2));
        }
        //settings
        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings2));
        }
        //history select date
        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SetHistoryDate));
        }
        //new list
        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Create));
        }
        //home
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            
        }
        void GoBack()
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        void GoForward()
        {
            if (this.Frame != null && this.Frame.CanGoForward) this.Frame.GoForward();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //String currentUser = "1";

            var date = App.Current as App;

            var currentUser = date.currentUserId; 

            String url = String.Format("http://localhost:11063/api/Settings/LastLimit/{0}", currentUser);


            HttpClient client = new HttpClient();
            HttpResponseMessage JsonReponse = await client.GetAsync(url);
            var response = JsonReponse.Content.ReadAsStringAsync().Result;
            textBox1.Text = response.ToString();

            String url2 = String.Format("http://localhost:11063/api/Settings/spend/{0}", currentUser);

            HttpResponseMessage JsonReponse2 = await client.GetAsync(url2);
            var response2 = JsonReponse2.Content.ReadAsStringAsync().Result;

            textBox3.Text = response2.ToString();


            String url3 = String.Format("http://localhost:11063/api/Settings/CalulateToLiveTile/{0}", currentUser);

            HttpResponseMessage JsonReponse3 = await client.GetAsync(url3);
            var response3 = JsonReponse3.Content.ReadAsStringAsync().Result;

            textBox5.Text = response3;

            if (response3.Contains("-"))
            {
                // template to load for showing Toast Notification
                var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                         "<visual>" +
                                           "<binding template =\"ToastGeneric\">" +
                                             "<text>You exceeded the limit!!!</text>" +
                                             "<text>Reset your limit ;) </text>"+
                                           "</binding>" +
                                         "</visual>" +
                                        "</toast>";

                // load the template as XML document
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlToastTemplate);

                // create the toast notification and show to user
                var toastNotification = new ToastNotification(xmlDocument);
                var notification = ToastNotificationManager.CreateToastNotifier();
                notification.Show(toastNotification);
            }


            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);

            var tileAtributes = tileXml.GetElementsByTagName("text");
            tileAtributes[0].AppendChild(tileXml.CreateTextNode("Current balanse"));
            tileAtributes[1].AppendChild(tileXml.CreateTextNode(textBox5.Text));
            var tileNotyfication = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotyfication);

        }
    }
}
