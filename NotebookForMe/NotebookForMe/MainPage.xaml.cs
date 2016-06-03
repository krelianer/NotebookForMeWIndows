using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model;
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
        public static MobileServiceClient MobileService = new MobileServiceClient("https://notebookforme.azurewebsites.net");
        private MobileServiceUser user;

        public MainPage()
        {
            this.InitializeComponent();
            launch();
          //  GetMovie();
        }

        public async void launch()
        {
            //await AuthenticateAsync();
            SearchMovie("007");
        }

        public async void GetMovie()
        {
            try
            {
                IMobileServiceTable<MovieItem> mMovieTable = MobileService.GetTable<MovieItem>();

                List<MovieItem> items = await mMovieTable.ToListAsync();
            }
            catch (Exception e)
            {

            }
        }

        private async System.Threading.Tasks.Task<bool> AuthenticateAsync()
        {
            string message;
            bool success = false;
            try
            {
                // Change 'MobileService' to the name of your MobileServiceClient instance.
                // Sign-in using Facebook authentication.
                user = await MobileService.LoginAsync(MobileServiceAuthenticationProvider.Google);
                message =
                    string.Format("You are now signed in - {0}", user.UserId);

                success = true;
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


        private async void SearchMovie(string name)
        {
            try {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name);

                var result = await MobileService.InvokeApiAsync<List<MovieItem>>("theMovieDB/SelectByName", System.Net.Http.HttpMethod.Get, parameters);
                //     ListenableFuture<JsonElement> result = AppController.getInstance().getService().getmClient().invokeApi("spotify/SelectByTrack", "GET", parameters);
                //invokeApi("google/GetGoogleInfo", "GET", null);
            }
            catch (Exception e)
            {
            }
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
