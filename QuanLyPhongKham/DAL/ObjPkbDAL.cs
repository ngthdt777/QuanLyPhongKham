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

        public DataTable FindNv()
        {
            Form main = Application.OpenForms["frmMain"];
            string idnv = ((frmMain)main).tb_pkb_findnv.Text.ToString();

            string Query = "";
            Query += "SELECT  MaNv,TenNV ";
            Query += "FROM NhanVien ";
            Query += "Where MaNv='" + idnv + "'";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);

            return dt;
        }

        public DataTable FindBn()
        {
            Form main = Application.OpenForms["frmMain"];
            string idbn = ((frmMain)main).tb_pkb_findbn.Text.ToString();

            string Query = "";
            Query += "SELECT  MaBN,TenBN,GioiTinh,TrieuChung ";
            Query += "FROM BenhNhan ";
            Query += "Where MaBN='" + idbn + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);

            return dt;
        }

        public DataTable GetDataNV()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM NhanVien";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery, null);
            return dt;

        }








    }
}
