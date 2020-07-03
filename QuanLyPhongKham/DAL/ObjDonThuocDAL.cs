using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.BLL;
using QuanLyPhongKham.DAL;

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
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery);
            return dt;
        }


    }
}
