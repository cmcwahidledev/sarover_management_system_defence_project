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
using System.Xml.Linq;

namespace sarover_management_system
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
             string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta thank you", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
                SqlCommand cmd = new SqlCommand("select * from users where username=@name and password=@pass", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("login success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    new dashboard().Show();
                }
                else
                {
                    MessageBox.Show("username or password is failed", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtpass.Clear();
                txtname.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !txtpass.UseSystemPasswordChar;
            if (txtpass.UseSystemPasswordChar)

                lbley.Text = "👁️";
            else
                lbley.Text = "👁️";
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
