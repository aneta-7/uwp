using Newtonsoft.Json;
using ShopList.Models;
using ShoppList.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShoppList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings2 : Page
    {
        public Settings2()
        {
            this.InitializeComponent();
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
            this.Frame.Navigate(typeof(MainPage));
        }
        //month
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {

        }
        //week
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        //slider
        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
        //ok

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            bool isCheckedWeek = false;
            bool isCheckedMonth = false;

            var date = App.Current as App;
            var currentUser = date.currentUserId;

            DateTime calc = DateTime.Today;

            if (radioButton.IsChecked == true)
            {
                isCheckedWeek = true;
                calc = DateTime.Today.AddDays(7);
            }

            if (radioButton1.IsChecked == true)
            {
                isCheckedMonth = true;
                calc = DateTime.Today.AddDays(30);
            }

            var settings = new SettingsViewModel()
            {
                Week = isCheckedWeek,
                Month = isCheckedMonth,
                From = DateTime.Now,
                To = calc,
                Limit = (int)slider.Value,
                User_id = currentUser
            };

            var settingsJson = JsonConvert.SerializeObject(settings);

            var client = new HttpClient();
            var HttpContent = new StringContent(settingsJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PostAsync("http://localhost:11063/api/settings", HttpContent);

            var dialog = new Windows.UI.Popups.MessageDialog(
                "Your limit are selected");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
         
            var result = await dialog.ShowAsync();
            this.Frame.Navigate(typeof(MainPage));
        }
        //calcel
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
