using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bombardier.WPF.WPFDemo.Binding
{
    /// <summary>
    /// Interaction logic for DataBindingView.xaml
    /// </summary>
    public partial class DataBindingView : Window
    {
        public DataBindingView()
        {
            InitializeComponent();

            LevelCrossing levelCrossing = new LevelCrossing
            {
                Id = 1,
                Name = "Przejazd kolejowy nr 1",
            };

            LevelCrossing levelCrossing2 = new LevelCrossing
            {
                Id = 2,
                Name = "Przejazd kolejowy nr 2",
            };


            this.DataContext = levelCrossing;
        }
    }
}
