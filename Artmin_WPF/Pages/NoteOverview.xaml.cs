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
    /// Interaction logic for NoteOverview.xaml
    /// </summary>
    public partial class NoteOverview : Page
    {
        public List<Note> Notes { get; set; }
        public NoteOverview()
        {
            DataContext = this;
            Notes = DatabaseOperations.GetNotes(1);
            InitializeComponent();
        }

        
    }
}
