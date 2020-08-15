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
    Status: <asp:DropDownList
        ID="DropDownListStatuses"
        runat="server"
        AutoPostBack="true" />

    <asp:GridView
        ID="GridViewBills"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="GridViewBills_RowCommand">
        <Columns>
            <asp:BoundField DataField="Number" HeaderText="Broj računa" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Ukupna cijena" DataFormatString="{0:0.00} kn" />
            <asp:BoundField DataField="LastStatus.Name" HeaderText="Status" />
            <asp:TemplateField HeaderText="Akcije">
                <ItemTemplate>
                    <asp:HiddenField
                        ID="HiddenFieldBillId"
                        Value='<%# Eval("Id") %>'
                        runat="server" />
                    <asp:LinkButton
                        ID="LinkButtonEditBill"
                        runat="server"
                        Text="Uredi"
                        CommandName="EditBill" />
                    <asp:LinkButton
                        ID="LinkButtonDeleteBill"
                        runat="server"
                        Text="Obriši"
                        CommandName="DeleteBill"
                        Visible='<%# "REJECTED".Equals((string)Eval("LastStatus.Name")) %>' />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
