<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="AddCategory.aspx.cs"
    Inherits="NoNameWebApp.Presentation.AddCategory"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dodavanje kategorije</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="twoColumnContainer">
        <span class="label twoColumnContainerItem">Naziv:</span>
        <asp:TextBox ID="TextBoxName" runat="server" CssClass="twoColumnContainerItem" />
        <asp:Button ID="ButtonAdd" runat="server" Text="Dodaj" OnClick="ButtonAdd_Click" CssClass="button twoColumnContainerItem" />
    </div>
</asp:Content>
