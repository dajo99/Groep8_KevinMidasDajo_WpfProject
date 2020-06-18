using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    [AddINotifyPropertyChangedInterface]
    public partial class Event
    {
        public Event(Event e)
        {
            EventID     = e.EventID;
            Name        = e.Name;
            EventTypeID = e.EventTypeID;
            Date        = e.Date;
            BeginTime   = e.BeginTime;
            EndTime     = e.EndTime;
            LocationID  = e.LocationID;
            ClientID    = e.ClientID;
            EventType   = e.EventType;
        }
    }
}
