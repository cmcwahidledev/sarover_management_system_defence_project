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

namespace sarover_management_system
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        public dashboard(string username, string role)
        {
            InitializeComponent();
        }

        private void guna2GradientPanel12_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
         
                  
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void dashboard_Load(object sender, EventArgs e)
        {
            check();
            cust();
            room();
            emp();
            slr();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        void slr()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from  salary", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void check()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(CheckINDate) from reservation", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblcheck.Text = result.ToString();
            }
            else
            {
                lblcheck.Text = "0";
            }
            conn.Close();
        }


        private void cust()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from customers", conn);
            conn.Open();
            object resu = cmd.ExecuteScalar();
            if (resu != DBNull.Value)
            {
                lblcust.Text = resu.ToString();
            }
            else
            {
                lblcust.Text = "0";
            }
            conn.Close();
        }


        private void room()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from rooms", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblroom.Text = result.ToString();
            }
            else
            {
                lblroom.Text = "0";
            }
            conn.Close();
        }


        private void emp()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from employees", conn);
            conn.Open();
            object resu = cmd.ExecuteScalar();
            if (resu != DBNull.Value)
            {
                lblemp.Text = resu.ToString();
            }
            else
            {
                lblemp.Text = "0";
            }
            conn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new reservation().Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new room().Show();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new employee().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new salary().Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new report().Show();
        }
    }
    
}
