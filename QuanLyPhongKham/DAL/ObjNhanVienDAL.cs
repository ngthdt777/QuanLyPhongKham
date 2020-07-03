using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DAL;

namespace QuanLyPhongKham.DAL
{
    class ObjNhanVienDAL
    {
        private static ObjNhanVienDAL instance;

        public static ObjNhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjNhanVienDAL();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string id { get; set; }
        public string ten { get; set; }
        public string sdt { get; set; }
        public string gtinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngsinh { get; set; }
        public DateTime ngvaolam { get; set; }
        public string maloainv { get; set; }
        public ObjNhanVienDAL() {  }


        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM NHANVIEN";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery);
            return dt;
        }



    }
}
