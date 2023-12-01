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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void hom_btn_Click(object sender, EventArgs e)
        {
            Main obj = new Main();
            obj.Show();
            this.Hide();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            New_Booking obj = new New_Booking();
            obj.Show();
            this.Hide();
        }

        private void upt_btn_Click(object sender, EventArgs e)
        {
            Update_Booking obj = new Update_Booking();
            obj.Show();
            this.Hide();
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            View_Booking obj = new View_Booking();
            obj.Show();
            this.Hide();
        }

        private void log_btn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
