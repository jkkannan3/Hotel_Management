using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Hotel_Booking_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {             
                    SqlCommand cmd = new SqlCommand("sp_Register", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@uname", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = textBox1.Text;

                    SqlParameter param2 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = textBox2.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds); ;
                    int a = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                if (a > 0)
                {
                    MessageBox.Show("Valid user");
                    Main add = new Main();
                    add.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid user");
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_Login obj = new Admin_Login();
            obj.Show();
            this.Hide();
        }
    }
}
