using Artmin_WPF.Dialogs;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Artmin_WPF.Controls
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// Author: Midas
    /// </summary>
    public partial class HeaderControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => GetValue(TitleProperty) as string;
            set => SetValue(TitleProperty, value);
        }
        public string Subtitle
        {
            get => GetValue(SubtitleProperty) as string;
            set => SetValue(SubtitleProperty, value);
        }

        public string BackButtonText
        {
            get => GetValue(BackButtonTextProperty) as string;
            set
            {
                SetValue(BackButtonTextProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackButtonText"));
            }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        private static readonly DependencyProperty BackButtonTextProperty =
            DependencyProperty.Register("BackButtonText", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        public HeaderControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utilities.FindParent<Frame>(this) is Frame frame && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BackButtonText)
                && Utilities.FindParent<Frame>(this) is Frame frame
                && frame.BackStack != null
                && frame.BackStack.Cast<JournalEntry>().FirstOrDefault() is JournalEntry journalEntry)
            {
                BackButtonText = journalEntry.Name;
            }
        }


        private async void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            var afsluiten = (bool)await DialogHost.Show(new ConfirmDialog("Are you sure you want to exit?"));

            if (afsluiten == true)
            {
                Application.Current.Shutdown();
            }
            
        }
    }
}
