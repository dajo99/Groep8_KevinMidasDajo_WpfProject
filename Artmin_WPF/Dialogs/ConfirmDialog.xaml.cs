using System.Windows.Controls;

namespace Artmin_WPF.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfirmDialog.xaml
    /// </summary>
    public partial class ConfirmDialog : UserControl
    {
        public ConfirmDialog(string messageText = "")
        {
            InitializeComponent();
            MessageText = messageText;
        }
        public string MessageText
        {
            get { return textMessage.Text;  }
            set { textMessage.Text = value;  }
        }
        public TextBlock TextBlock
        {
            get { return textMessage; }
        }
    }
}
