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

        private void addfriend_Click(object sender, EventArgs e)
        {
            // ads a friends from list of requests
        }

        private void removefriend_Click(object sender, EventArgs e)
        {
            // removes a friend from list of friends and ads it to the list of others
        }

        private void editFriends_Load(object sender, EventArgs e)
        {
            // load the requests and such things
            // maybe list of all connected clients
        }
    }
}
