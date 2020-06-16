using Artmin_DAL;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new ArtistOverviewPage(evt));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventEditPage());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new EventEditPage(evt));
        }

        private async void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            var ret = await DialogHost.Show(new ConfirmDialog("Remove event " + evt.Name + "?"));

            if (ret is bool b && b == true && DatabaseOperations.DeleteEvent(evt) > 0)
            {
                Events.Remove(evt);
            }
        }
    }
}
