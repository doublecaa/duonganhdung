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
    public partial class Formnhapso : Form
    {
        string str = "Data Source=DESKTOP-742OH1B;Initial Catalog=QLTB;Integrated Security=True";
        private string mess;
        public Formnhapso()
        {
            InitializeComponent();
        }

        public Formnhapso(string Message) : this()
        {
            mess = Message;
            txtTB.Text = Message;
        }
        private void Formnhapso_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string sql1 = "insert into Kho values(@matb,@sl)";
            SqlCommand command = new SqlCommand(sql1, cnn);
            command.Parameters.AddWithValue("matb", txtTB.Text);
            command.Parameters.AddWithValue("sl", txtNS.Text);
            command.ExecuteNonQuery();
            FormTTB ftb = new FormTTB();
            this.Hide();
            ftb.Show();
            
        }

        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
