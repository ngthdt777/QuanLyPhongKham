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
    class ObjHoaDonBLL
    {
        private static ObjHoaDonBLL instance;

        public static ObjHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjHoaDonBLL();
                }
                return instance;
            }
            set { instance = value; }
        }
        private ObjHoaDonBLL() { }


        public DataTable GetData()
        {
            return ObjHoaDonDAL.Instance.GetInfo();
        }

        public void AddHD()
        {
            ObjHoaDonDAL.Instance.Add();
        }



        public DataTable Check()
        {
            return ObjHoaDonDAL.Instance.Check();
        }

        public DataTable Find()
        {
            return ObjHoaDonDAL.Instance.Find();
        }
        public DataTable Show()
        {
            return ObjHoaDonDAL.Instance.Show();
        }

        public DataTable TongHop()
        {
            return ObjHoaDonDAL.Instance.TongHop();
        }


    }
}
