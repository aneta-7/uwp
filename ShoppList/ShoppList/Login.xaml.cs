using Newtonsoft.Json;
using ShoppList.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentName = txtLogin.Text;
            var currentPassword = txtPassword.Password;

           
                String check = String.Format("http://localhost:11063/api/users/checkLogin/{0}/{1}", currentName, currentPassword);
                HttpClient client2 = new HttpClient();
                HttpResponseMessage JsonReponse2 = await client2.GetAsync(check);
                var response = JsonReponse2.Content.ReadAsStringAsync().Result;

                if(response == "true")
                {
                    String url = String.Format("http://localhost:11063/api/users/getCurrentUser/{0}/{1}", currentName, currentPassword);

                    HttpClient client = new HttpClient();
                    HttpResponseMessage JsonReponse = await client.GetAsync(url);
                    var currentUserId = JsonReponse.Content.ReadAsStringAsync().Result;
                    //  var result = JsonConvert.DeserializeObject<int>(currentUserId);

                    var result = currentUserId.Trim(new Char[] { '[', ']' });

                    var date = App.Current as App;
                    date.currentUserId = Int32.Parse(result);

                    this.Frame.Navigate(typeof(MainPage), currentUserId);
                }

                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Invalid userName or password");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                    var result = await dialog.ShowAsync();
                }
            

        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Signup));
        }
    }
}
