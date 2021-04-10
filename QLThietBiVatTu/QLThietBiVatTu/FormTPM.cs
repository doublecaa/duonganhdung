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
    public partial class FormTPM : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        public FormTPM()
        {
            InitializeComponent();
        }
        void load()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select MaGV,TenGV,ttm.MaMuon,MaTB,NgayMuon,NgayTra,SLMuon from GiaoVien gv join ThongTinMuon ttm on gv.MaMuon=ttm.MaMuon";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadcbb()
        {
            SqlConnection cnn = new SqlConnection(str);
            string str1 = "select * from ThietBi";
            SqlCommand cmdcbb = new SqlCommand(str1, cnn);
            SqlDataAdapter adt = new SqlDataAdapter(cmdcbb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            cbtb.DisplayMember = "MaTB";
            cbtb.DataSource = dt;
        }
        private void FormTPM_Load(object sender, EventArgs e)
        {
            load();
            loadcbb();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtsl.Text);
            if (x < 0) MessageBox.Show("số lượng phải lớn hơn 0");
            try {
                SqlConnection cnn = new SqlConnection(str);
                cnn.Open();
                string sql1 = "insert into ThongTinMuon values(@mm,@matb,@ngaymuon,@ngaytra,@sl)";
                SqlCommand command = new SqlCommand(sql1, cnn);
                command.Parameters.AddWithValue("mm", txtMM.Text);
                command.Parameters.AddWithValue("matb", cbtb.Text);
                command.Parameters.AddWithValue("ngaymuon", dateTimePicker1.Text);
                command.Parameters.AddWithValue("ngaytra", dateTimePicker2.Text);
                command.Parameters.AddWithValue("sl", txtsl.Text);
                command.ExecuteNonQuery();

                DialogResult kq = MessageBox.Show("Bạn muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == System.Windows.Forms.DialogResult.Yes)
                {
                    load();
                    this.Hide();

                }
                FormnhapGV fs = new FormnhapGV(txtMM.Text);
                fs.Show();
            }
            catch
            {
                MessageBox.Show("Mã mmượn " + txtMM.Text + " đã tồn tại");
            }
        }
        private void btnRS_Click(object sender, EventArgs e)
        {
            txtMM.Text = "";
            txtsl.Text = "";
            cbtb.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            DialogResult kq = MessageBox.Show("Bạn muốn quay lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                fm.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();            
            }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
