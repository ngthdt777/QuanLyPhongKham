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

        public void LoginCheck()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmLogin"];
            string acc = ((frmLogin)f).txb_account.Text;
            string pass = ((frmLogin)f).txb_pass.Text;
            string query = "SELECT * from Dangnhap WHERE taikhoan = '" + acc + "' AND matkhau = '" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                frmMain form = new frmMain(result.Rows[0][0].ToString(), result.Rows[0][1].ToString(), result.Rows[0][2].ToString());
                this.Hide();
                form.ShowDialog();
            }

            else
            {
                MessageBox.Show("Nhập lại tài khoản/ mật khẩu");

            }

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btt_login_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }
       /* bool LoginCheck()   
        {
            return QuanLyPhongKham.BLL.DataProvider.Instance.LoginCheck();
        }*/

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginCheck();
            }
        }

        private void txb_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginCheck();
            }
        }

    }
}
