using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientSide;
using CS408_Step1_Server;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void clientclick()
        {
            var newclient = new Form1();
            newclient.Show();
        }

        public void serverclick()
        {
            var newserver = new Server();
            newserver.Show();
        }

        private void client_Click(object sender, EventArgs e)
        {
            clientclick();
        }

        private void server_Click(object sender, EventArgs e)
        {
            serverclick();
        }

    }
}
