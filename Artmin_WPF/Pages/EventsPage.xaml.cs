using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Artmin_DAL;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public ObservableCollection<Event> Events { get; set; }
        public EventsPage()
        {
            DataContext = this;
            Events = new ObservableCollection<Event>(DatabaseOperations.GetEvents());
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventEditPage());
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new EventDetailsPage(evt));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new EventEditPage(evt));
        }

        private async void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            var ret = (bool)await DialogHost.Show(new ConfirmDialog("Remove event " + evt.Name + "?"));

            if (ret == true && DatabaseOperations.DeleteEvent(evt) > 0)
            {
                Events.Remove(evt);
            }
        }
    }
}
