using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.Data.POCOs;
#endregion

namespace WebApp.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ArtistName.Text))
            {
                MessageUserControl.ShowInfo("Selection Error", "You must enter an artist name or part of");
                TracksBy.Text = "";
                SearchArg.Text = "";
            }
            else
            {
                TracksBy.Text = "Artist";
                SearchArg.Text = ArtistName.Text;
                //TracksSelectionList.DataBind(); //Forces the ODS to re-execute.
            }
        }


        protected void GenreFetch_Click(object sender, EventArgs e)
        {
                TracksBy.Text = "Genre";
                SearchArg.Text = GenreDDL.SelectedValue;
                //TracksSelectionList.DataBind(); //Forces the ODS to re-execute.
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AlbumTitle.Text))
            {
                MessageUserControl.ShowInfo("Selection Error", "You must enter an Album Title or part of");
                TracksBy.Text = "";
                SearchArg.Text = "";
            }
            else
            {
                TracksBy.Text = "Album";
                SearchArg.Text = AlbumTitle.Text;
                //TracksSelectionList.DataBind(); //Forces the ODS to re-execute.
            }

        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Data Missing", "Enter a playlist name");
            }
            else
            {
                string username = "HansenB"; //username will come from security once implemented.

                //Message user control will be used to handle code behind user friendly error handling.
                //Will NOT be using try catch. Try/catch is embedded within the MessageUserControl class.
                MessageUserControl.TryRun(() => 
                {
                    //coding block
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, username);
                    PlayList.DataSource = info;
                    PlayList.DataBind();
                },"Playlist","Manage your playlist"); //strings after the coding block are the messages for a successful input.
            }
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
 
        }


        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void TracksSelectionList_ItemCommand(object sender, 
            ListViewCommandEventArgs e)
        {
            //code to go here
            
        }

        protected void MediaTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(MediaTypeDDL.SelectedIndex == 0)
            {
                MessageUserControl.ShowInfo("Selection Error", "You must select a Media Type from the dropdown list.");
                TracksBy.Text = "";
                SearchArg.Text = "";
            }
            else
            {
                TracksBy.Text = "MediaType";
                SearchArg.Text = MediaTypeDDL.SelectedValue;
                //TracksSelectionList.DataBind(); //Forces the ODS to re-execute.
            }
        }

    }
}