using ManagementApp.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WaiterApp.Model.App;

namespace ManagementApp.Repo
{
    class OrdersRepo
    {

        public static IList<Order> getTodayOrders(int placeId)
        {
            var date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            return RestCom<IList<Order>>.CommunicateGet(ApiStrings.ORDERS_BY_PLACE_DATE(placeId, date));
        }

        internal static IList<Revenue> getMonthRev(int placeId)
        {
            var date = DateTime.Today.Date.ToString("yyyy-MM-01");
            return RestCom<IList<Revenue>>.CommunicateGet(ApiStrings.REVENUE_BY_PLACE_DATE(placeId, date));
        }

        internal static IList<OrderViewItem> GetViewItemsForOrder(Order order)
        {
            List<OrderViewItem> orderViewItems = new List<OrderViewItem>();
            IList<OrderItem> orderItems = RestCom<IList<OrderItem>>.CommunicateGet(ApiStrings.ORDERITEMS_FOR_ORDER(order.Id));
            IList<Item> items = StorageRepo.getAllItems(order.PlaceId);
            foreach (var orderItem in orderItems)
            {
                var i = items.Where(x => x.Id == orderItem.ItemId).FirstOrDefault();
                OrderViewItem ovi = new OrderViewItem
                {
                    Name = i.Name,
                    Quantity = orderItem.Quantity,
                    Price = "" + orderItem.Quantity * i.Price
                };
                orderViewItems.Add(ovi);
            }
            return orderViewItems;
        }

        internal static int UpdateOrder(Order order)
        {
            return RestCom<Order>.CommunicatePut(ApiStrings.ORDER_BASE, order);
        }

        internal static IList<OrderItem> GetItemsForOrder(Order order)
        {
            return RestCom<IList<OrderItem>>.CommunicateGet(ApiStrings.ORDERITEMS_FOR_ORDER(order.Id));
        }

        internal static int newOrderItem(OrderItem oi)
        {
            return RestCom<OrderItem>.CommunicatePost(oi, ApiStrings.ORDER_ITEMS_BASE);
        }

        public static Order newOrder(int placeId, string tblNumber, int userid)
        {
            Order o = new Order
            {
                DateTime = DateTime.Now,
                Charged = false,
                PlaceId = placeId,
                TableNumber = tblNumber,
                TotalPrice = 0,
                UserId = userid
            };
            int a = RestCom<Order>.CommunicatePost(o, ApiStrings.ORDER_BASE);
            o.Id = a;
            return o;
        }
    }
}
