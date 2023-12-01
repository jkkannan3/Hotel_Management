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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Booking_Management
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);

        private void sign_btn_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_add_Register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = textBox1.Text;

                SqlParameter param2 = new SqlParameter("@email", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = textBox2.Text;

                SqlParameter param3 = new SqlParameter("@age", SqlDbType.Int);
                cmd.Parameters.Add(param3).Value = textBox3.Text;

                SqlParameter param4 = new SqlParameter("@mobile", SqlDbType.Int);
                cmd.Parameters.Add(param4).Value = textBox4.Text;

                SqlParameter param5 = new SqlParameter("@username", SqlDbType.VarChar);
                cmd.Parameters.Add(param5).Value = textBox5.Text;

                SqlParameter param6 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(param6).Value = textBox6.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    MessageBox.Show("Registered successfully");

                }
                else
                {
                    MessageBox.Show("Data cannot be Registered");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main obj = new Admin_Main();
            obj.Show();
            this.Hide();
        }

    
    }
}
