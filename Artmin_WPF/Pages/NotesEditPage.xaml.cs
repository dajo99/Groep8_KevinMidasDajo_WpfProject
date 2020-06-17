using Artmin_DAL;
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
    /// Interaction logic for NotesEditPage.xaml
    /// </summary>
    public partial class NotesEditPage : Page
    {
        bool newNote = false;
        Note note;
        Note NewNote = new Note();
        Event eve;
        List<Note> notes = new List<Note>();
        public NotesEditPage(Note n, Event evt, string subtitle)
        {
            eve = evt;
            note = n;
            InitializeComponent();
            Header.Title = this.Title;
            Header.Subtitle = subtitle;
        }

        public NotesEditPage(Event evt)
        {
            InitializeComponent();
            NewNote = new Note();
            NewNote.EventID = evt.EventID;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (note == null)
            {
                Header.Title = "New Note";
                Header.Subtitle = "";
                newNote = true;
            }
            else
            {
                TitleNote.Text = note.Title;
                DescriptionNote.Text = note.Description;
            }
        }
        private string Valideer(string name)
        {
            if (name == "Title" && TitleNote.Text == "")
            {
                return "Er is geen titel!" + Environment.NewLine;
            }

            if (name == "Description" && DescriptionNote.Text == "")
            {
                return "Er is geen omschrijving!" + Environment.NewLine;
            }

            
            return "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Title");
            foutmelding += Valideer("Description");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                if (newNote != true)
                {
                    note.Title = TitleNote.Text;
                    note.Description = DescriptionNote.Text;

                    if (note.IsGeldig())
                    {
                        
                        
                            int ok = DatabaseOperations.AanpassenNote(note);
                            if (ok > 0)
                            {

                                MessageBox.Show("Notitie is opgeslagen!", "Gelukt!", MessageBoxButton.OK, MessageBoxImage.None);


                                NavigationService.GoBack();

                            }
                            else
                            {
                                MessageBox.Show("Notitie is niet opgeslagen!", "Mislukt!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                        
                    }
                    else
                    {
                        MessageBox.Show(note.Error, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    
                    NewNote.Title = TitleNote.Text;
                    NewNote.Description = DescriptionNote.Text;
                    if (NewNote.IsGeldig())
                    {
                      
                            int ok = DatabaseOperations.AddNote(NewNote);
                            if (ok > 0)
                            {
                                NavigationService.GoBack();
                            

                            }
                            else
                            {
                                MessageBox.Show("Notitie is niet opgeslagen!", "Mislukt!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        

                    }
                    else
                    {
                        MessageBox.Show(note.Error, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                

                

            }
            else
            {
                MessageBox.Show(foutmelding, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
