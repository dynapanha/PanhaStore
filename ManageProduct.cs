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
    public partial class ManageProduct : Form
    {
        public ManageProduct()
        {
            InitializeComponent();
        }
        private List<Product> products = new List<Product>();
        private List<Category> categories = new List<Category>();
        private void ManageProduct_Load(object sender, EventArgs e)
        {
            try
            {
                categories.Clear();                
                string sql = "select * from tblCategory";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string cateID = r[0] + "";
                    string cateName = r[1] + "";
                    Category category = new Category(cateID, cateName);
                    categories.Add(category);
                    cbCategoryName.Items.Add(category.CategoryName);
                }
                cbCategoryName.SelectedIndex = 0;
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                products.Clear();
                string sql = "select * from tblProduct";
                SqlCommand s= new SqlCommand(sql,DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
              
                while (r.Read())
                {
                    string prodID = r[0] + "";
                    string barcode = r[1] + "";
                    string name = r[2] + "";
                    string qty = r[3] + "";
                    string priceIn = r[4] + "";
                    string priceOut = r[5] + "";
                    string cateId = r[6] + "";                 
                    Product product = new Product(int.Parse(prodID), long.Parse(barcode), name, int.Parse(qty), double.Parse(priceIn), double.Parse(priceOut), int.Parse(cateId));
                    string cateName = "";
                    foreach (Category c in categories)
                    {
                        if (int.Parse(c.Id) ==int.Parse( cateId))
                        {
                            cateName = c.CategoryName;
                        }
                    }
                    products.Add(product);
                    dgProduct.Rows.Add(product.Id, product.Barcode, product.Name,product.Qty, product.PriceIn, product.PriceOut, cateName);
                }
                r.Close();
                s.Dispose();

               
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {               
                long barcode =long.Parse( txtBarcode.Text.Trim());
                string name = txtProductName.Text.Trim();
                string qty = txtProductQty.Text.Trim();
                string pricein = txtPriceIn.Text.Trim();
                string priceout = txtPriceOut.Text.Trim();
                int cateId = int.Parse(txtCategoryID.Text.Trim());
                foreach (Product p in products)
                {
                    if (p.Barcode.ToString() == barcode.ToString())
                    {
                        MessageBox.Show("Barcode is already in the List please go to Edit if you want to change new QTY", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                if (barcode<0||int.Parse(qty) < 0 || double.Parse(pricein) < 0 || double.Parse(priceout) < 0)
                {
                    MessageBox.Show("Input String was not in a correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = $"insert into tblProduct(prod_barcode,prod_name,prod_qty,prod_unit_price_in,prod_unit_price_out,cate_id) values('{barcode}',N'{name}','{qty}','{pricein}','{priceout}','{cateId}')";
                SqlCommand s=new SqlCommand(sql,DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();


                sql = "select SCOPE_IDENTITY()";
                s=new SqlCommand (sql,DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                string prodId = "";
                if (r.Read())
                {
                    prodId = r[0] + "";
                } 
                r.Close();
                s.Dispose();
                Product product = new Product(int.Parse(prodId),barcode,name,int.Parse(qty),double.Parse(pricein),double.Parse(priceout),cateId);
                products.Add(product);
                dgProduct.Rows.Add(product.Id,product.Barcode,product.Name,product.Qty,product.PriceIn,product.PriceOut, cbCategoryName.SelectedItem);
                MessageBox.Show("Product Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarcode.Clear();
                txtProductName.Clear();
                txtProductQty.Clear();
                txtPriceIn.Clear();
                txtPriceOut.Clear();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index= cbCategoryName.SelectedIndex;
                txtCategoryID.Text = categories[index].Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProduct.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this product?","Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning); 
                    if (result == DialogResult.Yes)
                    {
                        string id = dgProduct.SelectedRows[0].Cells[0].Value.ToString();
                        string sql = $"delete from tblProduct where prod_id='{id}'";
                        SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                        s.ExecuteNonQuery();
                        s.Dispose();
                        products.RemoveAt(dgProduct.SelectedRows[0].Index);
                        dgProduct.Rows.Remove(dgProduct.SelectedRows[0]);

                        MessageBox.Show("Product Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
      
        private void txtSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchBarcode.Text.Trim();
            foreach (DataGridViewRow row in dgProduct.Rows)
            {
                string barcode=row.Cells[1].Value.ToString();
                string name=row.Cells[2].Value.ToString();
                if(search.Length<1){
                    row.Visible = true;
                }
                else if (search.Contains(barcode))
                {
                    row.Visible = true;
                }
                else if (name.ToLower().Contains(search))
                {
                    row.Visible = true; 
                }
                else
                {
                    row.Visible = false;
                }
            }
            
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (btnEditProduct.Text == "Edit")
            {
               
                if (dgProduct.SelectedRows.Count<1)
                {
                    MessageBox.Show("Please select a row to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    btnAddProduct.Enabled = false;
                    btnDeleteProduct.Enabled = false;
                    txtBarcode.Enabled = false;
                    btnEditProduct.Text = "Update";
                    DataGridViewRow row = dgProduct.SelectedRows[0];
                    foreach (DataGridViewRow r in dgProduct.Rows)
                    {
                        r.Visible = r == row; 
                    }
                    txtBarcode.Text = row.Cells[1].Value.ToString();
                    txtProductName.Text = row.Cells[2].Value.ToString();
                    txtProductQty.Text = row.Cells[3].Value.ToString();
                    txtPriceIn.Text = row.Cells[4].Value.ToString();
                    txtPriceOut.Text = row.Cells[5].Value.ToString();
                    foreach (Category c in categories)
                    {
                        if (c.CategoryName == row.Cells[6].Value.ToString())
                        {
                            txtCategoryID.Text = c.Id;
                            cbCategoryName.Text = c.CategoryName;
                            break;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    string barcode=txtBarcode.Text.Trim();
                    string productName=txtProductName.Text.Trim();
                    string productQty=txtProductQty.Text.Trim();
                    string priceIn=txtPriceIn.Text.Trim();
                    string priceOut=txtPriceOut.Text.Trim();
                    string cateId=txtCategoryID.Text.Trim();
                    
                    if (int.Parse(productQty) < 0 || double.Parse(priceIn) < 0 || double.Parse(priceOut) < 0)
                    {
                        MessageBox.Show("Input String was not in a correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string sql = $"update tblProduct set prod_name=N'{productName}', prod_qty='{productQty}', prod_unit_price_in='{priceIn}', prod_unit_price_out='{priceOut}', cate_id='{cateId}' WHERE prod_barcode='{barcode}'";
                    SqlCommand s =new SqlCommand(sql,DataConnection.DataCon);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    foreach (Product p in products)
                    {
                        if (p.Barcode==long.Parse(barcode))
                        {
                            p.Name=productName;
                            p.Qty = int.Parse(productQty);
                            p.PriceIn = double.Parse(priceIn);
                            p.PriceOut=double.Parse(priceOut);
                            p.CateId = int.Parse(cateId);
                        }
                    }
                   
                    dgProduct.SelectedRows[0].Cells[2].Value = productName;
                    dgProduct.SelectedRows[0].Cells[3].Value = productQty;
                    dgProduct.SelectedRows[0].Cells[4].Value = priceIn;
                    dgProduct.SelectedRows[0].Cells[5].Value = priceOut;
                    dgProduct.SelectedRows[0].Cells[6].Value = cbCategoryName.SelectedItem;
                    btnEditProduct.Text = "Edit";
                    txtBarcode.Enabled = true;
                    MessageBox.Show("Update Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarcode.Clear();
                    txtPriceIn.Clear();
                    txtPriceOut.Clear();
                    txtProductName.Clear();
                    txtProductQty.Clear();
                    foreach (DataGridViewRow r in dgProduct.Rows)
                    {
                        r.Visible = true;
                    }
                    btnAddProduct.Enabled = true;
                    btnDeleteProduct.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
        }
    }
}
