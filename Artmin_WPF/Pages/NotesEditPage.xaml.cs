using Artmin_DAL;
using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
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

    //AUTHOR Dajo Vandoninck
    public partial class NotesEditPage : Page
    {
        bool newNote = false;
        readonly Note note;
        readonly Note NewNote = new Note();

        //constructor voor het opslaan een notitie 
        public NotesEditPage(Note n, string subtitle)
        {
            note = n;
            InitializeComponent();
            Header.Title = this.Title;
            Header.Subtitle = subtitle;
        }

        //constructor voor het toevoegen van een notitie 
        public NotesEditPage(Event evt)
        {
            InitializeComponent();
            NewNote = new Note
            {
                EventID = evt.EventID
            };
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

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Title");
            foutmelding += Valideer("Description");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                //Hier gaat men kijken of het al een bestaande notitie is of niet.
                if (newNote != true)
                {
                    note.Title = TitleNote.Text;
                    note.Description = DescriptionNote.Text;
                    note.creationdate = DateTime.Now;

                    if (note.IsValid())
                    {


                        int ok = DatabaseOperations.AanpassenNote(note);
                        if (ok > 0)
                        {
                            await DialogHost.Show(new ErrorDialog("Note has been saved!"));

                            NavigationService.GoBack();

                        }
                        else
                        {
                            await DialogHost.Show(new ErrorDialog("Note has not been saved!"));
                        }


                    }
                    else
                    {
                        await DialogHost.Show(new ErrorDialog(note.Error));
                        
                    }
                }
                else
                {

                    NewNote.Title = TitleNote.Text;
                    NewNote.Description = DescriptionNote.Text;
                    NewNote.creationdate = DateTime.Now;
                    if (NewNote.IsValid())
                    {

                        int ok = DatabaseOperations.AddNote(NewNote);
                        if (ok > 0)
                        {
                            await DialogHost.Show(new ErrorDialog("Note has been saved!"));
                            NavigationService.GoBack();


                        }
                        else
                        {

                            await DialogHost.Show(new ErrorDialog("Note has not been saved!"));
                        }


                    }
                    else
                    {
                        await DialogHost.Show(new ErrorDialog(NewNote.Error));
                    }
                }




            }
            else
            {
                await DialogHost.Show(new ErrorDialog(foutmelding));
            }
        }

    }
}
