using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bombardier.WPF.IServices;
using Bombardier.WPF.MockServices;
using Bombardier.WPF.Models;
using System.Linq;

namespace Bombardier.WPF.UnitTests
{
    [TestClass]
    public class NetworkServiceUnitTest
    {
        private INetworkService networkService;

        [TestInitialize]
        public void Init()
        {
            networkService = new MockNetworkService();
        }


        [TestMethod]
        public void GetTest()
        {
            // Przygotowanie

            int networkId = 1;


            // Akcja
            Network network = networkService.Get(networkId);

            // Sprawdzenie 

            Assert.IsNotNull(network);

            Assert.AreEqual(networkId, network.Id);

            Assert.IsNotNull(network.Items);

            Assert.IsTrue(network.Items.Any());

        }

        [TestMethod]
        public void GetTest2()
        {
            // Przygotowanie

            int networkId = 1;

            // Akcja
            Network network = networkService.Get(networkId);

            // Sprawdzenie 

            Assert.IsNotNull(network);

            Assert.AreEqual(networkId, network.Id);

            Assert.IsNotNull(network.Items);

            Assert.IsTrue(network.Items.Any());

        }
    }
}
