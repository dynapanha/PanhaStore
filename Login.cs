using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string dbname = "DynaPanha";
                string ip = "DYNAPANHA\\MSSQLSERVER1";
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                DataConnection.ConnectionDB(ip, dbname, username, password);
                new MainForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "dynapanha";
            txtPassword.Text = "dynapanha";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
