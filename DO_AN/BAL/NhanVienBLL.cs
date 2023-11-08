using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.BAL
{
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();
        public List<NhanVien> ReadNhanVien()
        {
            List<NhanVien> lstCus = dal.ReadNhanVien();
            return lstCus;
        }
        public void NewNhanVien(NhanVien cus)
        {
            dal.NewNhanVien(cus);
        }
        public bool DeleteNhanVien(NhanVien cus)
        {
            try
            {
                
                dal.DeleteNhanVien(cus);
               
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
            
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Loại bỏ các khoảng trắng, dấu gạch ngang, dấu ngoặc và các ký tự không phải số
            string cleanedPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Kiểm tra xem số điện thoại sau khi làm sạch có đủ 10 số hay không
            return cleanedPhoneNumber.Length == 10;
        }
        private bool ContainsSpecialCharacters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return true; // Nếu ký tự không phải chữ hoặc số và không phải khoảng trắng, coi như là ký tự đặc biệt
                }
            }

            return false; // Không có ký tự đặc biệt nào được tìm thấy
        }
        public bool EditNhanVien(NhanVien cus)
        {
            
            try
            {

                if (!IsValidPhoneNumber(cus.DienThoai))
                {
                    // Nếu số điện thoại không hợp lệ, trả về false
                    return false;
                }
                if (ContainsSpecialCharacters(cus.TenNhanVien))
                {
                    // Nếu tên nhân viên chứa ký tự đặc biệt, trả về false
                    return false;
                }

                dal.EditNhanVien(cus);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void LuuNhanVien(NhanVien cus)
        {
            dal.LuuNhanVien(cus);
        }
    }
}
