using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.DAL
{
    class Thuoc
    {
        public string id { get; set; }
        public string tenth { get; set; }
        public string slg { get; set; }
        public DateTime nsx { get; set; }
        public DateTime hsd { get; set; }
        public string ncc { get; set; }
        public string gia { get; set; }
        public Thuoc() { }
    }
}
