using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class OrderProduct : Form
    {
        public OrderProduct()
        {
            InitializeComponent();
        }
        List<Product> productsOrder = new List<Product>();   
        List<OrderDetail> orderDetails = new List<OrderDetail>();
        public void ClearOrderList()
        {
            orderDetails.Clear();  
            dgOrder.Rows.Clear();   
            txtTotalAmount.Text = "$0.00";
            num = 0;
        }
        private int IsIDExists(int id)
        {
            for (int i = 0; i < orderDetails.Count; i++)
            {
                if (orderDetails[i].ProductId == id) 
                {
                    return i; 
                }
            }
            return -1;
        }
        private double TotalAmount()
        {
            double amount = 0;
            foreach (OrderDetail p in orderDetails)
            {
                amount+=p.Qty*p.PriceOut;
            }

            return amount;
        }
        int num = 0;
        
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                
                string barcode=txtBarcode.Text.Trim();
                bool found = false;
                for(int i=0;i<productsOrder.Count;i++)
                {
                    if (productsOrder[i].Barcode.ToString()==barcode)
                    {                           
                        int id = productsOrder[i].Id;
                        string name=productsOrder[i].Name;
                        int qty=1;
                        double pricein=productsOrder[i].PriceIn;
                        double priceout=productsOrder[i].PriceOut;
                        double amount=qty*priceout;
                        int index = IsIDExists(id);
                        if (index>=0)
                        {
                            qty=orderDetails[index].Qty+1;
                            if (qty > productsOrder[i].Qty)
                            {
                                MessageBox.Show("Insuficient Qty");
                                return;
                            }
                            amount = qty * priceout;
                            dgOrder.Rows[index].Cells[3].Value = qty;
                            dgOrder.Rows[index].Cells[4].Value = amount;
                            orderDetails[index].Qty = qty;
                        }
                        else
                        {
                            if (qty > productsOrder[i].Qty)
                            {
                                MessageBox.Show("Insuficient Qty");
                                return;
                            }
                            num++;
                            dgOrder.Rows.Add(num, name,priceout,qty, amount);
                            OrderDetail detail = new OrderDetail(id, qty, pricein, priceout, name);
                            orderDetails.Add(detail);
                        }                          
                        txtBarcode.Clear();
                        found= true;
                        break;
                    }                                             
                }
                if (!found)
                {
                    MessageBox.Show("Product not in stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtTotalAmount.Text = TotalAmount().ToString("$0.00");

                
            }  
        }

        private void OrderProduct_Load(object sender, EventArgs e)
        {
            try
            {
                productsOrder.Clear();
                orderDetails.Clear();
                string sql = "select * from tblProduct";
                SqlCommand s = new SqlCommand(sql,DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0] + "";
                    string barcode = r[1] + "";
                    string name = r[2] + "";
                    string qty = r[3] + "";
                    string pricein = r[4] + "";
                    string priceout = r[5] + "";
                    string cateid = r[6] + "";
                    Product product = new Product(int.Parse(id), long.Parse(barcode),name, int.Parse(qty),double.Parse(pricein),double.Parse(priceout), int.Parse(cateid));
                    productsOrder.Add(product);
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgOrder.SelectedRows.Count<1)
                {
                    MessageBox.Show("Select a row to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int rowIndex = dgOrder.SelectedRows[0].Index;
                int newQty = int.Parse(txtQty.Text.Trim());              
                
                if (newQty<0)
                {
                    MessageBox.Show("Quantity Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = orderDetails[rowIndex].ProductId;
                for (int i=0;i<productsOrder.Count;i++)
                {
                    if (id.ToString() == productsOrder[i].Id.ToString())
                    {
                        if (newQty > productsOrder[i].Qty)
                        {
                            MessageBox.Show("Insufficient stock quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
               
                if (newQty==0)
                {
                    dgOrder.Rows.RemoveAt(rowIndex);
                    orderDetails.RemoveAt(rowIndex);
                    MessageBox.Show("Product removed from order.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    orderDetails[rowIndex].Qty = newQty;
                    double newAmount= orderDetails[rowIndex].Qty* orderDetails[rowIndex].PriceOut;
                    dgOrder.Rows[rowIndex].Cells[3].Value = newQty;
                    dgOrder.Rows[rowIndex].Cells[4].Value = newAmount;
                }
                txtTotalAmount.Text = TotalAmount().ToString("$0.00");
                txtQty.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgOrder.Rows.Count==0)
            {
                MessageBox.Show("No Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PaymentForm form = new PaymentForm(TotalAmount(),orderDetails,this,dgOrder.Rows);
            form.ShowDialog();
        }
    }
}
