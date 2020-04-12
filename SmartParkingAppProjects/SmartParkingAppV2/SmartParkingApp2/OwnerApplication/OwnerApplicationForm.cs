using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwnerApplication
{
    public partial class OwnerApplicationForm : Form
    {
        ParkingManager _pm;
        DataTable _activeDt;
        DataTable _passedDt;
        public OwnerApplicationForm()
        {
            InitializeComponent();
            _pm = new ParkingManager();
            capacityLabel.Text = "";
            percentageLabel.Text = "";
            usedPlacesLabel.Text = "";
            CreateDataTable("Active");
            CreateDataTable("Passed");
            dataGridView1.DataSource = _activeDt;
            dataGridView2.DataSource = _passedDt;
            capacityLabel.Text = _pm.parkingCapacity.ToString();
            usedPlacesLabel.Text = _pm.ActiveSessions.Count.ToString();
            percentageLabel.Text = ((double)_pm.ActiveSessions.Count / _pm.parkingCapacity * 100).ToString() + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal? profit = 0;

            DateTime from = dateTimePicker1.Value;
            DateTime to = dateTimePicker2.Value;

            for (int i = 0; i < _pm.PastSessions.Count; i++)
            {
                ParkingSession temp = _pm.PastSessions[i];

                if (temp.EntryDt > from && temp.ExitDt < to)
                    profit += temp.TotalPayment;
            }

            label10.Text = "Profit: " + profit.ToString();
        }
        void CreateDataTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);

            DataColumn[] columns = new DataColumn[8] {new DataColumn("ID", typeof(int)), new DataColumn("EntryDt", typeof(string)),
                new DataColumn("PaymentDt", typeof(string)), new DataColumn("ExitDt", typeof(string)),
                new DataColumn("Total Payment", typeof(decimal)), new DataColumn("CarPalteNumber", typeof(string)),
                new DataColumn("TicketNumber", typeof(int)), new DataColumn("UserID", typeof(int))};

            dt.Columns.AddRange(columns);

            if (tableName == "Active")
            {
                for (int i = 0; i < _pm.ActiveSessions.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    ParkingSession temp = _pm.ActiveSessions[i];
                    dr[0] = i;
                    dr[1] = temp.EntryDt == null ? "-" : temp.EntryDt.ToString();
                    dr[2] = temp.PaymentDt == null ? "-" : temp.PaymentDt.ToString();
                    dr[3] = temp.ExitDt == null ? "-" : temp.ExitDt.ToString();
                    dr[4] = temp.TotalPayment == null ? 0 : temp.TotalPayment;
                    dr[5] = temp.CarPlateNumber;
                    dr[6] = temp.TicketNumber;
                    dr[7] = temp.UserId;

                    dt.Rows.Add(dr);
                }
                _activeDt = dt;
            }
            else if (tableName == "Passed")
            {
                
                for (int i = 0; i < _pm.PastSessions.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    ParkingSession temp = _pm.PastSessions[i];
                    dr[0] = i;
                    dr[1] = temp.EntryDt == null ? "-" : temp.EntryDt.ToString();
                    dr[2] = temp.PaymentDt == null ? "-" : temp.PaymentDt.ToString();
                    dr[3] = temp.ExitDt == null ? "-" : temp.ExitDt.ToString();
                    dr[4] = temp.TotalPayment == null ? 0 : temp.TotalPayment;
                    dr[5] = temp.CarPlateNumber;
                    dr[6] = temp.TicketNumber;
                    dr[7] = temp.UserId;

                    dt.Rows.Add(dr);
                }
                _passedDt = dt;
            }
        }
    }
}
