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
    public partial class ManageCategoryAndExchangeRateAndDiscount : Form
    {
        public ManageCategoryAndExchangeRateAndDiscount()
        {
            InitializeComponent();
        }
        List<Category> cateName = new List<Category>();
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategory.Text.Trim();
                if (categoryName=="")
                {
                    MessageBox.Show("Please Enter Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Category c in cateName)
                {
                    if (categoryName.ToLower() == c.CategoryName.ToLower())
                    {
                        MessageBox.Show($"{categoryName} alrady exits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                string sql = $"insert into tblCategory (cate_name) values('{categoryName}')";               
                SqlCommand s = new SqlCommand(sql,DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();

                sql = "select SCOPE_IDENTITY()";
                s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                string cateID = "";
                if (r.Read())
                {
                    cateID = r[0] + "";
                }

                s.Dispose();
                r.Close();
                Category category = new Category(cateID,categoryName);
                dgCategory.Rows.Add(category.Id,category.CategoryName);
                cateName.Add(category);
                MessageBox.Show("Category Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void ManageCategory_Load(object sender, EventArgs e)
        {
            try
            {
                cateName.Clear();
                discounts.Clear();
                rate.Clear();
                string sql = "Select * from tblCategory";
                SqlCommand s=new SqlCommand(sql,DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0].ToString();
                    string cate_name=r[1].ToString();
                    Category category = new Category(id,cate_name);
                    cateName.Add(category);
                    dgCategory.Rows.Add(category.Id,category.CategoryName);
                }                
                s.Dispose();
                r.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }


            try
            {
                string sql = "Select * from tblExchangeRate";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0].ToString();
                    int exc_percent = int.Parse(r[1].ToString());
                    ExchangeRate exchange = new ExchangeRate(id, exc_percent);
                    rate.Add(exchange);
                    dgExchangeRate.Rows.Add(exchange.Id, "1$= "+exchange.Rate+" Riels");
                }
                s.Dispose();
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string sql = "Select * from tblDiscount";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0].ToString();
                    int dis_percent = int.Parse(r[1].ToString());
                    Discount discount = new Discount(id, dis_percent);
                    discounts.Add(discount);
                    dgDiscount.Rows.Add(discount.Id, discount.Dis + "%");
                }
                s.Dispose();
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCategory.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string id = dgCategory.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"delete from tblCategory where cate_id='{id}'";
                    SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                    s.ExecuteNonQuery();
                    s.Dispose();
                    cateName.RemoveAt(dgCategory.SelectedRows[0].Index);
                    dgCategory.Rows.Remove(dgCategory.SelectedRows[0]);                    
                    MessageBox.Show("Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void dgCategory_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private List<ExchangeRate> rate =new List<ExchangeRate>();
        private void btnAddExchangeRate_Click(object sender, EventArgs e)
        {
            try
            {
                int exc_price = int.Parse(txtExchangeRate.Text.Trim());
                if (exc_price.ToString() == "")
                {
                    MessageBox.Show("Please Enter Exchange Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ExchangeRate c in rate)
                {
                    if (c.Rate.ToString().ToLower() == exc_price.ToString().ToLower())
                    {
                        MessageBox.Show($"{exc_price} alrady exits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string sql = $"insert into tblExchangeRate (exc_price) values('{exc_price}')";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();

                sql = "select SCOPE_IDENTITY()";
                s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                string excID = "";
                if (r.Read())
                {
                    excID = r[0] + "";
                }

                s.Dispose();
                r.Close();
                ExchangeRate exchange = new ExchangeRate(excID,exc_price );
                dgExchangeRate.Rows.Add(exchange.Id, "1$= " +exchange.Rate + "Riels");
                rate.Add(exchange);
                MessageBox.Show("Exchange Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteExchangeRate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgExchangeRate.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string id = dgExchangeRate.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"delete from tblExchangeRate where exc_id='{id}'";
                    SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                    s.ExecuteNonQuery();
                    s.Dispose();
                    rate.RemoveAt(dgExchangeRate.SelectedRows[0].Index );
                    dgExchangeRate.Rows.Remove(dgExchangeRate.SelectedRows[0]);
                    MessageBox.Show("Deleted ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<Discount> discounts = new List<Discount>();
        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                int discount = int.Parse(txtDiscount.Text);
                if (discount.ToString() == ""||discount<0||discount>=100)
                {
                    MessageBox.Show("Please Enter a valid Discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Discount c in discounts)
                {
                    if (c.Dis.ToString().ToLower() == discount.ToString().ToLower())
                    {
                        MessageBox.Show($"{discount} alrady exits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string sql = $"insert into tblDiscount (dis_percent) values('{discount}')";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();

                sql = "select SCOPE_IDENTITY()";
                s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();

                string disID = "";
                if (r.Read())
                {
                    disID = r[0] + "";
                }

                s.Dispose();
                r.Close();
                Discount dis= new Discount(disID, discount);
                dgDiscount.Rows.Add(dis.Id, dis.Dis+"%");
                discounts.Add(dis);
                MessageBox.Show("Discount Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDiscount.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string id = dgDiscount.SelectedRows[0].Cells[0].Value.ToString();
                    Discount dis = new Discount();                    
                    string sql = $"delete from tblDiscount where dis_id='{id}'";
                    SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                    s.ExecuteNonQuery();
                    s.Dispose();
                    discounts.RemoveAt(dgDiscount.SelectedRows[0].Index);
                    dgDiscount.Rows.Remove(dgDiscount.SelectedRows[0]);
                   
                    MessageBox.Show("Deleted ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
        
    }
}
