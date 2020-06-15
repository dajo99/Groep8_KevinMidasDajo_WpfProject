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

namespace Artmin_WPF.Controls
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {
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

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(HeaderControl), new PropertyMetadata(string.Empty));


        public HeaderControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
