using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;


/*
 Frequently used places as Combo box !!
 */

namespace ClientSide
{
    public partial class newevent : Form
    {

        public newevent()
        {
            InitializeComponent();
        }

        //possible send problem solution:
        private Form1 mainForm = null;
        public newevent(Form callingForm)
        {
           mainForm = callingForm as Form1;
           InitializeComponent();
        }
        //overload constructor, with an input of Form1, so it can access
        //functions in Form1 (esp. btnsend_Click(object, EventArgs))
        //but maybe we should move everything inside btnsend_Click to a
        //seperate function, according to StockExchange(http://pi.vu/BILK)

        private void createButton()
        {
            string date = dtpDate.Value.ToShortDateString();
            string place = txtPlace.Text;
            string description = txtDescription.Text;
            string organizer = txtOrganizer.Text;
            string title = txtTitle.Text;

            events.function_date = dtpDate.Value.ToShortDateString();
            events.function_place = txtPlace.Text;
            events.function_description = txtDescription.Text;
            events.function_organizer = txtOrganizer.Text;
            events.function_title = txtTitle.Text;
            this.mainForm.isItEvent = "%" + date + "%" + title + "%" + place + "%" + description + "%" + organizer + "%";

            MessageBox.Show("Event created:" + title);
            this.mainForm.sendButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                createButton();
        }

        //need to handle sending event info to server

        private void button2_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            txtOrganizer.Clear();
            txtPlace.Clear();
            txtTitle.Clear();
            dtpDate.Value = DateTime.Now;
        }

        private void newevent_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtOrganizer_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
