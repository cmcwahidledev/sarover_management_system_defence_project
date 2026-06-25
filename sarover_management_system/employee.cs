using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarover_management_system
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        public employee(string username, string role)
        {
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            emp();

            compos.Items.Insert(0, "Posation");
            compos.SelectedIndex = 0;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new room().Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new customer().Show();
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

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new salary().Show();
        }

        void emp()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from employees ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
             string.IsNullOrWhiteSpace(compos.Text) ||
             string.IsNullOrWhiteSpace(txtphone.Text) ||
              string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save karenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SqlCommand cmd = new SqlCommand("insert into employees(fullname, position, phone, email) values(@name, @pos, @ph, @em)", conn);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@pos", compos.Text);
                cmd.Parameters.AddWithValue("@ph", txtphone.Text);
                cmd.Parameters.AddWithValue("@em", txtemail.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("employe saved successfully", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emp();
                conn.Close();

                txtname.Clear();
                txtemail.Clear();
                txtphone.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("employee is already exists", "400", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            emp();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtname.Text = row.Cells["fullName"].Value.ToString();
                    compos.Text = row.Cells["position"].Value.ToString();
                    txtphone.Text = row.Cells["phone"].Value.ToString();
                    txtemail.Text = row.Cells["email"].Value.ToString();
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
            string.IsNullOrWhiteSpace(compos.Text) ||
            string.IsNullOrWhiteSpace(txtphone.Text) ||
             string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta update karenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["emp_id"].Value);

                SqlCommand cmd = new SqlCommand("update employees set fullname=@name , position=@pos , phone=@ph , email=@em where emp_id=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@pos", compos.Text);
                cmd.Parameters.AddWithValue("@ph", txtphone.Text);
                cmd.Parameters.AddWithValue("@em", txtemail.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update employee success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                emp();

                txtname.Clear();
                txtemail.Clear();
                txtphone.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "404", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["emp_id"].Value);


            SqlCommand cmd = new SqlCommand("delete from employees where emp_id=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete employee success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            emp();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from employees where emp_id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new report().Show();
        }
    }
}
