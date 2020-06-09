using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongKham.GUI;

namespace QuanLyPhongKham.GUI
{
    public partial class frmMain : Form
    {
        string acc = "", pass = "", chucvi = "";
        public frmMain(string acc, string pass, string chucvi)
        {
            InitializeComponent();
            this.acc = acc;
            this.pass = pass;
            this.chucvi = chucvi;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Phanquyen()
        {
            if (this.chucvi == "2")//Bacsi
            {
                tabcontrolmain.Controls.Remove(tabp_hoadon);
                tabcontrolmain.Controls.Remove(tabp_pnh);
                tabcontrolmain.Controls.Remove(tabp_pxh);
                tabcontrolmain.Controls.Remove(tabp_kho);
                tabcontrolmain.Controls.Remove(tabp_dth);
            }
            else if (this.chucvi == "3")//Tiep tan
            {
                tabcontrolmain.Controls.Remove(tabp_pnh);
                tabcontrolmain.Controls.Remove(tabp_pxh);
                tabcontrolmain.Controls.Remove(tabp_kho);
                tabcontrolmain.Controls.Remove(tabp_dth);
            }
            else if (this.chucvi == "4")//Thu kho
            {
                tabcontrolmain.Controls.Remove(tabp_dth);
                tabcontrolmain.Controls.Remove(tabp_hsbn);
                tabcontrolmain.Controls.Remove(tabp_hoadon);
                tabcontrolmain.Controls.Remove(tabp_pkb);
            }
        }
        public void frmMain_Load(object sender, EventArgs e)
        {
            Phanquyen();
        }
    }
}
