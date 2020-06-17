using Artmin_DAL;
using Artmin_WPF.Controls;
using System;
using System.Collections.Generic;
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
using IbanNet;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ManageArtistPage.xaml
    /// </summary>
    public partial class ManageArtistPage : Page
    {
        Artist artist;
        Event evt;

        //Constructors page
        public ManageArtistPage(Artist a, Event e)
        {
            InitializeComponent();
            artist = a;
            evt = e;
        }
        public ManageArtistPage(Event e)
        {
            InitializeComponent();
            artist = null;
            evt = e;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (artist != null)
            {
                cntrlHeader.Title = artist.Name;
                cntrlHeader.Subtitle = "EDIT";
                txtName.Text = artist.Name;
                txtMail.Text = artist.Email;
                txtPhone.Text = artist.Phone;
                txtCard.Text = artist.BankAccountNo;
                
            }
            else
            {
                cntrlHeader.Title = "New Artist";
                cntrlHeader.Subtitle = "SETUP";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (artist != null)
            {

            }
            else
            {
                AddArtist();
            }
        }

        private async void AddArtist()
        {
            //aanmaken en opvullen nieuwe artiest
            Artist artist = new Artist();
            artist.Name = txtName.Text;
            artist.Phone = txtPhone.Text;
            artist.Email = txtMail.Text;
            artist.BankAccountNo = txtCard.Text;
            artist.EventID = evt.EventID;

            if (artist.IsGeldig())
            {
                int ok = DatabaseOperations.AddArtist(artist);
                if (ok > 0)
                {
                    NavigationService.Navigate(new ArtistOverviewPage(evt));
                }
                else
                {
                    await DialogHost.Show("Artiest is niet toegevoegd!");
                }
            }
            else
            {
                await DialogHost.Show(new ErrorDialog(artist.Error));
            }
        }

        private void EditArtist() 
        { 

        }
    }
}
