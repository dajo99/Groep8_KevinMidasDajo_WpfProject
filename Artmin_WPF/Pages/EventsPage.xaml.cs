using Artmin_DAL;
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
        public List<Event> Events { get; set; }
        public EventsPage()
        {
            DataContext = this;
            Events = DatabaseOperations.GetEvents();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var evt = (Event)((FrameworkElement)sender).DataContext;

            //MessageBox.Show("EventID: " + evt.EventID);

            NavigationService.Navigate(new ArtistOverviewPage(evt));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add button clicked :)");
        }
    }
}
