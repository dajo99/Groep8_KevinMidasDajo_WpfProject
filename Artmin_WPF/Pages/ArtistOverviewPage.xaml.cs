using Artmin_DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ArtistOverviewPage.xaml
    /// </summary>
    public partial class ArtistOverviewPage : Page
    {
        //Property voor artiestenlijst
        public ObservableCollection<Artist> Artists { get; set; }

        public ArtistOverviewPage(Event e)
        {
            InitializeComponent();

            //lijst van artiesten opvullen
            List<Artist> lijst = DatabaseOperations.GetArtists(e);

            //lijst maken die met binding update
            Artists = new ObservableCollection<Artist>(lijst);

            //Subtitle updaten met eventnaam
            cntrlHeader.Subtitle = e.Name;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var artist = (Artist)((FrameworkElement)sender).DataContext;

            int ok = DatabaseOperations.DeleteArtist(artist);
            if (ok > 0)
            {
                Artists.Remove(artist);
            }
            else
            {
                MessageBox.Show("De artiest is niet verwijderd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var artist = (Artist)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new ManageArtistPage(artist));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageArtistPage());
        }
    }
}
