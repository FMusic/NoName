<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="Supply.aspx.cs"
    Inherits="NoNameWebApp.Presentation.Supply"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nabava</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Kategorija:
    <asp:DropDownList ID="DropDownListCategories" runat="server" AutoPostBack="true" />
    <asp:Button
        ID="ButtonEditCategory"
        runat="server"
        Text="Uredi"
        OnClick="ButtonEditCategory_Click" />
    <asp:HiddenField ID="HiddenFieldNumberOfProducts" runat="server" />
    <asp:Button
        ID="ButtonDeleteCategory"
        runat="server"
        Text="Obriši"
        OnClick="ButtonDeleteCategory_Click" />
    <br />
    <asp:Button
        ID="ButtonAddCategory"
        runat="server"
        Text="Dodaj novu kategoriju"
        OnClick="ButtonAddCategory_Click" />
    <br /><br />

    Proizvodi:
    <asp:GridView
        ID="GridViewProducts"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewProducts_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Naziv" />
            <asp:BoundField DataField="AvailableQuantity" HeaderText="Stanje zaliha" />
            <asp:BoundField DataField="Price" HeaderText="Cijena" DataFormatString="{0:0.00} kn" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldProductId" Value='<%# Eval("Id") %>' runat="server" />
                    <asp:LinkButton
                        ID="LinkButtonEditProduct"
                        runat="server"
                        Text="Uredi"
                        CommandName="EditProduct" />
                    <asp:LinkButton
                        ID="LinkButtonDeleteProduct"
                        runat="server"
                        Text="Obriši"
                        CommandName="DeleteProduct" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <br />
    <asp:Button ID="ButtonAddProduct" runat="server" Text="Dodaj novi proizvod" OnClick="ButtonAddProduct_Click" />
</asp:Content>
