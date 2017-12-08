using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public abstract class Item : Base, IDataErrorInfo
    {
        #region Id

        private int _Id;
        public int Id
        {
            get { return _Id; }

            set
            {
                if (!(value > 0 && value< 10))
                {
                    throw new ArgumentOutOfRangeException();
                }

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

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName=="Name")
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        return "Nazwa musi być wypełniona";
                    }
                }
                else
                if (columnName == "Id")
                {
                    if (!(this.Id>0 && this.Id < 10))
                    {
                        return "1..10";
                    }
                }

                return string.Empty;
            }
        }
    }
}
