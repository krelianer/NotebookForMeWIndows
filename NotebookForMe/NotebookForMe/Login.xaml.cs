using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotebookForMe
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

        private async void btn_login_google_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                // Change 'MobileService' to the name of your MobileServiceClient instance.
                // Sign-in using Facebook authentication.
                var user = await MobileConnection.get().LoginAsync(MobileServiceAuthenticationProvider.Google);

                Session.set("googleSid", user.UserId);
                //String str = await MobileConnection.get().InvokeApiAsync<String>("google/GetGoogleInfo", HttpMethod.Get, null);


                Frame.Navigate(typeof(MainPage));
            }
            catch (InvalidOperationException)
            {
                var dialog = new MessageDialog("You should be sign in to continue!");
                await dialog.ShowAsync();
            }
        }
    }
}
