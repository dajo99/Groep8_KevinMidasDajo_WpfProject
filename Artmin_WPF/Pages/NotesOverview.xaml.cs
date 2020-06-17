using Artmin_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for NotesOverview.xaml
    /// </summary>
    public partial class NotesOverview : Page
    {
        public List<Note> Notes { get; set; }
        Event ev;
        public NotesOverview(Event e)
        {
            DataContext = this;
            Notes = DatabaseOperations.GetNotes(e.EventID);
            InitializeComponent();
            ev = e;
            Header.Title = this.Title;
            Header.Subtitle = e.Name;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var note = (Note)((FrameworkElement)sender).DataContext;

            int ok = DatabaseOperations.DeleteNote(note);
            if (ok > 0)
            {
                Notes.Remove(note);
                ListNotes.Items.Refresh();
                
            }
            else
            {
                MessageBox.Show("De notitie is niet verwijderd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var note = (Note)((FrameworkElement)sender).DataContext;

            NavigationService.Navigate(new NotesEditPage(note, ev, Header.Subtitle));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotesEditPage(ev));
        }
    }
}
