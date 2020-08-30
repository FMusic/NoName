using NoNameAppDataModel;
using System.Collections.Generic;

namespace NoNameWebApp.Business
{
    public class CommonBusinessStuff
    {
        public const string KEY_USER_DATA = "userData";
        public static MainData mainData;
        public static List<Bill> bills;

        public static readonly List<string> statusNames = new List<string>
        {
            "",
            "CREATED",
            "APPROVED",
            "REJECTED",
            "PAYED"
        };

        public static readonly Dictionary<string, List<string>> statusTransitions = new Dictionary<string, List<string>>
        {
            { "CREATED", new List<string> { "APPROVED", "REJECTED" } },
            { "APPROVED", new List<string> { "PAYED", "REJECTED" } },
            { "REJECTED", new List<string>() },
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
