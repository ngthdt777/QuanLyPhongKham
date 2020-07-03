using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using QuanLyPhongKham.GUI;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace QuanLyPhongKham.DAL
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }
            private set => instance = value;
        }
        public DataProvider() { }
        private string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLPhongKham;Integrated Security=True";

        public DataTable ExecuteQueryPhanQuyen(string query, Dictionary<String, String> parameters)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                foreach (String key in parameters.Keys)
                {
                    command.Parameters.AddWithValue(key, parameters[key]);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
        public int ExecuteNonQuery(string query)
        {

            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteNonQuery();

                return data;
            }
        }

        public object ExecuteScalar(string query)
        {

            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteScalar();

                return data;
            }
        }
        /*public void LoginCheck()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmLogin"];
            string acc = ((frmLogin)f).txb_account.Text;
            string pass = ((frmLogin)f).txb_pass.Text;
            string query = "SELECT * from Dangnhap WHERE taikhoan = '" + acc + "' AND matkhau = '" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count >0 )
            {
                frmMain f = new frmMain(result.Rows[0][0].ToString(), result.Rows[0][1].ToString(), result.Rows[0][2].ToString());
                this.Hide();
                f.ShowDialog();
            }

            else
            {
                MessageBox.Show("Nhập lại tài khoản/ mật khẩu");

            }

        }*/
    }
}
