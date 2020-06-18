using Artmin_DAL;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EventEditPage.xaml
    /// </summary>
    public partial class EventEditPage : Page
    {
        private Event Event;
        public Event ViewModel { get; private set; }
        public EventEditPage(Event e = null)
        {
            Event = e;
            ViewModel = (e == null) ? new Event() : new Event(e);

            DataContext = this;
            InitializeComponent();

            if (e != null)
            {
                dpDate.SelectedDate = ViewModel.Date;
            }
            else
            {
                Title = "Create Event";
            }

            cbType.ItemsSource = DatabaseOperations.GetEventTypes();
            txtName.Focus();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsGeldig())
            {
                if (Event != null)
                {
                    Event.Name = ViewModel.Name;
                    Event.EventTypeID = ViewModel.EventTypeID;
                    Event.Date = ViewModel.Date;
                    Event.BeginTime = ViewModel.BeginTime;
                    Event.EndTime = ViewModel.EndTime;
                }

                if (!(Event != null && DatabaseOperations.UpdateEvent(Event) > 0)
                    && !(Event == null && DatabaseOperations.AddEvent(ViewModel) > 0))
                {
                    await DialogHost.Show(new ErrorDialog());
                    return;
                }

                NavigationService.GoBack();
            }
            else
            {
                await DialogHost.Show(new ErrorDialog(ViewModel.Error));
            }
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.Date = dpDate.SelectedDate is DateTime date ? date : DateTime.MinValue;
        }
    }
}
