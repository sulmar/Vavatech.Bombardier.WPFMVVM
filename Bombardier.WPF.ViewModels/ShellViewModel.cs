using Bombardier.WPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bombardier.WPF.ViewModels
{
    public class ShellViewModel : BaseViewModel
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
            SelectedViewModel = new NetworkViewModel();
        }


        private BaseViewModel _SelectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get
            {
                return _SelectedViewModel;
            }

            set
            {
                _SelectedViewModel = value;
                OnPropertyChanged();
            }

        }

        public ShellViewModel()
        {
            SelectedViewModel = new ConfigurationViewModel();
        }
    }
}
