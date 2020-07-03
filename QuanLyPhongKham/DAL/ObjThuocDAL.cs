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
    class ObjThuocDAL
    {
        private static ObjThuocDAL instance;

        public static ObjThuocDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjThuocDAL();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string id { get; set; }
        public string tenth { get; set; }
        public string slg { get; set; }
        public DateTime nsx { get; set; }
        public DateTime hsd { get; set; }
        public string ncc { get; set; }
        public string gia { get; set; }
        public ObjThuocDAL() { }


        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM THUOC";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery);
            return dt;
        }


    }
}
