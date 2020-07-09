using QuanLyPhongKham.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.BLL
{
    class ObjCTPNBLL
    {
        private static ObjCTPNBLL instance;

        public static ObjCTPNBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjCTPNBLL();
                }

                return instance;
            }

            private set => instance = value;
        }

        private ObjCTPNBLL() { }

        public void Add(ObjCTPNDAL ctpn)
        {
            ObjCTPNDAL.Add(ctpn);
        }
    }
}
