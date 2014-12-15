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
        public seeevents()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        private int eventID = -1;
        private int YoN = -1;

        public seeevents(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            refreshEvents();
        }

        private void refreshEvents()
        {
            cbOrganizers.Items.Clear();
            this.mainForm.setIsItRequest("$");
            this.mainForm.sendButton();

            //Thread.Sleep(20);
            int i = 0;
            do
            {
                cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
                i++;
            }
            while (i < this.mainForm.getEventListCount());

        }

        private void sendAtte()
        {
            //Format: ${event id}${username}${yes/no}$
            //event id is obtained when select event in cbOrganizer
            //username is seleted from client-master
            //YoN means Yes or No, 1 is yes ,0 is no (or maybe we can use boolean)
            string isItAtte = "&" + eventID.ToString() + "&" + this.mainForm.getTbName() + "&" + YoN.ToString() + "&";
            this.mainForm.setIsItAtte("isItAtte");
            //this.mainForm.sendButton();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOrganizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = button1;
            //update eventID
            //update listBox1ent

            string selected_event = cbOrganizers.Text;

            // compare this value with ID

           eventID = this.mainForm.searchEventList(selected_event);

           txtDate.Text = this.mainForm.getEventListGetDate(eventID);
           txtDescription.Text = this.mainForm.getEventListGetDesc(eventID);
           txtPlace.Text = this.mainForm.getEventListGetPlace(eventID);
           txtTitle.Text = selected_event;
           txtOrganizer.Text = this.mainForm.getEventListGetOrganize(eventID);




            


            
               

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void r5button_Click(object sender, EventArgs e)
        {
             refreshEvents();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            YoN = 0; //Not going
            //when user select event in cbOrganizer it shoudl update eventID
            sendAtte();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            YoN = 1; //going
            sendAtte();
        }
    }
}
