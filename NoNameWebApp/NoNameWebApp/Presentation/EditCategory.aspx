<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="EditCategory.aspx.cs"
    Inherits="NoNameWebApp.Presentation.EditCategory"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uređivanje kategorije</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Naziv:
    <asp:TextBox ID="TextBoxName" runat="server" />
    <br /><br />
    <asp:Button ID="ButtonSave" runat="server" Text="Spremi" OnClick="ButtonSave_Click" CssClass="button" />
</asp:Content>
