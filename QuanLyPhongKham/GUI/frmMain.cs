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

        private void btt_Add_Click(object sender, EventArgs e)
        {
            int check = CheckTabPage();
            if (check == 0)
            {
                ObjBenhNhanBLL.Instance.Add();
              
            }
            else if (check == 1)
            {


            }
            else if (check == 2)
            {
                ObjThuocBLL.Instance.AddThuoc();

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

        private void Btt_Xoa_Click(object sender, EventArgs e)
        {
            int check = CheckTabPage();
            if (check == 0)
            {
                ObjBenhNhanBLL.Instance.Xoa();

            }
            else if (check == 1)
            {


            }
            else if (check == 2)
            {
                ObjThuocBLL.Instance.XoaThuoc();

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

        private void btt_Sua_Click(object sender, EventArgs e)
        {
            int check = CheckTabPage();
            if (check == 0)
            {
                ObjBenhNhanBLL.Instance.SuaBN();

            }
            else if (check == 1)
            {


            }
            else if (check == 2)
            {
                ObjThuocBLL.Instance.SuaThuoc();

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

        private void btt_hsbn_Reload_Click(object sender, EventArgs e)
        {
            dgvHoSo.DataSource = ObjBenhNhanBLL.Instance.GetData();
        }

        private void btt_khothuoc_Reload_Click(object sender, EventArgs e)
        {
            dgvKhoThuoc.DataSource = ObjThuocBLL.Instance.GetData();
        }

        private void dgvHoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                tb_bn_id.Text= dgvHoSo.Rows[e.RowIndex].Cells["MaBn"].Value.ToString();
                tb_bn_ten.Text=dgvHoSo.Rows[e.RowIndex].Cells["TenBn"].Value.ToString();
                tb_bn_sdt.Text=dgvHoSo.Rows[e.RowIndex].Cells["SoDT"].Value.ToString();
                cb_bn_sex.Text=dgvHoSo.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                tb_bn_add.Text=dgvHoSo.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                ngaySinhPicker.Text=dgvHoSo.Rows[e.RowIndex].Cells["NgSinh"].Value.ToString();
                ngayKhamPicker.Text=dgvHoSo.Rows[e.RowIndex].Cells["NgKham"].Value.ToString();
                tb_bn_trieuchung.Text=dgvHoSo.Rows[e.RowIndex].Cells["TrieuChung"].Value.ToString();
                tb_bn_klb.Text=dgvHoSo.Rows[e.RowIndex].Cells["KetLuanBenh"].Value.ToString();
                tb_bn_baohiem.Text=dgvHoSo.Rows[e.RowIndex].Cells["BaoHiem"].Value.ToString();
            }
        }

        private void dgvHoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                tb_bn_id.Text = dgvHoSo.Rows[e.RowIndex].Cells["MaBn"].Value.ToString();
                tb_bn_ten.Text = dgvHoSo.Rows[e.RowIndex].Cells["TenBn"].Value.ToString();
                tb_bn_sdt.Text = dgvHoSo.Rows[e.RowIndex].Cells["SoDT"].Value.ToString();
                cb_bn_sex.Text = dgvHoSo.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                tb_bn_add.Text = dgvHoSo.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                ngaySinhPicker.Text = dgvHoSo.Rows[e.RowIndex].Cells["NgSinh"].Value.ToString();
                ngayKhamPicker.Text = dgvHoSo.Rows[e.RowIndex].Cells["NgKham"].Value.ToString();
                tb_bn_trieuchung.Text = dgvHoSo.Rows[e.RowIndex].Cells["TrieuChung"].Value.ToString();
                tb_bn_klb.Text = dgvHoSo.Rows[e.RowIndex].Cells["KetLuanBenh"].Value.ToString();
                tb_bn_baohiem.Text = dgvHoSo.Rows[e.RowIndex].Cells["BaoHiem"].Value.ToString();
            }
        }

        private void Btt_Find_Click(object sender, EventArgs e)
        {
            int check = CheckTabPage();
            if (check == 0)
            {
                dgvHoSo.DataSource = ObjBenhNhanBLL.Instance.FindBN();
                
            }
            else if (check == 1)
            {


            }
            else if (check == 2)
            {
                dgvKhoThuoc.DataSource = ObjThuocBLL.Instance.FindThuoc();

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

        private void dgvKhoThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  int index = e.RowIndex;
            if (index >= 0)
            {
                tb_maThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["MaThuoc"].Value.ToString();
                tb_tenThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["TenThuoc"].Value.ToString();
                tb_slThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                tb_nhaCC.Text = dgvDT.Rows[e.RowIndex].Cells["NCC"].Value.ToString();
                ngaySanXuatPicker.Text = dgvDT.Rows[e.RowIndex].Cells["NSX"].Value.ToString();
                hanSDPicker.Text = dgvDT.Rows[e.RowIndex].Cells["HSD"].Value.ToString();
                tb_giaThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["Gia"].Value.ToString();

            }*/
        }

        private void dgvKhoThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         /*   int index = e.RowIndex;
            if (index >= 0)
            {
                tb_maThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["MaThuoc"].Value.ToString();
                tb_tenThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["TenThuoc"].Value.ToString();
                tb_slThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                tb_nhaCC.Text = dgvDT.Rows[e.RowIndex].Cells["NCC"].Value.ToString();
                ngaySanXuatPicker.Text = dgvDT.Rows[e.RowIndex].Cells["NSX"].Value.ToString();
                hanSDPicker.Text = dgvDT.Rows[e.RowIndex].Cells["HSD"].Value.ToString();
                tb_giaThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["Gia"].Value.ToString();

            }*/
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
                //ObjBenhNhanBLL.Instance.GetData();
                    

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
