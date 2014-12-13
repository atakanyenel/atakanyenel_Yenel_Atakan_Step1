using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS408_Step1_Server
{
    class events
    {
        static string date;
        static string title;
        static string description;
        static string organizer;
        static string[] Event;
        static string place;
        static string[] Going;
        static string[] notGoing;
        static string[] notReply;

        //set

        public void setDate(string date2)
        {
            date = date2;
        }

        public void setTitle(string date2)
        {
            title = date2;
        }

        public void setDesc(string date2)
        {
            description = date2;
        }

        public void setOrganizer(string date2)
        {
            organizer = date2;

        }
        public void setPlace(string date2)
        {
            place = date2;
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
