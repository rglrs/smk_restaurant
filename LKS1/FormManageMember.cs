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
    public partial class FormManageMember : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();
        void bersihkan()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
        }
        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from msmember", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "msmember");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "msmember";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public FormManageMember()
        {
            InitializeComponent();
        }

        private void FormManageMember_Load(object sender, EventArgs e)
        {
            tampil();
            bersihkan();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( tb2.Text.Trim() == "" || tb3.Text.Trim() == "")
            {
                MessageBox.Show("Data harus di isi!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    String date = DateTime.Now.ToString("yyyy-MM-dd");
                    cmd = new SqlCommand($"insert into msmember(Name,Email,Handphone,JoinDate) values('{tb2.Text}', '{tb3.Text}', '{tb4.Text}', '{date}')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di input");
                    tampil();
                    bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
