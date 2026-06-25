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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar2.Width += 8;
            if (guna2ProgressBar2.Width >= 348)
            {
                this.Hide();
                timer1.Stop();
                new login().Show();
            }

            }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void splash_Load(object sender, EventArgs e)
        {

        }
    }
}
