using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.DAL;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.BLL;
using System.Windows.Forms;
using QuanLyPhongKham.GUI;

namespace QuanLyPhongKham.DAL
{
    class ObjBenhNhanDAL
    {
        private static ObjBenhNhanDAL instance;

        public static ObjBenhNhanDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjBenhNhanDAL();
                }
                return instance;
            }
            set { instance = value; }
        }

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
        public ObjBenhNhanDAL() { }


        public DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM BENHNHAN";
            dt = DataProvider.Instance.ExecuteQuery(LoadQuery, null);
            return dt;
        }

        public DataTable GetInfoByID(String id)
        {
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM BenhNhan ";
            LoadQuery += "WHERE MaBN = @MaBN";

            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("@MaBN", id);

            DataTable dt = DataProvider.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }

        public void AddBN()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id = ((frmMain)f).tb_bn_id.Text;
            string ten = ((frmMain)f).tb_bn_ten.Text;
            string sdt = ((frmMain)f).tb_bn_sdt.Text;
            string gtinh = ((frmMain)f).cb_bn_sex.Text;
            string dchi = ((frmMain)f).tb_bn_add.Text;
            string ngsinh = ((frmMain)f).ngaySinhPicker.Value.ToString("MM//dd/YY") ;
            string ngkham = ((frmMain)f).ngayKhamPicker.Value.ToString("MM//dd/YY");
            string trieuchung = ((frmMain)f).tb_bn_trieuchung.Text;
            string klb = ((frmMain)f).tb_bn_klb.Text;
            string baohiem = ((frmMain)f).tb_bn_baohiem.Text;


            string AddQuery = "INSERT INTO BENHNHAN(MaBN,TenBN,SoDT,GioiTinh,DiaChi,NgSinh,NgKham,TrieuChung,KetLuanBenh,BaoHiem)" + 
                    "VALUES('" + id + "', '" + ten + "', '" + sdt + "', '" + gtinh + "', '" + dchi + "', CAST('"+ngsinh+ "' AS DATETIME),  CAST('" + ngkham + "' AS DATETIME), '" + trieuchung + "', '" + klb + "', '" + baohiem + "' )";
                int result = DataProvider.Instance.ExecuteNonQuery(AddQuery, null);
                if (result > 0)
                {
                    MessageBox.Show("OKE đã thêm ");
                }



        }


        public void XoaBN()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id_xoa = ((frmMain)f).tb_bn_id.Text;
            string DeleteQuery = "DELETE FROM BENHNHAN WHERE MaBN = '" + id_xoa + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(DeleteQuery, null);
            if (result > 0)
            {
                MessageBox.Show("Bệnh nhân đã bị xoá,bấm xem để xem dữ liệu mới", "Thông báo", MessageBoxButtons.OK);
            }
        }


        public void SuaBN()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id = ((frmMain)f).tb_bn_id.Text;
            string ten = ((frmMain)f).tb_bn_ten.Text;
            string sdt = ((frmMain)f).tb_bn_sdt.Text;
            string gtinh = ((frmMain)f).cb_bn_sex.Text;
            string dchi = ((frmMain)f).tb_bn_add.Text;
            string ngsinh = ((frmMain)f).ngaySinhPicker.Text;
            string ngkham = ((frmMain)f).ngayKhamPicker.Text;
            string trieuchung = ((frmMain)f).tb_bn_trieuchung.Text;
            string klb = ((frmMain)f).tb_bn_klb.Text;
            string baohiem = ((frmMain)f).tb_bn_baohiem.Text;


            string UpdateQuery = "UPDATE BENHNHAN " +
                   "SET TenBN= '" + ten + "', SoDT='" + sdt + "',GioiTinh= '" + gtinh + "',DiaChi= '" + dchi + "',NgSinh= '" + ngsinh + "', NgKham='" +
                     ngkham + "', TrieuChung='" + trieuchung + "', KetLuanBenh='" + klb + "', BaoHiem='" + baohiem + "'  WHERE MaBN='"+id+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(UpdateQuery, null);
            if (result > 0)
            {
                MessageBox.Show("Thông tin bệnh nhân đã được sửa ");
            }
        }



        public DataTable FindBN()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];



            string id, ten, sdt, gtinh, dchi, ngsinh, ngkham, trieuchung, klb, baohiem;


            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_id.Text))
                id = "='" + ((frmMain)f).tb_bn_id.Text + "'";
            else id = "is not null";

            MessageBox.Show(id);

            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_ten.Text))
                ten = "='" + ((frmMain)f).tb_bn_ten.Text + "'";
            else ten = "is not null";

            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_sdt.Text))
                sdt = "='" + ((frmMain)f).tb_bn_sdt.Text + "'";
            else sdt = "is not null";


            if (!string.IsNullOrEmpty(((frmMain)f).cb_bn_sex.Text))
                gtinh = "='" + ((frmMain)f).cb_bn_sex.Text + "'";
            else gtinh = "is not null";




            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_add.Text))
                dchi = "='" + ((frmMain)f).cb_bn_sex.Text + "'";
            else dchi = "is not null";

            string today = DateTime.Now.ToString("dd/MM/yyyy");



            if (((frmMain)f).ngaySinhPicker.Text != today) 
                ngsinh = "='" + ((frmMain)f).ngaySinhPicker.Text + "'";
            else ngsinh = "is not null";

            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_trieuchung.Text))
                trieuchung = "='" + ((frmMain)f).tb_bn_trieuchung.Text + "'";
            else trieuchung = "is not null";

            if (((frmMain)f).ngayKhamPicker.Text != today)
                 ngkham = "='" + ((frmMain)f).ngayKhamPicker.Text + "'";
            else ngkham = "is not null";

            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_klb.Text))
                klb = "='" + ((frmMain)f).tb_bn_klb.Text + "'";
            else klb = "is not null";

            if (!string.IsNullOrEmpty(((frmMain)f).tb_bn_baohiem.Text))
                baohiem = "='" + ((frmMain)f).tb_bn_baohiem.Text + "'";
            else baohiem = "is not null";



            DataTable dt = new DataTable();
            string LoadQuery = "SELECT * FROM BenhNhan" +
                                " where MaBN " + id + " and TenBN " + ten + " and SoDT " + sdt + "" +
                                 " and GioiTinh " + gtinh + "  and DiaChi " + dchi + " and NgSinh " + ngsinh + " and NgKham " + ngkham + " and TrieuChung " + trieuchung +
                                 " and KetLuanBenh " + klb +  " And BaoHiem " + baohiem;

            dt = DataProvider.Instance.ExecuteQuery(LoadQuery, null);
            return dt;

    
        }



    }

}
