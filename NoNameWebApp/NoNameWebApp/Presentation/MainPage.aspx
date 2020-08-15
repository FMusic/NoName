<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="MainPage.aspx.cs"
    Inherits="NoNameWebApp.Presentation.MainPage"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Podatci o korisniku:</legend>
        Korisnik:
        <asp:Label ID="LabelFullName" runat="server" />
        <br />
        Status:
        <asp:Label ID="LabelUserType" runat="server" />
    </fieldset>

    <asp:DropDownList ID="DropDownListCategories" runat="server" AutoPostBack="true" />

    <asp:GridView
        ID="GridViewProducts"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewProducts_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Naziv" />
            <asp:BoundField DataField="Price" HeaderText="Cijena" DataFormatString="{0:0.00} kn" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldProductId" Value='<%# Eval("Id") %>' runat="server" />
                    <asp:LinkButton
                        ID="LinkButton"
                        runat="server"
                        Text="Dodaj"
                        CommandName="AddProduct" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <fieldset>
        <legend>Račun</legend>
        <asp:GridView
            ID="GridViewBillContents"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="GridViewBillContents_RowCommand">
            <Columns>
                <asp:BoundField DataField="CorrespondingProduct.Name" HeaderText="Naziv" />
                <asp:BoundField DataField="ProductQuantity" HeaderText="Količina" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Jedinična cijena" DataFormatString="{0:0.00} kn" />
                <asp:TemplateField HeaderText="Akcije">
                    <ItemTemplate>
                        <asp:HiddenField
                            ID="HiddenFieldProductId"
                            Value='<%# Eval("CorrespondingProduct.Id") %>'
                            runat="server" />
                        <asp:LinkButton
                            ID="LinkButtonDecrease"
                            runat="server"
                            Text="-"
                            CommandName="DecreaseQuantity" />
                        <asp:LinkButton
                            ID="LinkButtonIncrease"
                            runat="server"
                            Text="+"
                            CommandName="IncreaseQuantity" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        Ukupno:
        <asp:Label ID="LabelTotal" runat="server" />
        <br />
        <asp:Button ID="ButtonOrder" runat="server" Text="Naruči" OnClick="ButtonOrder_Click" />
    </fieldset>
</asp:Content>
