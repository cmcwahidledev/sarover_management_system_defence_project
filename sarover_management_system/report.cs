using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarover_management_system
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        public report(string username,string role)
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            new salary().Show();
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

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void report_Load(object sender, EventArgs e)
        {
            comSelect.Items.Insert(0, "Section");
            comSelect.SelectedIndex = 0;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void comSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comSelect.SelectedItem.ToString() == "RESERVATION")
            {
                ReserReport rpt = new ReserReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (comSelect.SelectedItem.ToString() == "CUSTOMER")
            {
                CustReport rpt = new CustReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (comSelect.SelectedItem.ToString() == "ROOM")
            {
                RoomReport rpt = new RoomReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (comSelect.SelectedItem.ToString() == "EMPLOYEE")
            {
                EmployeeReport rpt = new EmployeeReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (comSelect.SelectedItem.ToString() == "SALARY")
            {
                SalaryReport rpt = new SalaryReport();
                crystalReportViewer1.ReportSource = rpt;
            }

        }
    }
}
