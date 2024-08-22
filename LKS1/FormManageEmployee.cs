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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LKS1
{
    public partial class FormManageEmployee : Form
    {
        int id = 0;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();
        void bersihkan()
        {
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            comboBox1.Text = "";
        }
        void aktif()
        {
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;
            tb5.Enabled = false;
            comboBox1.Enabled = false;
        }

        public FormManageEmployee()
        {
            InitializeComponent();
        }
        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from msemployee", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "msemployee");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "msemployee";
                dataGridView1.Columns[0].Visible = false;
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
        void combo()
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Chef");
            comboBox1.Items.Add("Cashier");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormManageEmployee_Load(object sender, EventArgs e)
        {
            tampil();
            combo();
            aktif();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tb2.Text.Trim() == "" || tb3.Text.Trim() == "" || tb4.Text.Trim() == "" || tb5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data harus di isi!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("insert into msemployee values ('" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + comboBox1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan");
                    tampil();
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
            if (MessageBox.Show("Yakin nich mau hapus : " + tb2.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("Delete msemployee where EmployeeID='" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");
                    tampil();
                    bersihkan();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb2.Text.Trim() == "" || tb3.Text.Trim() == "" || tb4.Text.Trim() == "" || tb5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data harus di isi!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("Update msemployee set Name = '" + tb2.Text + "',Email = '" + tb3.Text + "',Password = '"+ tb5.Text +"',Handphone = '" + tb4.Text + "',Position = '" + comboBox1.Text + "' where EmployeeID = '" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate");
                    tampil();
                    bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = int.Parse(row.Cells["EmployeeID"].Value.ToString());
                tb2.Text = row.Cells["Name"].Value.ToString();
                tb3.Text = row.Cells["Email"].Value.ToString();
                tb5.Text = row.Cells["Password"].Value.ToString();
                tb4.Text = row.Cells["Handphone"].Value.ToString();
                comboBox1.Text = row.Cells["Position"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            comboBox1.Enabled = true;
        }
    }
}
