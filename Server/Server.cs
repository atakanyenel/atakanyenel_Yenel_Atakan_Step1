using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

//SERVER SIDE

namespace CS408_Step1_Server
{
    public partial class Server : Form
    {
        class client
        {
            public string name;
            public Socket clisoc;
            public int attending;
            public List<string> friendsList = new List<string>();
            public List<string> requestList = new List<string>();
            internal void setname(string strclientname)
            {
                name = strclientname;
            }
            internal void setsocket(Socket yeni)
            {
                clisoc = yeni;
            }
            internal Socket getsocket()
            {
                return clisoc;
            }
            internal string getname()
            {
                return name;
            }
            internal string getstringfriendsList(int a)
            {
                return friendsList[a];
            }
            internal string getstringrequestList(int a)
            {
                return requestList[a];
            }
            internal int getfriendsListCountc()
            {
                return friendsList.Count;
            }
            internal int getrequestListCountc()
            {
                return requestList.Count;
            }
            public void addFriend(string newfriend)
            {
                friendsList.Add(newfriend);
            }
            public void addRequest(string newfriend)
            {
                requestList.Add(newfriend);
            }
            // public bool delFriend(string newfriend)
            // {
            //     //How to use remove?
            // }
        };

        DateTime Time;
        List<client> clientarray = new List<client>();
        List<events> eventsarray = new List<events>();
        events tempe = new events();
        Thread thraccept;
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket n;

        public Server()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        public int getFriendsListCount(int a)
        {
            return clientarray[a].getfriendsListCountc();
        }

        public string getFriendsListItem(int a, int b)
        {
            return clientarray[a].getstringfriendsList(b);
        }

        public int getRequestListCount(int a)
        {
            return clientarray[a].getrequestListCountc();
        }

        public string getRequestListItem(int a, int b)
        {
            return clientarray[a].getstringrequestList(b);
        }

        public void addToRequestList(string c1, string c2)
        {
            //put c1 into c2's request List
            int cc = clientarray.Count;
            for (int i = 0; i < cc; i++)
            {
                if (clientarray[i].getname() == c2)
                {
                    clientarray[i].addRequest(c1);
                }
            }
        }

        public int searchClientID(string un)
        {
            int cc = clientarray.Count;
            for (int i = 0; i < cc; i++)
            {
                if (clientarray[i].getname() == un)
                {
                    return i;
                }
            }
            return -1;
        }

        public Socket searchClient(string un)
        {
            int cc = clientarray.Count;
            for (int i = 0; i < cc; i++)
            {
                if (clientarray[i].getname() == un)
                {
                    return clientarray[i].getsocket();
                }
            }
            return null;
        }

