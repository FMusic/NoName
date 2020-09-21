<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs"
    Inherits="NoNameWebApp.Presentation.Reports"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ReportsPageStyle.css" rel="stylesheet" />
    <title>Izvještaji</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid-container">
        <h1 class="grid-item title"></h1>

        <asp:TextBox
            ID="SelectedDate"
            runat="server"
            PlaceHolder="Revenue Date"
            TextMode="Date"
            class="grid-item textbox" />

        <asp:Button
            ID="ButtonGetRevenue"
            runat="server"
            Text="Revenue"
            OnClick="ButtonRevenue_Click"
            CssClass="grid-item button" />
    </div>

    <asp:GridView
        ID="GridViewRevenue"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table drinkSelection">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Datum" />
            <asp:BoundField DataField="TotalRevenue" HeaderText="Totalan Prihod" DataFormatString="{0:0.00} kn" />
        </Columns>
    </asp:GridView>
</asp:Content>
