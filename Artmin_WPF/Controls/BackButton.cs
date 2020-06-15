using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    ///
    /// </summary>
    public class BackButton : ButtonBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TargetTitle
        {
            get
            {
                return (string)GetValue(TargetTitleProperty);
            }
            set
            {
                SetValue(TargetTitleProperty, value);
                NotifyPropertyChanged();
            }
        }

        private static readonly DependencyProperty TargetTitleProperty =
            DependencyProperty.Register("TargetTitle", typeof(string), typeof(BackButton), new PropertyMetadata("Back"));

        static BackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BackButton), new FrameworkPropertyMetadata(typeof(BackButton)));
        }

        public BackButton()
        {
            DataContext = this;
            Loaded += BackButton_Loaded;
            Click += BackButton_Click;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Utilities.FindParent<Frame>(this) is Frame frame
                && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void BackButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (Utilities.FindParent<Frame>(this) is Frame frame
                && frame.BackStack != null
                && frame.BackStack.Cast<JournalEntry>().LastOrDefault() is JournalEntry journalEntry)
            {
                TargetTitle = journalEntry.Name;
            }
        }
    }
}
