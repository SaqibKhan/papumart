using PapuMart.DAL;
using PapuMart.Entities;
using System;
using System.Collections.Generic;

namespace PapuMart.Business
{
    public class StockMangement : IStockManagement
    {
        public IItemRepository _itemRepository;
        public StockMangement(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> GetAllItem()
        {
            return _itemRepository.GetAllItem();
        }

        public Item AddItem(Item item)
        {
            return _itemRepository.AddItem(item);
        }

        public Item UpdateItem(Item item)
        {
            return _itemRepository.UpdateItem(item);
        }

        public bool DeleteItem(int id)
        {
            return _itemRepository.DeleteItem(id);
        }
        
    }

}
