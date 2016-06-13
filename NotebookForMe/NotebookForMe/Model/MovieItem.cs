﻿using Microsoft.WindowsAzure.MobileServices;
using NotebookForMe.Model.Utils;
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

        public async void GetMovie()
        {
            try
            {
                IMobileServiceTable<MovieItem> mMovieTable = MobileConnection.get().GetTable<MovieItem>();
                List<MovieItem> items = await mMovieTable.ToListAsync();
            }
            catch (Exception e)
            {

            }
        }


        public async void SearchMovie(string name)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name);

                var result = await MobileConnection.get().InvokeApiAsync<List<MovieItem>>("theMovieDB/SelectByName", System.Net.Http.HttpMethod.Get, parameters);
                //     ListenableFuture<JsonElement> result = AppController.getInstance().getService().getmClient().invokeApi("spotify/SelectByTrack", "GET", parameters);
                //invokeApi("google/GetGoogleInfo", "GET", null);
            }
            catch (Exception e)
            {
            }
        }
    }
}
