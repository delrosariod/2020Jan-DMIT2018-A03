<%@ Page Title="Repeater Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepeaterDemo.aspx.cs" Inherits="WebApp.SamplePages.RepeaterDemo" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Repeater for Nested Query</h1>
    <blockquote>
        This page will demonstrate the Repeater Control. This control is a great Web Control to display the structure of a DTO/POCO Query. The control can be nested within itself to be used to display the POCO component of the DTO structure.<br /><br />
        To ease the properties with the properties in your class on this control use the ItemType attribute and assign the class name of your data definition. The control uses a series of templates to fashion your display.
    </blockquote>
    <div class="row">
        <div class="col-md-12 text-center">
            Enter the size of Playlist to view: &nbsp; &nbsp;
            <asp:TextBox ID="NumberOfTracksText" runat="server"></asp:TextBox>&nbsp; &nbsp;
            <asp:Button ID="Submit" runat="server" Text="Submit" />
        </div>
    </div>
    <div class ="row">
        <div class="col-md-12 text-center">
            <asp:RequiredFieldValidator ID="RequiredNumberOfTracks" runat="server" ErrorMessage="Track size is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="NumberOfTracksText"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Track size must be a positive whole number" Display="None" ControlToValidate="NumberOfTracksText" SetFocusOnError="true" Type="Integer" ValueToCompare="0" Operator="GreaterThan"></asp:CompareValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <div class ="row">
        <div class="col-md-12 text-center">
            <asp:Repeater ID="ClientPlayListDTO" runat="server" DataSourceID="ClientPlayListDTOODS"
                ItemType="ChinookSystem.Data.DTOs.MyPlayList">
                <HeaderTemplate>
                    <h2>Client PlayLists for Requested Size</h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <h3>
                        <%# Item.PlaylistName %>  PlayTime: <%# Item.TotalPlayTime %>
                    </h3>
                    <%--<asp:GridView ID="SongList" runat="server" DataSource="<%# Item.PlayListSongs %>" ItemType="ChinookSystem.Data.POCOs.PlayListSong">
                    </asp:GridView>--%>
                    <asp:Repeater ID="SongList" runat="server" DataSource="<%# Item.PlayListSongs %>" ItemType="ChinookSystem.Data.POCOs.PlayListSong">
                        <ItemTemplate>
                            <%#Item.SongName %> &nbsp;&nbsp; <%# Item.Genre %> <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:ObjectDataSource ID="ClientPlayListDTOODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="PlayList_GetBySize" TypeName="ChinookSystem.BLL.PlaylistController" OnSelected="SelectedCheckForException">
        <SelectParameters>
            <asp:ControlParameter ControlID="NumberOfTracksText" DefaultValue="1" Name="numberoftracks" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </div>
</asp:Content>
