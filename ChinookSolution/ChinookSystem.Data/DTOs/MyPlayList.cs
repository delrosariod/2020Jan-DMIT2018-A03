using ChinookSystem.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.DTOs
{
    public class MyPlayList
    {
        public string PlaylistName { get; set; }
        public int NumberofTracks { get; set; }
        public int TotalPlayTime { get; set; }
        public IEnumerable<PlayListSong> PlayListSongs { get; set; }
    }
}
