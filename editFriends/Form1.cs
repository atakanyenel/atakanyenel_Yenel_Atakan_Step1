using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editFriends
{
    public partial class editfriends : Form
    {
        //each client recieves list when connection begins, just like events
        //1. friends(should be empty)
        //2. request(should be empty)
        //3. list of client name - himself
        public editfriends()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public editfriends(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        public void addFriends()
        {
            //check if listBox for add friends is selected
            //@c1(sending request)@c2(reciving request)@
            this.mainForm.setIsItAddFri("@" + /*c1*/ + "@" + /*c2*/ + "@");
        }

        public void acceptFridns()
        {

        }

        //listBox1:
        //1. requested
        //2. all clients - himself - requested - friends

        //listBox2:
        //1. friends

        //add button
        //1. if not requested not friend>>add to requested
        //2. if requested>>remove from requested + add to friend
        //3. if friends>>THIS SHOULD NOT EXIST

        //remove button
        //1. if already not friend>>THIS SHOULD NOT EXIST
        //2. else remove from requested/friends

        //refresh button
        //get list of
        //1. client names
        //2. request
        //3. friend list
        //clear both listbox
        //get list from client master
        //display them
    }
}
