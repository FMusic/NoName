<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs"
    Inherits="NoNameWebApp.Presentation.LoginPage"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="LoginPageStyle.css" rel="stylesheet" />
    <title>Prijava</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid-container">
        <h1 class="grid-item title">No Name Coffee Bar</h1>
        <asp:TextBox
            ID="TextBoxUserName"
            runat="server"
            PlaceHolder="Korisničko ime"
            class="grid-item textbox" />
        <asp:TextBox
            ID="TextBoxPassword"
            runat="server"
            TextMode="Password"
            PlaceHolder="Lozinka"
            class="grid-item textbox" />
        <asp:Button
            ID="ButtonLogin"
            runat="server"
            Text="Prijava"
            OnClick="ButtonLogin_Click"
            CssClass="grid-item button" />
    </div>
</asp:Content>
