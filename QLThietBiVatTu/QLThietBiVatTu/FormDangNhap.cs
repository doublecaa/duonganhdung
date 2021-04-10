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
   
    public partial class FormDangNhap : Form
    {
        string sqlstr = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (kq == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection cnn = new SqlConnection(sqlstr);
                cnn.Open();
                string sql = "select * from loggin where taikhoan=@acc and matkhau=@pass";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.Add(new SqlParameter("@acc", txtTK.Text));
                command.Parameters.Add(new SqlParameter("@pass", txtMK.Text));
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adap.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    string sql1 = "select _rank from loggin where taikhoan=@acc and matkhau=@pass";


                    SqlCommand command1 = new SqlCommand(sql1, cnn);
                    command1.Parameters.Add(new SqlParameter("@acc", txtTK.Text));
                    command1.Parameters.Add(new SqlParameter("@pass", txtMK.Text));
                    int x = (int)command1.ExecuteScalar();

                    if (x == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công quyền admin");
                        this.Hide();
                        FormMain fm = new FormMain();
                        fm.Show();
                    }
                    else if (x == 0)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        this.Hide();
                        FormTTdanhchoGV ftt = new FormTTdanhchoGV();
                        ftt.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    txtTK.Text = "";
                    txtMK.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            this.txtMK.PasswordChar = '*';
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
