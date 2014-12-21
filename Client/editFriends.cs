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
    public partial class editFriends : Form
    {
        public editFriends()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public editFriends(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            refresh_lists();
        }

        public void refresh_lists()
        {
            listBox3.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            //Request List
            int i = this.mainForm.getCountREQ();
            for (int x = 0; x < i; x++)
            {
               listBox3.Items.Add(this.mainForm.listRequestsX(x));
            }

            //Friends List
            i = this.mainForm.getCountFRI();
            for (int x = 0; x < i; x++)
            {
               listBox2.Items.Add(this.mainForm.listFriendsX(x));
            }

            //all users list
            int i = this.mainForm.allClientsCount();
            for (int x = 0; x < i; x++)
            {
                //it should not print if
                //a) that user is friends
                //b) that user is requesting
                //c) yourself
                listBox1.Items.Add(this.mainForm.listAllClinets(x));
            }


        }

        private void addfriend_Click(object sender, EventArgs e)
        {
            // ads a friends from list of requests
            // 1. check if anything in listBox? have been selected
            // 2. encode message
            // 3. store message in client master(setdirectlyToServer(string a))
            // 4. trigger send button(this.mainForm.sendButton())
        }

        private void removefriend_Click(object sender, EventArgs e)
        {
            // removes a friend from list of friends and ads it to the list of others
            // 1. check if anything in listBox? have been selected
            // 2. encode message
            // 3. store message in client master(setdirectlyToServer(string a))
            // 4. trigger send button(this.mainForm.sendButton())
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh_lists();
        }
    }
}
