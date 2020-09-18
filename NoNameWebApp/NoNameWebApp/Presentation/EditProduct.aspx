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
    <div class="twoColumnContainer">
        <span class="label twoColumnContainerItem">Naziv:</span>
        <asp:Label ID="LabelName" runat="server" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Dostupna količina:</span>
        <asp:TextBox ID="TextBoxAvailableQuantity" runat="server" TextMode="Number" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Cijena:</span>
        <asp:TextBox ID="TextBoxPrice" runat="server" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Kategorija:</span>
        <asp:DropDownList ID="DropDownListCategories" runat="server" CssClass="dropdownlist twoColumnContainerItem" />
        <asp:Button ID="ButtonSave" runat="server" Text="Spremi" OnClick="ButtonSave_Click" CssClass="button twoColumnContainerItem" />
    </div>
</asp:Content>
