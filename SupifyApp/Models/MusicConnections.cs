//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupifyApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MusicConnections
    {
        public int Id { get; set; }
        public int userid { get; set; }
        public int trackid { get; set; }
        public int playlistid { get; set; }
    
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
        public virtual Users Users { get; set; }
    }
}
