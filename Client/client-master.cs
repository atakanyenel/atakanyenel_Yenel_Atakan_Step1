using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// imported libraries
using System.Threading;
using System.Net;
using System.Net.Sockets;

//CLIENTSIDE  MASTER. Its a represenattion of the client side. All the other clients are copies of this one.
 
namespace ClientSide
{
    public partial class Form1 : Form
    {
        Thread thrReceive;
        bool unique;
        bool condition=true;
        Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        // the function for connecting the client to the server. A client uses an port number, IP number and a given name to connect to the server.
        // If the name textbox is empty or if the name alredy exists in the clients list that the user is asked to use another name
        // the connection part is handled in an try/catch method so if anything goes wrong the program does not crash but returns a message box.
        private void Connect_Click(object sender, EventArgs e)
        {
            if (Connect.Text == "Connect")
            {
                try
                {
                    if (tbname.Text == "")
                        MessageBox.Show("There should be a name");
                    else
                    {
                        c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        c.Connect(tbip.Text, Convert.ToInt32(tbport.Text));
                        byte[] clientname = new byte[64];
                        clientname = Encoding.Default.GetBytes(tbname.Text);
                        c.Send(clientname);
                        byte[] serveranswer = new byte[64];
                        c.Receive(serveranswer);
                        string strserveranswer = Encoding.Default.GetString(serveranswer);
                        strserveranswer = strserveranswer.Substring(0, 1);
                        if (strserveranswer == "1")
                        {
                            Connect.Text = "Disconnect!"; // When a client is succesfully connected the the CONNECT button changes to DISCONNECT with proper code behind it.
                            Connect.BackColor = Color.Red;
                            thrReceive = new Thread(new ThreadStart(Receive));
                            thrReceive.Start();
                            btnsend.Enabled = true;
                            tbname.Enabled = false;
                            tbport.Enabled = false;
                            condition = true;
                        }
                        else
                        {
                            MessageBox.Show("Choose a different name!");
                            c.Close();

                        }
                        this.AcceptButton = this.btnsend;
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR: Unable to Connect!!");
                }
            }
            else         // this code block stands for disconnection
            {
                try
                {
                    Connect.Text = "Connect";
                    Connect.BackColor = DefaultBackColor;
                    btnsend.Enabled = false;
                    byte[] buffer = new byte[64];
                    string text = "d";
                    buffer = Encoding.Default.GetBytes(text);
                    c.Send(buffer);
                    tbport.Text = "";
                    tbname.Enabled = true;
                    tbport.Enabled = true;
                    condition = false;                   
                    this.AcceptButton = this.Connect;
                }
                catch
                { 
                   
                }
            }
        }

        // a function for receive
        private void Receive()
        {
            try
            {
                condition = true;
                while (condition)
                {
                    byte[] buffer = new byte[64];
                    c.Receive(buffer);
                    string receivedmessage = Encoding.Default.GetString(buffer);
                    receivedmessage = receivedmessage.Substring(0, receivedmessage.IndexOf("\0"));
                    if(receivedmessage!="")
                    richtextbox.Text = richtextbox.Text + receivedmessage + "\r\n";
                }
            }
            catch
            {
                MessageBox.Show("There is a problem with the Server. Try Again");
                Connect.Enabled = true;
                Connect.Text = "Connect";
                tbsend.Text = "";
                btnsend.Enabled = false;
                tbname.Enabled = true;
                tbport.Enabled = true;
                Connect.BackColor = DefaultBackColor;
            }
        }
        
        // A function for sending messages. If a client wants to send an empty message a messagebox appears. 
        // If a message can not be sent because of some other malfunction the whole method is in try/catch so it does not crash
        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbsend.Text != "")
                {
                    richtextbox.Text = richtextbox.Text + tbname.Text + ": " + tbsend.Text + "\r\n";
                    string sentmessage = "m" + tbsend.Text;
                    byte[] buffer = Encoding.Default.GetBytes(sentmessage);
                    c.Send(buffer);
                    tbsend.Text = "";
                }
                else {
                    MessageBox.Show("You can't send empty messages.");
                }
            }
            catch 
            {
                MessageBox.Show("ERROR: Unable to send message !");
            }
            
        }
        // It is the same as at the server side. When a client wants to close the window he is asked if he/she is sure ...
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult DR = MessageBox.Show("Are you Sure?", "Close", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == DR)
                {
                    try
                    {
                        byte[] buffer = new byte[64];
                        string text = "d";
                        buffer = Encoding.Default.GetBytes(text);
                        c.Send(buffer);
                        System.Environment.Exit(1);
                    }
                    catch {
                        System.Environment.Exit(1);
                    }
                    }
                else
                    e.Cancel = true;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            var newevent = new newevent();
            newevent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var seeevents = new seeevents();
            seeevents.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
