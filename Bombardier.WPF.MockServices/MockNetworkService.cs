using Bombardier.WPF.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bombardier.WPF.Models;
using System.Collections.ObjectModel;

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
                Items = new ObservableCollection<Item>
                {
                    new StationSignal { Id = 1,  Name = "R", Direction = Direction.Nominal },
                    new Section { Id = 4, Name = "it309", State = SectionState.OutOfControl },
                    new Section { Id = 5, Name = "OT A", State = SectionState.Occupancy },
                    new Section { Id = 6, Name = "OT B", State = SectionState.OutOfControl },
                    new StationSignal { Id = 2, Name = "C", Direction = Direction.Reverse },
                }
            };
        }

        public Network Get(int id)
        {
            return network;
        }
    }
}
