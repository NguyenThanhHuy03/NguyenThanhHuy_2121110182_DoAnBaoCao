using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.DAL
{
    internal class KhachHangDAL:DBConection
    {
        public List<KhachHang> ReadKhachHang()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblKhach", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<KhachHang> lstKhachHang = new List<KhachHang>();

            while (reader.Read())
            {
                KhachHang khachHang = new KhachHang();
                khachHang.MaKhach = reader["MaKhach"].ToString();
                khachHang.TenKhach = reader["TenKhach"].ToString();
                khachHang.DiaChi = reader["DiaChi"].ToString();
                khachHang.DienThoai = reader["DienThoai"].ToString();

                lstKhachHang.Add(khachHang);
            }
            conn.Close();
            return lstKhachHang;
        }

        public void DeleteKhachHang(KhachHang khachHang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblKhach WHERE MaKhach = @MaKhach", conn);
            cmd.Parameters.Add(new SqlParameter("@MaKhach", khachHang.MaKhach));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewKhachHang(KhachHang khachHang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblKhach VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai)", conn);
            cmd.Parameters.Add(new SqlParameter("@MaKhach", khachHang.MaKhach));
            cmd.Parameters.Add(new SqlParameter("@TenKhach", khachHang.TenKhach));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", khachHang.DiaChi));
            cmd.Parameters.Add(new SqlParameter("@DienThoai", khachHang.DienThoai));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditKhachHang(KhachHang khachHang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblKhach SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhach = @MaKhach", conn);
            cmd.Parameters.Add(new SqlParameter("@MaKhach", khachHang.MaKhach));
            cmd.Parameters.Add(new SqlParameter("@TenKhach", khachHang.TenKhach));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", khachHang.DiaChi));
            cmd.Parameters.Add(new SqlParameter("@DienThoai", khachHang.DienThoai));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
