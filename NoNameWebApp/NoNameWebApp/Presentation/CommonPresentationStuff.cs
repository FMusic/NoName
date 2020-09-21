using System.Collections.Generic;
using System.Web.UI;

namespace NoNameWebApp.Presentation
{
    public class CommonPresentationStuff
    {
        private static readonly Stack<string> NAVIGATION_STACK = new Stack<string>();

        public static readonly Dictionary<string, string> pageTitles = new Dictionary<string, string>
        {
            { "AddCategory.aspx", "Dodavanje kategorije" },
            { "AddProduct.aspx", "Dodavanje proizvoda" },
            { "Bills.aspx", "Računi" },
            { "EditBill.aspx", "Uređivanje računa" },
            { "EditCategory.aspx", "Uređivanje kategorije" },
            { "EditProduct.aspx", "Uređivanje proizvoda" },
            { "LoginPage.aspx", "Login" },
            { "MainPage.aspx", "Ponuda" },
            { "Reports.aspx", "Izvještaji" },
            { "Supply.aspx", "Nabava" }
        };

        public static string GetPageTitle(string relativePath)
        {
            int indexOfQuestionMark = relativePath.IndexOf('?');

            return (indexOfQuestionMark == -1)
                ? pageTitles[relativePath]
                : pageTitles[relativePath.Substring(0, indexOfQuestionMark)];
        }

        public static bool DoesPreviousPageExist()
        {
            return NAVIGATION_STACK.Count > 1;
        }

        public static void ClearNavigationStack()
        {
            NAVIGATION_STACK.Clear();
        }

        public static void AddPageToNavigationStack(string page)
        {
            if (NAVIGATION_STACK.Count == 0 || !page.Equals(NAVIGATION_STACK.Peek()))
            {
                NAVIGATION_STACK.Push(page);
            }
        }

        public static string GetPreviousPage()
        {
            if (!DoesPreviousPageExist())
            {
                return null;
            }

            NAVIGATION_STACK.Pop();

            return NAVIGATION_STACK.Pop();
        }

        public static void ShowAlert(Page page, string message)
        {
            string script = string.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", script, true);
        }

        public static void ShowGenericErrorMessage(Page page)
        {
            ShowAlert(page, "Greška u komunikaciji sa servisom!");
        }

        public static string FormatPrice(double price)
        {
            return string.Format("{0:0.00} kn", price);
        }
    }
}