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

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Na pocetku moramo pokupiti sve račune i spremiti ih u view state.
                await RefreshBills();
            }
            else
            {
                // Ako je bio post back, izvadimo stvari iz view statea.
                CommonBusinessStuff.bills = (List<Bill>)ViewState[KEY_BILLS];
            }

            ShowStatuses();
            ShowBills();
        }

        private async Task RefreshBills()
        {
            CommonBusinessStuff.bills = await RestClient.GetBills();
            ViewState[KEY_BILLS] = CommonBusinessStuff.bills;
        }

        private void ShowStatuses()
        {
            int selectedIndex = DropDownListStatuses.SelectedIndex;
            DropDownListStatuses.DataSource = CommonBusinessStuff.statusNames;

            if (selectedIndex == -1)
            {
                // To znaci da smo upravo otvorili stranicu, DDL nije ranije bila popunjena.
                DropDownListStatuses.SelectedValue = "CREATED";
            }
            else
            {
                // Inace, postavi selektirani indeks na onaj koji je ranije postavljen.
                DropDownListStatuses.SelectedIndex = selectedIndex;
            }

            DropDownListStatuses.DataBind();
        }

        private void ShowBills()
        {
            string selectedStatusName = DropDownListStatuses.SelectedValue;

            if (string.IsNullOrWhiteSpace(selectedStatusName))
            {
                GridViewBills.DataSource = CommonBusinessStuff.bills;
            }
            else
            {
                GridViewBills.DataSource = CommonBusinessStuff
                    .bills
                    .Where(b => b.LastStatus.Name.Equals(selectedStatusName));
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