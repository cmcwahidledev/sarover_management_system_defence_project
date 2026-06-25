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
    public partial class reservation : Form
    {
        public reservation()
        {
            InitializeComponent();
        }

        public reservation(string username, string role)
        {
            InitializeComponent();
        }
        private void panel2_Paint(object sender, EventArgs e)
        {
       
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labe31_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void reservation_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reser();

            comstatus.Items.Insert(0, "Status");
            comstatus.SelectedIndex = 0;
        }

        void reser()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select reservation.reser_id, customers.fullName as CustomerName, reservation.room_id, reservation.CheckINDate, reservation.CheckOutDate, reservation.Status from reservation inner join customers on reservation.customer_id = customers.customer_id", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comstatus.Text) ||
               string.IsNullOrWhiteSpace(txtroomid.Text) ||
               string.IsNullOrWhiteSpace(txtcustid.Text))
            {
                MessageBox.Show("fadlan buuxi dhaman xogta save karenayso.\n xasuusin Date-ka ha ilaawin🙏", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO reservation(customer_id, room_id, CheckINDate, CheckOutDate, Status) VALUES (@customerID, @RoomsID, @CheckINDate, @CheckOutDate, @Status)", conn);

                cmd.Parameters.AddWithValue("@customerID", txtcustid.Text);
                cmd.Parameters.AddWithValue("@RoomsID", txtroomid.Text);
                cmd.Parameters.AddWithValue("@Status", comstatus.Text);
                cmd.Parameters.AddWithValue("@CheckINDate", DateTime.Parse(dateIn.Text));
                cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dateOut.Text));

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Reservation Saved SuccessFully!", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reser();

                txtroomid.Clear();
                txtcustid.Clear();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("reservation is already exists", "400", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            reser();
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                SqlCommand cmd = new SqlCommand("select * from reservation where reser_id='" + txtsearch.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }catch(SqlException ex)
            {
               MessageBox.Show(ex.Message, "400", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["reser_id"].Value);


                SqlCommand cmd = new SqlCommand("delete from reservation where reser_id=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete reservation success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                reser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtroomid.Text)) {
                MessageBox.Show("fadlan buuxi dhaman xogta update kareenayso", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=Hotel_management_system;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["reser_id"].Value);


                SqlCommand cmd = new SqlCommand("update reservation set room_id=@roomid ,CheckOutDate=@checkOut where reser_id=@ID", conn);

                cmd.Parameters.AddWithValue("@roomid", txtroomid.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@checkOut",DateTime.Parse(dateOut.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update reservation success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                reser();


                txtroomid.Clear();
                txtcustid.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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
