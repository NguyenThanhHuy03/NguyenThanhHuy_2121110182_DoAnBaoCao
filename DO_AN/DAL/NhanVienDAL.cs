using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.DAL
{
    internal class NhanVienDAL:DBConection
    {
        public List<NhanVien> ReadNhanVien()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblNhanVien", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<NhanVien> lstCus = new List<NhanVien>();
            while (reader.Read())
            {
                NhanVien cus = new NhanVien();
                cus.MaNhanVien = reader["MaNhanVien"].ToString();
                cus.TenNhanVien = reader["TenNhanVien"].ToString();
                bool gioiTinh = Convert.ToInt32(reader["GioiTinh"]) == 1;
                cus.GioiTinh = gioiTinh;
                cus.DiaChi = reader["DiaChi"].ToString();
                cus.DienThoai = reader["DienThoai"].ToString();
                if (reader["NgaySinh"] != DBNull.Value)
                {      
                    cus.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                }
                else
                {
                    cus.NgaySinh = DateTime.MinValue;
                }
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }

        //xóa 
        public void DeleteNhanVien(NhanVien cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from tblNhanVien where MaNhanVien = @MaNhanVien", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNhanVien", cus.MaNhanVien));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //thêm
        public void NewNhanVien(NhanVien cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblNhanVien (MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, NgaySinh) VALUES (@MaNhanVien, @TenNhanVien, @GioiTinh, @DiaChi, @DienThoai, @NgaySinh)", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNhanVien", cus.MaNhanVien));
            cmd.Parameters.Add(new SqlParameter("@TenNhanVien", cus.TenNhanVien));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", cus.GioiTinh));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", cus.DiaChi));
            cmd.Parameters.Add(new SqlParameter("@DienThoai", cus.DienThoai));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", cus.NgaySinh));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //sữa
        public void EditNhanVien(NhanVien cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblNhanVien SET TenNhanVien = @TenNhanVien, GioiTinh = @GioiTinh, DiaChi = @DiaChi, DienThoai = @DienThoai, NgaySinh = @NgaySinh WHERE MaNhanVien = @MaNhanVien", conn);

            cmd.Parameters.Add(new SqlParameter("@MaNhanVien", cus.MaNhanVien));
            cmd.Parameters.Add(new SqlParameter("@TenNhanVien", cus.TenNhanVien));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", cus.GioiTinh));
            cmd.Parameters.Add(new SqlParameter("@DiaChi", cus.DiaChi));
            cmd.Parameters.Add(new SqlParameter("@DienThoai", cus.DienThoai));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", cus.NgaySinh));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //lưu
        public void LuuNhanVien(NhanVien cus)
        {

        }
    }
}
