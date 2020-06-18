using Artmin_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ManageArtistPage.xaml
    /// </summary>
    public partial class ManageArtistPage : Page
    {
        //read-only Properties
        Artist ViewModel { get; }
        Artist Artist { get; }
        Event Evt { get; }


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
            Artist = a;
            ViewModel = new Artist(a);
            Evt = e;
        }
        public ManageArtistPage(Event e)
        {
            InitializeComponent();
            Artist = null;
            Evt = e;
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Combobox linken aan dictionary (2 waardes in 1 listitem)
            cmbPhone.ItemsSource = CountryCodes;
            
            if (Artist != null)
            {
                //Opvullen velden
                cntrlHeader.Title = Artist.Name;
                cntrlHeader.Subtitle = "EDIT";
                txtName.Text = Artist.Name;
                txtMail.Text = Artist.Email;
                txtPhone.Text = Artist.Phone.Substring(3);
                txtCard.Text = Artist.BankAccountNo;
                cmbPhone.SelectedItem = Artist.Phone.Substring(0, 3);

                // telefoonnummer opvullen d.m.v de index van landcode in de dictionary
                string phone = Artist.Phone.Substring(0, 3);
                int termIndex = Array.IndexOf(CountryCodes.Keys.ToArray(), phone);
                cmbPhone.SelectedIndex = termIndex;
            }
            else
            {
                cntrlHeader.Title = "New Artist";
                cntrlHeader.Subtitle = "SETUP";
                cmbPhone.SelectedIndex = 0;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Artist != null)
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

            FillingArtist(artist);

            if (artist.IsGeldig())
            {
                //Zorgen dat Nummer overzichtelijk in database komt en het zo teruggehaald kan worden
                for (int i = 4; i < artist.BankAccountNo.Length; i += 5)
                {
                    artist.BankAccountNo = artist.BankAccountNo.Insert(i, " ");
                }

                if (DatabaseOperations.AddArtist(artist) > 0)
                {
                    NavigationService.GoBack();
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
            FillingArtist(ViewModel);

            if (ViewModel.IsGeldig())
            {
                //Zorgen dat Nummer overzichtelijk in database komt en het zo teruggehaald kan worden
                for (int i = 4; i < ViewModel.BankAccountNo.Length; i+=5)
                {
                    ViewModel.BankAccountNo = ViewModel.BankAccountNo.Insert(i, " ");
                }

                if (DatabaseOperations.UpdateArtist(ViewModel) > 0)
                {
                    //Zorgen dat artiest terug geupdate wordt 
                    Artist.CopyFrom(ViewModel);

                    NavigationService.GoBack();
                }
                else
                {
                    await DialogHost.Show(new ErrorDialog("Artiest is niet gewijzigd!"));
                }
            }
            else
            {
                await DialogHost.Show(new ErrorDialog(ViewModel.Error));
            }
        }
        private void FillingArtist(Artist a)
        {
            a.Name = txtName.Text;
            //Samenstellen telefoonnummer en verwijderen van alle tekens behalve de cijfers
            a.Phone = CountryCodes.ElementAt(cmbPhone.SelectedIndex).Key + Regex.Replace(txtPhone.Text, @"[^0-9]", "");
            a.Email = txtMail.Text.Substring(0, txtMail.Text.IndexOf('@') + 1)
                    + txtMail.Text.Substring(txtMail.Text.IndexOf('@') + 1).ToLower();
            //verwijderen van spaties of andere tekens zoals koppeltekens die gebruikt werden om iban-nummers af te scheiden
            a.BankAccountNo = Regex.Replace(txtCard.Text, @"[^a-zA-Z0-9]", "");
            a.EventID = Evt.EventID;
        }
    }
}
