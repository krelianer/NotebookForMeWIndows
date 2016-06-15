using NotebookForMe.Model;
using NotebookForMe.ModelView;
using NotebookForMe.Model.Utils;
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotebookForMe.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResearchMusic : Page
    {
        private ResearchMusicModel context = new ResearchMusicModel();

        public ResearchMusic()
        {
            this.InitializeComponent();
            this.DataContext = this.context;
        }

        private void textbox_find_music_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox item = sender as TextBox;

            if (e.KeyStatus.ScanCode == 28)
            {
                context.FindMusic(item.Text);
            }
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView list = this.listResearch as ListView;

            list.SelectedItems.ToList().ForEach(async delegate(object item)
            {
                MusicItem music = item as MusicItem;

                try
                {
                    music.UserId = Session.get("googleSid");
                    await MobileConnection.get().GetTable<MusicItem>().InsertAsync(music);
                }
                catch(Exception ex)
                {

                }
            });


            Frame.Navigate(typeof(MainPage));
        }
    }
}
