using NotebookForMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.ModelView
{
    public class ResearchMovieModel
    {
        private ObservableCollection<MovieItem> _movieList = new ObservableCollection<MovieItem>();

        public async void FindMovie(String query)
        {
            List<MovieItem> list = await MovieItem.SearchMovie(query);

            _movieList.Clear();
            list.ToList().ForEach(_movieList.Add);
        }

        public ObservableCollection<MovieItem> MovieList
        {
            get
            {
                return this._movieList;
            }
        }
    }
}
