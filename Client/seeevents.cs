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
        public seeevents(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            this.mainForm.setIsItRequest("$");
            this.mainForm.sendButton();
            //there should be get(sth)  functions for this.mainForm.EventList
            //it should be able to use this.mainForm.get(sth)
            for (int i=0; i<this.mainForm.getEventListCount(); i++)
            {
                cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
            }
        }

        //private void seeevents_Load(object sender, EventArgs e)
        //{
        //    // message is "$"
        //    // for loop in server in will send the whole event list
        //    // using eventsarray.Count()
        //    // encode it
        //    // "%" + date + "%" + title + "%" + place + "%" + description + "%" + organizer + "%"
        //    // client will decodes it

        //    //string created_event = events.function_create_event;
        //    //cbOrganizers.Items.Add(Event[4]);
        //}

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
    }
}
