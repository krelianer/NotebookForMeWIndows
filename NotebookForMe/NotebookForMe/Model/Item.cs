using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookForMe.Model
{
    public class Item
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Duration { get; set; }

    }

    public class MusicItem : Item
    {
        public string Artists { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Genre { get; set; }
        public string PreviewUrl { get; set; }

        public static async Task<List<MusicItem>> GetMusic()
        {
            try
            {
                IMobileServiceTable<MusicItem> mMovieTable = MobileConnection.get().GetTable<MusicItem>();
                List<MusicItem> items = await mMovieTable
                    .Where(e => e.UserId == Session.get("googleSid")).ToListAsync();
                return items;
            }
            catch (Exception e)
            {

            }
            return new List<MusicItem>();
        }

        public static async Task<List<MusicItem>> SearchMusic(string name)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name);

                List<MusicItem> items = await MobileConnection.get().InvokeApiAsync<List<MusicItem>>("spotify/SelectByTrack", System.Net.Http.HttpMethod.Get, parameters);

                return items;
            }
            catch (Exception e)
            {
            }
            return new List<MusicItem>();
        }
    }

    public class MovieItem : Item
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public double Vote { get; set; }
        public string Poster { get; set; }
        public string Release { get; set; }

        public static async Task<List<MovieItem>> GetMovie()
        {
            try
            {
                IMobileServiceTable<MovieItem> mMovieTable = MobileConnection.get().GetTable<MovieItem>();
                List<MovieItem> items = await mMovieTable
                    .Where(e => e.UserId == Session.get("googleSid")).ToListAsync();
                return items;
            }
            catch (Exception e)
            {

            }
            return new List<MovieItem>();
        }

        public static async Task<List<MovieItem>> SearchMovie(string name)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name);

                List<MovieItem> items = await MobileConnection.get().InvokeApiAsync<List<MovieItem>>("theMovieDB/SelectByName", System.Net.Http.HttpMethod.Get, parameters);

                return items;
            }
            catch (Exception e)
            {
            }
            return new List<MovieItem>();
        }
    }
}
