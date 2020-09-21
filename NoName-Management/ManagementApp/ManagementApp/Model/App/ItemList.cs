using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementApp.Model.App
{
    public class ItemList : List<Item>
    {
        public string CategoryTitle { get; set; }
        public List<Item> Items => this;

        public ItemList(Category cat)
        {
            CategoryTitle = cat.Name;
        }
    }
}
