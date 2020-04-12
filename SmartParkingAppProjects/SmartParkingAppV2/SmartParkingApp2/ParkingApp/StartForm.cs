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
    public partial class StartForm : Form
    {
        private Random rand;

        public StartForm()
        {
            InitializeComponent();
            EmulateUserActivity();
            rand = new Random();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            Visible = false;

            regForm.ShowDialog();

            Visible = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm logForm = new LoginForm(this);
            Visible = false;

            logForm.ShowDialog();

            Visible = true;
        }

        private void EmulateUserActivity()
        {
            ParkingManager parkingManager = new ParkingManager();
            for(int i = 0; i < parkingManager.Users.Count; i++)
            {
                parkingManager.EnterParking(parkingManager.Users[i].CarPlateNumber);
                ParkingSession session = new ParkingSession();
                parkingManager.TryLeaveParkingByCarPlateNumber(parkingManager.Users[i].CarPlateNumber, out session);
            }
            for (int i = 0; i < parkingManager.Users.Count/2; i++)
            {
                parkingManager.EnterParking(parkingManager.Users[i].CarPlateNumber);
                ParkingSession session = new ParkingSession();
            }
        }
    }
}
