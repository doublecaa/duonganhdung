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

namespace QLThietBiVatTu
{
    public partial class FormChinhSuaTB : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adapter=new SqlDataAdapter();
        DataTable table = new DataTable();
        void load()
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "select tb.MaTB,TenTB,NSX,Soluong from ThietBi tb join Kho k on tb.MaTB=k.MaTB";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        void loadTMTB()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select tb.MaTB,TenTB,NSX,Soluong from ThietBi tb join Kho k on tb.MaTB=k.MaTB where tb.MaTB like '%" + txtsearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadTTTB()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select tb.MaTB,TenTB,NSX,Soluong from ThietBi tb join Kho k on tb.MaTB=k.MaTB where TenTB like '%" + txtsearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadTNSX()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select tb.MaTB,TenTB,NSX,Soluong from ThietBi tb join Kho k on tb.MaTB=k.MaTB where NSX like '%" + txtsearch.Text+"%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FormChinhSuaTB()
        {
            InitializeComponent();
        }

        private void FormChinhSuaTB_Load(object sender, EventArgs e)
        {   
            cnn = new SqlConnection(str);
            cnn.Open();
            load();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            DialogResult kq = MessageBox.Show("Bạn muốn quay lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq==System.Windows.Forms.DialogResult.Yes)
            {
                fm.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            int sl = Int32.Parse(txtSL.Text);
            if (sl < 0) MessageBox.Show("Số lượng phải lớn hơn 0");
            string sql1 = "update ThietBi set MaTB=@matb,TenTB=@tentb,NSX=@nsx where MaTB=@matb   update Kho set Soluong=@sl where MaTB=@matb";
            SqlCommand cmd = new SqlCommand(sql1, cnn);                       
            cmd.Parameters.AddWithValue("matb", txtMaTB.Text);
            cmd.Parameters.AddWithValue("tentb", txtTenTB.Text);
            cmd.Parameters.AddWithValue("nsx", txtNSX.Text);
            cmd.Parameters.AddWithValue("sl", txtSL.Text);
            cmd.ExecuteNonQuery();
            DialogResult kq = MessageBox.Show("Bạn muốn sửa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql2 = "delete from ThietBi where MaTB=@matb";
            SqlCommand cmd = new SqlCommand(sql2, cnn);
            cmd.Parameters.AddWithValue("matb", txtMaTB.Text);
            cmd.Parameters.AddWithValue("tentb", txtTenTB.Text);
            cmd.Parameters.AddWithValue("nsx", txtNSX.Text);
            cmd.Parameters.AddWithValue("sl", txtSL.Text);
            cmd.ExecuteNonQuery();
            DialogResult kq = MessageBox.Show("Bạn muốn xóa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                load();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTB.Text = "";
            txtNSX.Text = "";
            txtSL.Text = "";
            txtTenTB.Text = "";
        }

        private void btnXTK_Click(object sender, EventArgs e)
        {
            cbsearch.Text = "";
            txtsearch.Text = "";
            load();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (cbsearch.Text == "Tìm kiếm theo mã thiết bị") loadTMTB();
            else if (cbsearch.Text == "Tìm kiếm theo tên thiết bị") loadTTTB();
            else if (cbsearch.Text == "Tìm kiếm theo nhà sản xuất") loadTNSX();
        }

        

        private void FormChinhSuaTB_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaTB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenTB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNSX.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSL.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}


