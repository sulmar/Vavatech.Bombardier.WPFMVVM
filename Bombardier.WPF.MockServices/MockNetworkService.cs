using Bombardier.WPF.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bombardier.WPF.Models;

namespace Bombardier.WPF.MockServices
{
    public class MockNetworkService : INetworkService
    {
        private Network network;

        public MockNetworkService()
        {
            network = new Network
            {
                Name = "Sieć 1",
                Items = new List<Item>
                {
                    new ShuntingSignal { Id = 1, Name = "Signal 1"},
                    new RLSignal { Id = 2, Name = "Signal 2"},
                    new LevelCrossing { Id = 3, Name = "Przejazd kolejowy 1"}
                }

            };
        }

        public Network Get(int id)
        {
            return network;
        }
    }
}
