﻿using Bombardier.WPF.Common;
using Bombardier.WPF.IServices;
using Bombardier.WPF.MockServices;
using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bombardier.WPF.ViewModels
{
    public class NetworkViewModel : BaseViewModel
    {
        public Network Network { get; set; }


        private Item _SelectedItem;
        public Item SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value;

                OnPropertyChanged();

            }
        }

        public IEnumerable<SectionState> SectionStates { get; set; }

        #region CurrentMeasure

        private Measure _CurrentMeasure;
        public Measure CurrentMeasure
        {
            get { return _CurrentMeasure; }
            set
            {
                _CurrentMeasure = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ObservableCollection<Measure> Measures { get; set; }


        private readonly INetworkService networkService;
        private readonly ISensorsService sensorsService;

        public NetworkViewModel()
            : this(new MockNetworkService(), new MockSensorsService())
        {
        }

        public NetworkViewModel(INetworkService networkService, ISensorsService sensorsService)
        {
            this.networkService = networkService;
            this.sensorsService = sensorsService;

            Measures = new ObservableCollection<Measure>();

            

            SectionStates = Enum.GetValues(typeof(SectionState)).Cast<SectionState>();

            sensorsService.SensorChanged += SensorsService_SensorChanged;

        }

        private void SensorsService_SensorChanged(object sender, Measure e)
        {
            this.CurrentMeasure = e;


            DispatchService.Invoke(()=> Measures.Add(e));


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


        private ICommand loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(p => Load());
                }

                return loadCommand;
            }
        }

        private void Load()
        {
            var t1 = networkService.GetAsync(1);

            var t2 = networkService.GetAsync(1);

            var t3 = networkService.GetAsync(1);

            // Task.WaitAll()

        }

        private async void LoadAsync()
        {
            //networkService.GetAsync(1)
            //    .ContinueWith(t => Network = t.Result);

            Network = await networkService.GetAsync(1);


            Network = await networkService.GetAsync(2);
        }


        private ICommand _GetCommand;

        public ICommand GetCommand
        {
            get
            {
                if (_GetCommand == null)
                {
                    _GetCommand = new RelayCommand(p => Get());
                }

                return _GetCommand;
            }
        }

        public void Get1()

            // SELECT * FROM Items WHERE Typ = 'Section' AND State = 1 ORDER BY Name;
        {
            IList<Item> result = new List<Item>();

            var sections = this.Network.Items.OfType<Section>();

            foreach (var section in sections)
            {
                if (section.State == SectionState.Occupancy)
                {
                    result.Add(section);
                }
            }
        }

        public void Get2()
        {
            var query = this.Network.Items.OfType<Section>()
                .Where(section => section.State == SectionState.Occupancy)
                .Where(section => section.Id > 10)
                .OrderBy(section => section.Name)
                .Select(section => new { Nazwa = section.Name, Stan = section.State });


            var query2 = query.Where(x => x.Stan == SectionState.OutOfControl);
        }

        public void Get()
        {

            var occupancySections = from section in this.Network.Items.OfType<Section>()
                         where section.State == SectionState.Occupancy
                         orderby section.Name
                         select section;

            foreach (var item in occupancySections)
            {
                item.State = SectionState.Free;
            }

            //var freeSections = from section in this.Network.Items.OfType<Section>()
            //                        where section.State == SectionState.Free
            //                        orderby section.Name
            //                        select new { Nazwa = section.Name, Stan = section.State };

            //var fullSections = occupancySections.Union(freeSections);


            //var query = fullSections.Except(freeSections);
        }

    }
}
