using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.mainForm.setIsItRequest("$");
            this.mainForm.sendButton();
            for (int i = 0; i < this.mainForm.getEventListCount(); i++)
            {
                cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
            }
        }

        private void refreshEvents()
        {
            this.mainForm.setIsItRequest("$");
            this.mainForm.sendButton();
            cbOrganizers.Items.Clear();
            for (int i = 0; i < this.mainForm.getEventListCount(); i++)
            {
                cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
            }
        }

        private void sendAtte()
        {
            //Format: ${event id}${username}${yes/no}$
            //event id is obtained when select event in cbOrganizer
            //username is seleted from client-master
            //YoN means Yes or No, 1 is yes ,0 is no (or maybe we can use boolean)
            string isItAtte = "&" + eventID.ToString() + "&" + this.mainForm.tbname.Text + "&" + YoN.ToString() + "&";
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
            sendAtte();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            YoN = 1; //going
            sendAtte();
        }
    }
}
