namespace POS
{
    partial class Dashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblOveralIncome = new System.Windows.Forms.Label();
            this.lblTodayIncome = new System.Windows.Forms.Label();
            this.lblIncomeByDay = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Expense";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Today\'s Income";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Overal Income";
            // 
            // dtpDay
            // 
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDay.Location = new System.Drawing.Point(784, 88);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(113, 26);
            this.dtpDay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Income by day";
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.Location = new System.Drawing.Point(12, 149);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(71, 20);
            this.lblExpense.TabIndex = 9;
            this.lblExpense.Text = "Expense";
            // 
            // lblOveralIncome
            // 
            this.lblOveralIncome.AutoSize = true;
            this.lblOveralIncome.Location = new System.Drawing.Point(213, 149);
            this.lblOveralIncome.Name = "lblOveralIncome";
            this.lblOveralIncome.Size = new System.Drawing.Size(111, 20);
            this.lblOveralIncome.TabIndex = 10;
            this.lblOveralIncome.Text = "Overal Income";
            // 
            // lblTodayIncome
            // 
            this.lblTodayIncome.AutoSize = true;
            this.lblTodayIncome.Location = new System.Drawing.Point(461, 149);
            this.lblTodayIncome.Name = "lblTodayIncome";
            this.lblTodayIncome.Size = new System.Drawing.Size(120, 20);
            this.lblTodayIncome.TabIndex = 11;
            this.lblTodayIncome.Text = "Today\'s Income";
            // 
            // lblIncomeByDay
            // 
            this.lblIncomeByDay.AutoSize = true;
            this.lblIncomeByDay.Location = new System.Drawing.Point(657, 148);
            this.lblIncomeByDay.Name = "lblIncomeByDay";
            this.lblIncomeByDay.Size = new System.Drawing.Size(111, 20);
            this.lblIncomeByDay.TabIndex = 12;
            this.lblIncomeByDay.Text = "Income by day";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(924, 87);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 33);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblIncomeByDay);
            this.Controls.Add(this.lblTodayIncome);
            this.Controls.Add(this.lblOveralIncome);
            this.Controls.Add(this.lblExpense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblOveralIncome;
        private System.Windows.Forms.Label lblTodayIncome;
        private System.Windows.Forms.Label lblIncomeByDay;
        private System.Windows.Forms.Button btnSubmit;
    }
}