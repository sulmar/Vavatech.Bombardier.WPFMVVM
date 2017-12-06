using Bombardier.WPF.Common;
using Bombardier.WPF.IServices;
using Bombardier.WPF.MockServices;
using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bombardier.WPF.ViewModels
{
    public class NetworkViewModel : BaseViewModel
    {
        public Network Network { get; set; }

        public Item SelectedItem { get; set; }

        public IEnumerable<SectionState> SectionStates { get; set; }

        private readonly INetworkService networkService;

        public NetworkViewModel()
            : this(new MockNetworkService())
        {
        }

        public NetworkViewModel(INetworkService networkService)
        {
            this.networkService = networkService;

            Network = networkService.Get(1);

            SectionStates = Enum.GetValues(typeof(SectionState)).Cast<SectionState>();
        }

        #region ResetNetworkCommand

        private ICommand resetNetworkCommand;

        public ICommand ResetNetworkCommand
        {
            get
            {
                if (resetNetworkCommand==null)
                {
                    resetNetworkCommand = new RelayCommand(p => Reset(), p => CanReset());
                }

                return resetNetworkCommand;
            }
        }


        public void Reset()
        {
            foreach (var item in Network.Items.OfType<Section>())
            {
                item.State = SectionState.Free;
            }
        }

        public bool CanReset()
        {
            return Network.Items.OfType<Section>().Any(i=>i.State != SectionState.Free);
        }

        #endregion
    }
}
