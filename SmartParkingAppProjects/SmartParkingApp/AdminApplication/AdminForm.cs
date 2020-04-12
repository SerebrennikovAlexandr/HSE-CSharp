using SmartParkingAppLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApplication
{
    public partial class AdminForm : Form
    {
        public ParkingManager _parkingManager;

        public AdminForm()
        {
            InitializeComponent();
            _parkingManager = new ParkingManager();

            if(_parkingManager.ActiveSessions.Count != 0)
                textBoxPercent.Text = (_parkingManager.ActiveSessions.Count * 100 / (double)_parkingManager.ParkingCapacity).ToString("0.00") + "%";
            else
                textBoxPercent.Text = "0%";

            foreach (var session in _parkingManager.ActiveSessions)
            {
                textCurrentSessions.Text += session + "\n";
                textCurrentSessions.Text += 
                    "-------------------------------------------------------------------------------------------";
            }

            foreach (var session in _parkingManager.PastSessions)
            {
                textPastSessions.Text += session + "\n";
                textPastSessions.Text +=
                    "-------------------------------------------------------------------------------------------";
            }

            textIncome.Text = "0";
                
        }

        private void countBtn_Click(object sender, EventArgs e)
        {
            decimal? res = 0;
            foreach(var session in _parkingManager.PastSessions)
            {
                if(session.ExitDt >= dateTimePickerStart.Value 
                    && session.ExitDt <= dateTimePickerEnd.Value)
                {
                    res += session.TotalPayment;
                }
            }
            textIncome.Text = res.ToString();
        }
    }
}
