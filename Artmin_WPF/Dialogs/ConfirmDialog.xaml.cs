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
            get => textMessage.Text;
            set => textMessage.Text = value.Trim();
        }
        public TextBlock TextBlock
        {
            get => textMessage;
        }
    }
}
