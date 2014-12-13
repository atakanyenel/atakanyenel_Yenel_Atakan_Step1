using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
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
    }
}
