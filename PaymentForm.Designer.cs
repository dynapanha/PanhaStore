namespace POS
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPayConfirm = new System.Windows.Forms.Button();
            this.txtCashReturned = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDiscount = new System.Windows.Forms.ComboBox();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscountPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscountID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExchangeID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaymentRiels = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCashReceivedRiels = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPayConfirm
            // 
            this.btnPayConfirm.Location = new System.Drawing.Point(397, 552);
            this.btnPayConfirm.Name = "btnPayConfirm";
            this.btnPayConfirm.Size = new System.Drawing.Size(84, 35);
            this.btnPayConfirm.TabIndex = 26;
            this.btnPayConfirm.Text = "Pay";
            this.btnPayConfirm.UseVisualStyleBackColor = true;
            this.btnPayConfirm.Click += new System.EventHandler(this.btnPayConfirm_Click);
            // 
            // txtCashReturned
            // 
            this.txtCashReturned.Location = new System.Drawing.Point(216, 515);
            this.txtCashReturned.Name = "txtCashReturned";
            this.txtCashReturned.ReadOnly = true;
            this.txtCashReturned.Size = new System.Drawing.Size(265, 30);
            this.txtCashReturned.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Cash Returned";
            // 
            // cbDiscount
            // 
            this.cbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscount.FormattingEnabled = true;
            this.cbDiscount.Location = new System.Drawing.Point(216, 71);
            this.cbDiscount.Name = "cbDiscount";
            this.cbDiscount.Size = new System.Drawing.Size(265, 33);
            this.cbDiscount.TabIndex = 23;
            this.cbDiscount.SelectedIndexChanged += new System.EventHandler(this.cbDiscount_SelectedIndexChanged);
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Location = new System.Drawing.Point(213, 422);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(268, 30);
            this.txtCashReceived.TabIndex = 22;
            this.txtCashReceived.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCashReceived_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cash Received $";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(213, 331);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.ReadOnly = true;
            this.txtPayment.Size = new System.Drawing.Size(268, 30);
            this.txtPayment.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Payment $";
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Location = new System.Drawing.Point(213, 171);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.ReadOnly = true;
            this.txtDiscountPrice.Size = new System.Drawing.Size(268, 30);
            this.txtDiscountPrice.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Discount Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Discount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(213, 21);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(268, 30);
            this.txtTotalAmount.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total Amount";
            // 
            // cbRate
            // 
            this.cbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(216, 229);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(265, 33);
            this.cbRate.TabIndex = 28;
            this.cbRate.SelectedIndexChanged += new System.EventHandler(this.cbRate_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Exchange Rate";
            // 
            // txtDiscountID
            // 
            this.txtDiscountID.Location = new System.Drawing.Point(213, 117);
            this.txtDiscountID.Name = "txtDiscountID";
            this.txtDiscountID.ReadOnly = true;
            this.txtDiscountID.Size = new System.Drawing.Size(268, 30);
            this.txtDiscountID.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 25);
            this.label8.TabIndex = 29;
            this.label8.Text = "Discount ID";
            // 
            // txtExchangeID
            // 
            this.txtExchangeID.Location = new System.Drawing.Point(213, 280);
            this.txtExchangeID.Name = "txtExchangeID";
            this.txtExchangeID.ReadOnly = true;
            this.txtExchangeID.Size = new System.Drawing.Size(268, 30);
            this.txtExchangeID.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 25);
            this.label9.TabIndex = 31;
            this.label9.Text = "Exchange ID";
            // 
            // txtPaymentRiels
            // 
            this.txtPaymentRiels.Location = new System.Drawing.Point(213, 376);
            this.txtPaymentRiels.Name = "txtPaymentRiels";
            this.txtPaymentRiels.ReadOnly = true;
            this.txtPaymentRiels.Size = new System.Drawing.Size(268, 30);
            this.txtPaymentRiels.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "Payment Riels";
            // 
            // txtCashReceivedRiels
            // 
            this.txtCashReceivedRiels.Location = new System.Drawing.Point(216, 463);
            this.txtCashReceivedRiels.Name = "txtCashReceivedRiels";
            this.txtCashReceivedRiels.Size = new System.Drawing.Size(265, 30);
            this.txtCashReceivedRiels.TabIndex = 36;
            this.txtCashReceivedRiels.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCashReceivedRiels_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 466);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 25);
            this.label11.TabIndex = 35;
            this.label11.Text = "Cash Received Riels";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 599);
            this.Controls.Add(this.txtCashReceivedRiels);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPaymentRiels);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtExchangeID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDiscountID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPayConfirm);
            this.Controls.Add(this.txtCashReturned);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDiscount);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiscountPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPayConfirm;
        private System.Windows.Forms.TextBox txtCashReturned;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDiscount;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscountPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscountID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExchangeID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaymentRiels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCashReceivedRiels;
        private System.Windows.Forms.Label label11;
    }
}