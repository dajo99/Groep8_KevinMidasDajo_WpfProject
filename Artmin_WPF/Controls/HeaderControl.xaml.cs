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

namespace Artmin_WPF.Controls
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        public string Subtitle
        {
            get
            {
                return (string)GetValue(SubtitleProperty);
            }
            set
            {
                SetValue(SubtitleProperty, value);
            }
        }

        public string BackButtonText
        {
            get
            {
                return (string)GetValue(BackButtonTextProperty);
            }
            set
            {
                SetValue(BackButtonTextProperty, value);
                NotifyPropertyChanged();
            }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        private static readonly DependencyProperty BackButtonTextProperty =
            DependencyProperty.Register("BackButtonText", typeof(string), typeof(HeaderControl), new PropertyMetadata("Back"));


        public HeaderControl()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utilities.FindParent<Frame>(this) is Frame frame
                && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Utilities.FindParent<Frame>(this) is Frame frame
                && frame.BackStack != null
                && frame.BackStack.Cast<JournalEntry>().FirstOrDefault() is JournalEntry journalEntry)
            {
                BackButtonText = journalEntry.Name;
            }
        }
    }
}
