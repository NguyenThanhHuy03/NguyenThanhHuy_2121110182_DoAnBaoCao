﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO_AN.DAL
{
    public class DBConection
    {
        public DBConection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=msi\sqlexpress;Initial Catalog=QLBH;Integrated Security=True";
            return conn;
        }
    }
}
