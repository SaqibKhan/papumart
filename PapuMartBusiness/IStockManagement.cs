using PapuMart.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PapuMart.Business
{

    public interface IStockManagement
    {
        List<Item> GetAllItem();
        Item AddItem(Item item);
        Item UpdateItem(Item item);
        bool DeleteItem(int id);

    }
}
