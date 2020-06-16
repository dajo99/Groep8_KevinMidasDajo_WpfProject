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
        Note note;
        public NotesEditPage(Note n, string subtitle)
        {
            note = n;
            InitializeComponent();
            Subtitle.Text = subtitle;
            Header.Subtitle = subtitle;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TitleNote.Text = note.Title;
            DescriptionNote.Text = note.Description;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
