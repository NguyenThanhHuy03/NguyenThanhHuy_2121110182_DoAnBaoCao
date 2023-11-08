using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO_AN.DAL.LoginDAL;

namespace DO_AN.BAL
{
    public class HangBLL
    {
        HangDAL dal = new HangDAL();

        public List<Hang> ReadHang()
        {
            List<Hang> lstHang = dal.ReadHang();
            return lstHang;
        }
        private bool ContainsSpecialCharacters(string input)
        {
            // Chuỗi chứa các kí tự đặc biệt bạn muốn kiểm tra
            string specialCharacters = @"!@#$%^&*()_+[]{}|;:,.<>?";

            foreach (char c in specialCharacters)
            {
                if (input.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
        public bool NewHang(Hang hang)
        {
            try
            {
                if (ContainsSpecialCharacters(hang.TenHang))
                {
                    return false;
                }
                if (hang.TenHang=="")
                {
                    return false;
                }
                if (hang.SoLuong==0)
                {
                    return false;
                }
                if (hang.DonGiaNhap == "")
                {
                    return false;
                }
                if (hang.DonGiaBan == "")
                {
                    return false;
                }
                if (hang.Anh == "")
                {
                    return false;
                }
                dal.NewHang(hang);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool DeleteHang(Hang hang)
        {
            try
            {
              
                dal.DeleteHang(hang);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool EditHang(Hang hang)
        {
            try
            {
                if (ContainsSpecialCharacters(hang.TenHang))
                {
                    return false;
                }
                if (hang.TenHang == "")
                {
                    return false;
                }
                if (hang.SoLuong == 0)
                {
                    return false;
                }
                if (hang.DonGiaNhap == "")
                {
                    return false;
                }
                if (hang.DonGiaBan == "")
                {
                    return false;
                }
                if (hang.Anh == "")
                {
                    return false;
                }
                dal.EditHang(hang);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Hang> SearchHangByMaAndTen(string maHang, string tenHang)
        {
            List<Hang> searchResults = dal.SearchHangByMaAndTen(maHang, tenHang);
            return searchResults;
        }



    }
}
