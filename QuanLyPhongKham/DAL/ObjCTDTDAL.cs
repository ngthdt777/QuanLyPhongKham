using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.DAL
{
    class ObjCTDTDAL
    {
        private int maDT, sl;
        private string maThuoc, tenThuoc;

        public ObjCTDTDAL(int maDT, string maThuoc, string tenThuoc, int sl)
        {
            this.maDT = maDT;
            this.maThuoc = maThuoc;
            this.tenThuoc = tenThuoc;
            this.sl = sl;
        }

        private static int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 MaCTDT FROM CTDT ";
            Query += "ORDER BY MaCTDT DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["MaCTDT"].ToString(), out nextID);
                ++nextID;
            }

            return nextID;
        }

        public static void Add(ObjCTDTDAL ctdt)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            string AddQuery = String.Empty;
            AddQuery += "INSERT INTO CTDT (MaCTDT, MaDT, MaThuoc, TenThuoc, SoLuong) ";
            AddQuery += "VALUES (@MaCTDT, @MaDT, @MaThuoc, @TenThuoc, @SoLuong)";

            param.Add("@MaCTDT", GetNextID().ToString());
            param.Add("@MaDT", ctdt.maDT.ToString());
            param.Add("@MaThuoc", ctdt.maThuoc);
            param.Add("@TenThuoc", ctdt.tenThuoc);
            param.Add("@SoLuong", ctdt.sl.ToString());

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                Console.WriteLine("Thêm CTDT thành công");
            }
        }
    }
}
