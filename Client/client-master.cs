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
        bool condition = true;
        string isItEvent = "";
        string directlyToServer = "";
        Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<events> EventList = new List<events>();
        List<string> listFriends = new List<string>();
        List<string> listAllClients = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        public void setIsItEvent(string a)
        {
            isItEvent = a;
        }
        public void setdirectlyToServer(string a)
        {
            directlyToServer = a;
        }
        public string getIsItEvent()
        {
            return isItEvent;
        }
        public string getdirectlyToServer()
        {
            return directlyToServer;
        }
        public string getIsItOwner()
        {
            string Owner = tbname.Text;
            return Owner;
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
            return EventList[i].getOrganizer();
        }
        public string getEventListGetPlace(int i)
        {
            return EventList[i].getPlace();
        }

        public int searchEventList(string un)
        {
            int x = EventList.Count();
            for (int i = 0; i < x; i++)
            {
                if (EventList[i].getTitle() == un)
                {
                    return i;
                }
            }
            return -1;
        }

        public string getEventGoingList(int eID, int i)
        {
            return EventList[eID].getGoingList(i);
        }
        public string getEventNotGoingList(int eID, int i)
        {
            return EventList[eID].getNotGoingList(i);
        }
        public string getEventNotReplyList(int eID, int i)
        {
            return EventList[eID].getNotReplyList(i);
        }
        public int getEventGoingCount(int eID)
        {
            return EventList[eID].getGoingListCount();
        }
        public int getEventNotGoingCount(int eID)
        {
            return EventList[eID].getNotGoingListCount();
        }
        public int getEventNotReplyCount(int eID)
        {
            return EventList[eID].getNotReplyListCount();
        }
        public int getCountFRI()
        {
            return listFriends.Count;
        }

        public string listFriendsX(int name)
        {
            return listFriends[name];
        }

        public int allClientsCount()
        {
            return listAllClients.Count;
        }

        public string listAllClinets(int name)
        {
            return listAllClients[name];
        }
        public bool isItFriend(string nameOf)
        {
            return listFriends.Contains(nameOf);
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
                        MessageBox.Show("PLEASE INSERT YOUR NAME");
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
                            btnFriends.Enabled = true;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            condition = true;
                            this.AcceptButton = this.btnsend;
                            directlyToServer = "$";
                            sendButton();
                        }
                        else
                        {
                            MessageBox.Show("YOUR NAME IS INVALID");
                            c.Close();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR: UNABLE TO CONNECT");
                }
            }
            else         // this code block stands for disconnection
            {
                try
                {
                    Connect.Text = "Connect";
                    Connect.BackColor = DefaultBackColor;
                    btnsend.Enabled = false;
                    btnFriends.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
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
                        if (check_symbol(ref receivedmessage) == 1) //event
                        {
                            //we need to store these events into EvnetList
                            string a;
                            string b = receivedmessage;
                            int index1 = 0;
                            int index2 = 0;
                            string[] event_info = new string[5];
                            for (int i = 0; i < 4; i++)
                            {
                                index1 = b.IndexOf("%");
                                a = b.Substring(index1 + 1);
                                index2 = a.IndexOf("%");
                                event_info[i] = b.Substring(1, index2);
                                b = b.Substring(index2 + 1);
                            }
                            b = b.Substring(1);
                            index1 = b.IndexOf("%");
                            event_info[4] = b.Substring(0, index1);

                            events tempe = new events();
                            tempe.setDate(event_info[0]);
                            tempe.setTitle(event_info[1]);
                            tempe.setPlace(event_info[2]);
                            tempe.setDesc(event_info[3]);
                            tempe.setOrganizer(event_info[4]);
                            EventList.Add(tempe);
                        }
                        else if (check_symbol(ref receivedmessage) == 2) //message
                        {
                            richtextbox.Text = richtextbox.Text + receivedmessage.Substring(1) + "\r\n";
                        }
                        else if (check_symbol(ref receivedmessage) == 3) // attendance
                        {
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = receivedmessage;
                            string[] atte_rec = new string[3];
                            //Format: "&"+{enent id}"&"{username}&{yes or no}"&"
                            for (int i = 0; i < 2; i++)
                            {
                                i1 = B.IndexOf("&");
                                A = B.Substring(i1 + 1);
                                i2 = A.IndexOf("&");
                                atte_rec[i] = B.Substring(1, i2);
                                B = B.Substring(i2 + 1);
                            }
                            B = B.Substring(1);
                            i1 = B.IndexOf("&");
                            atte_rec[2] = B.Substring(0, i1);
                            //convert event id into int
                            int eID = Convert.ToInt32(atte_rec[0]);
                            //remove that username from all instance of that event
                            EventList[eID].removeGoingList(atte_rec[2]);
                            EventList[eID].removeNotGoingList(atte_rec[2]);
                            EventList[eID].removeNotReplyList(atte_rec[2]);
                            //decide where the username should be store according to event and answer
                            if (atte_rec[2] == "1") //going
                            {
                                EventList[eID].addGoingList(atte_rec[1]);
                            }
                            else if (atte_rec[2] == "0") //not going
                            {
                                EventList[eID].addNotGoingList(atte_rec[1]);
                            }
                            else if (atte_rec[2] == "-1") //not reply
                            {
                                EventList[eID].addNotReplyList(atte_rec[1]);
                            }
                            else
                            {
                                MessageBox.Show("Something's wrong");
                            }
                        }
                        else if (check_symbol(ref receivedmessage) == 6) // serevr replyed with the list of clients
                        {
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = receivedmessage;
                            i1 = B.IndexOf("^");
                            A = B.Substring(i1 + 1);
                            i2 = A.IndexOf("^");
                            string reply_usernames_S = B.Substring(1, i2);

                            listAllClients.Add(reply_usernames_S);

                        }
                        else if (check_symbol(ref receivedmessage) == 5) // add friends(symbol: @)
                        {
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = receivedmessage;
                            string[] addfri = new string[2];
                            i1 = B.IndexOf("@");
                            A = B.Substring(i1 + 1);
                            i2 = A.IndexOf("@");
                            addfri[0] = B.Substring(1, i2);
                            B = B.Substring(i2 + 2);
                            i1 = B.IndexOf("@");
                            addfri[1] = B.Substring(0, i1);
                            string my_name = tbname.Text;

                            if (addfri[0] != my_name)
                            {
                                listFriends.Add(addfri[0]);
                            }
                            else
                            {
                                listFriends.Add(addfri[1]);
                            }
                        }
                        else if (check_symbol(ref receivedmessage) == 7) // add clients(symbol: §)
                        {
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = receivedmessage;
                            string addc;
                            i1 = B.IndexOf("§");
                            A = B.Substring(i1 + 1);
                            i2 = A.IndexOf("§");
                            addc = B.Substring(1, i2);
                            listAllClients.Add(addc);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("THERE IS A PROBLEM WITH THE SERVER. PLEASE RETRY");
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
                message = message.Substring(0, message.Length);
                return 1;
            }
            else if (message.ElementAt(0) == '#') //message
            {
                message = message.Substring(0, message.Length - 1);
                return 2;
            }
            else if (message.ElementAt(0) == '&') //attendance
            {
                message = message.Substring(0, message.Length);
                return 3;
            }
            else if (message.ElementAt(0) == '$') //request
            {
                return 4;
            }
            else if (message.ElementAt(0) == '@') //add friends
            {
                return 5;
            }
            else if (message.ElementAt(0) == '^') // get usernames from server (reply from server)
            {
                return 6;
            }
            else if (message.ElementAt(0) == '§') // get usernames from server (reply from server)
            {
                return 7;
            }
            return 0;
        }

        public string getTbName()
        {
            return tbname.Text;
        }

        public void sendButton()
        {
            try
            {
                string tbsendTextBox = tbsend.Text;
                if (isItEvent != "") //just event
                {
                    //send event string
                    byte[] buffer = Encoding.Default.GetBytes(isItEvent);
                    //This is not correct
                    //display event info
                    richtextbox.Text = richtextbox.Text + "You have created an event!\r\n";
                    c.Send(buffer);
                    isItEvent = "";
                    this.ActiveControl = tbsend;
                }
                else if (directlyToServer != "") //just request/attendance/add friends
                {
                    byte[] buffer = Encoding.Default.GetBytes(directlyToServer);
                    c.Send(buffer);
                    directlyToServer = "";
                }
                else if (tbsendTextBox != "") //just message
                {
                    //send message
                    richtextbox.Text = richtextbox.Text + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    tbsendTextBox = "#" + tbname.Text + ": " + tbsendTextBox + "\r\n";
                    byte[] buffer = Encoding.Default.GetBytes(tbsendTextBox);
                    c.Send(buffer);
                    tbsend.Clear();
                    tbsendTextBox = "";
                }
                else
                {
                    MessageBox.Show("EMPTY MESSAGE CAN NOT BE SENT");
                }
                tbsend.Clear();
            }
            catch
            {
                MessageBox.Show("ERROR: UNABLE TO SEND A MESSAGE !");
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
                catch
                {
                    System.Environment.Exit(1);
                }
            }
            else
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create Event button
            var newevent = new newevent(this);
            newevent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //See event button
            var seeevents = new seeevents(this);
            seeevents.Show();
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            // show form

            var editfriends = new editFriends(this);
            editfriends.Show();
        }




    }
}
