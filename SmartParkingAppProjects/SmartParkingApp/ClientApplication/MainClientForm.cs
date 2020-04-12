using System;
using SmartParkingAppLib.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class MainClientForm : Form
    {
        ClientApplicationForm _parent;
        User _user;
        public MainClientForm()
        {
            InitializeComponent();
        }
        public MainClientForm(ClientApplicationForm parent) : this()
        {
            _parent = parent;
        }
        public MainClientForm(ClientApplicationForm parent, User user): this()
        {
            _parent = parent;
            _user = user;
            label1.Text = $"Welcome, {_user.Name}!";

            try
            {
                ParkingSession active = _parent._parkingManager.GetSessionByCarPlateNumber(_user.CarPlateNumber);
                textBox1.Text = active.ToString();
            }
            catch (ArgumentException ex)
            {
                textBox1.Text = "There are no active parking sesssions!";
            }
            

            string sessions = _parent._parkingManager.GetCompletedSessionsByCarPlateNumber(_user.CarPlateNumber);
            if (sessions == "")
                textBox2.Text = "There are no passed parking sessions!";
            else
                textBox2.Text = sessions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
