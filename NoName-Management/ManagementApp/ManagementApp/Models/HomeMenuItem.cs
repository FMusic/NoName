using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ManagementApp.Models
{
    public enum MenuItemType
    {
        Today,
        Week,
        Storage
    }
    class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public String Title { get; set; }
    }
}
