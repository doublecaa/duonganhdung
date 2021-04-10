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
    public partial class FormTTB : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";

      
        void load()
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sqltb = "select tb.MaTB,TenTB,NSX,Soluong from ThietBi tb join Kho k on tb.MaTB=k.MaTB";
            SqlCommand cmd = new SqlCommand(sqltb, cnn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FormTTB()
        {
            InitializeComponent();
        }

        private void FormTTB_Load(object sender, EventArgs e)
        {
          
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMTB.TextLength == 0) MessageBox.Show("Mã thiết bị không được trống");
            else if (txtTenTB.TextLength == 0) MessageBox.Show("Tên thiết bị không được trống");
            else
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(str);
                    cnn.Open();
                    string sql1 = "insert into ThietBi values(@matb,@tentb,@nsx)";
                    SqlCommand command = new SqlCommand(sql1, cnn);
                    command.Parameters.AddWithValue("matb", txtMTB.Text);
                    command.Parameters.AddWithValue("tentb", txtTenTB.Text);
                    command.Parameters.AddWithValue("nsx", txtNSX.Text);
                    command.ExecuteNonQuery();

                    DialogResult kq = MessageBox.Show("Bạn muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == System.Windows.Forms.DialogResult.Yes)
                    {
                        load();
                        this.Hide();

                    }
                    Formnhapso fs = new Formnhapso(txtMTB.Text);
                    fs.Show();
                }
                catch
                {
                    MessageBox.Show("Mã thiết bị " + txtMTB.Text + " đã tồn tại");
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMTB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenTB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }


        private void btnRS_Click(object sender, EventArgs e)
        {
            txtTenTB.Text = "";
            txtMTB.Text = "";
            txtNSX.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            DialogResult kq = MessageBox.Show("Bạn muốn quay lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                fm.Show();
                this.Hide();
            }

        }
    }
}
