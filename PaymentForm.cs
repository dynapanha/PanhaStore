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
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }
        DataGridViewRowCollection data;
        List<OrderDetail> details;
        OrderProduct o;

        public PaymentForm(double totalAmount,List<OrderDetail>list,OrderProduct o,DataGridViewRowCollection data)
        {
            InitializeComponent();
            this.details = list;
            this.totalAmount = totalAmount;
            this.o = o;
            this.data = data;

        }
        double totalAmount;
       
        List<Discount> discountList = new List<Discount>();
        List<ExchangeRate> exchangeRates = new List<ExchangeRate>();
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
            try
            {

                discountList.Clear();
                string sql = "select * from tblDiscount";
                SqlCommand s= new SqlCommand(sql,DataConnection.DataCon);
                SqlDataReader r= s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0] + "";
                    string discount = r[1] + "";
                    Discount dis=new Discount(id,int.Parse(discount));
                    discountList.Add(dis);
                    cbDiscount.Items.Add(dis.Dis+" %");
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            try
            {
                exchangeRates.Clear();
                string sql = "select * from tblExchangeRate";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r[0] + "";
                    string rate = r[1] + "";
                    ExchangeRate rateRate = new ExchangeRate(id, int.Parse(rate));
                    exchangeRates.Add(rateRate);
                    cbRate.Items.Add(rateRate.Rate+" Riels");
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbDiscount.SelectedIndex = 0;
            cbRate.SelectedIndex = 0;
            txtTotalAmount.Text = totalAmount.ToString("c2");
            btnPayConfirm.Enabled = false;
        }
        double payment;
        int rateIndex;
        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            rateIndex = cbRate.SelectedIndex;
            btnPayConfirm.Enabled = false;
            txtExchangeID.Text = exchangeRates[rateIndex].Id;
            paymentRiels = (exchangeRates[rateIndex].Rate * payment);
            txtPaymentRiels.Text = "Riels " + paymentRiels.ToString("N0");

        }
        int disIndex;
        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            disIndex=cbDiscount.SelectedIndex;
            txtDiscountID.Text = discountList[disIndex].Id;
            double disPrice = (discountList[disIndex].Dis * totalAmount)/100;
            txtDiscountPrice.Text = disPrice.ToString("c2");
            payment = totalAmount - disPrice;
            txtPayment.Text = payment.ToString("c2");
            btnPayConfirm.Enabled=false;          
            paymentRiels = (exchangeRates[rateIndex].Rate * payment);
            txtPaymentRiels.Text = "Riels " + paymentRiels.ToString("N0");
        }
        double paymentRiels;
        
        private void txtCashReceived_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtCashReceived.Text.Length > 0)
                {
                    txtCashReceivedRiels.Enabled = false;                    
                    double cashUSD = double.Parse(txtCashReceived.Text.Trim());                    
                    double cashUSDChange = cashUSD-payment;
                    txtCashReturned.Text = cashUSDChange.ToString("c2");
                    double cashRounded = Math.Round(cashUSD, 2);
                    double paymentRounded = Math.Round(payment, 2);
                    if (cashRounded >= paymentRounded)
                    {
                        btnPayConfirm.Enabled = true;
                    }
                    else
                    {
                        txtCashReturned.Text = "$0.00";
                        btnPayConfirm.Enabled = false;
                    }
                }
                else
                {
                    txtCashReceivedRiels.Enabled = true;
                    txtCashReturned.Text = "";
                }
            }
            catch (Exception ex)
            {
                btnPayConfirm.Enabled=false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCashReceivedRiels_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtCashReceivedRiels.Text.Length > 0)
                {
                    txtCashReceived.Enabled = false;
                    double cashRiels = double.Parse(txtCashReceivedRiels.Text.Trim());
                    double cashRielsChange = cashRiels-paymentRiels;
                    txtCashReturned.Text = cashRielsChange.ToString("#,000.00") + " R";
                    double cashRounded = Math.Round(cashRiels, 2);
                    double paymentRounded = Math.Round(paymentRiels, 2);
                    if (cashRounded >= paymentRounded)
                    {
                        btnPayConfirm.Enabled = true;
                    }
                    else
                    {
                        txtCashReturned.Text = "$0.00";
                        btnPayConfirm.Enabled = false;
                    }
                }
                else
                {
                    txtCashReceived.Enabled = true;
                    txtCashReturned.Text = "";
                }
            }
            catch (Exception ex)
            {
                btnPayConfirm.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InsertToOrderDetail(string ordId)
        {
            foreach (OrderDetail od in details)
            {
                string prodID = od.ProductId.ToString();
                string qty = od.Qty.ToString();
                string pricein = od.PriceIn.ToString();
                string priceout = od.PriceOut.ToString();
                string sql = $"insert into tblOrderDetail(ord_id,prod_id ,qty,unit_price_in,unit_price_out) values({ordId},{prodID},{qty},{pricein},{priceout})";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();
            }
        }
        public void UpdateStock()
        {
            foreach (OrderDetail temp in details)
            {
                int qty = temp.Qty;
                int pid = temp.ProductId;
                string sql = $"update tblProduct set prod_qty=prod_qty-{qty} where prod_id={pid}";
                SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
                s.ExecuteNonQuery();
                s.Dispose();
            }
        }
        public string InsertToOrder()
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd");
            string time = now.ToString("HH:mm:ss");
            string discount = txtDiscountPrice.Text;
            double amount = payment;
            string seller = DataConnection.Seller;
            string excId = txtExchangeID.Text;
            string disID = txtDiscountID.Text;

            Order order = new Order();
            string sql = $"insert into tblOrder(ord_date, ord_time, amount, seller, exc_id, dis_id) values('{date}','{time}',{amount},'{seller}','{excId}','{disID}')";
            SqlCommand s = new SqlCommand(sql, DataConnection.DataCon);
            s.ExecuteNonQuery();

            MessageBox.Show("Order Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            sql = "select SCOPE_IDENTITY()";
            s = new SqlCommand(sql, DataConnection.DataCon);
            SqlDataReader r = s.ExecuteReader();

            string orderId = "";
            while (r.Read())
            {
                orderId = r[0] + "";
            }         
            r.Close();
            s.Dispose();
            return orderId;
        }
        private void PrintReport(string id,int discount)
        {
            ReportForm reportForm = new ReportForm();
            List<ReportDetail> reportDetails = new List<ReportDetail>();           
            foreach (DataGridViewRow temp in data)
            {
                string name = temp.Cells[1].Value.ToString();
                int qty = Convert.ToInt32(temp.Cells[3].Value);
                double price = Convert.ToDouble(temp.Cells[2].Value);
                ReportDetail rd=new ReportDetail(name,price,qty);
                reportDetails.Add(rd);
                
            }
           
            reportForm.SetSource(reportDetails);
            reportForm.SetParameter(0, id);
            reportForm.SetParameter(1, DataConnection.Seller);
            reportForm.SetParameter(2,discount);
            reportForm.ShowDialog();    
        }
        private void btnPayConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert Order
                string id = InsertToOrder();
                //Insert OrderDetail              
                InsertToOrderDetail(id);
                //Update Stock
                UpdateStock();
                int disPercent = discountList[disIndex].Dis;
                //Print Report
                PrintReport(id,disPercent);
                //Clear for new Order
                details.Clear();
                o.ClearOrderList();

                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
   
        }
    }
}
