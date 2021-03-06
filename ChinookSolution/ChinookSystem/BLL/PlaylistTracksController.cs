﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.DTOs;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
using DMIT2018Common.UserControls;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {

        //create a class level private data member to hold your list of errors.
        private List<string> errors = new List<string>();

        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
                List<UserPlaylistTrack> results = (from x in context.PlaylistTracks
                                                   where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username)
                                                   orderby x.TrackNumber
                                                   select new UserPlaylistTrack
                                                   {
                                                       TrackID = x.TrackId,
                                                       TrackNumber = x.TrackNumber,
                                                       TrackName = x.Track.Name,
                                                       Milliseconds = x.Track.Milliseconds,
                                                       UnitPrice = x.Track.UnitPrice
                                                   }).ToList();

                return results;
            }
        }//eom
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //dtermine if playlist exists
                //  do a query to find playlist
                //test results = null
                //if yes,
                //create and instance of a playlist
                //load
                //add
                //set tracknumber to 1
                //no
                //query to find max track number.
                //tracknumber ++
                //query to find track exists
                //test results == null
                //yes
                //throw exception
                //create an instance of playlisttrack.
                //load
                //add
                //SaveChange

                //what would happen if there is no match for the incoming parameter values?
                //we need to ensure that the results have a valid value
                //this value will be resolved by the query either as null
                // (not found) or an IEnumerable collection.
                //we are looking for a single occurence to match the where.
                //to achieve a valid value we encapsulate the query in a 
                //(query).FirstOrDefault();
                int tracknumber = 0;
                PlaylistTrack newtrack = null;
                Playlist exists = (from x in context.Playlists
                             where x.Name.Equals(playlistname) && x.UserName.Equals(username)
                             select x).FirstOrDefault();

                if (exists == null)
                {
                    //new playlist
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //existing playlist
                     newtrack = (from x in context.PlaylistTracks
                                              where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username)
                                              && x.TrackId == trackid
                                              select x).FirstOrDefault();
                    if (newtrack == null)
                    {
                        //not found can be added:
                        tracknumber = (from x in context.PlaylistTracks
                                    where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username)
                                    select x.TrackNumber).Max();
                        tracknumber++; //increment by 1.
                    }
                    else
                    {
                        //found. violates business rule where a track can only appear on a playlist once:
                        //There are two ways of handling the message:
                        //a) single possible error
                        //b) multiple business rule errors that it oculd catch.

                        //a)
                        //throw new Exception("Song already exists on playlist. Please choose another.");

                        //b)use the BusinessRuleException class to throw the error. This technique can be used in the BLL and on the WebPage.
                        //to use this technique you will collect the errors within a List<string>; Then throw the BusinessRuleException along with the List<string> errors.
                        errors.Add("@#Song already exists on playlist. Please choose another.");
                        
                    }
                }

                //finish all possible business rule validation.
                if (errors.Count > 0)
                {
                    throw new BusinessRuleException("Adding Track", errors);
                }
                //add the new Playlist Track record:
                newtrack = new PlaylistTrack();
                //when you do a .Add() to an entity the record is only STAGED and NOT YET in the DataBase. Any Expected PKey value does not yet exist until we use .SaveChanges()
                //newtrack.PlaylistId = exists.PlaylistId; removed
                newtrack.TrackId = trackid;
                newtrack.TrackNumber = tracknumber;
                //By using "existing" instead of context, the parent will automatically added and generate the playlistId based on entityFramework. That way, the child can be associated with the parent and added accordingly.
                exists.PlaylistTracks.Add(newtrack);
                context.SaveChanges();
                
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                var exists = (from x in context.Playlists
                              where x.UserName.Equals(username)
                                && x.Name.Equals(playlistname)
                              select x).FirstOrDefault();
                if (exists == null)
                {
                    throw new Exception("Play list has been removed from the file");
                }
                else
                {
                    PlaylistTrack moveTrack = (from x in exists.PlaylistTracks
                                               where x.TrackId == trackid
                                               select x).FirstOrDefault();
                    if (moveTrack == null)
                    {
                        throw new Exception("Play list song has been removed from the file.");
                    }
                    else
                    {
                        //up
                        PlaylistTrack otherTrack = null;
                        if (direction.Equals("up"))
                        {
                            if (moveTrack.TrackNumber == 1)
                            {
                                throw new Exception("Play list song already at the top");
                            }
                            else
                            {
                                //move it
                                otherTrack = (from x in exists.PlaylistTracks
                                              where x.TrackNumber == moveTrack.TrackNumber - 1
                                              select x).FirstOrDefault();
                                if (otherTrack == null)
                                {
                                    throw new Exception("Other play list song is missing.");
                                }
                                else
                                {
                                    //good to move
                                    moveTrack.TrackNumber -= 1;
                                    otherTrack.TrackNumber += 1;
                                }
                            }
                        }
                        else
                        {
                            //down
                            if (moveTrack.TrackNumber == exists.PlaylistTracks.Count)
                            {
                                throw new Exception("Play list song already at the bottom");
                            }
                            else
                            {
                                //move it
                                otherTrack = (from x in exists.PlaylistTracks
                                              where x.TrackNumber == moveTrack.TrackNumber + 1
                                              select x).FirstOrDefault();
                                if (otherTrack == null)
                                {
                                    throw new Exception("Other play list song is missing.");
                                }
                                else
                                {
                                    //good to move
                                    moveTrack.TrackNumber += 1;
                                    otherTrack.TrackNumber -= 1;
                                }
                            }
                        }
                        //update database
                        //a field update NOT an entity update --> does field by field because POCOS.
                        //if you're doing CRUD (change a field or any number) --> do an entity update. Here we only have one field to change so we do one field instead
                        context.Entry(moveTrack).Property(y => y.TrackNumber).IsModified = true;
                        context.Entry(otherTrack).Property(y => y.TrackNumber).IsModified = true;
                        //commit transaction
                        context.SaveChanges();
                    }
                }

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
                var exists = (from x in context.Playlists
                              where x.UserName.Equals(username)
                                 && x.Name.Equals(playlistname)
                              select x).FirstOrDefault();
                if(exists == null)
                {
                    throw new Exception("Playlist has been removed from the system.");
                }
                else
                {
                    //get a list of every track that we DONT want to delete (keep them)
                    var trackKept = exists.PlaylistTracks
                                    .Where(tr => !trackstodelete.Any(tod => tod == tr.TrackId))      //This gets items that are in list but not in our tracks to delete.
                                    .OrderBy(tr => tr.TrackNumber)
                                    .Select(tr => tr);

                    //remove unwanted tracks
                    PlaylistTrack item = null;
                    foreach(var dtrackid in trackstodelete)
                    {
                        item = (exists.PlaylistTracks
                               .Where(tr => tr.TrackId == dtrackid)
                               .Select(tr => tr)).FirstOrDefault();
                        if (item != null)
                        {
                            exists.PlaylistTracks.Remove(item);
                        }
                    }

                    int number = 1;
                    foreach(var tKept in trackKept)
                    {
                        tKept.TrackNumber = number;
                        context.Entry(tKept).Property(y => y.TrackNumber).IsModified = true;
                        number++;
                    }

                    context.SaveChanges();

                }


            }
        }//eom
    }
}
