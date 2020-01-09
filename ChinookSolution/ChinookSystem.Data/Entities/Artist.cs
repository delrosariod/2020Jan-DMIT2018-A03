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
    //identify the sql entity (table) this class maps
    [Table("Artists", Schema = "dbo")]
    public class Artist
    {
        private string _Name;

        [Key]
        public int ArtistId { get; set; }

        [StringLength(120,ErrorMessage ="Artist name is limited to 120 characters.")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Name = null;
                }
                else
                {
                    _Name = value;
                }
            }
        }

        //virtual navigational properties. (Do not contain Data)
        //these properties form a virtual relationship between the entity classes.
        //based on the ERD relationship between entities.
        public virtual ICollection<Album> Albums { get; set; }

    }
}
