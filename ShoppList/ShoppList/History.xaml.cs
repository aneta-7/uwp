using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using ShoppList.Models;
using ShoppList.ViewModel;
using System.Runtime.Serialization.Json;
using Windows.Data.Json;
using Windows.Graphics.Display;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShoppList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class History : Page
    {

        public History()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {        
            var date = App.Current as App;

            var from = String.Format("{0:M-d-yyyy}", date.From);
            var to = String.Format("{0:M-d-yyyy}", date.To);
            var currentUser = date.currentUserId;

            String url = String.Format("http://localhost:11063/api/shops/getFromDate/{0}/{1}/{2}", currentUser, from, to);
 
            HttpClient client = new HttpClient();
            HttpResponseMessage JsonReponse = await client.GetAsync(url);
            var response =  JsonReponse.Content.ReadAsStringAsync().Result;
            var shopResult = JsonConvert.DeserializeObject<List<ShopViewModel>>(response);
            shopsList.ItemsSource = shopResult;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        //home
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        //new list
        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Create));
        }
        //history
        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SetHistoryDate));
        }

        //settings
        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings2));
        }

        //help
        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help2));
        }
        private void MenuButton6_Click(object sender, RoutedEventArgs e)
        {
            var data = App.Current as App;
            this.Frame.Navigate(typeof(Login));

        }

        //ok
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewList));
        }
    }
}
