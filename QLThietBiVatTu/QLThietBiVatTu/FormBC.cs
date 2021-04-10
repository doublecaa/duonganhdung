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
    public partial class FormBC : Form
    {
        public FormBC()
        {
            InitializeComponent();
        }
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void FormBC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLTBDataSet1.vwBC' table. You can move, or remove it, as needed.
            this.vwBCTableAdapter.Fill(this.QLTBDataSet1.vwBC);
            // TODO: This line of code loads data into the 'QLTBDataSet.ThietBi' table. You can move, or remove it, as needed.
            this.ThietBiTableAdapter.Fill(this.QLTBDataSet.ThietBi);

            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
