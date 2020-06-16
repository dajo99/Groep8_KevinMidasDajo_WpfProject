using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for ArtistOverviewPage.xaml
    /// </summary>
    public partial class ArtistOverviewPage : Page, INotifyPropertyChanged
    {
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _sub = "Hello";
        public string Sub
        {
            get { return _sub; }
            set { _sub = value;
                NotifyPropertyChanged(); }
        } 

        public ArtistOverviewPage()
        {
            InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            Sub = "Hello";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
