using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ParkingApp
{
    public partial class RegistrationForm : Form
    {

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void startButon_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
                SetErrorMessage("Enter your name, please:");
            else if (textNumber.Text == "")
                SetErrorMessage("Enter your phone number, please:");
            else if (textCar.Text == "")
                SetErrorMessage("Enter car plate number, please:");
            else if (textPass.Text == "")
                SetErrorMessage("Enter password, please:");
            else if (textRepeatPass.Text == "")
                SetErrorMessage("Repeat password, please:");
            else if (textPass.Text != textRepeatPass.Text)
                SetErrorMessage("Passwords you entered must be equal:");
            else if (!Regex.IsMatch(textNumber.Text, @"[0-9+]{11,12}"))
                SetErrorMessage("Incorrect phone number format:");
            else
            {
                ParkingManager parkingManager = new ParkingManager();
                bool isUnique = true;
                int newId = 0;
                foreach(var user in parkingManager.Users)
                {
                    newId = Math.Max(newId, user.Id);
                    if (user.Phone == textNumber.Text)
                        isUnique = false;
                }
                if (!isUnique)
                    SetErrorMessage("User with this phone number's already registered");
                else
                {
                    User user = new User(newId + 1, textName.Text,
                        textCar.Text, textNumber.Text, textPass.Text);
                    parkingManager.Users.Add(user);
                    parkingManager.SerializeAllUsers();
                    MainForm logForm = new MainForm(user);
                    Visible = false;

                    logForm.ShowDialog();

                    Close();
                }
            }
        }

        private void SetErrorMessage(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }
    }
}
