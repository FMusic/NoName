using System;
using System.Collections.Generic;
using System.Text;

namespace NoName_Management.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Blab,
        gigiu
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
