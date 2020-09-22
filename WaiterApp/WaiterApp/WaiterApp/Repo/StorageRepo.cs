using ManagementApp.Model.App;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApp.Repo
{
    public class StorageRepo
    {
        public static List<ItemList> getItems()
        {
            List<Category> categories = RestCom<List<Category>>.CommunicateGet(ApiStrings.CATEGORIES);
            List<Item> items = RestCom<List<Item>>.CommunicateGet(ApiStrings.ITEMS);
            List<ItemList> itemList = new List<ItemList>();
            foreach (Category category in categories)
            {
                var i = new ItemList(category);
                foreach (var i1 in items.Where(x => x.CategoryId == category.Id))
                {
                    i.Add(i1);
                }
            }
            var list = new List<ItemList>();
            foreach (var item in itemList)
            {
                list.Add(item);
            }
            return list;
        }

        internal static List<Category> getAllStorage(int placeid)
        {
            List<Category> categories = RestCom<List<Category>>.CommunicateGet(ApiStrings.CATEGORIES_BY_PLACE(placeid));
            List<Item> items = RestCom<List<Item>>.CommunicateGet(ApiStrings.ITEMS);
            foreach (var cat in categories)
            {
                cat.Items = new List<Item>();
                var its = items.Where(x => x.CategoryId == cat.Id).ToList();
                foreach (var i in its)
                {
                    cat.Items.Add(i);
                }
            }
            return categories;
        }

        internal static IList<Item> getAllItems(int placeId)
        {
            List<Item> items = new List<Item>();

            var cats = getAllStorage(placeId);
            foreach (var cat in cats)
            {
                foreach (var item in cat.Items)
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }
}
