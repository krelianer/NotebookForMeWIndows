using NotebookForMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace NotebookForMe.ModelView
{
    public class MainPageModel
    {
        private ObservableCollection<Item> _listItems = new ObservableCollection<Item>();
        private ObservableCollection<MovieItem> _movieList = new ObservableCollection<MovieItem>();
        private ObservableCollection<MusicItem> _musicList = new ObservableCollection<MusicItem>();

        public MainPageModel()
        {
            InitializeModel();
        }

        public async void InitializeModel()
        {
            List<MovieItem> list = await MovieItem.GetMovie();

            list.ToList().ForEach(_listItems.Add);
        }

        public ObservableCollection<Item> ListItems
        {
            get
            {
                return this._listItems;
            }
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

        public async void FindMovie(String query)
        {
            List<MovieItem> list = await MovieItem.SearchMovie(query);

            _movieList.Clear();
           list.ToList().ForEach(_movieList.Add);
        }

        public async void FindMusic(String query)
        {
            List<MusicItem> list = await MusicItem.SearchMusic(query);

            _musicList.Clear();
            list.ToList().ForEach(_musicList.Add);
        }
    }
}
