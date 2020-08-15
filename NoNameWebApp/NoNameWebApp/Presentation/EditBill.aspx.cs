using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Linq;

namespace NoNameWebApp.Presentation
{
    public partial class EditBill : System.Web.UI.Page
    {
        private const string KEY_BILL = "bill";
        private Bill bill;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                bill = CommonBusinessStuff.bills.Single(b => b.Id == id);
                ViewState[KEY_BILL] = bill;
            }
            else
            {
                bill = (Bill)ViewState[KEY_BILL];
            }

            ShowBill(false);
        }

        private void ShowBill(bool afterUpdate)
        {
            LabelNumber.Text = bill.Number;
            LabelTotal.Text = CommonPresentationStuff.FormatPrice(bill.TotalPrice);

            GridViewContents.DataSource = bill.Contents;
            GridViewContents.DataBind();

            GridViewStatuses.DataSource = bill.Statuses;
            GridViewStatuses.DataBind();

            ShowDropdownListOfStatuses(afterUpdate);
        }

        private void ShowDropdownListOfStatuses(bool afterUpdate)
        {
            int selectedIndex = DropDownListStatuses.SelectedIndex;
            DropDownListStatuses.Items.Clear();
            DropDownListStatuses.Items.Add(bill.LastStatus.Name);

            foreach (string status in CommonBusinessStuff.statusTransitions[bill.LastStatus.Name])
            {
                DropDownListStatuses.Items.Add(status);
            }

            if (selectedIndex == -1 || afterUpdate)
            {
                DropDownListStatuses.SelectedValue = bill.LastStatus.Name;
            }
            else
            {
                DropDownListStatuses.SelectedIndex = selectedIndex;
            }
        }

        protected async void ButtonSave_Click(object sender, EventArgs e)
        {
            string selectedStatus = DropDownListStatuses.SelectedValue;

            if (selectedStatus.Equals(bill.LastStatus.Name))
            {
                return;
            }

            bill.Statuses.Add(new BillStatus { Name = selectedStatus });
            bool success = await RestClient.UpdateBill(bill);

            if (success)
            {
                CommonPresentationStuff.ShowAlert(this, "Promjene su uspješno spremljene!");
                ViewState[KEY_BILL] = bill;
                ShowBill(true);
            }
            else
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
            }
        }
    }
}