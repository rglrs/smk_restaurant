using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS1
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
       
        private SqlDataReader rd;
        Koneksi Konn = new Koneksi();
        public Form1()
        {
            InitializeComponent();
        }
        bool validasiemail(String email)
        {
            bool result = false;
            try
            {
                var emaillvalidator = new System.Net.Mail.MailAddress(email);
                result = (email.LastIndexOf(".") > email.LastIndexOf("@"));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(temail.Text == "" || tpass.Text == "")
            {
                MessageBox.Show("Isi semua!");
                return;
            }
            if (!validasiemail(temail.Text))
            {
                MessageBox.Show("Email tidak sesuai!");
                return;
            }
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            da = new SqlDataAdapter("Select * from Msemployee where Email='" + temail.Text + "' and Password='" + StaticData.sha256Convert(tpass.Text) + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow dr in dt.Rows)  
                StaticData.employeeid = dt.Rows[0].Field<int>(0);

                String level = dt.Rows[0].Field<String>(5);

                if (level.ToLower() == "admin")
                {
                    FormAdminNav fadminnav = new FormAdminNav();
                    fadminnav.Show();
                    this.Hide();
                }else if(level.ToLower() == "cashier")
                {
                    FormCashierNav frm = new FormCashierNav();
                    frm.Show();
                    this.Hide();
                }else if(level.ToLower() == "chef")
                {
                    FormChefNav frm = new FormChefNav();
                    frm.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Username atau Password mu salah!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tpass.UseSystemPasswordChar = false;
            }
            else
            {
                tpass.UseSystemPasswordChar= true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
