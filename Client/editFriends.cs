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
            //int i = this.mainForm.getCountREQ();
            //listBox3.Items.Clear();

            //for (int x = 0; x < i; x++)
            //{
            //    listBox3.Items.Add(this.mainForm.listRequestsX(x));
            //}

            //i = this.mainForm.getCountFRI();
            //listBox2.Items.Clear();

            //for (int x = 0; x < i; x++)
            //{
            //    listBox2.Items.Add(this.mainForm.listFriendsX(x));
            //}
            listBox1.Items.Clear();
            int i = this.mainForm.allClientsCount();
            if(i < 1){
                MessageBox.Show("asfafdfda:" + i);
            }

            for (int x = 0; x < i; x++)
            {
                listBox1.Items.Add(this.mainForm.listAllClinets(x));
            }


        }

        private void addfriend_Click(object sender, EventArgs e)
        {
            // ads a friends from list of requests
        }

        private void removefriend_Click(object sender, EventArgs e)
        {
            // removes a friend from list of friends and ads it to the list of others
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
