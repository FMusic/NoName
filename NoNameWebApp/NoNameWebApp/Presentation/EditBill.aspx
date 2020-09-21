<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="EditBill.aspx.cs"
    Inherits="NoNameWebApp.Presentation.EditBill"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EditBillPageStyle.css" rel="stylesheet" />
    <title>Uređivanje računa</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="twoColumnContainer">
        <span class="label twoColumnContainerItem">Broj računa:</span>
        <span class="label twoColumnContainerItem">
            <asp:Label ID="LabelNumber" runat="server" />
        </span>
        <span class="label twoColumnContainerItem">Trenutni status:</span>
        <asp:DropDownList ID="DropDownListStatuses" runat="server" CssClass="dropdownlist twoColumnContainerItem" />
        <asp:Button ID="ButtonSave" runat="server" Text="Spremi promjene" OnClick="ButtonSave_Click" CssClass="button twoColumnContainerItem" />
    </div>

    <div id="billContents">
        <div>
            <span class="label">Detalji računa:</span>
            <asp:GridView
                ID="GridViewContents"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table">
                <Columns>
                    <asp:BoundField DataField="CorrespondingProduct.Name" HeaderText="Naziv" />
                    <asp:BoundField DataField="Quantity" HeaderText="Količina" />
                    <asp:BoundField DataField="Price" HeaderText="Jedinična cijena" DataFormatString="{0:0.00} kn" />
                </Columns>
            </asp:GridView>
        </div>

        <span class="label">Ukupno:</span>
        <span class="label">
            <asp:Label ID="LabelTotal" runat="server" />
        </span>
    </div>
</asp:Content>
