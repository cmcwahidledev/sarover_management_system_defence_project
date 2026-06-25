using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace sarover_management_system
{
    public partial class customer : Form
    {

        public customer()
        {
            InitializeComponent();
        }

        public customer(string username, string role)
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new reservation().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        void cust()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from customers ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
               string.IsNullOrWhiteSpace(txtphone.Text) ||
               string.IsNullOrWhiteSpace(txtemail.Text) ||
                   string.IsNullOrWhiteSpace(txtaddress.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save kareenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = txtemail.Text;

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("fadlan kali email sax ah", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO customers(fullName, phone, email, address) VALUES (@name, @phone, @email, @address)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("customer saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cust();
                txtname.Clear();
                txtphone.Clear();
                txtemail.Clear();
                txtaddress.Clear();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("customer is already exists", "400", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void customer_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cust();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cust();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtname.Text = row.Cells["fullName"].Value.ToString();
                    txtphone.Text = row.Cells["phone"].Value.ToString();
                    txtemail.Text = row.Cells["email"].Value.ToString();
                    txtaddress.Text = row.Cells["address"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
              string.IsNullOrWhiteSpace(txtphone.Text) ||
              string.IsNullOrWhiteSpace(txtemail.Text) ||
                  string.IsNullOrWhiteSpace(txtaddress.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta update kareenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = txtemail.Text;

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("fadlan kali email sax ah", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["customer_id"].Value);


                SqlCommand cmd = new SqlCommand("update customers set fullName=@name ,phone=@phone ,email=@email, address=@address  where customer_id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update customer success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                cust();

                txtname.Clear();
                txtphone.Clear();
                txtemail.Clear();
                txtaddress.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from customers where customer_id='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("fadlan xogta aad searching-ka kali thanks ", "400", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                SqlCommand cmd = new SqlCommand("select * from customers where customer_id=@id OR fullName like @name +'%'", conn);
                cmd.Parameters.AddWithValue("@id", txtsearch.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["customer_id"].Value);


            SqlCommand cmd = new SqlCommand("delete from customers where customer_id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete customer success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            cust();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new room().Show();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
