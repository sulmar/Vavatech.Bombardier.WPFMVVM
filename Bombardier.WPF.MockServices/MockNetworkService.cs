using Bombardier.WPF.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bombardier.WPF.Models;
using System.Collections.ObjectModel;
using System.Threading;

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
                    new Section { Id = 7, Name = "it301", State = SectionState.OutOfControl },
                    new Section { Id = 8, Name = "OT A", State = SectionState.Free },
                    new Section { Id = 9, Name = "OT B", State = SectionState.OutOfControl },
                    new StationSignal { Id = 2, Name = "C", Direction = Direction.Reverse },
                }
            };
        }


        public Task<Network> GetAsync(int id)
        {
            return Task.Run(()=>Get(id));
        }


        public Network Get(int id)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));

            return network;
        }
    }
}
