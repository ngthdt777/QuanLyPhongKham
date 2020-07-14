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
using QuanLyPhongKham.DAL;
using System.Runtime.Remoting.Messaging;

namespace QuanLyPhongKham.GUI
{
    public partial class frmMain : Form
    {
        string acc = "", pass = "", chucvi = "";
        private int nextPNID;
        private Dictionary<string, string[]> listPhNhap = new Dictionary<string, string[]>();
        private Dictionary<string, string[]> listDT = new Dictionary<string, string[]>();

        public frmMain(string acc, string pass, string chucvi)
        {
            InitializeComponent();
            this.acc = acc;
            this.pass = pass;
            this.chucvi = chucvi;

            ObjPhNhapBLL.Instance.GetNextID(out nextPNID);
            tb_pn_id.Text = nextPNID.ToString();

            tb_maDT.Text = ObjDonThuocBLL.Instance.GetNextID().ToString();

            dgvPNH.AutoGenerateColumns = false;
            
            dgvPNH.Columns.Add("MaThuoc", "Mã thuốc");
            dgvPNH.Columns.Add("TenThuoc", "Tên thuốc");
            dgvPNH.Columns.Add("SL", "Số lượng");
            dgvPNH.Columns.Add("NSX", "Ngày sản xuất");
            dgvPNH.Columns.Add("HSD", "Hạn sử dụng");
            dgvPNH.Columns.Add("NCC", "Nhà cung cấp");
            dgvPNH.Columns.Add("Gia", "Giá thuốc");
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

                tabcontrolmain.Controls.Remove(tabp_kho);
                tabcontrolmain.Controls.Remove(tabp_dth);
            }
            else if (this.chucvi.CompareTo("3") == 0)//Tiep tan
            {
                tabcontrolmain.Controls.Remove(tabp_pnh);

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

                for (int row = 0; row < dgvDT.Rows.Count - 1; ++row)
                {
                    int dtID = 1, sl = 0;
                    string maThuoc;

                    DataTable dt = ObjThuocBLL.Instance.GetInfoByName(dgvDT.Rows[row].Cells["TenThuocDT"].Value.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        maThuoc = dt.Rows[0]["MaThuoc"].ToString();
                        Int32.TryParse(tb_maDT.Text, out dtID);
                        Int32.TryParse(dgvDT.Rows[row].Cells["SoLuongDT"].Value.ToString(), out sl);

                        ObjCTDTBLL.Instance.Add(new ObjCTDTDAL(
                                dtID,
                                maThuoc,
                                dgvDT.Rows[row].Cells["TenThuocDT"].Value.ToString(),
                                sl
                            ));
                    }
                }

                listDT.Clear();
                dgvDT.Rows.Clear();
                tb_maDT.Text = ObjDonThuocBLL.Instance.GetNextID().ToString();
                tb_maNV.Text = tb_maBNThuoc.Text = String.Empty;
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
            else if (check == 6) //phieu nhap
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
                    ObjPkbBLL.Instance.Add();
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
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        private void updateSLInThuoc(string maThuoc, int sl)
        {
            DataTable dt = ObjThuocBLL.Instance.GetInfoByID(maThuoc);
            if (dt.Rows.Count > 0)
            {
                int slCu = 0;
                Int32.TryParse(dt.Rows[0]["SoLuong"].ToString(), out slCu);

                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("@MaThuoc", maThuoc);
                param.Add("@SL", (slCu + sl).ToString());

                ObjThuocBLL.Instance.Update(param);
            }
        }

        private void insertIntoCTPN()
        {
            for (int row = 0; row < dgvPNH.Rows.Count; ++row)
            {
                int idPN = 1, sl = 0;
                decimal gia = 0;
                
                Int32.TryParse(tb_pn_id.Text, out idPN);
                Int32.TryParse(dgvPNH.Rows[row].Cells["SL"].Value.ToString(), out sl);
                Decimal.TryParse(dgvPNH.Rows[row].Cells["Gia"].Value.ToString(), out gia);

                DataTable dt = ObjThuocBLL.Instance.GetInfoByID(dgvPNH.Rows[row].Cells["MaThuoc"].Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    updateSLInThuoc(dgvPNH.Rows[row].Cells["MaThuoc"].Value.ToString(), sl);
                }
                else
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("@MaThuoc", dgvPNH.Rows[row].Cells["MaThuoc"].Value.ToString());
                    param.Add("@TenThuoc", dgvPNH.Rows[row].Cells["TenThuoc"].Value.ToString());
                    param.Add("SL", dgvPNH.Rows[row].Cells["SL"].Value.ToString());
                    param.Add("NSX", dgvPNH.Rows[row].Cells["NSX"].Value.ToString());
                    param.Add("HSD", dgvPNH.Rows[row].Cells["HSD"].Value.ToString());
                    param.Add("NCC", dgvPNH.Rows[row].Cells["NCC"].Value.ToString());
                    param.Add("Gia", dgvPNH.Rows[row].Cells["Gia"].Value.ToString());

                    ObjThuocBLL.Instance.Add(param);
                }

                ObjCTPNBLL.Instance.Add(new ObjCTPNDAL(
                                        idPN,
                                        dgvPNH.Rows[row].Cells["MaThuoc"].Value.ToString(),
                                        dgvPNH.Rows[row].Cells["TenThuoc"].Value.ToString(),
                                        sl,
                                        dgvPNH.Rows[row].Cells["NSX"].Value.ToString(),
                                        dgvPNH.Rows[row].Cells["HSD"].Value.ToString(),
                                        dgvPNH.Rows[row].Cells["NCC"].Value.ToString(),
                                        gia
                                                      )
                );
            }
        }
        

