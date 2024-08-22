using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LKS1
{
    public partial class FormChangePass : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();
        void bersihkan()
        {
            OldPass.Text = "";
            NewPass.Text = "";
            ConfirmPass.Text = "";
        }
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (OldPass.Text.Trim() == "" || NewPass.Text.Trim() == "" || ConfirmPass.Text.Trim() == "")
            {
                MessageBox.Show("Isien!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("Update msemployee set password = '"+ ConfirmPass.Text +"' where EmployeeID = '" + StaticData.employeeid + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password berhasil diubah");
                    bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
