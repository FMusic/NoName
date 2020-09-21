<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="MainPage.aspx.cs"
    Inherits="NoNameWebApp.Presentation.MainPage"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ponuda</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <span class="label">Odaberite kategoriju:</span>
        <asp:DropDownList ID="DropDownListCategories" runat="server" AutoPostBack="true" CssClass="dropdownlist" />
    </div>

    <asp:GridView
        ID="GridViewProducts"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewProducts_RowCommand"
        CssClass="table drinkSelection">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Naziv" />
            <asp:BoundField DataField="Price" HeaderText="Cijena" DataFormatString="{0:0.00} kn" />
            <asp:TemplateField HeaderText="Akcije">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldProductId" Value='<%# Eval("Id") %>' runat="server" />
                    <asp:LinkButton
                        ID="LinkButton"
                        runat="server"
                        Text="Dodaj"
                        CommandName="AddProduct"
                        CssClass="button" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="PanelBillContents" runat="server">
        <span class="label">Detalji računa:</span>

        <asp:GridView
            ID="GridViewBillContents"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="GridViewBillContents_RowCommand"
            CssClass="table billContents">
            <Columns>
                <asp:BoundField DataField="CorrespondingProduct.Name" HeaderText="Naziv" />
                <asp:BoundField DataField="Quantity" HeaderText="Količina" />
                <asp:BoundField DataField="Price" HeaderText="Jedinična cijena" DataFormatString="{0:0.00} kn" />
                <asp:TemplateField HeaderText="Akcije">
                    <ItemTemplate>
                        <asp:HiddenField
                            ID="HiddenFieldProductId"
                            Value='<%# Eval("CorrespondingProduct.Id") %>'
                            runat="server" />
                        <div class="actionContainer">
                            <asp:LinkButton
                                ID="LinkButtonDecrease"
                                runat="server"
                                Text="-"
                                CommandName="DecreaseQuantity"
                                CssClass="button actionItem" />
                            <asp:LinkButton
                                ID="LinkButtonIncrease"
                                runat="server"
                                Text="+"
                                CommandName="IncreaseQuantity"
                                CssClass="button actionItem" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div>
            <span class="label">Ukupno:</span>
            <span class="label strong">
                <asp:Label ID="LabelTotal" runat="server" /></span>
            <asp:Button ID="ButtonOrder" runat="server" Text="Naruči" OnClick="ButtonOrder_Click" CssClass="button" />
        </div>
    </asp:Panel>
</asp:Content>
