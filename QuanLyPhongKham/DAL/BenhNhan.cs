using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.DAL
{
    class BenhNhan
    {
        public string id { get; set; }
        public string ten { get; set; }
        public string sdt { get; set; }
        public string gtinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngsinh { get; set; }
        public DateTime ngkham { get; set; }
        public string trieuchung { get; set; }
        public string ketluan { get; set; }
        public string baohiem { get; set; }
        public BenhNhan() { }
    }
}
