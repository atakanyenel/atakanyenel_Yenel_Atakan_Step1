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

        private void seeevents_Load(object sender, EventArgs e)
        {
            string created_event = events.function_create_event;
            //cbOrganizers.Items.Add(Event[4]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //string[] Event = events.function_createevent;
            //txtDescription.Text = Event[3];
            //txtOrganizer.Text = Event[4];
            //txtPlace.Text = Event[2];
            //txtTitle.Text = Event[1];
            //txtDate.Text = Event[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOrganizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
