using QuanLyPhongKham.BLL;
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
    class ObjPkbDAL
    {
        /*private string id;
        private string idBN;
        private DateTime ngKham;
        private string chuanDoan;
        private string idNV;*/

        private static ObjPkbDAL instance;

        public static ObjPkbDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjPkbDAL();
                }
                return instance;
            }

            private set { instance = value; }
        }

        private ObjPkbDAL() { }

        public DataTable GetInfoByID(String id)
        {
            string Query = "";
            Query += "SELECT * FROM PKB ";
            Query += "WHERE MaPKB = @MaPKB";

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaPKB", id);

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, param);
            return dt;
        }

        public string GetNextID()
        {
            string id;
            int nextID = 1;

            string Query = "";
            Query += "SELECT TOP 1 MaPKB ";
            Query += "FROM PKB ";
            Query += "ORDER BY MaPKB DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count == 0)
            {
                return id = nextID.ToString();
            }
            Int32.TryParse(dt.Rows[0]["MaPKB"].ToString(), out nextID);
            nextID++;
            return id = nextID.ToString();
        }

        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            DataTable dt = ObjBenhNhanBLL.Instance.GetInfoByID(((frmMain)main).tb_maBNPKB.Text);
            string chuanDoan = dt.Rows[0]["TrieuChung"].ToString();

            string AddQuery = "";
            AddQuery += "INSERT INTO PKB (MaPKB, MaBN, MaNV, NgayKham, ChuanDoan) ";
            AddQuery += "VALUES (@MaPKB, @MaBN, @MaNV, @NgKham, @ChDoan)";

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaPKB", GetNextID());
            param.Add("@MaBN", ((frmMain)main).tb_maBNPKB.Text);
            param.Add("@MaNV", ((frmMain)main).tb_maNVPKB.Text);
            param.Add("@NgKham", DateTime.Now.ToString());
            param.Add("@ChDoan", chuanDoan);

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm phiếu khám bệnh thành công");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        public void Xoa() { }

        public void Sua() { }
    }
}
