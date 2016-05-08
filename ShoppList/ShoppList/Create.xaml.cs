using Newtonsoft.Json;
using ShoppList.Interfaces;
using ShoppList.Models;
using ShoppList.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShoppList
{
    public sealed partial class Create : Page
    {
         public Create()
        {
            this.InitializeComponent();
            
        }
        //add
        private void button1_Click(object sender, RoutedEventArgs e)
        { 
        }
        //submit
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewList));
        }
        //calcel
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var date = App.Current as App;
            var currentUser = date.currentUserId;

            var shop = new ShopViewModel()
            {
                Date = datePicker.Date.DateTime,
                Value = textBlock.Text,
                Descripion = textBlock3.Text,
                Category = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString(),
                User_id = currentUser
            };
            var shopJson = JsonConvert.SerializeObject(shop);

            var client = new HttpClient();
            var HttpContent = new StringContent(shopJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("http://localhost:11063/api/shops", HttpContent);


            var dialog = new Windows.UI.Popups.MessageDialog(
                "Your shopping have been added");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });

            var result = await dialog.ShowAsync();

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