        // function for START. With this function the server starts listening to the port that is given by the user.
        // It is handled in the try/cathch method to prevent crashing of the system.
        // If an error occurs a message box will appear and inform the server administrator about the error
        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "Start!")
                try
                {
                    s.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(textBox1.Text)));
                    s.Listen(Convert.ToInt32(textBox1.Text));
                    thraccept = new Thread(new ThreadStart(Accept));
                    thraccept.Start();
                    textBox1.Enabled = false;
                    start.Text = "Stop!";
                    richTextBox1.Text += "Server is now listening at port " + textBox1.Text + ".\r\n";
                }
                catch
                {
                    MessageBox.Show("ERROR: SERVER IS UNABLE TO START");
                }

                // if a user wants to close the server a messagebox appears. It is the same procedure s with the server closing.
            // the procedure is differnet if there are clients connected and if there is none
            else
            {
                int clientnumber = clientarray.Count;
                if (clientnumber > 0)
                {
                    DialogResult DR = MessageBox.Show("There are " + clientnumber + " client(s) connected to server.\n Are you sure ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DR == DialogResult.Yes)
                    {
                        foreach (client c in clientarray)
                        {
                            c.getsocket().Close();
                        }
                        clientarray.Clear();
                        s.Close();
                        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        richTextBox1.Text += "Server stopped listening at port " + textBox1.Text + ".\r\n";
                        start.Text = "Start!";
                        textBox1.Enabled = true;
                    }
                    else
                    {
                    }
                }
                else if (clientnumber == 0)
                {
                    DialogResult DR = MessageBox.Show("Are you sure ?", "Server ShutDown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DR == DialogResult.Yes)
                    {
                        start.Text = "Start!";
                        textBox1.Enabled = true;
                        s.Close();                                 //Shut the listening Socket !!!
                        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Redefine the listening socket so it unbinds
                        richTextBox1.Text += "Server stopped listening at port " + textBox1.Text + ".\r\n";
                    }
                }
            }
        }

        // communication with the clients
        private void Accept()
        {
            try
            {
                while (true)
                {
                    n = s.Accept();
                    Thread namereceive;
                    namereceive = new Thread(new ParameterizedThreadStart(Receivename));
                    namereceive.Start(n);
                }
            }
            catch
            {
                // does something happen here?
            }
        }

        private void Receivename(object o)
        {
            try
            {
                Socket yeni = (Socket)o;
                byte[] clientname = new byte[64];
                yeni.Receive(clientname);
                string strclientname = Encoding.Default.GetString(clientname);
                strclientname = strclientname.Substring(0, strclientname.IndexOf("\0"));
                if (checkname(strclientname))
                {
                    clientarray.Add(new client());
                    clientarray[clientarray.Count - 1].setname(strclientname);
                    clientarray[clientarray.Count - 1].setsocket(yeni);
                    string serveranswer = "1";
                    byte[] send = Encoding.Default.GetBytes(serveranswer);
                    yeni.Send(send);
                    Time = DateTime.Now;
                    richTextBox1.Text += "-> " + strclientname + " has connected at " + Time + "." + "\r\n";
                    byte[] sendmessage = new byte[64];
                    string joinedmsg = strclientname + " has joined the conversation.";
                    sendmessage = Encoding.Default.GetBytes(joinedmsg);
                    foreach (client c in clientarray)
                    {
                        if (c.getsocket() != yeni)
                        {
                            c.getsocket().Send(sendmessage);
                        }
                    }
                    bool condition = true;
                    while (condition)
                    {
                        byte[] buffer2 = new byte[64];
                        yeni.Receive(buffer2);
                        string newmessage = Encoding.Default.GetString(buffer2);
                        int pos = clientarray.IndexOf(clientarray.Find(client => client.getsocket() == yeni));
                        if (check_symbol(ref newmessage) == 2) //message
                        {
                            string clientsendername = clientarray[pos].getname();
                            sendmessage = Encoding.Default.GetBytes(newmessage);
                            for (int k = 0; k < clientarray.Count; k++)
                            {
                                if (k != pos)
                                    clientarray[k].getsocket().Send(sendmessage);
                                else
                                {
                                    Time = DateTime.Now;
                                    richTextBox1.Text = richTextBox1.Text + "-> " + clientsendername + " sent a message at " + Time + ".\r\n";
                                }
                            }
                        }
                        else if (check_symbol(ref newmessage) == 1) // event
                        {
                            string a;
                            string b = newmessage;
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

                            //store all into into a new event in eventsarray
                            events tempe = new events();
                            tempe.setDate(event_info[0]);
                            tempe.setTitle(event_info[1]);
                            tempe.setPlace(event_info[2]);
                            tempe.setDesc(event_info[3]);
                            tempe.setOrganizer(event_info[4]);
                            eventsarray.Add(tempe);

                            //richTextBox1.Text = richTextBox1.Text + "Events counter: " + eventsarray.Count.ToString() + "\r\n";
                            richTextBox1.Text = richTextBox1.Text + "Event " + event_info[1] + " has been added to List." + "\r\n\r\n";
                            foreach (client c in clientarray)
                            {
                                c.getsocket().Send(buffer2);
                            }
                            byte[] buffer33 = Encoding.Default.GetBytes("#" + event_info[4] + " just created an new event!  ");
                            foreach (client c in clientarray)
                            {
                                if (c.getsocket() != yeni)
                                {
                                    c.getsocket().Send(buffer33);
                                }
                            }
                            //we forgot to add every existing client into notReply List of that event
                        }
                        else if (check_symbol(ref newmessage) == 3) // attendance(symbol: &)
                        {
                            byte[] buffer = new byte[64];
                            buffer = Encoding.Default.GetBytes(newmessage);
                            foreach (client c in clientarray)
                            {
                                c.getsocket().Send(buffer);
                            }
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = newmessage;
                            string[] atte_rec = new string[3];
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
                            eventsarray[eID].removeGoingList(atte_rec[1]);
                            eventsarray[eID].removeNotGoingList(atte_rec[1]);
                            eventsarray[eID].removeNotReplyList(atte_rec[1]);
                            //decide where the username should be store according to event and answer
                            if (atte_rec[2] == "1") //going
                            {
                                eventsarray[eID].addGoingList(atte_rec[1]);
                            }
                            else if (atte_rec[2] == "0") //not going
                            {
                                eventsarray[eID].addNotGoingList(atte_rec[1]);
                            }
                            else
                            {
                                MessageBox.Show("You can only choose between Yes or No");
                            }
                            //send notificatino back to organizer
                            //Someone just responded to your event!
                            string replyTo = eventsarray[eID].getOrganizer();
                            byte[] buffer20 = new byte[64];
                            buffer20 = Encoding.Default.GetBytes("#Someone just responded to your event!  ");
                            Socket iney = searchClient(replyTo);
                            iney.Send(buffer20);
                        }
                        else if (check_symbol(ref newmessage) == 4) // event request(symbol: $)
                        {
                            MessageBox.Show("Sending Event list: " + clientarray.Count);
                            for (int i = 0; i < eventsarray.Count; i++)
                            {
                                //Recieved a request of event lists, so server will send them
                                //"%" + date + "%" + title + "%" + place + "%" + description + "%" + organizer + "%";
                                string event_request = "%" + eventsarray[i].getDate() + "%" + eventsarray[i].getTitle() + "%" + eventsarray[i].getPlace() + "%" + eventsarray[i].getDesc() + "%" + eventsarray[i].getOrganizer() + "%";
                                byte[] buffer = new byte[64];
                                buffer = Encoding.Default.GetBytes(event_request);
                                yeni.Send(buffer);
                                //we forgot to send goingList, notGoingList and notReplyList
                                //use 3 more for loop
                                //encode each of them like newly added attendance reply
                            }
                            MessageBox.Show("Sending complete client list: " + clientarray.Count);
                            for (int i = 0; i < clientarray.Count; i++)
                            {
                                string event_request = "^" + clientarray[i].getname()+ "^";
                                MessageBox.Show(event_request);
                                byte[] buffer = new byte[64];
                                buffer = Encoding.Default.GetBytes(event_request);
                                yeni.Send(buffer);
                            }
                            //friends list and request list should be empty at first
                        }
                        else if (check_symbol(ref newmessage) == 5) // add friends(symbol: @)
                        {
                            //decode
                            int i1 = 0;
                            int i2 = 0;
                            string A;
                            string B = newmessage;
                            string[] addfri = new string[2];
                            i1 = B.IndexOf("@");
                            A = B.Substring(i1 + 1);
                            i2 = A.IndexOf("@");
                            addfri[0] = B.Substring(1, i2);
                            B = B.Substring(i2 + 2);
                            i1 = B.IndexOf("@");
                            addfri[1] = B.Substring(0, i1);
                            //go to c2 (addfri[1])
                            int c2ID = searchClientID(addfri[1]);
                            bool alreadyFriends = false;
                            bool alreadyRequested = false;
                            int FLCount = getFriendsListCount(c2ID);
                            int RLCount = getrequestListCount(c2ID);
                            for (int i = 0; i < FLcount; i++)
                            {
                                if (getFriendsListItem(c2ID, i) == addfri[0])
                                {
                                    alreadyFriends = true;
                                }
                            }
                            for (int i = 0; i < RLCount; i++)
                            {
                                if (getRequestListItem(c2ID, i) == addfri[0])
                                {
                                    alreadyRequested = true;
                                }
                            }
                            if (alreadyRequested == false)
                            {
                                if (alreadyFriends == false)
                                {
                                    //add to request list
                                    addToRequestList(addfri[0], addfri[1]);
                                    //send message to that client immediately
                                    //send message to that client
                                    byte[] buffer64 = new byte[64];
                                    buffer64 = Encoding.Default.GetBytes("#Someone just sent you a friend request!  ");
                                    Socket iney2 = searchClient(addfri[1]);
                                    iney2.Send(buffer64);
                                    iney2.Send(buffer2);
                                }
                                else
                                {
                                    //not possible
                                    MessageBox.Show("Not Possible(alreadyFriends == true)");
                                }
                                //send a message to c1
                                //"already requestd blah blah blah"
                            }
                        }
                        else
                        {
                            Time = DateTime.Now;
                            richTextBox1.Text = richTextBox1.Text + "-> " + clientarray[pos].getname() + " has disconnected from the server at " + Time + ".\r\n ";
                            newmessage = clientarray[pos].getname() + " has left the conversation.";
                            sendmessage = Encoding.Default.GetBytes(newmessage);
                            clientarray[pos].getsocket().Close();
                            clientarray.RemoveAt(pos);
                            foreach (client c in clientarray)
                            {
                                c.getsocket().Send(sendmessage);
                            }
                            condition = false;
                        }
                    }
                    Thread.CurrentThread.Abort();
                }
                else
                {
                    string serveranswer = "0";
                    byte[] send = Encoding.Default.GetBytes(serveranswer);
                    yeni.Send(send);
                    yeni.Close();
                }
            }
            catch
            {

            }
        }

        //return what the first symbol is/what is the purpose of message
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
            else if (message.ElementAt(0) == '$') // request
            {
                return 4;
            }
            else if (message.ElementAt(0) == '@') //add friend
            {
                return 5;
            }
            else if (message.ElementAt(0) == '^') // get usernames from server (reply from server)
            {
                return 6;
            }
            return 0;
        }

        public bool friendsOrNot(string client1, string client2)
        {
            //most sending need to check if this one is true first
            return true;
        }

        private bool checkname(string name)
        {
            bool notfound = true;
            for (int f = 0; f < clientarray.Count; f++)
            {
                if (clientarray[f].getname() == name)
                {
                    notfound = false;
                    return notfound;
                }
            }
            return notfound;
        }
        // When a user tries to shut down the server, we implemented a safety mechanism. It inform the user how many clinets are connected and if he/she
        // really wants to shut down the server. When the server shuts down all the clients also shut down.
        private void Fom1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int clientnumber = clientarray.Count;
            if (clientnumber > 0)
            {
                DialogResult DR = MessageBox.Show("There are " + clientnumber + " client(s) connected to server.\n Are you sure ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (DR == DialogResult.Yes)
                {

                    System.Environment.Exit(1);
                }
                else
                {

                    e.Cancel = true;
                }
            }
            else if (clientnumber == 0)
            {
                DialogResult DR = MessageBox.Show("Are you sure ?", "Server ShutDown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    System.Environment.Exit(1);
                }
                else
                    e.Cancel = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = start;
        }
    }
}
