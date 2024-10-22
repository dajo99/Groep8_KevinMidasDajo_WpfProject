﻿using System;

namespace Artmin_DAL
{
    /// <summary>
    /// Author: Midas
    /// </summary>
    public partial class Event : BaseClass
    {
        public Event(Event e)
        {
            EventID = e.EventID;
            Name = e.Name;
            EventTypeID = e.EventTypeID;
            Date = e.Date;
            BeginTime = e.BeginTime;
            EndTime = e.EndTime;
            LocationID = e.LocationID;
            ClientID = e.ClientID;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Event Name is required";
                }
                else if (columnName == "EventTypeID" && EventTypeID < 0)
                {
                    return "Type is required";
                }
                else if (columnName == "Date" && Date == DateTime.MinValue)
                {
                    return "Date is required";
                }
                else if (columnName == "BeginTime")
                {
                    if (string.IsNullOrWhiteSpace(BeginTime))
                    {
                        return "Start time is required";
                    }
                    else if (!TimeSpan.TryParse(BeginTime, out _))
                    {
                        return "Please enter a valid start time";
                    }
                }
                else if (columnName == "EndTime")
                {
                    if (string.IsNullOrWhiteSpace(EndTime))
                    {
                        return "End time is required";
                    }
                    else if (!TimeSpan.TryParse(EndTime, out _))
                    {
                        return "Please enter a valid end time";
                    }
                }
                return "";
            }
        }
    }
}
