using Newtonsoft.Json;
using ShoppList.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
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
    public sealed partial class Signup : Page
    {
        public Signup()
        {
            this.InitializeComponent();
        }


        IsolatedStorageFile ISOFile = IsolatedStorageFile.GetUserStoreForApplication();

        private async void Submit_Click(object sender, RoutedEventArgs e)

        {

            //UserName Validation   

            if (!Regex.IsMatch(TxtUserName.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))

            {
                var dialog = new Windows.UI.Popups.MessageDialog("Invalid UserName");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                var result = await dialog.ShowAsync();
            }



            //Password length Validation   

            else if (TxtPwd.Password.Length < 6)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Password length should be minimum of 6 characters!");
                dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                var result = await dialog.ShowAsync();
            }


            //After validation success ,store user detials in isolated storage   

            else if (TxtUserName.Text != "" && TxtPwd.Password != "")

            {
                var newLogin = TxtUserName.Text;
                String url = String.Format("http://localhost:11063/api/users/existsUser/{0}", newLogin);
                HttpClient client = new HttpClient();
                HttpResponseMessage JsonReponse = await client.GetAsync(url);
                var response = JsonReponse.Content.ReadAsStringAsync().Result;

                if (response == "false")
                {
                    var user = new User()
                    {
                        Login = TxtUserName.Text,
                        Password = TxtPwd.Password
                    };

                    var userJson = JsonConvert.SerializeObject(user);

                    var HttpContent = new StringContent(userJson);
                    HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await client.PostAsync("http://localhost:11063/api/users", HttpContent);

                    var dialog = new Windows.UI.Popups.MessageDialog("Your account has been created!");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                    var result = await dialog.ShowAsync();

                    this.Frame.Navigate(typeof(Login));

                }
                else {
                    var dialog = new Windows.UI.Popups.MessageDialog("Login is already busy :(");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                    var result = await dialog.ShowAsync();
                }

            }
        }
    }
}
