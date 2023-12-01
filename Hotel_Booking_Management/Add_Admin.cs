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
    public partial class Add_Admin : Form
    {
        public Add_Admin()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_addadmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@username", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = textBox1.Text;

                SqlParameter param2 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = textBox2.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    MessageBox.Show("Admin Added successfully");
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
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main obj = new Admin_Main();
            obj.Show();
            this.Hide();
        }
    }
}
