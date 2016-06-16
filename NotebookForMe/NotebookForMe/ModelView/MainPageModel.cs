using GalaSoft.MvvmLight;
using Newtonsoft.Json.Linq;
using NotebookForMe.Model;
using NotebookForMe.Model.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace NotebookForMe.ModelView
{
    public class MainPageModel : ViewModelBase
    {
        private ObservableCollection<MusicItem> _musicList = new ObservableCollection<MusicItem>();
        private ObservableCollection<MovieItem> _movieList = new ObservableCollection<MovieItem>();

        public MainPageModel()
        {
            InitializeModel();
        }

        public async void InitializeModel()
        {
            //Dictionary<string, string> parameters = new Dictionary<string, string>();

            //JObject str = await MobileConnection.get().InvokeApiAsync<JObject>("google/GetGoogleInfo", HttpMethod.Get, parameters);

            List<MovieItem> movies = await MovieItem.GetMovie();

            movies.ToList().ForEach(_movieList.Add);

            RaisePropertyChanged("MovieList");
            RaisePropertyChanged("Release1");
            RaisePropertyChanged("Release2");
            RaisePropertyChanged("LeftHours");
            RaisePropertyChanged("LeftMinutes");

            List<MusicItem> musics = await MusicItem.GetMusic();

            musics.ToList().ForEach(_musicList.Add);

            RaisePropertyChanged("MusicList");
            RaisePropertyChanged("Release1");
            RaisePropertyChanged("Release2");
            RaisePropertyChanged("LeftHours");
            RaisePropertyChanged("LeftMinutes");
        }

        public ObservableCollection<MusicItem> MusicList
        {
            get
            {
                return this._musicList;
            }
        }
        public ObservableCollection<MovieItem> MovieList
        {
            get
            {
                return this._movieList;
            }
        }

        public String LeftHours
        {
            get
            {
                int time = 0;

                this._movieList.ToList().ForEach(delegate (MovieItem item)
                {
                    time += item.Duration / 60000;
                });
                this._musicList.ToList().ForEach(delegate (MusicItem item)
                {
                    time += item.Duration / 60000;
                });

                return Convert.ToString(time / 60);
            }
        }
        public String LeftMinutes
        {
            get
            {
                int time = 0;

                this._movieList.ToList().ForEach(delegate (MovieItem item)
                {
                    time += item.Duration / 60000;
                });
                this._musicList.ToList().ForEach(delegate (MusicItem item)
                {
                    time += item.Duration / 60000;
                });

                return Convert.ToString(time % 60);
            }
        }

        public Item Release1
        {
            get
            {
                if (this._movieList.Count > 0)
                {
                    return this._movieList[0];
                }
                return null;
            }
        }
        public Item Release2
        {
            get
            {
                if (this._movieList.Count > 1)
                {
                    return this._movieList[1];
                }
                return null;
            }
        }

        public async void Remove_movie(MovieItem movie, int index)
        {
            _movieList.RemoveAt(index);
            await MobileConnection.get().GetTable<MovieItem>().DeleteAsync(movie);
        }

        public async void Remove_music(MusicItem music, int index)
        {
            _musicList.RemoveAt(index);
            await MobileConnection.get().GetTable<MusicItem>().DeleteAsync(music);
        }
    }
}
