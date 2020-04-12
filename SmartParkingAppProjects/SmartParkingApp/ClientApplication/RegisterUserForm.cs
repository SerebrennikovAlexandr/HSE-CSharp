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
    public partial class RegisterUserForm : Form
    {
        ClientApplicationForm _parent;
        User _user;
        public RegisterUserForm()
        {
            InitializeComponent();
        }

        public RegisterUserForm(ClientApplicationForm form) : this()
        {
            _parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool created = true;

            if (!CheckName(textBox1.Text))
            {
                label6.Text = "Incorrect Name";
                created = false;
            }
                
            if (!CheckCarPlateNumber(textBox2.Text))
            {
                label6.Text = "Incorrect CarPlateNumber";
                created = false;
            }
                
            if (!CheckTelephone(textBox3.Text, _parent.Users))
            {
                label6.Text = "Incorrect Telephone!";
                created = false;
            }

            if (created)
            {
                
                int id = _parent.Users[_parent.Users.Count - 1].Id + 1;
                
                _user = new User(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                label5.Text = _user.ToString();
                _parent.NewUser = _user;
                Close();
            }
            else
            {
                label6.Text = "Try again :(";
            }
        }

        static bool CheckName(string name)
        {
            for (int i = 0; i < name.Length; i++)
                if (!(name[i] >= 'a' & name[i] <= 'z' || name[i] == ' ' || name[i] >= 'A' & name[i] <= 'Z'))
                    return false;

            return true;
        }

        static bool CheckCarPlateNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
                if (!(number[i] >= 'A' & number[i] <= 'Z' || number[i] >= '0' & number[i] <= '9'))
                    return false;

            return true;
        }

        static bool CheckTelephone(string number, List<User> users)
        {
            if (number == "")
                return false;
            if (number[0] != '+')
                return false;
            for (int i = 1; i < number.Length; i++)
                if (!(number[i] >= '0' & number[i] <= '9'))
                    return false;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Phone.Equals(number))
                    return false;
            }

            return true;
        }
    }
}
