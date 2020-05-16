<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashboardForm.aspx.cs" Inherits="NoNameApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sustav za kafiće</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-inner">
        <div id="content-inner-left">
            Kategorije:
            <hr />
            <asp:Table ID="TableCategories" runat="server" />
            <asp:Table ID="TableProducts" runat="server" />
        </div>
        <div id="content-inner-right">
            Trenutna narudžba:
            <hr />
            <asp:Table ID="TableOrder" runat="server" />
            <asp:Button
                ID="ButtonFinishOrder"
                runat="server"
                Text="Zaključi narudžbu"
                OnClick="ButtonFinishOrder_Click" />
        </div>
    </div>
</asp:Content>
