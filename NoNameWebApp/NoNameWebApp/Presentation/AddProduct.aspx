<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="AddProduct.aspx.cs"
    Inherits="NoNameWebApp.Presentation.AddProduct"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dodavanje proizvoda</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="twoColumnContainer">
        <span class="label twoColumnContainerItem">Naziv:</span>
        <asp:TextBox ID="TextBoxName" runat="server" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Dostupna količina:</span>
        <asp:TextBox ID="TextBoxAvailableQuantity" runat="server" TextMode="Number" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Cijena:</span>
        <asp:TextBox ID="TextBoxPrice" runat="server" CssClass="twoColumnContainer" />
        <span class="label twoColumnContainerItem">Kategorija:</span>
        <asp:DropDownList ID="DropDownListCategories" runat="server" CssClass="dropdownlist twoColumnContainerItem" />
        <asp:Button ID="ButtonAdd" runat="server" Text="Dodaj" OnClick="ButtonAdd_Click" CssClass="button twoColumnContainerItem" />
    </div>
</asp:Content>
