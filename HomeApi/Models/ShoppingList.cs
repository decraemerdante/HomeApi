using HomeApi.DataAccessLayer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Models
{
    public class ShoppingList
    {     
        public Dictionary<string, List<ShoppingItem>> Items {get;set;}       

        public ShoppingList(IEnumerable<ShoppingCategory> categories, IEnumerable<ShoppingItem> products)
        {
            Items = new Dictionary<string, List<ShoppingItem>>();

            foreach(var category in categories)
            {
                var productForCategory = products.Where(m => m.CategoryId == category.Id).ToList();

                if (!Items.ContainsKey(category.Name))
                {
                    Items.Add(category.Name, productForCategory);
                }
                else
                {
                    Items[category.Name] =  productForCategory;
                }
            }           
        }
    }
}
