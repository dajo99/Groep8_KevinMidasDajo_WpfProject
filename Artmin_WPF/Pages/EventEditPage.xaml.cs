using Artmin_DAL;
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

namespace Artmin_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EventEditPage.xaml
    /// </summary>
    public partial class EventEditPage : Page
    {
        public EventEditPage(Event e = null)
        {
            InitializeComponent();

            if (e == null)
            {
                Title = "Create Event";
            }
        }
    }
}
