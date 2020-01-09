using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addtional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Data.Entities
{
    public class Album
    {
        private string _ReleaseLabel;

        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album Title is required.")]
        [StringLength(160, ErrorMessage = "Maximum length for Album Title is 160 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Artist ID is required.")]
        public int ArtistId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Release Year must be a positive number.")]
        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length for Release Label is 50 characters.")]
        public string ReleaseLabel
        {
            get
            {
                return _ReleaseLabel;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReleaseLabel = null;
                }
                else
                {
                    _ReleaseLabel = value;
                }
            }
        }

        public virtual Artist Artist { get; set; }
        //public virtual ICollection<Track> Tracks { get; set; }
    }
}
