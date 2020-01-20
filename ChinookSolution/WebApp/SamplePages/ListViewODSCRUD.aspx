<%@ Page Title="ListView ODS CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewODSCRUD.aspx.cs" Inherits="WebApp.SamplePages.ListViewODSCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>ListView ODS CRUD</h1>
    <blockquote class ="alert alert-info">
        This page will demonstrate the ListView control doing a complete CRUD using only ODS.
        The page will demonstrate the use of the user control MessageUserControl as it pertains to ODS.
        CRUD Methods are added to the ODS using the several tabs/options available on the wizard.
    </blockquote>

    <%-- For the Delete to work on this ODS CRUD, you **MUST** include a parameter called DataKeyNames 
         This parameter will be set to the PKey field Name on the Entity
         
         For Insert and Edit Templates use "Bind('XXX')" instead of Eval which is for Alternating, Item and Select
         
         A change to a Layout/control on one template should be duplicated to the other templates, ie. ArtistId Width 50px
         
         Remove Navigational properties
         Remove NotMapped properties--%>
    <asp:ListView ID="AlbumList" runat="server" DataSourceID="AlbumListODS" InsertItemPosition="LastItem" DataKeyNames="AlbumId">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        selectedvalue ='<%# Eval("ArtistId") %>' Width="300px"  AppendDataBoundItems ="true" Enabled="False">
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' Enabled="False" Width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        selectedvalue ='<%# Bind("ArtistId") %>' Width="300px" AppendDataBoundItems ="true">
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' Width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' Enabled="False" Width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        selectedvalue ='<%# Bind("ArtistId") %>' Width="300px" AppendDataBoundItems ="true">
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' Width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        selectedvalue ='<%# Eval("ArtistId") %>' Width="300px" AppendDataBoundItems ="true">
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">ID</th>
                                <th runat="server">Title</th>
                                <th runat="server">Artist</th>
                                <th runat="server">Year</th>
                                <th runat="server">Label</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #008A8C; font-weight: bold;color: #000000;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        selectedvalue ='<%# Eval("ArtistId") %>' Width="300px" AppendDataBoundItems ="true" Enabled="False">
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' Width="50px"/>
                </td>
                <td>
                    <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>

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
