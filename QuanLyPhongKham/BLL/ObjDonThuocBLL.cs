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
    class ObjDonThuocBLL
    {
        private static ObjDonThuocBLL instance;

        public static ObjDonThuocBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjDonThuocBLL();
                }
                return instance;
            }
            set { instance = value; }
        }
        private ObjDonThuocBLL() { }


        public DataTable GetData()
        {
            return ObjDonThuocDAL.Instance.GetInfo();
        }

    }
}
