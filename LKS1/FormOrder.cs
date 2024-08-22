using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS1
{
    public partial class FormOrder : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();
        int harga_saat_ini = 0;
        int menu_id = 0;

        
        
        public FormOrder()
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
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
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

        void tampilDummy()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from dummyOrder", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "msmenu");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "msmenu";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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


        private void FormOrder_Load(object sender, EventArgs e)
        {
            tampil();
            isiCombo();
            deleteDummy();
        }

        void isiCombo()
        {
            SqlConnection conn = Konn.GetConn();
            SqlDataAdapter cma = new SqlDataAdapter("select * from Msmember", conn);
            DataTable td = new DataTable();
            cma.Fill(td);
            comboBox1.DataSource = td;
            comboBox1.ValueMember = "MemberId";
            comboBox1.DisplayMember = "Name";

        }

    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView1.Rows[int.Parse(e.RowIndex.ToString())].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[int.Parse(e.RowIndex.ToString())].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[int.Parse(e.RowIndex.ToString())].Cells[2].Value.ToString();
            harga_saat_ini = int.Parse(dataGridView1.Rows[int.Parse(e.RowIndex.ToString())].Cells[2].Value.ToString());
            menu_id = int.Parse(dataGridView1.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString());
            updateHarga();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            SqlCommand cmo = new SqlCommand("insert into dummyOrder(nama,menu_id,qty,price) values(@nama,@idmenu,@qty,@price)", conn);
            cmo.Parameters.AddWithValue("@nama", textBox1.Text);
            cmo.Parameters.AddWithValue("@idmenu", menu_id);
            cmo.Parameters.AddWithValue("@qty", textBox3.Text);
            cmo.Parameters.AddWithValue("@price", textBox2.Text);
            conn.Open();
            cmo.ExecuteNonQuery();
            tampilDummy();
            totalHarga();

        }

        void updateHarga()
        {
            try
            {
            int harga = harga_saat_ini * int.Parse(textBox3.Text.ToString());
            textBox2.Text = harga.ToString();
            }catch(Exception e)
            {
                textBox2.Text = "";
            }
        }

        void deleteDummy()
        {
            SqlConnection conn = Konn.GetConn();
            SqlCommand cmo = new SqlCommand("delete from dummyOrder", conn);
            conn.Open();
            cmo.ExecuteNonQuery();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            updateHarga();
        }
        void totalHarga()
        {
            SqlConnection conn = Konn.GetConn();
            SqlDataAdapter da = new SqlDataAdapter("select sum(price) as total from dummyOrder", conn);
            DataTable ta = new DataTable();
            da.Fill(ta);
            label4.Text = "Total harga Rp. " + ta.Rows[0].Field<int>(0).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            headerOrder();
            detailOrder();
        }

        void headerOrder()
        {
            SqlConnection conn = Konn.GetConn();
            SqlCommand cmo = new SqlCommand("insert into headorder(EmployeeID, MemberID, Date) values(@employe, @member, @date)", conn);
            cmo.Parameters.AddWithValue("@employe", StaticData.employeeid);
            cmo.Parameters.AddWithValue("@member", comboBox1.SelectedValue);
            cmo.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            conn.Open();
            cmo.ExecuteNonQuery();
        }

        void detailOrder()
        {
            SqlConnection conn = Konn.GetConn();
            SqlDataAdapter ido = new SqlDataAdapter("select top(1) orderId from headorder order by orderId desc", conn);
            DataTable idt = new DataTable();
            ido.Fill(idt);
            int orderId = idt.Rows[0].Field<int>(0);

            SqlDataAdapter loop = new SqlDataAdapter("select * from dummyOrder", conn);
            DataTable oop = new DataTable();
            loop.Fill(oop);
            conn.Open();
            foreach (DataRow row in oop.Rows)
            {
                SqlCommand cmaa = new SqlCommand($"insert into detailorder(OrderId,MenuID, Qty, Price, Status) values({orderId},{menu_id}, {row["qty"]}, {row["price"]}, 'Pending')", conn);
                cmaa.ExecuteNonQuery();
            }
            deleteDummy();
            MessageBox.Show("Pesanan Berhasil Ditambahkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tampilDummy();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
