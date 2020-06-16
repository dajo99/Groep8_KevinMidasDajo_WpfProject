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
    /// Interaction logic for NotesOverview.xaml
    /// </summary>
    public partial class NotesOverview : Page
    {
        public List<Note> Notes { get; set; }
        public NotesOverview(Event e)
        {
            DataContext = this;
            Notes = DatabaseOperations.GetNotes(e.EventID);
            InitializeComponent();
            Subtitle.Text = e.Name;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
