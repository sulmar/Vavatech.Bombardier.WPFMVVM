using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public class Section : Item
    {
        private SectionState state;
        public SectionState State
        {
            get { return state; }
            set
            {
                state = value;

                OnPropertyChanged();
            }
        }
    }
}
