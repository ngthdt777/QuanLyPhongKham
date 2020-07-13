using QuanLyPhongKham.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.BLL
{
    class ObjCTDTBLL
    {
        private static readonly Lazy<ObjCTDTBLL> instance = new Lazy<ObjCTDTBLL>(() => new ObjCTDTBLL());

        public static ObjCTDTBLL Instance
        {
            get => instance.Value;
        }

        private ObjCTDTBLL() { }

        public void Add(ObjCTDTDAL ctdt)
        {
            ObjCTDTDAL.Add(ctdt);
        }
    }
}
