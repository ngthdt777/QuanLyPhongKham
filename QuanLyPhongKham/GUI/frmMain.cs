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
using QuanLyPhongKham.BLL;

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
            if (this.chucvi.CompareTo("2") == 0) //Bacsi
            {
                tabcontrolmain.Controls.Remove(tabp_hoadon);
                tabcontrolmain.Controls.Remove(tabp_pnh);
                tabcontrolmain.Controls.Remove(tabp_pxh);
                tabcontrolmain.Controls.Remove(tabp_kho);
                tabcontrolmain.Controls.Remove(tabp_dth);
            }
            else if (this.chucvi.CompareTo("3") == 0)//Tiep tan
            {
                tabcontrolmain.Controls.Remove(tabp_pnh);
                tabcontrolmain.Controls.Remove(tabp_pxh);
                tabcontrolmain.Controls.Remove(tabp_kho);
                tabcontrolmain.Controls.Remove(tabp_dth);
            }
            else if (this.chucvi.CompareTo("4") == 0)//Thu kho
            {
                tabcontrolmain.Controls.Remove(tabp_dth);
                tabcontrolmain.Controls.Remove(tabp_hsbn);
                tabcontrolmain.Controls.Remove(tabp_hoadon);
                tabcontrolmain.Controls.Remove(tabp_pkb);
            }
        }

        int CheckTabPage()
        {

            return tabcontrolmain.SelectedIndex;
        }


        public void frmMain_Load(object sender, EventArgs e)
        {
                Phanquyen();
            dgvHoSo.DataSource = ObjBenhNhanBLL.Instance.GetData();
            dgvDT.DataSource = ObjDonThuocBLL.Instance.GetData();
            dgvKhoThuoc.DataSource = ObjThuocBLL.Instance.GetData();
            dgv_hoadon.DataSource = ObjHoaDonBLL.Instance.GetData();
            int check = CheckTabPage();
                if (check == 0)
                {

                    

                }
                else if (check == 1)
                {
                    

                }
                else if (check == 2)
                {

                    
                }
                else if (check == 3)
                {

                }
                else if (check == 4)
                {
                    
                }
                else if (check == 5)
                {

                }
                else if (check == 6)
                {

                }
                else if (check == 7)
                {

                }
        }
    }
}
