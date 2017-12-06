using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Bombardier.WPF.WPFClient.Behaviors
{
    public class ButtonBehavior : Behavior<Button>
    {
        public Section SelectedSection
        {
            get { return (Section)GetValue(SectionProperty); }
            set { SetValue(SectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Section.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SectionProperty =
            DependencyProperty.Register("SelectedSection", typeof(Section), typeof(ButtonBehavior), new PropertyMetadata());


        protected override void OnAttached()
        {
            this.AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
        }

        private void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (SelectedSection!=null && SelectedSection.State == SectionState.Occupancy)
            {
                this.AssociatedObject.Background = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
