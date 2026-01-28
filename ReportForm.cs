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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public void SetParameter(int index,Object value)
        {
            MartReport1.SetParameterValue(index,value);
        }     
        public void SetSource(List<ReportDetail> arr)
        {
            MartReport1.SetDataSource(arr);
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
