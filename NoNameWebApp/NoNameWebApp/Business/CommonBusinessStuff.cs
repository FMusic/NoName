using NoNameAppDataModel;
using System.Collections.Generic;

namespace NoNameWebApp.Business
{
    public class CommonBusinessStuff
    {
        public const string KEY_USER_DATA = "userData";
        public static MainData mainData;

        public static readonly Dictionary<string, string> roleNames = new Dictionary<string, string>
        {
            { "Admin", "Admin" },
            { "Waiter", "Konobar" }
        };

        public static readonly Dictionary<string, string> statusNames = new Dictionary<string, string>
        {
            { "", "Svi" },
            { "CREATED", "Kreirano" },
            { "PAYED", "Plaćeno" }
        };

        public static readonly Dictionary<string, List<string>> statusTransitions = new Dictionary<string, List<string>>
        {
            { "CREATED", new List<string> { "PAYED" } },
            { "PAYED", new List<string>() }
        };


        public static readonly List<string> pagesHiddenFromNonAdminUser = new List<string>
        {
            "AddCategory.aspx",
            "AddProduct.aspx",
            "EditCategory.aspx",
            "EditProduct.aspx",
            "Reports.aspx",
            "Supply.aspx"
        };
    }
}
