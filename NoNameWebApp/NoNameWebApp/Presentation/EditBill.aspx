<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="EditBill.aspx.cs"
    Inherits="NoNameWebApp.Presentation.EditBill"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uređivanje računa</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Broj računa:
    <asp:Label ID="LabelNumber" runat="server" />
    <br />
    Trenutni status:
    <asp:DropDownList ID="DropDownListStatuses" runat="server" />
    <asp:Button ID="ButtonSave" runat="server" Text="Spremi promjene" OnClick="ButtonSave_Click" />
    <br />
    <br />

    Sastav računa:
    <asp:GridView
        ID="GridViewContents"
        runat="server"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CorrespondingProduct.Name" HeaderText="Naziv" />
            <asp:BoundField DataField="ProductQuantity" HeaderText="Količina" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Jedinična cijena" DataFormatString="{0:0.00} kn" />
        </Columns>
    </asp:GridView>
    <br />

    Ukupno:
    <asp:Label ID="LabelTotal" runat="server" />
    <br />
    <br />

    Povijest statusa:
    <asp:GridView
        ID="GridViewStatuses"
        runat="server"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Naziv" />
            <asp:BoundField DataField="StatusTimestamp" HeaderText="Datum i vrijeme" />
        </Columns>
    </asp:GridView>
</asp:Content>
