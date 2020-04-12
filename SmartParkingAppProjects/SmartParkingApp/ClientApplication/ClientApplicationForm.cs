using System;
using SmartParkingAppLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartParkingAppLib.Models;

namespace ClientApplication
{
    public partial class ClientApplicationForm : Form
    {
        public List<User> Users { get; set; } 
        public User NewUser { get; set; }
        public ParkingManager _parkingManager;

        public ClientApplicationForm()
        {
            InitializeComponent();
            _parkingManager = new ParkingManager();

            Users = _parkingManager.users;

            foreach (var user in Users)
                _parkingManager.EnterParking(user.CarPlateNumber);

            ParkingSession parkingSession = new ParkingSession();

            if (Users[0] != null)
                _parkingManager.TryLeaveParkingByCarPlateNumber(Users[0].CarPlateNumber, out parkingSession);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUser = null;

            RegisterUserForm regForm = new RegisterUserForm(this);
            this.Visible = false;
            regForm.ShowDialog();

            this.Visible = true;
            if (NewUser != null)
                _parkingManager.users.Add(NewUser);
            _parkingManager.SaveUserData();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            User user = _parkingManager.Users.Find(x => x.Phone.Equals(emailTextBox.Text));

            try
            {
                CheckPassword(user);
                MainClientForm clientForm = new MainClientForm(this, user);
                emailTextBox.Text = "";
                passwordTextBox.Text = "";  
                this.Visible = false;
                clientForm.ShowDialog();
                this.Visible = true;
            }
            catch(AuthException ex)
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void CheckPassword(User user)
        {
            if (user == null)
                throw new AuthException("The user with such login doesn't exist!");
            else if (user.Password != passwordTextBox.Text)
                throw new AuthException("Incorrect password!");
                
        }
    }
}
