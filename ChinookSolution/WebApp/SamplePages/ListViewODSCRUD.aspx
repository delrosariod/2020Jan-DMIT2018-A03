<%@ Page Title="ListView ODS CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewODSCRUD.aspx.cs" Inherits="WebApp.SamplePages.ListViewODSCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>ListView ODS CRUD</h1>
    <blockquote class ="alert alert-info">
        This page will demonstrate the ListView control doing a complete CRUD using only ODS.
        The page will demonstrate the use of the user control MessageUserControl as it pertains to ODS.
        CRUD Methods are added to the ODS using the several tabs/options available on the wizard.
    </blockquote>
    <asp:ListView ID="AlbumList" runat="server">

    </asp:ListView>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Artist_List" 
        TypeName="ChinookSystem.BLL.ArtistController">

    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlbumListODS" runat="server" 
        DataObjectTypeName="ChinookSystem.Data.Entities.Album" 
        OldValuesParameterFormatString="original_{0}"
        DeleteMethod="Album_Delete" 
        InsertMethod="Album_Add"
        SelectMethod="Album_List" TypeName="ChinookSystem.BLL.AlbumController" 
        UpdateMethod="Album_Update">
    </asp:ObjectDataSource>
</asp:Content>
