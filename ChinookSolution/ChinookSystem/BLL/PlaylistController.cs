using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Name Spaces
using ChinookSystem.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using DMIT2018Common.UserControls;
using ChinookSystem.Data.POCOs;
using ChinookSystem.Data.DTOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<MyPlayList> PlayList_GetBySize(int numberoftracks)
        {
            using(var context = new ChinookContext())
            {
                var plresults = from x in context.Playlists
                                where x.PlaylistTracks.Count() == numberoftracks
                                select new MyPlayList
                                {
                                    PlaylistName = x.Name,
                                    NumberofTracks = x.PlaylistTracks.Count(),
                                    TotalPlayTime = x.PlaylistTracks.Sum(plt => plt.Track.Milliseconds),
                                    PlayListSongs = from y in x.PlaylistTracks
                                             orderby y.Track.Genre.Name
                                             select new PlayListSong
                                             {
                                                 SongName = y.Track.Name,
                                                 Genre = y.Track.Genre.Name
                                             }
                                };
                return plresults.ToList();
            }
        }
    }
}
