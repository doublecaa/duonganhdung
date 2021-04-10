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
    public partial class FormMain : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adapter=new SqlDataAdapter();
        DataTable table = new DataTable();
        
      
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {            
            
           
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChinhSuaTB fcstb = new FormChinhSuaTB();
            this.Hide();
            fcstb.Show();
        }


        private void quayLạiĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormDangNhap fdn = new FormDangNhap();
            DialogResult kq = MessageBox.Show("Bạn muốn quay lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                fdn.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void thôngTinGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChinhSuaGV fcsgv = new FormChinhSuaGV();
            this.Close();
            fcsgv.Show();
        }

        private void refeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
               
        }

        private void thêmMớiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTTB ftb = new FormTTB();
            this.Close();
            ftb.Show();
        }

        private void tạoPhiếuMượnThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTPM f1 = new FormTPM();
            this.Close();
            f1.Show();
        }

        private void tạoBáoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBC bc = new FormBC();
            bc.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
