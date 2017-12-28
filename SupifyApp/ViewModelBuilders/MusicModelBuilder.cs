using SupifyApp.Models;
using SupifyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupifyApp.ViewModelBuilders
{
    public class MusicModelBuilder
    {
        public SupinfydbEntities db = new SupinfydbEntities();
        MusicViewModel f;

        public MusicModelBuilder()
        {
            f = new MusicViewModel();
        }

        public MusicViewModel Build(Users usr)
        {
            f.u = usr;
            f.tracklist = db.Track.Where(t => t.userid == usr.Id).ToList();
            return f;
        }
    }
}