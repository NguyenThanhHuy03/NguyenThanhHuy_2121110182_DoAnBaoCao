using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.DAL
{
    internal class ChatLieuDAL:DBConection
    {
        public List<ChatLieu> ReadChatLieu()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblChatLieu", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ChatLieu> lstCus = new List<ChatLieu>();
            while (reader.Read())
            {
                ChatLieu cus = new ChatLieu();
                cus.MaChatLieu = reader["MaChatLieu"].ToString();
                cus.TenChatLieu = reader["TenChatLieu"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public List<string> ReadAllMaChatLieu()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MaChatLieu FROM tblChatLieu", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<string> maChatLieuList = new List<string>();

            while (reader.Read())
            {
                string maChatLieu = reader["MaChatLieu"].ToString();
                maChatLieuList.Add(maChatLieu);
            }

            conn.Close();
            return maChatLieuList;
        }
        //xóa 
        public void DeleteChatLieu(ChatLieu cus)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblChatLieu where MaChatLieu = @MaChatLieu", conn);
                cmd.Parameters.Add(new SqlParameter("@MaChatLieu", cus.MaChatLieu));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            //thêm
            public void NewChatLieu(ChatLieu cus)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into tblChatLieu values(@MaChatLieu,@TenChatLieu)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaChatLieu", cus.MaChatLieu));
                cmd.Parameters.Add(new SqlParameter("@TenChatLieu", cus.TenChatLieu));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            //sữa
            public void EditChatLieu(ChatLieu cus)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("update tblChatLieu set TenChatLieu = @TenChatLieu where MaChatLieu = @MaChatLieu", conn);
                cmd.Parameters.Add(new SqlParameter("@MaChatLieu", cus.MaChatLieu));
                cmd.Parameters.Add(new SqlParameter("@TenChatLieu", cus.TenChatLieu));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            //lưu
            public void LuuChatLieu(ChatLieu cus)
            {
                
            }



    }
}
