using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.BLL;
using QuanLyPhongKham.DAL;
using System.Windows.Forms;
using QuanLyPhongKham.GUI;

namespace QuanLyPhongKham.DAL
{
    class ObjDonThuocDAL
    {
        private static ObjDonThuocDAL instance;

        public static ObjDonThuocDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjDonThuocDAL();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string id { get; set; }
        public string id_thuoc { get; set; }
        public string tenthuoc { get; set; }
        public string slg { get; set; }
        public string idNV { get; set; }
        public string idBN { get; set; }
        public ObjDonThuocDAL() { }


        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM DONTHUOC";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery, null);
            return dt;
        }

        public int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 MaDT FROM DonThuoc ";
            Query += "ORDER BY MaDT DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["MaDT"].ToString(), out nextID);
                ++nextID;
            }

            return nextID;
        }

        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            string AddQuery = "";
            AddQuery += "INSERT INTO DonThuoc(MaDT, NgDT, MaNV, MaBN) ";
            AddQuery += "VALUES (@MaDT, @NgDT, @MaNV, @MaBN)";

            DataTable dt = ObjThuocBLL.Instance.GetInfoByName(((frmMain)main).tb_tenThuoc.Text);

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaDT", ((frmMain)main).tb_maDT.Text);
            param.Add("@NgDT", ((frmMain)main).dt_DT.Value.ToString());
            param.Add("@MaNV", ((frmMain)main).tb_maNV.Text);
            param.Add("@MaBN", ((frmMain)main).tb_maBNThuoc.Text);

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm đơn thuốc thành công");
            }
        }

        public void Xoa()
        {
            Form main = Application.OpenForms["frmMain"];

            string DeleteQuery = "";
            DeleteQuery += "DELETE FROM DonThuoc ";
            DeleteQuery += "WHERE MaDT = @MaDT";
            
            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaDT", ((frmMain)main).tb_maDT.Text);

            int result = DataProvider.Instance.ExecuteNonQuery(DeleteQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Xóa đơn thuốc thành công");
            }
        }

        public void Sua()
        {
            Form main = Application.OpenForms["frmMain"];

            string UpdateQuery = "";
            UpdateQuery += "UPDATE DONTHUOC SET ";
            UpdateQuery += "NgDT = @NgDT ";
            UpdateQuery += "MaNV = @MaNV ";
            UpdateQuery += "MaBN = @MaBN ";
            UpdateQuery += "WHERE MaDT = @MaDT";

            DataTable dt = ObjThuocBLL.Instance.GetInfoByName(((frmMain)main).tb_tenThuoc.Text);

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaDT", ((frmMain)main).tb_maDT.Text);
            param.Add("@NgDT", ((frmMain)main).dt_DT.Value.ToString());
            param.Add("@MaNV", ((frmMain)main).tb_maNV.Text);
            param.Add("@MaBN", ((frmMain)main).tb_maBNThuoc.Text);

            int result = DataProvider.Instance.ExecuteNonQuery(UpdateQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Sửa đơn thuốc thành công");
            }
        }

        public DataTable Find()
        {
            DataTable dt = new DataTable();

            Form main = Application.OpenForms["frmMain"];

            string FindQuery = "";
            FindQuery += "SELECT * FROM DonThuoc ";
            FindQuery += "WHERE MaDT = @MaDT";

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaDT", ((frmMain)main).tb_maDT.Text.Trim());

            dt = DataProvider.Instance.ExecuteQuery(FindQuery, param);
            return dt;
        }
    }
}
