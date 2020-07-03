﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.DAL;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyPhongKham.BLL
{
    class ObjBenhNhanBLL
    {
        private static ObjBenhNhanBLL instance;

        public static ObjBenhNhanBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjBenhNhanBLL();
                }
                return instance;
            }
            set { instance = value; }
        }
        private ObjBenhNhanBLL() { }

        public DataTable GetData()
        {
            return ObjBenhNhanDAL.Instance.GetInfo();
        }


    }
}