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

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ManageArtistPage.xaml
    /// </summary>
    public partial class ManageArtistPage : Page
    {
        Artist artist;

        //Constructors page
        public ManageArtistPage(Artist a)
        {
            InitializeComponent();
            artist = a;
        }
        public ManageArtistPage()
        {
            InitializeComponent();
            artist = null;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool ok = ValidateInputs.CheckIban("GB94BARC10201530093459");
            if (ok ==true)
            {
                MessageBox.Show("Geldig iban");
            }
            
            if (artist != null)
            {

            }
            else
            {

            }
        }

        private void AddArtist()
        {

        }

        private void EditArtist() 
        { 

        }
    }
}
