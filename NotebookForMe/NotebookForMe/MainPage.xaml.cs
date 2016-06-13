using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model;
using NotebookForMe.Model.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotebookForMe
{
      /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MobileServiceUser user;

        public MainPage()
        {
            this.InitializeComponent();
            launch();
          //  GetMovie();
        }

        public async void launch()
        {
            await AuthenticateAsync();
            //SearchMovie("007");
        }

        

        private async System.Threading.Tasks.Task<bool> AuthenticateAsync()
        {
            string message;
            bool success = false;
            try
            {
                // Change 'MobileService' to the name of your MobileServiceClient instance.
                // Sign-in using Facebook authentication.
                user = await MobileConnection.get().LoginAsync(MobileServiceAuthenticationProvider.Google);
                message = "You are now signed in";
                success = true;
                Session.set("googleSid", user.UserId);
            }
            catch (InvalidOperationException)
            {
                message = "You must log in. Login Required";
            }

            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
            return success;
        }


    }
}

//Class user
/*
@com.google.gson.annotations.SerializedName("id")
    private String id;
@com.google.gson.annotations.SerializedName("email")
    private String email;
@com.google.gson.annotations.SerializedName("name")
    private String name;
@com.google.gson.annotations.SerializedName("given_name")
    private String given_name;
@com.google.gson.annotations.SerializedName("family_name")
    private String family_name;
@com.google.gson.annotations.SerializedName("link")
    private String link;
@com.google.gson.annotations.SerializedName("picture")
    private String picture;
@com.google.gson.annotations.SerializedName("gender")
    private String gender;
@com.google.gson.annotations.SerializedName("locale")
    private String locale;
    */
