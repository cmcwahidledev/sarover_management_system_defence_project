using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;

namespace sarover_management_system
{
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
        }

        public salary(string username, string role)
        {
            InitializeComponent();
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

        void slr()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            //SqlDataAdapter da = new SqlDataAdapter("select * from  salary", conn);
            SqlDataAdapter da = new SqlDataAdapter("select salary.salary_id, employees.fullName as EmployeeName, salary.basicsalary, salary.bonus, salary.deducation, salary.netsalary from salary inner join employees on salary.emp_id = employees.emp_id", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text) ||
              string.IsNullOrWhiteSpace(txtbasic.Text) ||
              string.IsNullOrWhiteSpace(txtbonus.Text) ||
               string.IsNullOrWhiteSpace(txtdeduc.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save karenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into salary(emp_id, basicsalary, bonus, deducation)values(@emp, @basi, @bonus, @deduc)", conn);

                cmd.Parameters.AddWithValue("@emp", txtempid.Text);
                cmd.Parameters.AddWithValue("@basi", txtbasic.Text);
                cmd.Parameters.AddWithValue("@bonus", txtbonus.Text);
                cmd.Parameters.AddWithValue("@deduc", txtdeduc.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("salary saved successfully", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                slr();
                conn.Close();

                txtempid.Clear();
                txtbasic.Clear();
                txtbonus.Clear();
                txtdeduc.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("salary is already exists", "400", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void salary_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            slr();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            slr();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtempid.Text = row.Cells["emp_id"].Value.ToString();
                    txtbasic.Text = row.Cells["basicsalary"].Value.ToString();
                    txtbonus.Text = row.Cells["bonus"].Value.ToString();
                    txtdeduc.Text = row.Cells["deducation"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from salary where salary_id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["salary_id"].Value);


                SqlCommand cmd = new SqlCommand("delete from salary where salary_id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete salary success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                slr();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.Hide();
            new report().Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text) ||
             string.IsNullOrWhiteSpace(txtbasic.Text) ||
             string.IsNullOrWhiteSpace(txtbonus.Text) ||
              string.IsNullOrWhiteSpace(txtdeduc.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save karenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["salary_id"].Value);


                SqlCommand cmd = new SqlCommand("update salary set emp_id=@empid, basicsalary=@basicsalary, bonus=@bonus, deducation=@deducation  where salary_id=@ID", conn);

                cmd.Parameters.AddWithValue("@empid", txtempid.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@basicsalary", txtbasic.Text);
                cmd.Parameters.AddWithValue("@bonus", txtbonus.Text);
                cmd.Parameters.AddWithValue("@deducation", txtdeduc.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update salary success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                slr();

                txtempid.Clear();
                txtbasic.Clear();
                txtbonus.Clear();
                txtdeduc.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
