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
using System.Drawing.Printing;

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
                ObjThuocBLL.Instance.AddThuoc();
            }
            else if (check == 2)
            {
                ObjDonThuocBLL.Instance.Add();
            }
            else if (check == 3)
            {

            }
            else if (check == 4)
            {
                ObjHoaDonBLL.Instance.Add();
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
                ObjThuocBLL.Instance.XoaThuoc();
            }
            else if (check == 2)
            {
                ObjDonThuocBLL.Instance.Xoa();
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
                ObjThuocBLL.Instance.SuaThuoc();
            }
            else if (check == 2)
            {
                ObjDonThuocBLL.Instance.Sua();
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
                dgvKhoThuoc.DataSource = ObjThuocBLL.Instance.FindThuoc();
            }
            else if (check == 2)
            {
                dgvDT.DataSource = ObjDonThuocBLL.Instance.Find();
            }
            else if (check == 3)
            {

            }
            else if (check == 4)
            {
                dgv_hoadon.DataSource = ObjHoaDonBLL.Instance.Find();
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

        private void btt_in_Click(object sender, EventArgs e)
        {
            var resultDialog = MessageBox.Show("In phiếu khám bệnh?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (resultDialog == DialogResult.OK)
            {
                bool result = PrintPDFPKB();

                if (result)
                {
                    MessageBox.Show("In pkb thành công");
                }
                else
                {
                    MessageBox.Show("In pkb thất bại");
                }
            }
        }

        private bool PrintPDFPKB()
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A3;

            var resultDialog = printDialog1.ShowDialog();

            if (resultDialog == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                    ObjPkbBLL.Instance.Add();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.ScaleTransform(1.5f, 1.5f);
            
            DataTable dt = ObjBenhNhanBLL.Instance.GetInfoByID(tb_maBNPKB.Text);

            Font font = new Font("Courier New", 12);
            Brush brush = new SolidBrush(Color.Black);

            float fontHeight = font.GetHeight();

            int startX = 10, startY = 10;

            //info benh nhan
            string id = String.Format("Mã bệnh nhân: {0}", tb_maBNPKB.Text);
            string name = String.Format("Tên bệnh nhân: {0}", dt.Rows[0]["TenBN"].ToString());
            string birthDate = String.Format("Ngày sinh: {0}", dt.Rows[0]["NgSinh"].ToString());
            string address = String.Format("Địa chỉ: {0}", dt.Rows[0]["DiaChi"].ToString());
            string phone = String.Format("SĐT: {0}", dt.Rows[0]["SoDT"].ToString());
            string symptom = String.Format("Triệu chứng: {0}", dt.Rows[0]["TrieuChung"].ToString());
            string insurance = String.Format("Bảo hiểm: {0}", dt.Rows[0]["BaoHiem"].ToString());
            string date = String.Format("Ngày khám: {0}", DateTime.Now.ToString());

            Graphics graphic = e.Graphics;
            graphic.DrawString("PHIẾU KHÁM BỆNH", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Red), startX, 0);

            graphic.DrawString(id, font, brush, startX, startY + 20);
            graphic.DrawString(name, font, brush, startX, startY + 40);
            graphic.DrawString(birthDate, font, brush, startX, startY + 60);
            graphic.DrawString(address, font, brush, startX, startY + 80);
            graphic.DrawString(phone, font, brush, startX, startY + 100);
            graphic.DrawString("--------------------------------", font, brush, startX, 120);
            graphic.DrawString(date, font, brush, startX, startY + 140);
            graphic.DrawString(symptom, font, brush, startX, startY + 160);
            graphic.DrawString("--------------------------------", font, brush, startX, 180);
            graphic.DrawString(String.Format("In ngày: {0}", DateTime.Now.ToString()), font, brush, startX, startY + 200);
            graphic.DrawString(insurance, font, brush, startX, startY + 220);

            graphic.DrawImage(Properties.Resources.pill, startX, startY + 260);
        }

        private void btt_pkb_findnv_Click(object sender, EventArgs e)
        {
            dgv_pkb_nv.DataSource = ObjPkbBLL.Instance.FindNv();
        }

        private void btt_pkb_findbn_Click(object sender, EventArgs e)
        {
            dgv_pkb_bn.DataSource= ObjPkbBLL.Instance.FindBn();
        }

        private void tb_pkb_findnv_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_pkb_findnv_Click(object sender, EventArgs e)
        {
            tb_pkb_findnv.Text = "";
        }

        private void tb_pkb_findbn_Click(object sender, EventArgs e)
        {
            tb_pkb_findbn.Text = "";
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
                check = CheckTabPage();
                ObjBenhNhanBLL.Instance.GetData();
            }
            else if (check == 1)
            {
                check = CheckTabPage();
                ObjThuocBLL.Instance.GetData();
            }
            else if (check == 2)
            {
                check = CheckTabPage();
                ObjDonThuocBLL.Instance.GetData();
            }
            else if (check == 3)
            {
                check = CheckTabPage();
                dgv_pkb_bn.DataSource = ObjBenhNhanBLL.Instance.GetData();
                dgv_pkb_nv.DataSource = ObjPkbBLL.Instance.GetDataNV();
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
