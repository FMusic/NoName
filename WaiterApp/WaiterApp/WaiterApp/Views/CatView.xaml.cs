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
        public List<Item> Items { get; set; }
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
            quantity = 1;
            lblQuantity.Text = $"{i.Name} {quantity}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (quantity != 0)
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
            Navigation.PopAsync();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = $"{i.Name} {quantity}";
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (quantity > 1)
            quantity--;
            lblQuantity.Text = $"{i.Name} {quantity}";
        }
    }
}