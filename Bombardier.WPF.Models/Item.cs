using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public abstract class Item : Base
    {
        #region Id

        private int _Id;
        public int Id
        {
            get { return _Id; }

            set
            {
                _Id = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        #endregion

        #region Name

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        #endregion

        public override string ToString() => Name;

        // interpolacja stringów
        public string FullName => $"{Id} {Name}";
    }
}
