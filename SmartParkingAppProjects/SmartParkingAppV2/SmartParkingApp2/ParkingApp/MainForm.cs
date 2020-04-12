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
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(User user) : this()
        {
            currentUser = user;
            label1.Text += currentUser.Name + "!";
            ParkingManager parkingManager = new ParkingManager();
            foreach(var session in parkingManager.ActiveSessions)
            {
                if(session.CarPlateNumber == currentUser.CarPlateNumber)
                {
                    textActiveSession.Text += session.ToString();
                    textActiveSession.Text += "Remaining cost: " + parkingManager.GetRemainingCost(session.TicketNumber).ToString() + "\r\n";
                    textActiveSession.Text += "=============================================\r\n";
                }
            }
            if (textActiveSession.Text == "")
                textActiveSession.Text = "You don't have any active sessions";
            foreach (var session in parkingManager.PastSessions)
            {
                if (session.CarPlateNumber == currentUser.CarPlateNumber)
                {
                    textCompletedSessions.Text += session.ToString();
                    textCompletedSessions.Text += "=============================================\r\n";
                }
            }
        }
    }
}
