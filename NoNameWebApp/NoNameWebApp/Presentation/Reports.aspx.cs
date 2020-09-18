using NoNameAppDataModel;
using NoNameWebApp.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace NoNameWebApp.Presentation
{
    public partial class Reports : System.Web.UI.Page
    {
        private const string KEY_BILL_REPORTS = "billReports";
        private const string KEY_SUPPLY_REPORTS = "supplyReports";
        private List<BillReport> billReports;
        private List<SupplyReport> supplyReports;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                billReports = await RestClient.GetBillReports();
                ViewState[KEY_BILL_REPORTS] = billReports;

                supplyReports = await RestClient.GetSupplyReports();
                ViewState[KEY_SUPPLY_REPORTS] = supplyReports;
            }
            else
            {
                billReports = (List<BillReport>)ViewState[KEY_BILL_REPORTS];
                supplyReports = (List<SupplyReport>)ViewState[KEY_SUPPLY_REPORTS];
            }

            ShowBillReports();
            ShowSupplyReports();
        }

        private void ShowBillReports()
        {
            GridViewBillReports.DataSource = billReports
                .OrderByDescending(br => br.Year)
                .ThenByDescending(br => br.Month)
                .ThenByDescending(br => br.Day);

            GridViewBillReports.DataBind();
        }

        private void ShowSupplyReports()
        {
            GridViewSupplyReports.DataSource = supplyReports
                .OrderByDescending(sr => sr.Year)
                .ThenByDescending(sr => sr.Month)
                .ThenByDescending(sr => sr.Day);

            GridViewSupplyReports.DataBind();
        }

        private async void DownloadFile(int fileId)
        {
            FileData fileData = await RestClient.GetFileData(fileId);

            if (fileData == null)
            {
                CommonPresentationStuff.ShowGenericErrorMessage(this);
                return;
            }

            string contentDispositionHeaderValue = string.Format(
                "attachment;filename=\"{0}\"",
                fileData.Name);

            Response.Clear();
            Response.ClearHeaders();
            Response.AppendHeader("Content-Length", fileData.Data.Length.ToString());
            Response.AppendHeader("Content-Disposition", contentDispositionHeaderValue);
            Response.ContentType = fileData.ContentType;
            Response.Write(fileData.Data);
            Response.End();
        }

        private int GetFileId(GridViewCommandEventArgs e, string hiddenFieldName)
        {
            LinkButton button = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            return Convert.ToInt32(((HiddenField)row.FindControl(hiddenFieldName)).Value);
        }

        protected void GridViewBillReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fileId = GetFileId(e, "HiddenFieldBillFileDataId");
            DownloadFile(fileId);
        }

        protected void GridViewSupplyReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fileId = GetFileId(e, "HiddenFieldSupplyFileDataId");
            DownloadFile(fileId);
        }
    }
}