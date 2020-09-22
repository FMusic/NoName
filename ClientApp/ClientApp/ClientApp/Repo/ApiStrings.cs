using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementApp.Repo
{
    class ApiStrings
    {
        public const string API_BASE = "40.68.47.205/api/";

        public const string USERS_BASE = "Users/";
        public const string USER_BY_USERNAME = USERS_BASE + "?username=";
        public const string LOGIN = USERS_BASE + "Login";
        public const string ITEMS = "Items";
        public const string ORDERS_BY_PLACE = "Orders?placeId=";
        public const string CATEGORIES = "Categories";
        public const string ORDER_ITEMS_BASE = "OrderItems";
        public const string ORDER_BASE = "Orders";
        public const string PLACES = "Places";


        public static string CATEGORIES_BY_PLACE(int placeId) => $"Categories?placeId={placeId}";
        public static string EMPLOYEES(int placeId) => $"Users?placeId={placeId}";
        public static string ORDERS_BY_PLACE_DATE(int placeId, string date) => $"Orders?placeId={placeId}&date={date}";
        internal static string ORDERITEMS_FOR_ORDER(int id) => $"OrderItems?orderId={id}";
        internal static string REVENUE_BY_PLACE_DATE(int placeId, string date) => $"Revenue?placeId={placeId}&month={date}";
    }
}
