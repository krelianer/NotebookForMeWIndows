using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model;
using NotebookForMe.Model.Utils;
using NotebookForMe.ModelView;
using NotebookForMe.View;
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
        private MainPageModel context = new MainPageModel();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this.context;
        }

        private void btn_add_movie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMovie));
        }

        private void btn_add_music_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMusic));
        }

        private void list_movie_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView list = sender as ListView;

            MovieItem movie = list.SelectedItem as MovieItem;

            if (movie != null)
            {
                context.Remove_movie(movie, list.SelectedIndex);
            }
        }

        private void list_music_Holding(object sender, HoldingRoutedEventArgs e)
        {
            ListView list = sender as ListView;

            MusicItem music = list.SelectedItem as MusicItem;

            if (music != null)
            {
                context.Remove_music(music, list.SelectedIndex);
            }
        }
    }
}