using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;
using TraderClientTelerikWpfApp.OrderEntry.ViewModel;
using FakeRepositories;
namespace TraderClientTelerikWpfApp.OrderEntry.View
{
    /// <summary>
    ///     Interaction logic for OrderEntry.xaml
    /// </summary>
    public partial class OrderEntry : Window
    {

        OrderEntryViewModel _vm;

        public OrderEntry()
        { 
            
            _vm = new OrderEntryViewModel();
            _vm.Init(new FakeInstrumentRepository());
            InitializeComponent();
            // direct initialisation for now - use ioc container..
            DataContext = _vm;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                // call business service for sending in order
            }
        }



        private bool Validate()
        {
            return true;
        }


        private void Input_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            Visibility oldValue = e.OldValue is Visibility ? (Visibility) e.NewValue : Visibility.Hidden;
            Nullable<bool> newValue = e.NewValue as Nullable<bool>;
            
            Control control = sender as Control;
            if (control == null || !control.IsLoaded)
                return;
           

            if (oldValue == Visibility.Collapsed || oldValue == Visibility.Hidden) 
            {
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = 1;
                da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                da.AutoReverse = false;
                control.BeginAnimation(OpacityProperty, da);
                return;
            }
        }

        // binding error with RadControl - use 
        private void TimeInForceDatePicker_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.ChosenExperieDate = ((RadCalendar) sender).SelectedDate.Value;
        }

    }
}

