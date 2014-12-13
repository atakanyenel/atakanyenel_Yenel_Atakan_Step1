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
<<<<<<< HEAD
=======

>>>>>>> origin/master
        //string event_created = events.function_create_event; // global variable
        Thread thrReceive;
        bool unique;
        bool condition=true;
        string isItEvent = "" ;
        string isItRequest = "" ;
        Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<events> EventList = new List<events>();
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        List<events> eventsarray_client_side = new List<events>();

        //DO NOT create set functions for events date/title/org/desc/place
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
        public int getEventListCount()
        {
            return EventList.Count();
        }
        public string getEventListGetDate(int i)
        {
            return EventList[i].getDate();
        }
        public string getEventListGetTitle(int i)
        {
            return EventList[i].getTitle();
        }
        public string getEventListGetDesc(int i)
        {
            return EventList[i].getDesc();
        }
        public string getEventListGetOrganize(int i)
        {
            return EventList[i].getOrganize();
        }
        public string getEventListGetPlace(int i)
        {
            return EventList[i].getPlace();
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
<<<<<<< HEAD
                { 
=======
                {

>>>>>>> origin/master
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
<<<<<<< HEAD
=======

>>>>>>> origin/master
                    byte[] buffer = new byte[64];
                    c.Receive(buffer);
                    string receivedmessage = Encoding.Default.GetString(buffer);
                    string received_event = receivedmessage; // without substring
                    receivedmessage = receivedmessage.Substring(0, receivedmessage.IndexOf("\0"));
                    if (receivedmessage != "")
                    {
<<<<<<< HEAD
                        if (check_symbol(ref receivedmessage) == 1) // 1 is event
                        {
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
                        else if (check_symbol(ref receivedmessage) == 2) // 2 is message
                        {
                            richtextbox.Text = richtextbox.Text + receivedmessage.Substring(0) + "\r\n";
                        }
                        else if (check_symbol(ref receivedmessage) == 3) // 3 is attendance
                        {
                            // still needs to be implemented
                            // no solution yet
                        }
                        else if (check_symbol(ref received_event) == 4) // 3 request an event 
                        {
                            MessageBox.Show("RECEIVED EVENT:" + received_event);

                            string b = received_event;
                            int index1 = 0;
                            int index2 = 0;

                            string a;
                            string[] event_info = new string[5];

                            for (int i = 0; i < 4; i++)
                            {
                                index1 = b.IndexOf("$");
                                a = b.Substring(index1 + 1);
                                index2 = a.IndexOf("$");
                                event_info[i] = b.Substring(1, index2);
                                b = b.Substring(index2 + 1);
                            }
                            b = b.Substring(1);
                            index1 = b.IndexOf("$");
                            event_info[4] = b.Substring(0, index1);

                            eventsarray_client_side.Add(new events());
                            eventsarray_client_side[eventsarray_client_side.Count - 1].setDate(event_info[0]);
                            eventsarray_client_side[eventsarray_client_side.Count - 1].setTitle(event_info[1]);
                            eventsarray_client_side[eventsarray_client_side.Count - 1].setPlace(event_info[2]);
                            eventsarray_client_side[eventsarray_client_side.Count - 1].setDesc(event_info[3]);
                            eventsarray_client_side[eventsarray_client_side.Count - 1].setOrganizer(event_info[4]);

                            MessageBox.Show(eventsarray_client_side[eventsarray_client_side.Count - 1].getDate());
                            MessageBox.Show(eventsarray_client_side[eventsarray_client_side.Count - 1].getTitle());
                            MessageBox.Show(eventsarray_client_side[eventsarray_client_side.Count - 1].getPlace());
                            MessageBox.Show(eventsarray_client_side[eventsarray_client_side.Count - 1].getDesc());
                            MessageBox.Show(eventsarray_client_side[eventsarray_client_side.Count - 1].getOrganizer());
                        }
                    }
=======
                        if (check_symbol(ref receivedmessage) == 1) //event
                        {
                            //we need to store these events into EvnetList
                            string a;
                            string b = receivedmessage;
                            int index1 = 0;
                            int index2 = 0;
                            string[] event_info = new string[5];
                            for (int i = 0; i<4; i++){
                                index1= b.IndexOf("%");
                                a = b.Substring(index1 +1);
                                index2 = a.IndexOf("%");
                                event_info[i] = b.Substring(1, index2);
                                b = b.Substring(index2 + 1);
                            }
                            b = b.Substring(1);
                            index1 = b.IndexOf("%");
                            event_info[4] = b.Substring(0, index1);
                            EventList.Add(new events());
                            EventList[EventList.Count - 1].setDate(event_info[0]);
                            EventList[EventList.Count - 1].setTitle(event_info[1]);
                            EventList[EventList.Count - 1].setPlace(event_info[2]);
                            EventList[EventList.Count - 1].setDesc(event_info[3]);
                            EventList[EventList.Count - 1].setOrganizer(event_info[4]);

                            // int i = 0;
                            // int location = receivedmessage.IndexOf('%',i);
                            // while ( location!= -1){
                            //     int location2 = receivedmessage.IndexOf('%', i+1);
                            //     MessageBox.Show(location2.ToString());
                            //     string value_get = receivedmessage.Substring(location, location2 - location);
                            //     i++;
                            //     location = receivedmessage.IndexOf('%', i);
                            //     MessageBox.Show(value_get);
                            // }
                            // int name = receivedmessage.IndexOf('%');

                        }
                        else if (check_symbol(ref receivedmessage) == 2) //message
                        {
                            richtextbox.Text = richtextbox.Text + receivedmessage.Substring(0) + "\r\n";
                        }
                        else
                        {
                                //both 3(attendence) and 4(request) and anything else should not exist
                                MessageBox.Show("There is a problem. Try Again");
                        }
                    }


>>>>>>> origin/master
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

<<<<<<< HEAD
        // A function for sending messages. If a client wants to send an empty message a messagebox appears. 
=======
        // A function for sending messages. If a client wants to send an empty message a messagebox appears.
>>>>>>> origin/master
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
            else if (message.ElementAt(0) == '&') //attendance
            {
                message = message.Substring(0, message.Length - 2);
                return 3;
            }
<<<<<<< HEAD
            else if (message.ElementAt(0) == '$') //This is for request
            {
                message = message.Substring(0, message.Length - 2);
=======
            else if(message.ElementAt(0) == '$') //request
            {
>>>>>>> origin/master
                return 4;
            }
            return 0;
        }

        public void sendButton()
        {
            try
            {
                string tbsendTextBox = tbsend.Text;
<<<<<<< HEAD
                if ((isItEvent != "")&&(tbsendTextBox == ""))
=======
                MessageBox.Show("The next Box should have text iff you just clicked the create button on event:");
                MessageBox.Show(isItEvent);
                MessageBox.Show("The next Box should have text iff you just open See event form: ");
                MessageBox.Show(isItRequest);
                if (isItEvent != "") //just event
>>>>>>> origin/master
                {
                    //send event string
                    byte[] buffer = Encoding.Default.GetBytes(isItEvent);
                    //This is not correct
                    richtextbox.Text = richtextbox.Text + isItEvent + "\r\n";
                    //display event info
                    richtextbox.Text = richtextbox.Text + "You have created an event!\r\n";
                    c.Send(buffer);
                    isItEvent = "";
                }
                else if (isItRequest != "") //just request
                {
                    //isItRequest should always be just "$"
                    byte[] buffer = Encoding.Default.GetBytes(isItRequest);
                    c.Send(buffer);
                    //for debugging:
                    richtextbox.Text = richtextbox.Text + "Seeevent just sent a request: " + isItRequest + "\r\n";
                    isItRequest = "";
                }
                else if (tbsendTextBox != "") //just message
                {
                    //send message
                    richtextbox.Text = richtextbox.Text + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    tbsendTextBox = "#" + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    byte[] buffer = Encoding.Default.GetBytes(tbsendTextBox);
                    c.Send(buffer);
                }
                else
                {
                    MessageBox.Show("You can't send empty messages.");
                }
                tbsend.Clear();
            }
            catch
            {
                MessageBox.Show("ERROR: Unable to send message !");
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            sendButton();
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
            //Create Event
            //possible solution to sending problem:
            var newevent = new newevent(this);
            newevent.Show();
<<<<<<< HEAD
=======
            //http://pi.vu/BILX (useful StockExchange question)
>>>>>>> origin/master
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check events
            var seeevents = new seeevents(this);
            seeevents.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbsend_TextChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======

>>>>>>> origin/master
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // send a request to server for events
            // send a symbol and the server responds properly
            // current application and should be changed - see events button!!!!

            string request_event = "$";
            byte[] buffer = Encoding.Default.GetBytes(request_event);
            string test = Encoding.Default.GetString(buffer);
            MessageBox.Show(test);
            byte[] buffer1 = Encoding.Default.GetBytes(request_event);
            
            c.Send(buffer1);

            // gets the events
            // saves them into a list
            // fils the combobox with titles
        }
    }
}
