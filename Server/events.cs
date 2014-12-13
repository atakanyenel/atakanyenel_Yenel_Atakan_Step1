using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS408_Step1_Server
{
    class events
    {
        private string date;
        private string title;
        private string description;
        private string organizer;
        private string place;

        public void setDate(string newValue)
        {
            date = newValue;
        }

        public void setTitle(string newValue1)
        {
            title = newValue1;
        }

        public void setDesc(string newValue2)
        {
            description = newValue2;
        }

        public void setOrganizer(string newValue3)
        {
            organizer = newValue3;

        }
        public void setPlace(string newValue4)
        {
            place = newValue4;
        }

        //get

        public string getDate()
        {
            return date;
        }

        public string getTitle()
        {
            return title;
        }

        public string getDesc()
        {
            return description;
        }

        public string getOrganizer()
        {
            return organizer;

        }
        public string getPlace()
        {
            return place;
        }

        //apparently List cannot access data using the mathods below
        // public static string function_date
        // {
        //     get
        //     {
        //         return date;
        //     }
        //     set
        //     {
        //         date = value;
        //     }
        // }
        // public static string function_place
        // {
        //     get
        //     {
        //         return place;
        //     }
        //     set
        //     {
        //         place = value;
        //     }
        // }
        // public static string[] function_event
        // {
        //     get
        //     {
        //         return Event;
        //     }
        //     set
        //     {
        //         Event = value;
        //     }
        // }
        // public static string function_title
        // {
        //     get
        //     {
        //         return title;
        //     }
        //     set
        //     {
        //         title = value;
        //     }
        // }
        // public static string function_description
        // {
        //     get
        //     {
        //         return description;
        //     }
        //     set
        //     {
        //         description = value;
        //     }
        // }
        // public static string function_organizer
        // {
        //     get
        //     {
        //         return organizer;
        //     }
        //     set
        //     {
        //         organizer = value;
        //     }
        // }
    }
}
