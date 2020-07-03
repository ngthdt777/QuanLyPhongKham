using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.DAL;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.BLL;

namespace QuanLyPhongKham.DAL
{
    class ObjBenhNhanDAL
    {
        private static ObjBenhNhanDAL instance;

        public static ObjBenhNhanDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjBenhNhanDAL();
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
        public DateTime ngkham { get; set; }
        public string trieuchung { get; set; }
        public string ketluan { get; set; }
        public string baohiem { get; set; }
        public ObjBenhNhanDAL() { }


        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM BENHNHAN";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery);
            return dt;
        }



    }

}
