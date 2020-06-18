using System.Windows.Controls;

namespace Artmin_WPF.Dialogs
{
    /// <summary>
    /// Interaction logic for ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : UserControl
    {
        public ErrorDialog(string messageText = "")
        {
            InitializeComponent();
            if (messageText != "") MessageText = messageText;
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
