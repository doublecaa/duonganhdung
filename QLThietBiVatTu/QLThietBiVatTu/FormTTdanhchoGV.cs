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
    public partial class FormTTdanhchoGV : Form
    { 
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        void load()
        {

           
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sql = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon";
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
           
        }
        void loadTB()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon  where TenTB like '%" + txtword.Text+"%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
      
        }
        void loadGV()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqlgv = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon where TenGV like '%" + txtword.Text+"%'";
            SqlCommand cmd = new SqlCommand(sqlgv, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;           
        }
        void loadTMTB()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqlgv = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon where tb.MaTB like '%" + txtword.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlgv, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadTMGV()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqlgv = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon where MaGV like '%" + txtword.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlgv, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadTMM()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqlgv = "select MaGV,TenGV,SDT,ttm.MaMuon,tb.MaTB,TenTB,NgayMuon,NgayTra,SLMuon from(ThietBi tb join ThongTinMuon ttm on tb.MaTB = ttm.MaTB) join GiaoVien gv on gv.MaMuon = ttm.MaMuon where gv.MaMuon like '%" + txtword.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlgv, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FormTTdanhchoGV()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormTTdanhchoGV_Load(object sender, EventArgs e)
        {          
            load();
        }
        void loadccb()
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tìm kiếm theo tên thiết bị")
            {
                loadTB();

            }
            else if (comboBox1.Text == "Tìm kiếm theo tên giáo viên")
            {
                loadGV();
            }
            else if (comboBox1.Text == "Tìm kiếm theo mã thiết bị") loadTMTB();
            else if (comboBox1.Text == "Tìm kiếm theo mã giáo viên") loadTMGV();
            else if (comboBox1.Text == "Tìm kiếm theo mã mượn") loadTMM();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            txtword.Text = "";
            load();
        }

        private void txtword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangNhap fdn = new FormDangNhap();
            DialogResult kq = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq==System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                fdn.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
