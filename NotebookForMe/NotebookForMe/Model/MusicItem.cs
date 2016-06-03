using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.Model
{
    class MusicItem
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Album { get; set; }
        public string AlbumImage { get; set; }
        public string Artists { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string PreviewUrl { get; set; }
    }
}
