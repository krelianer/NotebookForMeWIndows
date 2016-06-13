using NotebookForMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.ModelView
{
    public class MainPageModel
    {
        private ObservableCollection<Item> _listItems = new ObservableCollection<Item>();

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
    }
}
