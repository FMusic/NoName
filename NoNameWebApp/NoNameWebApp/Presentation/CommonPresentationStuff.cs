using System.Web.UI;

namespace NoNameWebApp.Presentation
{
    public class CommonPresentationStuff
    {
        public static void ShowAlert(Page page, string message)
        {
            string script = string.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", script, true);
        }

        public static void ShowGenericErrorMessage(Page page)
        {
            ShowAlert(page, "Greška u komunikaciji sa servisom!");
        }

        public static string FormatPrice(float price)
        {
            return string.Format("{0:0.00} kn", price);
        }
    }
}