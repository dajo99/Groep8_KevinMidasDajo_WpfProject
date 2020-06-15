using Artmin_DAL;
using System;
using System.Collections.Generic;
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
        public EventsPage(Event evt)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Event evt = (Event)((Button)sender).DataContext;

            //var eventDetailsPage = new EventDetailsPage(evt);

            //NavigationService.Navigate(eventDetailsPage);
        }
    }
}
