using Bombardier.WPF.IServices;
using Bombardier.WPF.MockServices;
using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.ViewModels
{
    public class NetworkViewModel : BaseViewModel
    {
        public Network Network { get; set; }

        private readonly INetworkService networkService;

        public NetworkViewModel()
            : this(new MockNetworkService())
        {
        }

        public NetworkViewModel(INetworkService networkService)
        {
            this.networkService = networkService;

            Network = networkService.Get(1);
        }
    }
}
