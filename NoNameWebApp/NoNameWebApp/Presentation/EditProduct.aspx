<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="EditProduct.aspx.cs"
    Inherits="NoNameWebApp.Presentation.EditProduct"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uređivanje proizvoda</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>Naziv:</td>
            <td>
                <asp:Label ID="LabelName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Dostupna količina:</td>
            <td>
                <asp:TextBox ID="TextBoxAvailableQuantity" runat="server" TextMode="Number" />
            </td>
        </tr>
        <tr>
            <td>Cijena:</td>
            <td>
                <asp:TextBox ID="TextBoxPrice" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Kategorija:</td>
            <td>
                <asp:DropDownList ID="DropDownListCategories" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="ButtonSave" runat="server" Text="Spremi" OnClick="ButtonSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
