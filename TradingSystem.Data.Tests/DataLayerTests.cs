using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingSystem.Business.Bootstrapper;
using TradingSystem.Business.Entities;
using TradingSystem.Data.Contracts;
using System.ComponentModel.Composition;

namespace TradingSystem.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MefLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();
            IEnumerable<OrderRequest> orderRequests = repositoryTest.GetOrderRequests();

            Assert.IsTrue(orderRequests !=null);
        }
    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryTestClass(IOrderRequestRepository orderRequestRepository)
        {
            _orderRequestRepository = orderRequestRepository;
        }

        [Import] 
        IOrderRequestRepository _orderRequestRepository;

        public IEnumerable<OrderRequest> GetOrderRequests()
        {
            IEnumerable<OrderRequest> orderRequests = _orderRequestRepository.Get();

            return orderRequests;
        }
    }
}
