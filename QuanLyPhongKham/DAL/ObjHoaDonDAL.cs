using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyPhongKham.BLL;
using QuanLyPhongKham.DAL;
using System.Windows.Forms;
using QuanLyPhongKham.GUI;

namespace QuanLyPhongKham.DAL
{
    class ObjHoaDonDAL
    {
        private static ObjHoaDonDAL instance;

        public static ObjHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjHoaDonDAL();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string id { get; set; }
        public string id_dt { get; set; }
        public DateTime nghd { get; set; }
        public string trigia { get; set; }
        public ObjHoaDonDAL() { }

        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM HoaDon";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery, null);
            return dt;
        }

        public void Add()
        {
           /* Form main = Application.OpenForms["frmMain"];

            string AddQuery = "";
            AddQuery += "INSERT INTO HoaDon(MaHD, MaDT, NgHD, TriGia) ";
            AddQuery += "VALUES (@MaHD, @MaDT, @NgHD, @TG)";

            DataTable dt = ObjThuocBLL.Instance.GetInfoByName(((frmMain)main).tb_tenThuoc.Text);

            Dictionary<String, String> param = new Dictionary<string, string>();
         ///   param.Add("@MaHD", ((frmMain)main).tb_maHD.Text);
            param.Add("@MaDT", ((frmMain)main).tb_maDTHoaDon.Text);
            param.Add("@NgHD", DateTime.Now.ToString());
         //   param.Add("@TG", ((frmMain)main).tb_triGia.Text);

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm hóa đơn thành công");
            }*/


            DataTable dt = new DataTable();

            Form main = Application.OpenForms["frmMain"];
            int iddt = Int32.Parse(((frmMain)main).tb_maDTHoaDon.Text.ToString());
            string stt = ((frmMain)main).tb_maDTHoaDon.Text;


            string AddQuery = "";
            AddQuery += "INSERT INTO HoaDon(MaHD, MaDT, NgHD, TriGia) ";
            AddQuery += "VALUES (@MaHD, @MaDT, @NgHD, @TG)";


            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaHD", "HD" + stt );
            param.Add("@MaDT", ((frmMain)main).tb_maDTHoaDon.Text);
            param.Add("@NgHD", ((frmMain)main).dgv_hoadon.Rows[0].Cells["NgKham"].Value.ToString());
            param.Add("@TG", ((frmMain)main).tb_hoadon_trigia.Text);

            int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm hóa đơn thành công");
            }



        }


        public DataTable Find()
        {
            DataTable dt = new DataTable();

            Form main = Application.OpenForms["frmMain"];

            string FindQuery = "";
            FindQuery += "SELECT * FROM HoaDon ";
            FindQuery += "WHERE MaHD = @MaHD";

            Dictionary<String, String> param = new Dictionary<string, string>();
        //    param.Add("@MaHD", ((frmMain)main).tb_maHD.Text.Trim());

            dt = DataProvider.Instance.ExecuteQuery(FindQuery, param);
            return dt;
        }


        public DataTable Check()
        {
            DataTable dt = new DataTable();

            Form main = Application.OpenForms["frmMain"];
            int iddt = Int32.Parse(((frmMain)main).tb_maDTHoaDon.Text.ToString());

            string FindQuery = "";
            FindQuery += "SELECT DonThuoc.MaDT,TenNV,TenBN,CAST(DonThuoc.NgDT AS DATE) AS [NgKham] ,Thuoc.Gia * CTDT.SoLuong as [Thanh tien]";
            FindQuery += "from DonThuoc,Thuoc,BenhNhan,NhanVien,CTDT ";
            FindQuery += "where DonThuoc.MaDT ='"+iddt+"' and CTDT.MaThuoc = Thuoc.MaThuoc and  DonThuoc.MaBN = BenhNhan.MaBN and DonThuoc.MaNV = NhanVien.MaNV";
            FindQuery += " and DonThuoc.MaDT = CTDT.MaDT";

            dt = DataProvider.Instance.ExecuteQuery(FindQuery,null);

            return dt;
        }


        public DataTable Show()
        {
            DataTable dt = new DataTable();


            string FindQuery = "";
            FindQuery += "SELECT *";
            FindQuery += "from HoaDon ";


            dt = DataProvider.Instance.ExecuteQuery(FindQuery, null);

            return dt;
        }


        public DataTable TongHop()
        {
            DataTable dt = new DataTable();

            Form main = Application.OpenForms["frmMain"];
            string from = ((frmMain)main).dtp_doanhthu_from.Value.ToString("MM/dd/yyyy");
            string to = ((frmMain)main).dtp_doanhthu_to.Value.ToString("MM/dd/yyyy");



            string FindQuery = "";
            FindQuery += "SELECT NgDT AS [Ngay],count(MaBN) as [SoBenhNhan], Sum(convert(int,TriGia,0)) As [DoanhThu] ";
            FindQuery += "FROM DonThuoc,HoaDon Where NgDT between '" + from +  "' and '" + to + "' and DonThuoc.MaDT= HoaDon.MaDT ";
            FindQuery += "group by NgDT";
            FindQuery += " order by NgDT";

            dt = DataProvider.Instance.ExecuteQuery(FindQuery, null);

            return dt;
        }











    }
}
