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
using System.Configuration;

namespace QLThietBiVatTu
{
    public partial class FormChinhSuaGV : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void load()
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "select MaGV,TenGV,SDT,gv.MaMuon,tb.MaTB,NgayMuon,NgayTra,SLMuon from (ThietBi tb join ThongTinMuon ttm on tb.MaTB=ttm.MaTB) right join GiaoVien gv on gv.MaMuon=ttm.MaMuon";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        void loadcbb()
        {
            string str1 = "select * from ThietBi";
            SqlCommand cmdcbb = new SqlCommand(str1,cnn);
            SqlDataAdapter adt = new SqlDataAdapter(cmdcbb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            cbMTBM.DisplayMember="MaTB";
            cbMTBM.DataSource = dt;
            
        }
        void loadTMGV()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select MaGV,TenGV,SDT,gv.MaMuon,tb.MaTB,NgayMuon,NgayTra,SLMuon from (ThietBi tb join ThongTinMuon ttm on tb.MaTB=ttm.MaTB) right join GiaoVien gv on gv.MaMuon=ttm.MaMuon where MaGV like '%" + txtword.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void loadTTGV()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select MaGV,TenGV,SDT,gv.MaMuon,tb.MaTB,NgayMuon,NgayTra,SLMuon from (ThietBi tb join ThongTinMuon ttm on tb.MaTB=ttm.MaTB) right join GiaoVien gv on gv.MaMuon=ttm.MaMuon where TenGV like '%" + txtword.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        public FormChinhSuaGV()
        {
            InitializeComponent();
        }

        private void FormChinhSuaGV_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            load();
            loadcbb();
            
        }

        private void FormChinhSuaGV_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenGV.TextLength == 0)
                MessageBox.Show("Tên giáo viên không bỏ trống");
            else
            {
                try {
                        string sql1 = "update GiaoVien set MaGV=@magv, TenGV=@tengv, SDT=@sdt where MaGV=@magv  update ThongTinMuon set MaMuon=@mm,MaTB=@mtb,NgayMuon=@ngaymuon,NgayTra=@ngaytra, SLMuon=@sl where MaMuon=@mm";
                        SqlCommand cmd = new SqlCommand(sql1, cnn);
                        cmd.Parameters.AddWithValue("magv", txtMaGV.Text);
                        cmd.Parameters.AddWithValue("tengv", txtTenGV.Text);
                        cmd.Parameters.AddWithValue("sdt", txtsdt.Text);
                        cmd.Parameters.AddWithValue("mm", txtMaTB.Text);
                        cmd.Parameters.AddWithValue("mtb", cbMTBM.Text);
                        cmd.Parameters.AddWithValue("ngaymuon", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("ngaytra", dateTimePicker2.Text);
                        cmd.Parameters.AddWithValue("sl", txtSLmuon.Text);
                        cmd.ExecuteNonQuery();
                        DialogResult kq = MessageBox.Show("Bạn muốn sửa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (kq == System.Windows.Forms.DialogResult.Yes)
                        {
                            load();
                        }
                }
                catch { MessageBox.Show("Ngay trả không được nhỏ hơn ngày mượn"); }
               
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql2 = "delete from ThongTinMuon  where MaMuon=@mm";
            SqlCommand cmd = new SqlCommand(sql2, cnn);
            cmd.Parameters.AddWithValue("magv", txtMaGV.Text);
            cmd.Parameters.AddWithValue("tengv", txtTenGV.Text);
            cmd.Parameters.AddWithValue("sdt", txtsdt.Text);
            cmd.Parameters.AddWithValue("mm", txtMaTB.Text);
            cmd.Parameters.AddWithValue("mtb", cbMTBM.Text);
            cmd.Parameters.AddWithValue("ngaymuon", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("ngaytra", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("sl", txtSLmuon.Text);
            cmd.ExecuteNonQuery();
            DialogResult kq = MessageBox.Show("Bạn muốn xóa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                load();
            }          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql3 = "insert into ThongTinGV values(@MaGV,@TenGV,@SDT,@MaMuon,@MaTB,@TenTB@NgayMuon,@NgayTra,@SoLuongMuon)";
            SqlCommand cmdt = new SqlCommand(sql3, cnn);
            cmd.Parameters.AddWithValue("MaGV", txtMaGV.Text);
            cmd.Parameters.AddWithValue("TenGV", txtTenGV.Text);
            cmd.Parameters.AddWithValue("SDT", txtsdt.Text);
            cmd.Parameters.AddWithValue("MaMuon", cbMTBM.Text);
            cmd.Parameters.AddWithValue("MaTB", txtMaTB.Text);
            cmd.Parameters.AddWithValue("NgayMuon", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("NgayTra", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("SoLuongMuon", txtSLmuon.Text);
            cmdt.ExecuteNonQuery();
            DialogResult kq = MessageBox.Show("Bạn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                load();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            DialogResult kq = MessageBox.Show("Bạn muốn quay lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {

                fm.Show();
                this.Hide();
            }
        }

      

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            cbMTBM.Text = "";
            txtSLmuon.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void cbMTBM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void getvalue(string value)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (cbsearch.Text == "Theo mã GV") { loadTMGV(); }
            else if (cbsearch.Text == "Theo tên GV") { loadTTGV(); }
         
        }

        private void btnXPM_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            cbsearch.Text = "";
            txtword.Text = "";
            load();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaGV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenGV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsdt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbMTBM.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMaTB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtSLmuon.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void txtSLmuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
