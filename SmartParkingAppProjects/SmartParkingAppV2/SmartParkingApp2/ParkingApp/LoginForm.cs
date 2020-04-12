using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingApp
{
    public partial class LoginForm : Form
    {
        private StartForm previousForm;
        private ParkingManager parkingManager;

        public LoginForm()
        {
            InitializeComponent();
            parkingManager = new ParkingManager();
        }

        public LoginForm(StartForm previousForm) : this()
        {
            this.previousForm = previousForm;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(textLogin.Text == "" && textPass.Text == "")
                SetErrorMessage("Please, enter your login and password");

            else if(textLogin.Text == "")
                SetErrorMessage("Please, enter your login");

            else if(textPass.Text == "")
                SetErrorMessage("Please, enter your password");

            else
            {
                bool foundUser = false;
                foreach(var user in parkingManager.Users)
                {
                    if(user.Phone == textLogin.Text && user.Password == textPass.Text)
                    {
                        foundUser = true;
                        MainForm logForm = new MainForm(user);
                        Visible = false;

                        logForm.ShowDialog();

                        Close();
                    }
                }

                if (!foundUser)
                    SetErrorMessage("Such user doesn't exist, go back and sign up");
            }
        }

        private void SetErrorMessage(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }
    }
}
