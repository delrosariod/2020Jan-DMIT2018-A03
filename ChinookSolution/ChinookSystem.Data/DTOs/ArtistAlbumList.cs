using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using ChinookSystem.Data.POCOs;
#endregion

namespace ChinookSystem.Data.DTOs
{
    public class ArtistAlbumList
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        List<ListDDL> AlbumList { get; set; }
    }
}
