using Bombardier.WPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bombardier.WPF.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {

        private ICommand _ShowNetworkCommand;

        public ICommand ShowNetworkCommand
        {
            get
            {
                if (_ShowNetworkCommand == null)
                {
                    _ShowNetworkCommand = new RelayCommand(p => ShowNetwork());
                }

                return _ShowNetworkCommand;
            }
        }

        private void ShowNetwork()
        {
            // TODO:

            //var networkView = new NetworkView();
            //networkView.Show();

        }

    }
}
