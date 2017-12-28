using SupifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Users user = new Users();
            List<Playlist> Playists = new List<Playlist>();
            List<MusicConnections> ConnectionsList = new List<MusicConnections>();
        }

        public Users user { get; set; }

        public List<Playlist> Playists { get; set; }

        public List<MusicConnections> ConnectionsList { get; set; }
    }
}