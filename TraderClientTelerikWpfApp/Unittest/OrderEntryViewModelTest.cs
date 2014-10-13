using System;
using DomainModel.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraderClientTelerikWpfApp.OrderEntry.ViewModel;

namespace Unittest
{
    [TestClass]
    public class OrderEntryViewModelTest
    {
        [TestMethod]
        public void IsPriceVisible_TypeIsMarket_ReturnFalse()
        {
            //Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();

            //act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Market);
            
            //Assert
            Assert.IsFalse(vm.IsPriceVisible);
        }
        [TestMethod]
        public void IsYieldVisible_TypeIsMarket_ReturnFalse()
        {
            //Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();
            
            //Act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Market);
            
            //Assert
            Assert.IsFalse(vm.IsYieldVisible);
        }
        [TestMethod]
        public void IsPriceVisible_TypeIsLimitANDinstrumentIsPrice_ReturnTrue()
        {
            // Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();
            
            // Act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Limit);
            AddNewChosenInstrumentPriceQuated(vm);
            
            // Assert
            Assert.IsTrue(vm.IsPriceVisible);
        }
        
        [TestMethod]
        public void IsYieldVisible_TypeIsLimitANDInstrumentIsYield_ReturnTrue()
        {
            //Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();
            
            //act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Limit);
            AddNewChosenInstrumentYieldQuated(vm);
            
            //assert
            Assert.IsTrue(vm.IsYieldVisible);
        }
        [TestMethod]
        public void IsPriceVisible_TypeIsLimitANDinstrumentIsYield_ReturnFalse()
        {
            //Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();
            
            // Act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Market);
            AddNewChosenInstrumentYieldQuated(vm);

            //Assert
            Assert.IsFalse(vm.IsPriceVisible);

        }
        [TestMethod]
        public void IsYieldVisible_TypeIsLimitANDInstrumentIsPrice_ReturnFalse()
        {
            // Arrange
            OrderEntryViewModel vm = new OrderEntryViewModel();

            // Act
            vm.ChosenOrderType = new OrderType(OrderType.OrderTypeEnum.Limit);
            AddNewChosenInstrumentPriceQuated(vm);
            
            //Assert
            Assert.IsFalse(vm.IsYieldVisible);
        }

        // Helper functions

        private static void AddNewChosenInstrumentPriceQuated(OrderEntryViewModel vm)
        {
            Instrument instrument = Instrument.GetNullObject();
            instrument.QuotedIn = Instrument.QuotedInEnum.Price;
            vm.ChosenInstrument = instrument;
        }
        private static void AddNewChosenInstrumentYieldQuated(OrderEntryViewModel vm)
        {
            Instrument instrument = Instrument.GetNullObject();
            instrument.QuotedIn = Instrument.QuotedInEnum.Yield;
            vm.ChosenInstrument = instrument;
        }
    }
}
