<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs"
    Inherits="NoNameWebApp.Presentation.LoginPage"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Prijava</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>Korisničko ime:</td>
            <td>
                <asp:TextBox ID="TextBoxUserName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Lozinka:</td>
            <td>
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="ButtonLogin" runat="server" Text="Prijava" OnClick="ButtonLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
