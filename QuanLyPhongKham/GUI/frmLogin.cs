using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongKham.BLL;

namespace QuanLyPhongKham.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btt_login_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {
                MessageBox.Show("OKE");
            }
        }
        bool LoginCheck()
        {
            return QuanLyPhongKham.BLL.DataProvider.Instance.LoginCheck();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { 
              if (LoginCheck())
              {
                    MessageBox.Show("OKE");
              }
            }
        }

        private void txb_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (LoginCheck())
                {
                    frmMain f = new frmMain();
                    this.Hide();
                    f.Show();
                }
            }
        }
    }
}
