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
    public partial class User_Details : Form
    {
        public User_Details()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);

        private void User_Details_Load(object sender, EventArgs e)
        {
            viewdata();
        }
        private void viewdata()
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_view_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void srh_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_user_search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@value", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand("sp_delete_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@id", SqlDbType.Int);
                cmd.Parameters.Add(param1).Value = textBox2.Text;
                if (MessageBox.Show("Are you sure delete ?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Data deleted successfully");

                }
                else
                {
                    MessageBox.Show("Data was not deleted");

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            viewdata();

        }
        private void sign_btn_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_update_Register", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@id", SqlDbType.Int);
                cmd.Parameters.Add(param1).Value = textBox3.Text;

                SqlParameter param2 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = textBox4.Text;

                SqlParameter param3 = new SqlParameter("@email", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = textBox5.Text;

                SqlParameter param4 = new SqlParameter("@age", SqlDbType.Int);
                cmd.Parameters.Add(param4).Value = textBox6.Text;

                SqlParameter param5 = new SqlParameter("@mobile", SqlDbType.Int);
                cmd.Parameters.Add(param5).Value = textBox7.Text;

                SqlParameter param6 = new SqlParameter("@username", SqlDbType.VarChar);
                cmd.Parameters.Add(param6).Value = textBox8.Text;

                SqlParameter param7 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(param7).Value = textBox9.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox7.Text = string.Empty;
                    textBox8.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    MessageBox.Show("Updated successfully...");
                    viewdata();
                }
                else
                {
                    MessageBox.Show("Details cannot be Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main obj = new Admin_Main();
            obj.Show();
            this.Hide();
        }

       
    }
}
