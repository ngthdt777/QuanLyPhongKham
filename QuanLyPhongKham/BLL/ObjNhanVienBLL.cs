using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.DAL;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyPhongKham.BLL
{
    class ObjNhanVienBLL
    {
        private static ObjNhanVienBLL instance;

        public static ObjNhanVienBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjNhanVienBLL();
                }
                return instance;
            }
            set { instance = value; }
        }
        private ObjNhanVienBLL() { }

        public DataTable GetData()
        {
            return ObjNhanVienDAL.Instance.GetInfo();
        }


    }
}
