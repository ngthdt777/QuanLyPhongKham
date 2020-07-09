using QuanLyPhongKham.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.BLL
{
    class ObjPhNhapBLL
    {
        private static ObjPhNhapBLL instance;

        public static ObjPhNhapBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjPhNhapBLL();
                }
                return instance;
            }

            private set => instance = value;
        }

        private ObjPhNhapBLL() { }

        public void GetNextID(out int id)
        {
            ObjPhNhapDAL.Instance.GetNextID(out id);
        }

        public void Add()
        {
            ObjPhNhapDAL.Instance.Add();
        }
    }
}
