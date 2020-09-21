<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Presentation/MyMasterPage.Master"
    AutoEventWireup="true"
    CodeBehind="Bills.aspx.cs"
    Inherits="NoNameWebApp.Presentation.Bills"
    Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Računi</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <span class="label">Status:</span>
        <asp:DropDownList ID="DropDownListStatuses" runat="server" AutoPostBack="true" CssClass="dropdownlist" />
    </div>

    <asp:GridView
        ID="GridViewBills"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewBills_RowCommand"
        CssClass="table">
        <Columns>
            <asp:BoundField DataField="TableNumber" HeaderText="Broj računa" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Ukupna cijena" DataFormatString="{0:0.00} kn" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# GetStatusName((NoNameAppDataModel.Bill)Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Akcije">
                <ItemTemplate>
                    <asp:HiddenField
                        ID="HiddenFieldBillId"
                        Value='<%# Eval("Id") %>'
                        runat="server" />
                    <div class="actionContainer">
                        <asp:LinkButton
                            ID="LinkButtonEditBill"
                            runat="server"
                            Text="Uredi"
                            CommandName="EditBill"
                            CssClass="button actionItem" />
                        <asp:LinkButton
                            ID="LinkButtonDeleteBill"
                            runat="server"
                            Text="Obriši"
                            CommandName="DeleteBill"
                            CssClass="button actionItem" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
