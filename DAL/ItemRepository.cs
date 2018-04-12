using PapuMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PapuMart.DAL
{
    public class ItemRepository: IItemRepository
    {
        public List<Item> items { get; set; }

        public ItemRepository()
        {
            items = new List<Item>
            {
             new Item { Id = 1,ItemType=1,Name="Maggie CUP",Description="Maggie Cup used for Maggie noodles" },
             new Item { Id = 1,ItemType=1,Name="Tea CUP",Description="Tea Cup" },
             new Item { Id = 1,ItemType=1,Name="Mango Juice",Description="Mango Juice" },
             new Item { Id = 1,ItemType=1,Name="Rice",Description="Rice" }
            };
                        
        }

        public List<Item> GetAllItem()
        {

            return items;
        }
        public Item AddItem(Item item)
        {
            items.Add(item);
            return item;
        }
        public Item UpdateItem(Item item)
        {
            var selectedItem = items.Where(i => i.Id == item.Id).FirstOrDefault();
            if(selectedItem!=null)
            {
                selectedItem.Name = item.Name;
                selectedItem.Quantity = item.Quantity;
                selectedItem.Price = item.Price;
                selectedItem.ItemType = item.ItemType;
            }

            return selectedItem;

        }
        public bool DeleteItem(int id)
        {
            var selectedItem = items.Where(i => i.Id == id).FirstOrDefault();
            items.Remove(selectedItem);
            return true;
        }
    }

    public interface IItemRepository
    {
         List<Item> GetAllItem();
         Item AddItem(Item item);
         Item UpdateItem(Item item);
        bool DeleteItem(int id);

    }
}
