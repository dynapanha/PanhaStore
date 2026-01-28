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

namespace POS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dtpDay.Format = DateTimePickerFormat.Custom;
            dtpDay.CustomFormat = "MM/dd/yyyy";

            LoadExpense();
            LoadOveralIncome();
            LoadTodayIncome();
        }

      

        private void LoadExpense()
        {
            try
            {
                string sql = "select ISNULL(sum(cast(qty as float) * cast(unit_price_in as float)),0) from tblOrderDetail";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                double total = 0;
                if (r.Read())
                {
                    total = double.Parse(r[0].ToString());
                }

                r.Close();
                s.Dispose();

                lblExpense.Text = total.ToString("c2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOveralIncome()
        {
            try
            {
                string sql = "select ISNULL(sum(cast(qty as float) * (cast(unit_price_out as float) - cast(unit_price_in as float))),0) from tblOrderDetail";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                double total = 0;
                if (r.Read())
                {
                    total = double.Parse(r[0].ToString());
                }

                r.Close();
                s.Dispose();

                lblOveralIncome.Text = total.ToString("c2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTodayIncome()
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                string sql = $"select ISNULL(sum(cast(od.qty as float) * (cast(od.unit_price_out as float) - cast(od.unit_price_in as float))),0) " +
                             $"from tblOrder o inner join tblOrderDetail od on o.ord_id = od.ord_id " +
                             $"where CONVERT(date,o.ord_date)='{today}'";

                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                double total = 0;
                if (r.Read())
                {
                    total = double.Parse(r[0].ToString());
                }

                r.Close();
                s.Dispose();

                lblTodayIncome.Text = total.ToString("c2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIncomeByDay()
        {
            try
            {
                string day = dtpDay.Value.ToString("yyyy-MM-dd");

                string sql = $"select ISNULL(sum(cast(od.qty as float) * (cast(od.unit_price_out as float) - cast(od.unit_price_in as float))),0) " +
                             $"from tblOrder o inner join tblOrderDetail od on o.ord_id = od.ord_id " +
                             $"where CONVERT(date,o.ord_date)='{day}'";

                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                double total = 0;
                if (r.Read())
                {
                    total = double.Parse(r[0].ToString());
                }

                r.Close();
                s.Dispose();

                lblIncomeByDay.Text = total.ToString("c2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadIncomeByDay();
        }
    }
}
