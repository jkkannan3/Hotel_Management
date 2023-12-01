using Hotel_Booking_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aspform
{
    public partial class New_Booking : Form
    {
        public New_Booking()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        private void Sub_btn_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_add_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = textBox1.Text;

                SqlParameter param2 = new SqlParameter("@phone", SqlDbType.Int);
                cmd.Parameters.Add(param2).Value = textBox2.Text;

                SqlParameter param3 = new SqlParameter("@idproof", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = comboBox1.Text;

                SqlParameter param4 = new SqlParameter("@tob", SqlDbType.VarChar);
                cmd.Parameters.Add(param4).Value = comboBox2.Text;

                SqlParameter param5 = new SqlParameter("@checkin", SqlDbType.DateTime);
                cmd.Parameters.Add(param5).Value = dateTimePicker1.Text;

                SqlParameter param6 = new SqlParameter("@checkout", SqlDbType.DateTime);
                cmd.Parameters.Add(param6).Value = dateTimePicker2.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    comboBox2.Text = string.Empty;
                    dateTimePicker1.Text = string.Empty;
                    dateTimePicker2.Text = string.Empty;
                    MessageBox.Show("Booked successfully...");

                }
                else
                {
                    MessageBox.Show("Details cannot be inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                dateTimePicker1.Text = string.Empty;
                dateTimePicker2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main obj = new Main();
            obj.Show();
            this.Hide();
        }
    }
}
