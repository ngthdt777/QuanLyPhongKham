using QuanLyPhongKham.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham.DAL
{
    class ObjCTPNDAL
    {
        private string maThuoc, tenThuoc, nsx, hsd, ncc;
        private int maPN, soLuong;
        private decimal gia;

        public ObjCTPNDAL(int maPN, string maThuoc, string tenThuoc, int soLuong, string nsx, string hsd, string ncc, decimal gia) {
            this.maPN = maPN;
            this.maThuoc = maThuoc;
            this.tenThuoc = tenThuoc;
            this.soLuong = soLuong;
            this.nsx = nsx;
            this.hsd = hsd;
            this.ncc = ncc;
            this.gia = gia;
        }

        private static int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 MaCTPN FROM CTPN ";
            Query += "ORDER BY MaCTPN DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["MaCTPN"].ToString(), out nextID);
                ++nextID;
            }

            return nextID;
        }

        public static void Add(ObjCTPNDAL ctpn)
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            string AddQuery = String.Empty;
            AddQuery += "INSERT INTO CTPN (MaCTPN, MaPN, MaThuoc, TenThuoc, SoLuong, NSX, HSD, NCC, Gia) ";
            AddQuery += "VALUES (@MaCTPN, @MaPN, @MaThuoc, @TenThuoc, @SL, @NSX, @HSD, @NCC, @Gia)";

            param.Add("@MaCTPN", ObjCTPNDAL.GetNextID().ToString());
            param.Add("@MaPN", ctpn.maPN.ToString());
            param.Add("@MaThuoc", ctpn.maThuoc);
            param.Add("@TenThuoc", ctpn.tenThuoc);
            param.Add("@SL", ctpn.soLuong.ToString());
            param.Add("@NSX", ctpn.nsx);
            param.Add("@HSD", ctpn.hsd);
            param.Add("@NCC", ctpn.ncc);
            param.Add("@Gia", ctpn.gia.ToString());

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                Console.WriteLine("Thêm CTPN thành công");
            }
        }
    }
}
