using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DO_AN.DAL
{
    internal class ThuongHieuDAL:DBConection
    {
        public List<ThuongHieu> ReadThuongHieu()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblThuongHieu", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ThuongHieu> lstThuongHieu = new List<ThuongHieu>();

            while (reader.Read())
            {
                ThuongHieu thuonghieu = new ThuongHieu();
                thuonghieu.MaThuongHieu = reader["MaThuongHieu"].ToString();
                thuonghieu.TenThuongHieu = reader["TenThuongHieu"].ToString();
                thuonghieu.GhiChu = reader["GhiChu"].ToString();
                thuonghieu.Anh = reader["Anh"].ToString();

                lstThuongHieu.Add(thuonghieu);
            }

            conn.Close();
            return lstThuongHieu;
        }

        public void NewThuongHieu(ThuongHieu thuonghieu)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblThuongHieu VALUES (@MaThuongHieu, @TenThuongHieu, @GhiChu, @Anh)", conn);
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", thuonghieu.MaThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@TenThuongHieu", thuonghieu.TenThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", thuonghieu.GhiChu));
            cmd.Parameters.Add(new SqlParameter("@Anh", thuonghieu.Anh));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditThuongHieu(ThuongHieu thuonghieu)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblThuongHieu SET TenThuongHieu = @TenThuongHieu, GhiChu = @GhiChu, Anh = @Anh WHERE MaThuongHieu = @MaThuongHieu", conn);
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", thuonghieu.MaThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@TenThuongHieu", thuonghieu.TenThuongHieu));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", thuonghieu.GhiChu));
            cmd.Parameters.Add(new SqlParameter("@Anh", thuonghieu.Anh));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteThuongHieu(ThuongHieu thuonghieu)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblThuongHieu WHERE MaThuongHieu = @MaThuongHieu", conn);
            cmd.Parameters.Add(new SqlParameter("@MaThuongHieu", thuonghieu.MaThuongHieu));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

}
