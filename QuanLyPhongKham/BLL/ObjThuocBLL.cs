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
    class ObjThuocBLL
    {
        private static ObjThuocBLL instance;

        public static ObjThuocBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjThuocBLL();
                }
                return instance;
            }
            set { instance = value; }
        }
        private ObjThuocBLL() { }


        public DataTable GetData()
        {
            return ObjThuocDAL.Instance.GetInfo();
        }

        public void AddThuoc()
        {
            ObjThuocDAL.Instance.AddThuoc();
        }

        public void XoaThuoc()
        {
            ObjThuocDAL.Instance.XoaThuoc();
        }

        public void SuaThuoc()
        {
            ObjThuocDAL.Instance.SuaThuoc();
        }



    }
}
