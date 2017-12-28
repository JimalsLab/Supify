using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupifyApp.Models;

namespace SupifyApp.ViewModels
{
    public class MusicViewModel
    {
        public MusicViewModel()
        {
            List<Track> tracklist = new List<Track>();
            Users u = new Users();
        }

        public List<Track> tracklist { get; set; }

        public Users u { get; set; }
    }
}