        private void bttn_in_phnhap_Click(object sender, EventArgs e)
        {
            var resultDialog = MessageBox.Show("In phiếu nhập hàng?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultDialog == DialogResult.OK)
            {
                bool result = PrintPDFPN();

                if (result)
                {
                    MessageBox.Show("In phiếu nhập thành công");

                    //insert into table PhNhap
                    ObjPhNhapBLL.Instance.Add();

                    //insert into table CTPN
                    insertIntoCTPN();

                    listPhNhap.Clear();
                    dgvPNH.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("In phiếu nhập thất bại");
                }
            }

            ObjPhNhapBLL.Instance.GetNextID(out nextPNID);
            tb_pn_id.Text = nextPNID.ToString();
        }

        private bool PrintPDFPN()
        {
            printDocument2.DefaultPageSettings.Landscape = true;
            printDocument2.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A3;

            var resultDialog = printDialog1.ShowDialog();

            if (resultDialog == DialogResult.OK)
            {
                try
                {
                    printDocument2.Print();
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
            string birthDate = String.Format("Ngày sinh: {0}", dt.Rows[0]["NgSinh"].ToString().Substring(0, 10));
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

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.ScaleTransform(0.8f, 0.8f);

            Font font = new Font("Courier New", 12);
            Brush brush = new SolidBrush(Color.Black);

            float fontHeight = font.GetHeight();

            int startX = 10, startY = 10, offset = 100;

            //get max string length
            int maxLen = 0;
            foreach (string[] item in listPhNhap.Values.ToList())
            {
                int maxLenStr = item.Max(str => str.Length);
                if (maxLenStr > maxLen)
                {
                    maxLen = maxLenStr;
                }
            }

            //info phieu nhap
            string id = String.Format("Mã phiếu nhập: {0}", tb_pn_id.Text);
            string date = String.Format("Ngày nhập hàng: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

            string listHeader = String.Empty;
            listHeader += String.Format("{0,-15}", "Mã thuốc");
            listHeader += String.Format("{0,-15}", "Tên thuốc");
            listHeader += String.Format("{0,-15}", "Số lượng");
            listHeader += String.Format("{0,-15}", "Ngày sản xuất");
            listHeader += String.Format("{0,-15}", "Hạn sử dụng");
            listHeader += String.Format("{0,-15}", "Nhà cung cấp");
            listHeader += String.Format("{0,-15}", "Giá thuốc");




            Graphics graphic = e.Graphics;
            graphic.DrawString("PHIẾU NHẬP HÀNG", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Red), startX, 0);
            graphic.DrawString(id, font, brush, startX, startY + 20);
            graphic.DrawString(date, font, brush, startX, startY + 40);

            graphic.DrawString("--------------------------------", font, brush, startX, startY + 60);

            graphic.DrawString(listHeader, font, brush, startX, startY + 80);

            string format = "{0,-" + maxLen + "}\t";
            foreach (string[] items in listPhNhap.Values.ToList())
            {
                string itemStr = String.Empty;

                for (int itemInd = 0; itemInd < items.Length; ++itemInd)
                {
                    itemStr += String.Format(format, items[itemInd]);
                }

                graphic.DrawString(itemStr, font, new SolidBrush(Color.Gray), startX, startY + offset);

                offset += (int)fontHeight + 5;
            }

            graphic.DrawImage(Properties.Resources.pill, startX, startY + offset);
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

        private void btt_hoadon_thanhtien_Click(object sender, EventArgs e)
        {
            dgv_hoadon.DataSource = ObjHoaDonBLL.Instance.Check();
            tb_hoadon_trigia.Text = dgv_hoadon.Rows[0].Cells["Thanh tien"].Value.ToString();
        }

        private void btt_hoadon_luu_Click(object sender, EventArgs e)
        {
            ObjHoaDonBLL.Instance.AddHD();
        }

        private void btt_hoadon_danhsach_Click(object sender, EventArgs e)
        {
            dgv_hoadon.DataSource= ObjHoaDonBLL.Instance.Show();
        }

        private void bttn_addDT_Click(object sender, EventArgs e)
        {
            DataTable dt = ObjThuocBLL.Instance.GetInfoByName(tb_tenThuoc.Text);
            if (dt.Rows.Count > 0)
            {
                listDT.Add(tb_tenThuoc.Text, new string[] {
                    tb_tenThuoc.Text,
                    tb_slThuoc.Text
                });

                dgvDT.Rows.Add(listDT.Values.Last());

                //clear textboxes
                tb_tenThuoc.Text = tb_slThuoc.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Tên thuốc không tồn tại");
            }
        }

        private void bttn_delDT_Click(object sender, EventArgs e)
        {
            if (dgvDT.Rows.Count == 0)
            {
                return;
            }

            listDT.Remove(dgvDT.CurrentRow.Cells["TenThuocDT"].Value.ToString());
            dgvDT.Rows.RemoveAt(dgvDT.CurrentRow.Index);
        }

        private void bttn_updateDT_Click(object sender, EventArgs e)
        {
            if (dgvDT.Rows.Count == 0)
            {
                return;
            }

            listDT[dgvDT.CurrentRow.Cells["TenThuocDT"].Value.ToString()][1] = tb_slThuoc.Text;

            dgvDT.CurrentRow.Cells["SoLuongDT"].Value = tb_slThuoc.Text;
        }

        private void dgvDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_tenThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["TenThuocDT"].Value.ToString();
                tb_slThuoc.Text = dgvDT.Rows[e.RowIndex].Cells["SoLuongDT"].Value.ToString();
            }
            else
            {
                tb_tenThuoc.Text = tb_slThuoc.Text = String.Empty;
            }
        }

        private void btt_hsbn_them_Click(object sender, EventArgs e)
        {
            ObjBenhNhanBLL.Instance.Add();
        }

        private void btt_hsbn_sua_Click(object sender, EventArgs e)
        {
            ObjBenhNhanBLL.Instance.SuaBN();
        }

        private void btt_hsbn_xoa_Click(object sender, EventArgs e)
        {
            ObjBenhNhanBLL.Instance.Xoa();
        }

        private void btt_hsbn_tim_Click(object sender, EventArgs e)
        {
            dgvHoSo.DataSource = ObjBenhNhanBLL.Instance.FindBN();
        }

        private void btt_hoadon_tim_Click(object sender, EventArgs e)
        {
            dgv_hoadon.DataSource = ObjHoaDonBLL.Instance.Find();
        }

        private void btt_pnh_them_Click(object sender, EventArgs e)
        {

                try
                {
                    listPhNhap.Add(tb_maThuocPN.Text, new string[]
                    {
                        tb_maThuocPN.Text,
                        tb_tenThuocPN.Text,
                        tb_slPN.Text,
                        dt_nsxPN.Value.ToString(),
                        dt_hsdPN.Value.ToString(),
                        tb_nccPN.Text,
                        tb_giaPN.Text
                    });

                    dgvPNH.Rows.Add(listPhNhap.Values.Last());

                    //clear text boxes
                    tb_maThuocPN.Text = tb_tenThuocPN.Text = tb_slPN.Text = tb_nccPN.Text = tb_giaPN.Text = String.Empty;
                    dt_nsxPN.Value = dt_hsdPN.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trùng mã phiếu nhập hàng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }


        }

        private void btt_pnh_xoa_Click(object sender, EventArgs e)
        {
            {
                if (dgvPNH.Rows.Count == 0)
                {
                    return;
                }

                listPhNhap.Remove(dgvPNH.CurrentRow.Cells["MaThuoc"].Value.ToString());
                dgvPNH.Rows.RemoveAt(dgvPNH.CurrentRow.Index);
            }
        }

        private void dgv_pkb_nv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_pkb_bn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_pkb_nv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_pkb_bn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int CheckTabPage()
        {

            return tabcontrolmain.SelectedIndex;
        }


        public void frmMain_Load(object sender, EventArgs e)
        {
            Phanquyen();
            dgvHoSo.DataSource = ObjBenhNhanBLL.Instance.GetData();
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
