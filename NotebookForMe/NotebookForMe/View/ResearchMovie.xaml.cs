using NotebookForMe.Model;
using NotebookForMe.Model.Utils;
using NotebookForMe.ModelView;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotebookForMe.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResearchMovie : Page
    {
        private ResearchMovieModel context = new ResearchMovieModel();

        public ResearchMovie()
        {
            this.InitializeComponent();
            this.DataContext = this.context;
        }

        private void textbox_find_movie_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox item = sender as TextBox;

            if (e.KeyStatus.ScanCode == 28)
            {
                context.FindMovie(item.Text);
            }

        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView list = this.listResearc as ListView;

            list.SelectedItems.ToList().ForEach(async delegate (object item)
            {
                MovieItem movie = item as MovieItem;

                try
                {
                    movie.UserId = Session.get("googleSid");
                    await MobileConnection.get().GetTable<MovieItem>().InsertAsync(movie);
                }
                catch (Exception ex)
                {

                }
            });


            Frame.Navigate(typeof(MainPage));
        }
    }
}
