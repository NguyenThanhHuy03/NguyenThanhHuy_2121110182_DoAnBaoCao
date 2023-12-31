﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DO_AN.DAL
{
    internal class LoginDAL: DBConection
    {
        public class DataAccessLayer
        {
            public static bool ValidateLoginCredentials(string username, string password)
            {
                string connectionString = "Data Source=msi\\sqlexpress;Initial Catalog=QuanLyBanHang;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                   {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
        }

        //private bool IsAdminAccount(string Username)
        //{
        //    string connectionString = "Data Source=MSI;Initial Catalog=QLBHC#;User ID=sa;Password=sa";
        //    SqlCommand cmd = new SqlCommand("SELECT Role FROM NguoiDung WHERE Username = @Username");
        //}
        
      


        }
}
