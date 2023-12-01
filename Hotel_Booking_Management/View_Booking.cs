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

namespace Hotel_Booking_Management
{
    public partial class View_Booking : Form
    {
        public View_Booking()
        {
            InitializeComponent();
        }
        static string connection = ConfigurationManager.ConnectionStrings["jkcon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);

        private void View_Booking_Load(object sender, EventArgs e)
        {
            viewdata();
        }
           private void viewdata()
           { 
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_view_customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
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
        private void srh_btn_Click(object sender, EventArgs e)
        {
            try
            { 
                SqlCommand cmd = new SqlCommand("sp_view_search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@value", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = textBox1.Text;
                con.Open();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Main obj = new Main();
            obj.Show();
            this.Hide();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_view_delete", con);
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
    }
}
