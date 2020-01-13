<%@ Page Title="ODS Review" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSReview.aspx.cs" Inherits="WebApp.SamplePages.ODSReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Query: Albums by Artist</h1>

    <%--<asp:Label ID="Label1" runat="server" Text="Select an Artist"></asp:Label> &nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ArtistLookUpDDL" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Fetch" />
    <br /><br /><br />--%>

    <asp:Label ID="Label3" runat="server" Text="Enter album title: "></asp:Label> &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="SearchAlbumTitle" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Fetch" />
    <br /><br /><br />


    <asp:GridView ID="AlbumList" runat="server" AllowPaging="True" DataSourceID="AlbumListODS" PageSize="15" GridLines="Horizontal" BorderStyle ="None" CssClass ="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="AlbumList_SelectedIndexChanged" Caption="Albums for Artists">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("AlbumId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Artist">
                <ItemTemplate>
                    <asp:DropDownList ID="ArtistDDL" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId"
                        AppendDataBoundItems="true" Width ="200px"
                        selectedvalue ='<%# Eval("ArtistId") %>'>
                        <asp:ListItem Value="Select">Select....</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Year">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Label">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ReleaseLabel") ?? "------------------"%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No albums to display at this time.
        </EmptyDataTemplate>

    </asp:GridView>
    <asp:ObjectDataSource ID="AlbumListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Album_FindByTitle" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SearchAlbumTitle" DefaultValue="zasadedasasdhgasjbdtad43672vt87v" Name="albumtitle" PropertyName="Text" Type="String" />
        </SelectParameters>

    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_List" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>

</asp:Content>
