using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace NoNameWebApp.Presentation
{
    public partial class Bills : System.Web.UI.Page
    {
        private const string KEY_BILLS = "bills";
        private List<Bill> bills;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await RefreshBills();
            }
            else
            {
                bills = (List<Bill>)ViewState[KEY_BILLS];
            }

            ShowStatuses();
            ShowBills();
        }

        public string GetStatusName(Bill bill)
        {
            return CommonBusinessStuff.statusNames[bill.LastStatus.Name];
        }

        private async Task RefreshBills()
        {
            bills = await RestClient.GetBills();
            ViewState[KEY_BILLS] = bills;
        }

        private void ShowStatuses()
        {
            int selectedIndex = DropDownListStatuses.SelectedIndex;
            DropDownListStatuses.DataSource = CommonBusinessStuff.statusNames;
            DropDownListStatuses.DataTextField = "Value";
            DropDownListStatuses.DataValueField = "Key";

            if (selectedIndex == -1)
            {
                DropDownListStatuses.SelectedValue = "CREATED";
            }
            else
            {
                DropDownListStatuses.SelectedIndex = selectedIndex;
            }

            DropDownListStatuses.DataBind();
        }

        private void ShowBills()
        {
            string selectedStatusName = DropDownListStatuses.SelectedValue;

            if (string.IsNullOrWhiteSpace(selectedStatusName))
            {
                GridViewBills.DataSource = bills.OrderByDescending(b => b.Number);
            }
            else
            {
                GridViewBills.DataSource = bills
                    .Where(b => b.LastStatus.Name.Equals(selectedStatusName))
                    .OrderByDescending(b => b.Number);
            }

            GridViewBills.DataBind();
        }

        private int GetBillId(GridViewCommandEventArgs e)
        {
            LinkButton button = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            return Convert.ToInt32(((HiddenField)row.FindControl("HiddenFieldBillId")).Value);
        }

        protected async void GridViewBills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int billId = GetBillId(e);

            if (e.CommandName.Equals("EditBill"))
            {
                string url = string.Format("EditBill.aspx?id={0}", billId);
                Response.Redirect(url, false);
            }
            else if (e.CommandName.Equals("DeleteBill"))
            {
                bool success = await RestClient.DeleteBill(billId);

                if (success)
                {
                    CommonPresentationStuff.ShowAlert(this, "Račun uspješno obrisan!");
                    await RefreshBills();
                    ShowBills();
                }
                else
                {
                    CommonPresentationStuff.ShowGenericErrorMessage(this);
                }
            }
        }
    }
}