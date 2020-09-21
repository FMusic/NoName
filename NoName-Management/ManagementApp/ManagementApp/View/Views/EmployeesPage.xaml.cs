using ManagementApp.Repo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ManagementApp.View.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        public IList<User> Employees { get; set; }
        public int place { get; set; }
        private int selectedId = 0;
        public EmployeesPage(User u)
        {
            InitializeComponent();
            Employees = UserRepo.GetEmployees(u);
            place = u.PlaceId;
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            inputEmpl.IsVisible = true;
            selectedId = 0;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            inputEmpl.IsVisible = false;
            User u = new User()
            {
                FirstName = fname.Text,
                LastName = sname.Text,
                Email = email.Text,
                Address = addr.Text,
                Username = un.Text,
                Password = pwd.Text,
                PlaceId = place,
                UserEnum = UserEnum.Employee
            };
            if(selectedId == 0)
            {
                UserRepo.NewEmpl(u);
            }
            else
            {
                u.Id = selectedId;
                UserRepo.UpdateEmpl(u);
            }
            Employees = UserRepo.GetEmployees(u);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            User u = e.Item as User;
            PopulateAndShow(u);

        }

        private void PopulateAndShow(User u)
        {
            fname.Text = u.FirstName;
            sname.Text = u.LastName;
            email.Text = u.Email;
            addr.Text = u.Address;
            un.Text = u.Username;
            pwd.Text = u.Password;
            selectedId = u.Id;
            inputEmpl.IsVisible = true;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User u = e.SelectedItem as User;
            PopulateAndShow(u);

        }
    }
}