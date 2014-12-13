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
        
        //string event_created = events.function_create_event; // global variable
        Thread thrReceive;
        bool unique;
        bool condition=true;
        Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
<<<<<<< HEAD
<<<<<<< HEAD

=======
=======
>>>>>>> parent of 70367f5... Just a lot of get and set functions
        public void setIsItEvent(string a)
        {
            isItEvent = a;
        }
        public void setIsItRequest(string a)
        {
            isItRequest = a;
        }
        public string getIsItEvent()
        {
            return isItEvent;
        }
        public string getIsItRequest()
        {
            return isItRequest;
        }
<<<<<<< HEAD
>>>>>>> parent of 70367f5... Just a lot of get and set functions
=======
>>>>>>> parent of 70367f5... Just a lot of get and set functions
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
                    if (receivedmessage != "")
                    {
                        if (check_symbol(ref receivedmessage) == 1)
                        {
                            // 1 is event
                            // change this
                            int i = 0;
                            int location = receivedmessage.IndexOf('%',i);
                            while ( location!= -1){
                                int location2 = receivedmessage.IndexOf('%', i+1);
                                MessageBox.Show(location2.ToString());
                                string value_get = receivedmessage.Substring(location, location2 - location);
                                i++;
                                location = receivedmessage.IndexOf('%', i);
                                MessageBox.Show(value_get);
                            }
                            int name = receivedmessage.IndexOf('%');


                        }
                        else if (check_symbol(ref receivedmessage) == 2)
                        {
                            // 2 is message
                            richtextbox.Text = richtextbox.Text + receivedmessage.Substring(0) + "\r\n";
                        }
                        else if (check_symbol(ref receivedmessage) == 3)
                        {
                            // 3 is attendance

                        }
                    }

                    
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

        int check_symbol(ref string message)
        {
            if (message.ElementAt(0) == '%') // event
            {
                message = message.Substring(0, message.Length - 2);
                return 1;
            }
            else if (message.ElementAt(0) == '#') //message
            {
                message = message.Substring(0, message.Length - 2);
                return 2;
            }
            else if (message.ElementAt(0) == '&') //This is for attendance
            {
                message = message.Substring(0, message.Length - 2);
                return 3;
            }
            return 0;
        }
        private void btnsend_Click(object sender, EventArgs e)
        { 
            try
            {
                string isItEvent = events.function_create_event;
                string tbsendTextBox = tbsend.Text;
                Console.WriteLine(isItEvent);
                if ((isItEvent != "")&&(tbsendTextBox == ""))
                {
                    //send event string
                    byte[] buffer = Encoding.Default.GetBytes(isItEvent);
                    //This is not correct
                    richtextbox.Text = richtextbox.Text + isItEvent + "\r\n";
                    //display event info
                    richtextbox.Text = richtextbox.Text + "You have created: " + events.function_title + "\r\n";
                    c.Send(buffer);
                }
                else if (tbsendTextBox != "")
                {
                    //send message
                    richtextbox.Text = richtextbox.Text + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    tbsendTextBox = "#" + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    //you may want to change m to something more complicated             
                    byte[] buffer = Encoding.Default.GetBytes(tbsendTextBox);
                    c.Send(buffer);
                }
                else {
                    MessageBox.Show("You can't send empty messages.");
                }
                tbsend.Clear();
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
            
            //string created_event = newevent.event_name_test();

            //while(created_event == "");
            //richtextbox.Text = "llll";
            //richtextbox.Text = created_event;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var seeevents = new seeevents();
            seeevents.Show();




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tbsend_TextChanged(object sender, EventArgs e)
        {
            //string tbsendTextBox = tbsend.Text;
            //string isItEvent = events.function_create_event;
            
            //richtextbox.Text = richtextbox.Text + isItEvent + "\r\n";
            
            //tbsendTextBox = "#" + tbname.Text + ": " + tbsendTextBox + "\r\n";
            //tbsend.Text = isItEvent;
            ////you may want to change m to something more complicated             
            //byte[] buffer = Encoding.Default.GetBytes(isItEvent);
            //c.Send(buffer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // request to server and get the info about events
        }
    }
}
