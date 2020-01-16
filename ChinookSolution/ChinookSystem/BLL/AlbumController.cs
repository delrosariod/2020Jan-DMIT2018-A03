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
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        //this List<T> will hold a series of error message strings. It will be used by MessageUserControl via the BusinessRuleException
        private List<string> _reasons = new List<string>();
        
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Album_FindByID(int albumid)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_FindByArtist(int artistid)
        {
            using (var context = new ChinookContext())
            {
                //simple example of a lookup using foreign key "artistID" on a DBset<t> using Linq
                var results = from albumrow in context.Albums
                              where albumrow.ArtistId == artistid
                              select albumrow;
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Album_FindByTitle(string albumtitle)
        {
            using (var context = new ChinookContext())
            {
                //simple example of a lookup using foreign key "artistID" on a DBset<t> using Linq
                var results = from albumrow in context.Albums
                              where albumrow.Title.Contains(albumtitle)
                              select albumrow;
                return results.ToList();
            }
        }
        #endregion

        #region Add,Update,Delete
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public int Album_Add(Album item)
        {
            //add
            using (var context = new ChinookContext())
            {
                //additional logic
                if(CheckReleaseYear(item))
                {
                    item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;

                    context.Albums.Add(item); //staging
                    context.SaveChanges(); //actual commit to database
                    return item.AlbumId; //instance now has the identity PK value.
                }
                else
                {
                    throw new BusinessRuleException("Validation error", _reasons);
                }
            }
        }
        //update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public int Album_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                //additional logic
                if (CheckReleaseYear(item))
                {
                    item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;

                    context.Entry(item).State = System.Data.Entity.EntityState.Modified; //staging
                    return context.SaveChanges(); //actual commit to database and return rowsaffected
                    
                }
                else
                {
                    throw new BusinessRuleException("Validation error", _reasons);
                }
            }
        }
        //An overload function because ODS is on the Entity Level
        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public int Album_Delete(Album item)
        {
            return Album_Delete(item.AlbumId);
        }

        //delete is a physical delete
        public int Album_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {
                    throw new Exception("Record already has been removed, no additional removal was executed.");
                }
                context.Albums.Remove(existing);
                return context.SaveChanges();
            }
        }
        #endregion

        #region Support Methods
        private bool CheckReleaseYear(Album item)
        {
            bool isValid = true;
            int releaseyear;
            if(string.IsNullOrEmpty(item.ReleaseYear.ToString()))
            {
                isValid = false;
                _reasons.Add("Release year is required");
            }
            else if(!int.TryParse(item.ReleaseYear.ToString(), out releaseyear))
            {
                isValid = false;
                _reasons.Add("Release year is not a valid year number.");
            }
            else if (releaseyear < 1950 || releaseyear > DateTime.Today.Year)
            {
                isValid = false;
                _reasons.Add(string.Format("Release year {0} is invalid, year must be between 1950 and today.", releaseyear));
            }
            return isValid;
        }
        #endregion
    }

}
