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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ManageArtistPage.xaml
    /// </summary>
    public partial class ManageArtistPage : Page
    {
        Artist ViewModel;
        Artist artist;
        Event evt;
       

        private static readonly Dictionary<string, string> CountryCodes = new Dictionary<string, string>
        {
            { "+32",  "/Images/belgium-flag-icon-16.png" },
            { "+31", "/Images/netherlands-flag-icon-16.png"},
            { "+33", "/Images/france-flag-icon-16.png"},
            { "+49", "/Images/germany-flag-icon-16.png"},
            { "+44", "/Images/united-kingdom-flag-icon-16.png"}  
        };

        //Constructors page
        public ManageArtistPage(Artist a, Event e)
        {
            InitializeComponent();
            artist = a;
            ViewModel = new Artist(a);
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
            cmbPhone.ItemsSource = CountryCodes;
            cmbPhone.SelectedIndex = 0;

            

            if (artist != null)
            {
                cntrlHeader.Title = artist.Name;
                cntrlHeader.Subtitle = "EDIT";
                txtName.Text = artist.Name;
                txtMail.Text = artist.Email;
                txtPhone.Text = artist.Phone.Substring(3);
                txtCard.Text = artist.BankAccountNo;
                cmbPhone.SelectedItem = artist.Phone.Substring(0, 3);
                string phone = artist.Phone.Substring(0,3);
                int termIndex = Array.IndexOf(CountryCodes.Keys.ToArray(), phone);
                cmbPhone.SelectedIndex = termIndex;
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
                EditArtist();
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
            ViewModel.Phone = CountryCodes.ElementAt(cmbPhone.SelectedIndex).Key + Regex.Replace(txtPhone.Text, @"[^0-9]+", "");
            artist.Email = txtMail.Text;
            artist.BankAccountNo = txtCard.Text;
            artist.EventID = evt.EventID;

            if (artist.IsGeldig())
            {
                if (DatabaseOperations.AddArtist(artist) > 0)
                {
                    NavigationService.Navigate(new ArtistOverviewPage(evt));
                }
                else
                {
                    await DialogHost.Show(new ErrorDialog("Artiest is niet toegevoegd!"));
                }
            }
            else
            {
                await DialogHost.Show(new ErrorDialog(artist.Error));
            }
        }

        private async void EditArtist() 
        {
            ViewModel.Name = txtName.Text;
            ViewModel.Phone = CountryCodes.ElementAt(cmbPhone.SelectedIndex).Key + Regex.Replace(txtPhone.Text, @"[^0-9]+", "");
            ViewModel.Email = txtMail.Text;
            ViewModel.BankAccountNo = txtCard.Text;
            ViewModel.EventID = evt.EventID;

            if (ViewModel.IsGeldig())
            {
                if (DatabaseOperations.UpdateArtist(ViewModel) > 0)
                {
                    artist.copyFrom(ViewModel);

                    NavigationService.GoBack();
                }
                else
                {
                    await DialogHost.Show(new ErrorDialog("Artiest is niet gewijzigd!"));
                }
            }
            else
            {
                await DialogHost.Show(new ErrorDialog(artist.Error));
            }
        }
    }
}
