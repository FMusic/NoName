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
    <div class="reportsContainer">
        <span class="label">Izvještaji o računima:</span>

        <asp:GridView
            ID="GridViewBillReports"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="GridViewBillReports_RowCommand"
            CssClass="table">
            <Columns>
                <asp:BoundField DataField="Year" HeaderText="Godina" />
                <asp:BoundField DataField="Month" HeaderText="Mjesec" />
                <asp:BoundField DataField="Day" HeaderText="Dan" />
                <asp:TemplateField HeaderText="Akcije">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldBillFileDataId" Value='<%# Eval("FileDataId") %>' runat="server" />
                        <asp:LinkButton
                            ID="LinkButton"
                            runat="server"
                            Text="Preuzmi"
                            CommandName="DownloadBillReport"
                            CssClass="button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="reportsContainer">
        <span class="label">Izvještaji o nabavama:</span>

        <asp:GridView
            ID="GridViewSupplyReports"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="GridViewSupplyReports_RowCommand"
            CssClass="table">
            <Columns>
                <asp:BoundField DataField="Year" HeaderText="Godina" />
                <asp:BoundField DataField="Month" HeaderText="Mjesec" />
                <asp:BoundField DataField="Day" HeaderText="Dan" />
                <asp:TemplateField HeaderText="Akcije">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldSupplyFileDataId" Value='<%# Eval("FileDataId") %>' runat="server" />
                        <asp:LinkButton
                            ID="LinkButton"
                            runat="server"
                            Text="Preuzmi"
                            CommandName="DownloadSupplyReport"
                            CssClass="button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
