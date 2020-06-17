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
            MessageText = messageText;
        }
        public string MessageText
        {
            get { return textMessage.Text; }
            set { textMessage.Text = value; }
        }
    }
}
