using Artmin_DAL;
using System.Windows;
using System.Windows.Controls;

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EventEditPage.xaml
    /// </summary>
    public partial class EventEditPage : Page
    {
        private Event Event;
        public Event Model { get; set; }
        public EventEditPage(Event e = null)
        {
            Event = e;

            if (e != null)
            {
                Model = new Event(e);
            }
            else
            {
                Model = new Event();
            }

            DataContext = this;

            InitializeComponent();

            if (e == null)
            {
                Title = "Create Event";
            }

            cbType.ItemsSource = DatabaseOperations.GetEventTypes();
            txtName.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
