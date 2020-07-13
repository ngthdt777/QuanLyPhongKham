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

        public int GetNextID()
        {
            return ObjDonThuocDAL.Instance.GetNextID();
        }

        public void Add()
        {
            ObjDonThuocDAL.Instance.Add();
        }

        public void Xoa()
        {
            ObjDonThuocDAL.Instance.Xoa();
        }

        public void Sua()
        {
            ObjDonThuocDAL.Instance.Sua();
        }

        public DataTable Find()
        {
            return ObjDonThuocDAL.Instance.Find();
        }
    }
}
