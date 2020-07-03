using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyPhongKham.BLL;
using QuanLyPhongKham.DAL;

namespace QuanLyPhongKham.DAL
{
    class ObjHoaDonDAL
    {
        private static ObjHoaDonDAL instance;

        public static ObjHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjHoaDonDAL();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string id { get; set; }
        public string id_dt { get; set; }
        public DateTime nghd { get; set; }
        public string trigia { get; set; }
        public ObjHoaDonDAL() { }

        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM DONTHUOC";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery);
            return dt;
        }

    }
}
