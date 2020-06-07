using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.DAL
{
    class NhanVien
    {
        public string id { get; set; }
        public string ten { get; set; }
        public string sdt { get; set; }
        public string gtinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngsinh { get; set; }
        public DateTime ngvaolam { get; set; }
        public string maloainv { get; set; }
        public NhanVien() {  }
    }
}
