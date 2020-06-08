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
        public int checkacc()
        {
            if (txb_account.Text.Substring(0, 1) == "tt")
                return 3;
            else if (txb_account.Text.Substring(0, 1) == "bs")
                return 2;
            else if (txb_account.Text.Substring(0, 1) == "tk")
                return 4;
            else if (txb_account.Text == "admin")
                return 1;
            return 5;
        }
    }
}
