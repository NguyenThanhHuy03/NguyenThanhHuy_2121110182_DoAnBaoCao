using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DO_AN.BAL;

namespace DO_AN.DAL
{
    internal class HangDAL:DBConection
    {
        public List<Hang> ReadHang()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblHang", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Hang> lstHang = new List<Hang>();
         

            while (reader.Read())
            {
                Hang hang = new Hang();
                hang.MaHang = reader["MaHang"].ToString();
                hang.TenHang = reader["TenHang"].ToString();
                hang.MaChatLieu = reader["MaChatLieu"].ToString();
                hang.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                hang.DonGiaNhap = reader["DonGiaNhap"].ToString();
                hang.DonGiaBan = reader["DonGiaBan"].ToString();
                hang.Anh = reader["Anh"].ToString();
                hang.GhiChu = reader["GhiChu"].ToString();

                lstHang.Add(hang);
            }
            conn.Close();
            return lstHang;
        }
        public List<string> GetMaChatLieuList()
        {
            ChatLieuDAL chatLieuDAL = new ChatLieuDAL();
            List<string> maChatLieuList = chatLieuDAL.ReadAllMaChatLieu();
            return maChatLieuList;
        }
        
        //xóa
        public void DeleteHang(Hang hang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblHang WHERE MaHang = @MaHang", conn);
            cmd.Parameters.Add(new SqlParameter("@MaHang", hang.MaHang));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //thêm
        public void NewHang(Hang hang)
        {

            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblHang VALUES (@MaHang, @TenHang, @MaChatLieu, @SoLuong, @DonGiaNhap, @DonGiaBan, @Anh, @GhiChu)", conn);
            cmd.Parameters.Add(new SqlParameter("@MaHang", hang.MaHang));
            cmd.Parameters.Add(new SqlParameter("@TenHang", hang.TenHang));
            cmd.Parameters.Add(new SqlParameter("@MaChatLieu", hang.MaChatLieu));
            cmd.Parameters.Add(new SqlParameter("@SoLuong", hang.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@DonGiaNhap", hang.DonGiaNhap));
            cmd.Parameters.Add(new SqlParameter("@DonGiaBan", hang.DonGiaBan));
            cmd.Parameters.Add(new SqlParameter("@Anh", hang.Anh));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", hang.GhiChu));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //sữa
        public void EditHang(Hang hang)
        { 
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblHang SET TenHang = @TenHang, MaChatLieu = @MaChatLieu, SoLuong = @SoLuong, DonGiaNhap = @DonGiaNhap, DonGiaBan = @DonGiaBan, Anh = @Anh, GhiChu = @GhiChu WHERE MaHang = @MaHang", conn);
            cmd.Parameters.Add(new SqlParameter("@MaHang", hang.MaHang));
            cmd.Parameters.Add(new SqlParameter("@TenHang", hang.TenHang));
            cmd.Parameters.Add(new SqlParameter("@MaChatLieu", hang.MaChatLieu));
            cmd.Parameters.Add(new SqlParameter("@SoLuong", hang.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@DonGiaNhap", hang.DonGiaNhap));
            cmd.Parameters.Add(new SqlParameter("@DonGiaBan", hang.DonGiaBan));
            cmd.Parameters.Add(new SqlParameter("@Anh", hang.Anh));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", hang.GhiChu));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        // Trong lớp HangDAL
        public List<Hang> SearchHangByMaAndTen(string maHang, string tenHang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblHang WHERE MaHang = @MaHang OR TenHang = @TenHang", conn);
            cmd.Parameters.Add(new SqlParameter("@MaHang", maHang));
            cmd.Parameters.Add(new SqlParameter("@TenHang", tenHang));

            SqlDataReader reader = cmd.ExecuteReader();
            List<Hang> searchResults = new List<Hang>();

            while (reader.Read())
            {
                Hang hang = new Hang();
                hang.MaHang = reader["MaHang"].ToString();
                hang.TenHang = reader["TenHang"].ToString();
                hang.MaChatLieu = reader["MaChatLieu"].ToString();
                hang.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                hang.DonGiaNhap = reader["DonGiaNhap"].ToString();
                hang.DonGiaBan = reader["DonGiaBan"].ToString();
                hang.Anh = reader["Anh"].ToString();
                hang.GhiChu = reader["GhiChu"].ToString();

                searchResults.Add(hang);
            }

            conn.Close();
            return searchResults;
        }


    }
}
