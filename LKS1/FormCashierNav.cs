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

namespace LKS1
{
    public partial class FormCashierNav : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        private SqlDataReader rd;
        Koneksi Konn = new Koneksi();
        void getemployeename()
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            da = new SqlDataAdapter("Select * from msemployee where EmployeeId=" + StaticData.employeeid, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            String employeename = dt.Rows[0].Field<String>(1);
            label2.Text = "Welcome, " + employeename;
        }
        public FormCashierNav()
        {
            InitializeComponent();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            FormChangePass fcp = new FormChangePass();
            fcp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormPayment fp = new FormPayment();
            fp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOrder fo = new FormOrder();
            fo.Show();
            this.Hide();
        }

        private void FormCashierNav_Load(object sender, EventArgs e)
        {
            getemployeename();
        }
    }
}
