using Artmin_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EventDetailsPage.xaml
    /// Author: Midas
    /// </summary>
    public partial class EventDetailsPage : Page
    {
        public Event Event { get; private set; }
        public EventDetailsPage(Event e)
        {
            Event = e;
            DataContext = this;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            runNotesCount.Text = DatabaseOperations.CountNotes(Event).ToString();
            runArtistsCount.Text = DatabaseOperations.CountArtists(Event).ToString();
        }

        private void NotesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotesOverview(Event));
        }

        private void TodoButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LocationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArtistsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistOverviewPage(Event));
        }
    }
}
