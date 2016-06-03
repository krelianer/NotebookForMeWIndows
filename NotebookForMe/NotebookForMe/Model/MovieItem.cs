using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.Model
{
    public class MovieItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public double Vote { get; set; }
        public string Poster { get; set; }
        public string Release { get; set; }
        public int Duration { get; set; }
    }
}
