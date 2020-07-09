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
    class ObjPhNhapDAL
    {
        private static ObjPhNhapDAL instance;

        public static ObjPhNhapDAL Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new ObjPhNhapDAL();
                }
                return instance;
            }

            private set => instance = value;
        }

        private ObjPhNhapDAL() { }

        public void GetNextID(out int id)
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 MaPN FROM PhNhap ";
            Query += "ORDER BY MaPN DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["MaPN"].ToString(), out nextID);
                ++nextID;
            }
            id = nextID;
        }

        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            string AddQuery = String.Empty;
            AddQuery = String.Empty;
            AddQuery += "INSERT INTO PhNhap (MaPN, NgPhieuNhap) ";
            AddQuery += "VALUES (@MaPN, @NgPN)";

            param.Add("@MaPN", ((frmMain)main).tb_pn_id.Text);
            param.Add("@NgPN", DateTime.Now.ToString());

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm phiếu nhập thành công");
            }
        }
    }
}
