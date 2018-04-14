using NSubstitute;
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
        private IStockManagement _stock;
        private IItemRepository _ItemRepository;
        List<Item> _itemsList;

        [SetUp]
        public void SetUp()
        {
           _itemsList = new List<Item>
            {
             new Item { Id = 1,ItemType=1,Name="Maggie CUP",Description="Maggie Cup used for Maggie noodles" },
             new Item { Id = 1,ItemType=1,Name="Tea CUP",Description="Tea Cup" },
             new Item { Id = 1,ItemType=1,Name="Mango Juice",Description="Mango Juice" },
             new Item { Id = 1,ItemType=1,Name="Rice",Description="Rice" }
            };
            

            _ItemRepository = Substitute.For<IItemRepository>();
            _stock = new StockMangement(_ItemRepository);
            _stock.GetAllItem().Returns(_itemsList);
           
        }

        [Test]
        public void GelAllItems_DAL_ReceiveCall()
        {
            // ACt
            var list = _stock.GetAllItem();
           
            // Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count , _itemsList.Count);

        }

        [Test]
        public void CreateItem_DAL_ReceiveCall()
        {
            // Arrange
            var item = new Item()
            {
                Id = 10213,
                Name = "TestItem",
                Description = "Item Description 01",
                Quantity = 9,
                ItemType = 1,
                Price = 100,
                discount = 5
            };
            _stock.AddItem(item).Returns(item);

            // ACt
           var tempItem= _stock.AddItem(item);
            var list = _stock.GetAllItem();
            
            // Assert
            _ItemRepository.Received(1).AddItem(Arg.Any<Item>());
            Assert.IsNotNull(item);
            Assert.AreEqual(tempItem.Id, item.Id);

        }

        [Test]
        public void UpdateItem__DAL_ReceiveCall()
        {
            // Arrange
            var item = new Item()
            {
                Id = 10213,
                Name = "TestItem",
                Description = "Item Description 01",
                Quantity = 9,
                ItemType = 1,
                Price = 100,
                discount = 5
            };
            _stock.UpdateItem(item).Returns(item);

            // ACt
            var tempItem = _stock.UpdateItem(item);
            var list = _stock.GetAllItem();

            // Assert
            _ItemRepository.Received(1).UpdateItem(Arg.Any<Item>());
            Assert.IsNotNull(item);
            Assert.AreEqual(tempItem.Id, item.Id);

        }

        [Test]
        public void DeleteItem__DAL_ReceiveCall()
        {
            // Arrange
            int ItemId = 10213;

            // ACt
            _stock.DeleteItem(ItemId);
            var list = _stock.GetAllItem();

            // Assert
            _ItemRepository.Received(1).DeleteItem(Arg.Any<int>());
           

        }
    }

    
}
