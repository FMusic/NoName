<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="Supply.aspx.cs"
    Inherits="NoNameWebApp.Presentation.Supply"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="SupplyPageStyle.css" rel="stylesheet" />
    <title>Nabava</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="categoriesContainer">
        <asp:HiddenField ID="HiddenFieldNumberOfProducts" runat="server" />
        <span class="label categoryItem1">Odaberite kategoriju:</span>
        <asp:DropDownList ID="DropDownListCategories" runat="server" AutoPostBack="true" CssClass="dropdownlist categoryItem2" />
        <asp:Button
            ID="ButtonEditCategory"
            runat="server"
            Text="Uredi kategoriju"
            OnClick="ButtonEditCategory_Click"
            CssClass="button categoryItem3" />
        <asp:Button
            ID="ButtonDeleteCategory"
            runat="server"
            Text="Obriši kategoriju"
            OnClick="ButtonDeleteCategory_Click"
            CssClass="button categoryItem4" />
        <asp:Button
            ID="ButtonAddCategory"
            runat="server"
            Text="Dodaj novu kategoriju"
            OnClick="ButtonAddCategory_Click"
            CssClass="button categoryItem5" />
    </div>

    <div id="productsContainer">
        <span class="label">Proizvodi:</span>
        <asp:GridView
            ID="GridViewProducts"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="GridViewProducts_RowCommand"
            CssClass="table">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Naziv" />
                <asp:BoundField DataField="AvailableQuantity" HeaderText="Stanje zaliha" />
                <asp:BoundField DataField="Price" HeaderText="Cijena" DataFormatString="{0:0.00} kn" />
                <asp:TemplateField HeaderText="Akcije">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldProductId" Value='<%# Eval("Id") %>' runat="server" />
                        <div class="actionContainer">
                            <asp:LinkButton
                                ID="LinkButtonEditProduct"
                                runat="server"
                                Text="Uredi"
                                CommandName="EditProduct"
                                CssClass="button actionItem" />
                            <asp:LinkButton
                                ID="LinkButtonDeleteProduct"
                                runat="server"
                                Text="Obriši"
                                CommandName="DeleteProduct"
                                CssClass="button actionItem" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="ButtonAddProduct" runat="server" Text="Dodaj novi proizvod" OnClick="ButtonAddProduct_Click" CssClass="button" />
    </div>
</asp:Content>
