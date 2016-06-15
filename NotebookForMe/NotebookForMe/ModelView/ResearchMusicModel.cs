using NotebookForMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.ModelView
{
    public class ResearchMusicModel
    {
        private ObservableCollection<MusicItem> _musicList = new ObservableCollection<MusicItem>();

        public async void FindMusic(String query)
        {
            List<MusicItem> list = await MusicItem.SearchMusic(query);

            _musicList.Clear();
            list.ToList().ForEach(_musicList.Add);
        }

        public ObservableCollection<MusicItem> MusicList
        {
            get
            {
                return this._musicList;
            }
        }
    }
}
