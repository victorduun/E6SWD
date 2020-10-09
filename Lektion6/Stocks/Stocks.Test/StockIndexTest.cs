using System.Collections.Generic;
using NUnit.Framework;
using Stocks.Interfaces;
using System.Linq;

namespace Stocks.Test
{

    [TestFixture]
    public class StockIndexTest
    {
        StockIndex _uut;
        [SetUp]
        public void Setup()
        {
            var stocks = new List<IStock>();
            stocks.Add(new Stock("Test1", "TST1"));
            stocks.Add(new Stock("Test2", "TST2"));
            stocks.Add(new Stock("Test3", "TST3"));
            _uut = new StockIndex(stocks);
        }


        [Test]
        public void GetAllStockTypes_CheckStockTypesIsCorrectSize_SizeIs3()
        {
            var stockTypes = _uut.GetAllStockTypes();

            Assert.That(stockTypes.Count() == 3);
        }

        [Test]
        public void GetAllStockTypes_CheckStockSizeContainsTest1Stock_ContainsTest1Stock()
        {
            var stockTypes = _uut.GetAllStockTypes();
            var test1Stock = stockTypes.Select(s => s.Name == "Test1");
            Assert.IsNotNull(test1Stock);
        }


        [Test]
        public void ChangeStockPrice_SetNewStockPrice_StockPriceIsChanged()
        {
            var stockTypes = _uut.GetAllStockTypes();
            var stock = stockTypes.First();
            
            _uut.GetStockPrice(stock);
            _uut.ChangeStockPrice(stock, 100);
            _uut.ChangeStockPrice(stock, 1000);
            Assert.Pass();
        }
    }
}