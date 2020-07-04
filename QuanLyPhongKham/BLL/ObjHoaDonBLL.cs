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

        public void Add()
        {
            ObjHoaDonDAL.Instance.Add();
        }

        public void Xoa()
        {

        }

        public void Sua()
        {

        }

        public DataTable Find()
        {
            return ObjHoaDonDAL.Instance.Find();
        }
    }
}
