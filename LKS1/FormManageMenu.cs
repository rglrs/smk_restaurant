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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LKS1
{
    public partial class FormManageMenu : Form
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
            tb4.Text = "";
        }
        public FormManageMenu()
        {
            InitializeComponent();
        }
        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from msmenu", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "msmenu");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "msmenu";
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

        private void FormManageMenu_Load(object sender, EventArgs e)
        {
            tampil();
            bersihkan();
            tb1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( tb2.Text.Trim() == "" || tb3.Text.Trim() == "" || tb4.Text.Trim() == "")
            {
                MessageBox.Show("Data harus di isi!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("insert into msmenu values ('" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" +pictureBox1.ImageLocation+ "')", conn);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin nich mau hapus : " + tb2.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("Delete msmenu where menuid='" + tb1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di hapus");
                    tampil();
                    bersihkan();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                tb1.Text = row.Cells["menuid"].Value.ToString();
                tb2.Text = row.Cells["name"].Value.ToString();
                tb3.Text = row.Cells["price"].Value.ToString();
                tb4.Text = row.Cells["photo"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb2.Text.Trim() == "" || tb3.Text.Trim() == "" || tb4.Text.Trim() == "")
            {
                MessageBox.Show("Data harus di isi!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("update msmenu set name='" + tb2.Text + "',price='" + tb3.Text + "',photo='" + tb4.Text + "' where menuid='" + tb1.Text+ "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di ubah");
                    tampil();
                    bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bersihkan();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
