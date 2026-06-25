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

namespace sarover_management_system
{
    public partial class room : Form
    {
        public room()
        {
            InitializeComponent();
        }

        public room(string username, string role)
        {
            InitializeComponent();
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

        private void room_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ROM();

            comtype.Items.Insert(0, "Room Type");
            comtype.SelectedIndex = 0;

            comstatus.Items.Insert(0, "Status");
            comstatus.SelectedIndex = 0;

        }

        void ROM()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from rooms ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtroomnum.Text) ||
              string.IsNullOrWhiteSpace(comtype.Text) ||
              string.IsNullOrWhiteSpace(txtprice.Text) ||
                  string.IsNullOrWhiteSpace(comstatus.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save kareenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomNum =Convert.ToInt32(txtroomnum.Text);
            if (roomNum > 135)
            {
                MessageBox.Show($"fadlan qolkan {roomNum} ma jiro thank you", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO rooms(RoomNumber, Price, Roomtype, Status) VALUES (@num, @price, @type, @status)", conn);

                cmd.Parameters.AddWithValue("@num", txtroomnum.Text);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@type", comtype.Text);
                cmd.Parameters.AddWithValue("@status", comstatus.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Room saved successFully!", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ROM();

                txtroomnum.Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("room is already exists", "400", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from rooms where Room_id='" + txtsearch.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Room_id"].Value);


            SqlCommand cmd = new SqlCommand("delete from rooms where Room_id=@id", conn);

            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete room success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            ROM();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ROM();
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtroomnum.Text = row.Cells["RoomNumber"].Value.ToString();
                    txtprice.Text = row.Cells["Price"].Value.ToString();
                    comtype.Text = row.Cells["Roomtype"].Value.ToString();
                    comstatus.Text = row.Cells["Status"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtprice.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta update kareenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomNum = Convert.ToInt32(txtroomnum.Text);
            if (roomNum > 135)
            {
                MessageBox.Show($"fadlan qolkan {roomNum} ma jiro thank you", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Room_id"].Value);


                SqlCommand cmd = new SqlCommand("update rooms set Price=@price where Room_id=@ID", conn);

                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update room success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                ROM();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
