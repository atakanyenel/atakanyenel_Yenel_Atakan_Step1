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
            this.reshreshEvents(mainForm);
        }

        private void refreshEvents(Form callingForm)
        {
            this.mainForm.setIsItRequest("$");
            this.mainForm.sendButton();
            for (int i=0; i<this.mainForm.getEventListCount(); i++)
            {
                cbOrganizers.Items.Add(this.mainForm.getEventListGetTitle(i));
            }
        }

        // create a refresh button
        // private void {This should be a refresh button}(object sender, EventArgs e)
        // {
        //     refreshEvents(mainForm);
        //     you may want to refresh cbOrganizer or something
        // }

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
