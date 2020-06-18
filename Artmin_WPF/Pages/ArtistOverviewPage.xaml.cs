using Artmin_DAL;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
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
/*----------------------------
 * AUTHOR: Kevin Beliën
 * --------------------------*/
namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ArtistOverviewPage.xaml
    /// </summary>
    public partial class ArtistOverviewPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Property voor artiestenlijst
        private ObservableCollection<Artist> artists;
        public ObservableCollection<Artist> Artists
        {
            get
            {
                return artists;
            }
            set
            {
                artists = value;
                NotifyPropertyChanged();
            }
        }

        public Event Evt { get; set; }

        public ArtistOverviewPage(Event e)
        {
            InitializeComponent();

            Evt = e;

            lbArtists.Items.Refresh();
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var artist = (Artist)((FrameworkElement)sender).DataContext;

            var ret = (bool)await DialogHost.Show(new ConfirmDialog("Remove Artist " + artist.Name + "?"));

            if (ret == true)
            {
                if (DatabaseOperations.DeleteArtist(artist) > 0)
                {
                    Artists.Remove(artist);
                    ToggleVisibility();
                }
                else
                {
                    await DialogHost.Show(new ErrorDialog("De artiest is niet verwijderd!"));
                }
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            cntrlHeader.Subtitle = Evt.Name;

            //lijst van artiesten opvullen
            List<Artist> lijst = DatabaseOperations.GetArtists(Evt);

            //lijst maken die met binding update
            Artists = new ObservableCollection<Artist>(lijst);

            ToggleVisibility();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var artist = (Artist)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new ArtistEditPage(artist, Evt));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistEditPage(Evt));


        }

        private void ToggleVisibility()
        {
            if (Artists.Count == 0)
            {
                lbArtists.Visibility = Visibility.Hidden;
                lblNoArtist.Visibility = Visibility.Visible;
            }
            else
            {
                lbArtists.Visibility = Visibility.Visible;
                lblNoArtist.Visibility = Visibility.Hidden;
            }
        }

    }
}
