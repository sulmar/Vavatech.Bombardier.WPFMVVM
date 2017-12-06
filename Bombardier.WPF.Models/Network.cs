using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public class Network : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private ObservableCollection<Item> _Items;
        public ObservableCollection<Item> Items
        {
            get { return _Items; }
            set {
                _Items = value;

                this.Items.CollectionChanged += Items_CollectionChanged;

                Subscribe(_Items);
            }
        }
            

        public int OccupancyCount
        {
            get
            {
                return Items
                    .OfType<Section>()
                    .Where(s=>s.State == SectionState.Occupancy)
                    .Count();
            }
        }

        public void Subscribe(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "State")
            {
                OnPropertyChanged(nameof(OccupancyCount));
            }
        }


        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Subscribe(e.NewItems.Cast<Item>());
            }
        }
    }
}
