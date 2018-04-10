using System;

namespace PapuMart.Entities
{
    public class Item
    {
      public Int64 Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public int Quantity { get; set; }
      public int ItemType { get; set; }
      public int Price { get; set; }
      public int discount { get; set; }
    }
}
