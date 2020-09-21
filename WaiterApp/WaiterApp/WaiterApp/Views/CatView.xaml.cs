using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaiterApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatView : ContentPage
    {
        public List<Item> Items;
        private int quantity;
        private int orderId;
        private Item i;
        public CatView(Category c, Order o)
        {
            orderId = o.Id;
            InitializeComponent();
            Items = c.Items;
            BindingContext = this;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            i = e.Item as Item;
            quantity++;
            lblQuantity.Text = $"{i.Name} {quantity}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            OrderItem oi = new OrderItem
            {
                ItemId = i.Id,
                OrderId = orderId,
                Quantity = quantity,
                Price = i.Price * quantity
            };
            OrdersRepo.newOrderItem(oi);
        }
    }
}