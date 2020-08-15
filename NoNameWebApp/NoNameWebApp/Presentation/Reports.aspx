<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs"
    Inherits="NoNameWebApp.Presentation.Reports"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Izvještaji</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Izvještaji o računima:
    <br />

    <asp:GridView
        ID="GridViewBillReports"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewBillReports_RowCommand">
        <Columns>
            <asp:BoundField DataField="Year" HeaderText="Godina" />
            <asp:BoundField DataField="Month" HeaderText="Mjesec" />
            <asp:BoundField DataField="Day" HeaderText="Dan" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldBillFileDataId" Value='<%# Eval("FileDataId") %>' runat="server" />
                    <asp:LinkButton
                        ID="LinkButton"
                        runat="server"
                        Text="Preuzmi"
                        CommandName="DownloadBillReport" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />

    Izvještaji o nabavama:
    <br />

    <asp:GridView
        ID="GridViewSupplyReports"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewSupplyReports_RowCommand">
        <Columns>
            <asp:BoundField DataField="Year" HeaderText="Godina" />
            <asp:BoundField DataField="Month" HeaderText="Mjesec" />
            <asp:BoundField DataField="Day" HeaderText="Dan" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldSupplyFileDataId" Value='<%# Eval("FileDataId") %>' runat="server" />
                    <asp:LinkButton
                        ID="LinkButton"
                        runat="server"
                        Text="Preuzmi"
                        CommandName="DownloadSupplyReport" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
