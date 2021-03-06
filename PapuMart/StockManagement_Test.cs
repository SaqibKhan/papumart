﻿using NSubstitute;
using NUnit.Framework;
using PapuMart.Business;
using PapuMart.DAL;
using PapuMart.Entities;
using System.Collections.Generic;
using NSubstitute.Callbacks;

namespace PapuMart
{
    [TestFixture]
    public class StockManagement_Test
    {
        private StockMangement _stock;

        [SetUp]
        public void SetUp()
        {
            var itemsList = new List<Item>
            {
             new Item { Id = 1,ItemType=1,Name="Maggie CUP",Description="Maggie Cup used for Maggie noodles" },
             new Item { Id = 1,ItemType=1,Name="Tea CUP",Description="Tea Cup" },
             new Item { Id = 1,ItemType=1,Name="Mango Juice",Description="Mango Juice" },
             new Item { Id = 1,ItemType=1,Name="Rice",Description="Rice" }
            };
            _stock = new StockMangement();
            _stock.GetAllItem().Returns(itemsList);
        }

        [Test]
        public void CreateItem_ShouldAddOneIteminList()
        {
            // Arrange
            var list = _stock.GetAllItem();
            var ItemRepository = Substitute.For<IItemRepository>();
            // ACt
            var item = new Item
            {
                Id = 10213,
                Name = "TestItem",
                Description = "Item Description 01",
                Quantity = 9,
                ItemType = 1,
                Price = 100,
                discount = 5
            };
            _stock.AddItem(item);


            // Assert
            ItemRepository.Received(1).AddItem(item);
        }
                      
        
    }

    
}
