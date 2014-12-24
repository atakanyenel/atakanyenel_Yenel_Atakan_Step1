using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class seeevents : Form
    {
        private Form1 mainForm = null;
        private int eventID = -1;
        private int YoN = -1;

        public seeevents()
        {
            InitializeComponent();
        }

        //If we simply refresh in the constructor once, the single event seems
        //to be able to arrive to client-master, but seeevent fail to read it
        public seeevents(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            //refreshEvents();

            cbOrganizers.Items.Clear();
            //this.mainForm.setIsItRequest("$");
            //this.mainForm.sendButton();
            int count = this.mainForm.getEventListCount();
            //attempt 1
            //and then we try to use different approach force constructor to
            //read multiple times, and we gets multiple times of the event
            //even though we have used clear
            if (count > 0)
            {
                cbOrganizers.Items.Clear();
                for (int i = 0; i < count; i++)
                {
                    string org = this.mainForm.getEventListGetOrganize(i);
                    bool check = this.mainForm.isItFriend(org);
                    if (check == true)
                    {
                        cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
                    }
                }
            }
        }

        private void refreshEvents()
        {
            cbOrganizers.Items.Clear();
            listBox1.Items.Clear();
            //listBox1.Text = " Invited: \r\n";
            //listBox1.Text += " Accepted: \r\n";
            //listBox1.Text += " Rejected: \r\n";
            //this.mainForm.setIsItRequest("$");
            //this.mainForm.sendButton();
            int count = this.mainForm.getEventListCount();

            if(count > 0){
                cbOrganizers.Items.Clear();
                for (int i = 0; i<count; i++)
                {
                    string org = this.mainForm.getEventListGetOrganize(i);
                    bool check = this.mainForm.isItFriend(org);
                    if (check == true)
                    {
                        cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
                    }
                    
                }
            }
            else
            {
                refreshEvents();
            }
            // attempt 2
            // the server sends another message "@" AFTER finish transfering
            // all events, and the seeevent will got stuck in a while loop
            // while (this.mainForm.getUnique == false);
            // which act as a lock.
        }

        private void sendAtte()
        {
            //Format: ${event id}${username}${yes/no}$
            //event id is obtained when select event in cbOrganizer
            //username is seleted from client-master
            //YoN means Yes or No, 1 is yes ,0 is no (or maybe we can use boolean)
            string a = "&" + eventID.ToString() + "&" + this.mainForm.getTbName() + "&" + YoN.ToString() + "&";
            this.mainForm.setdirectlyToServer(a);
            this.mainForm.sendButton();
        }

        public void updateEventInfos()
        {
            string selected_event = cbOrganizers.Text;
            eventID = this.mainForm.searchEventList(selected_event);
            txtDate.Text = this.mainForm.getEventListGetDate(eventID);
            txtDescription.Text = this.mainForm.getEventListGetDesc(eventID);
            txtPlace.Text = this.mainForm.getEventListGetPlace(eventID);
            txtTitle.Text = selected_event;
            txtOrganizer.Text = this.mainForm.getEventListGetOrganize(eventID);
            listBox1.Items.Clear();
            updatelistBox1();
        }

        public void updatelistBox1()
        {
            int gCount = this.mainForm.getEventGoingCount(eventID);
            int ngCount = this.mainForm.getEventNotGoingCount(eventID);
            int nrCount = this.mainForm.getEventNotReplyCount(eventID);
            listBox1.Items.Add("Going:");
            if (gCount>0)
            {
                for (int i = 0; i<gCount; i++)
                {
                    // listBox1.Items.Add(this.mainForm.EventList[eventID].getGoingList(i));
                    listBox1.Items.Add(this.mainForm.getEventGoingList(eventID, i));
                }
            }
            else
            {
                listBox1.Items.Add("No one");
            }
            listBox1.Items.Add("Not Going:");
            if (ngCount>0)
            {
                for (int i = 0; i<ngCount; i++)
                {
                    //listBox1.Items.Add(this.mainForm.EventList[eventID].getNotGoingList(i));
                    listBox1.Items.Add(this.mainForm.getEventNotGoingList(eventID, i));
                }
            }
            else
            {
                listBox1.Items.Add("No one");
            }
            listBox1.Items.Add("Invited:");
            if (gCount>0)
            {
                for (int i = 0; i<nrCount; i++)
                {
                    //listBox1.Items.Add(this.mainForm.EventList[eventID].getNotReplyList(i));
                    listBox1.Items.Add(this.mainForm.getEventNotReplyList(eventID, i));
                }
            }
            else
            {
                listBox1.Items.Add("No one");
            }
        }

        private void cbOrganizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEventInfos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void r5button_Click(object sender, EventArgs e)
        {
             refreshEvents();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            YoN = 0; //Not going
            sendAtte();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            YoN = 1; //going
            sendAtte();
        }
    }
}
