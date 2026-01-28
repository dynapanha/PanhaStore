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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void LoadForm(Form form)
        {
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.RemoveAt(0);
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.Show();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageProduct());
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageCategoryAndExchangeRateAndDiscount());
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderProduct());
        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new Dashboard());
        }
    }
}
