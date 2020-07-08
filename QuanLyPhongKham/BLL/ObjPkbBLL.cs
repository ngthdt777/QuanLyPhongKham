using QuanLyPhongKham.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.BLL
{
    class ObjPkbBLL
    {
        private static ObjPkbBLL instance;

        public static ObjPkbBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjPkbBLL();
                }
                return instance;
            }

            private set { instance = value; }
        }

        private ObjPkbBLL() { }

        public DataTable GetInfoByID(String id)
        {
            return ObjPkbDAL.Instance.GetInfoByID(id);
        }

        public string GetNextID()
        {
            return ObjPkbDAL.Instance.GetNextID();
        } 

        public void Add()
        {
            ObjPkbDAL.Instance.Add();
        }

        public DataTable FindBn()
        {
            return ObjPkbDAL.Instance.FindBn();
        }


        public DataTable FindNv()
        {
            return ObjPkbDAL.Instance.FindNv();
        }

        public DataTable GetDataNV()
        {
            return ObjPkbDAL.Instance.GetDataNV();
        }


    }
}
