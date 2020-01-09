using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Additional Name Spaces
using System.Data.Entity;
using ChinookSystem.Data.Entities;
#endregion

namespace ChinookSystem.DAL
{
    internal class ChinookContext : DbContext
    {
        public ChinookContext() : base ("ChinookDB")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        //DTOs and POCOs do not get DBSet properties.
       
    }
}
