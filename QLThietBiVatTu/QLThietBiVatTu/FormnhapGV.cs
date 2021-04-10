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
    
    public partial class FormnhapGV : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        private string mess;
        
        public FormnhapGV()
        {
            InitializeComponent();
        }
        public FormnhapGV(string Message) : this()
        {
            mess = Message;
            txtMM.Text = mess;
        }
        private void FormnhapGV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (txtMGV.Text == "")
            {
                SqlConnection cnn1 = new SqlConnection(str);
                string sql2 = "delete from ThongTinMuon where MaMuon=@mm";
                SqlCommand cmd = new SqlCommand(sql2, cnn1);
                cmd.Parameters.AddWithValue("mm", txtMM.Text);

                cmd.ExecuteNonQuery();
            }*/

            try
            {
                {
                    SqlConnection cnn = new SqlConnection(str);
                    cnn.Open();
                    string sql1 = "insert into GiaoVien values(@magv,@tengv,@mm,@sdt)";
                    SqlCommand command = new SqlCommand(sql1, cnn);
                    command.Parameters.AddWithValue("magv", txtMGV.Text);
                    command.Parameters.AddWithValue("tengv", txtTGV.Text);
                    command.Parameters.AddWithValue("mm", txtMM.Text);
                    command.Parameters.AddWithValue("sdt", txtSDT.Text);
                    command.ExecuteNonQuery();
                    FormTPM ftb = new FormTPM();
                    this.Hide();
                    ftb.Show();
                }
            }
            catch
            {
                MessageBox.Show("Mã giáo viên " + txtMGV + " đã tồn tại");
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
