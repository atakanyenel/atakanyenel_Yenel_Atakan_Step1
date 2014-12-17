using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408_Step1_Server
{
    class events
    {
        private string date;
        private string title;
        private string description;
        private string organizer;
        private string place;
        private List<string> goingList = new List<string>();
        private List<string> notGoingList = new List<string>();
        private List<string> notReplyList = new List<string>();

        //set
        public void setDate(string newValue)
        {
            date = newValue;
        }
        public void setTitle(string newValue)
        {
            title = newValue;
        }
        public void setDesc(string newValue)
        {
            description = newValue;
        }
        public void setOrganizer(string newValue)
        {
            organizer = newValue;
        }
        public void setPlace(string newValue)
        {
            place = newValue;
        }
        public void addGoingList(string newValue)
        {
            goingList.Add(newValue);
        }
        public void addNotGoingList(string newValue)
        {
            notGoingList.Add(newValue);
        }
        public void addNotReplyList(string newValue)
        {
            notReplyList.Add(newValue);
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
        public string getGoingList(int i)
        {
            return goingList[i];
        }
        public string getNotGoingList(int i)
        {
            return notGoingList[i];
        }
        public string getNotReplyList(int i)
        {
            return notReplyList[i];
        }
        public int getGoingListCount()
        {
            return goingList.Count;
        }
        public int getNotGoingListCount()
        {
            return notGoingList.Count;
        }
        public int getNotReplyListCount()
        {
            return notReplyList.Count;
        }

        //search functions for the 3 lists
        //update event.cs in client as well
        public int searchGoingList(string un)
        {
            int x = goingList.Count();
            for (int i = 0; i<x; i++)
            {
                if (goingList[i] == un)
                {
                    return i;
                }
            }
            return -1;
        }
        public int searchNotGoingList(string un)
        {
            int x = notGoingList.Count();
            for (int i = 0; i<x; i++)
            {
                if (notGoingList[i] == un)
                {
                    return i;
                }
            }
            return -1;
        }
        public int searchNotReplyList(string un)
        {
            int x = notReplyList.Count();
            for (int i = 0; i<x; i++)
            {
                if (notReplyList[i] == un)
                {
                    return i;
                }
            }
            return -1;
        }

        //remove
        public void removeGoingList(string un)
        {
            bool ans = goingList.Remove(un);
        }
        public void removeNotGoingList(string un)
        {
            bool ans = notGoingList.Remove(un);
        }
        public void removeNotReplyList(string un)
        {
            bool ans = notReplyList.Remove(un);
        }
    }
}
