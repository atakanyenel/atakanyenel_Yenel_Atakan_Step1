using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dtpDate.Value.ToShortDateString();
            
            string place = txtPlace.Text;
            string description = txtDescription.Text;
            string organizer = txtOrganizer.Text;
            string title = txtTitle.Text;

            string[] new_event = {date, title, place, description, organizer};

            events.function_date = dtpDate.Value.ToShortDateString();
            events.function_place = txtPlace.Text;
            events.function_description = txtDescription.Text;
            events.function_organizer = txtOrganizer.Text;
            events.function_title = txtTitle.Text;
            events.function_event = new_event;

            MessageBox.Show("You have created an event: " + title);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            txtOrganizer.Clear();
            txtPlace.Clear();
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
