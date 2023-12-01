using aspform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Booking_Management
{
    public partial class Admin_Main : Form
    {
        public Admin_Main()
        {
            InitializeComponent();
        }


        private void reg_btn_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            User_Details obj = new User_Details();
            obj.Show();
            this.Hide();
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            Add_Admin obj = new Add_Admin();
            obj.Show();
            this.Hide();
        }

        private void log_btn_Click(object sender, EventArgs e)
        {
            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

     
    }
}
