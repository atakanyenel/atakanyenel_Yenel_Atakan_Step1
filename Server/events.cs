using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    class events
    {
        static string date;
        static string title;
        static string description;
        static string organizer;
        static string[] Event;
        static string place;

        public static string function_date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public static string function_place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
            }
        }
        public static string[] function_event
        {
            get
            {
                return Event;
            }
            set
            {
                Event = value;
            }
        }
        public static string function_title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public static string function_description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public static string function_organizer
        {
            get
            {
                return organizer;
            }
            set
            {
                organizer = value;
            }
        }
    }
}
