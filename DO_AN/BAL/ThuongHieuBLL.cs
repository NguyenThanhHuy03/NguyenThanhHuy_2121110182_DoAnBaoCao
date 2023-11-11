using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.BAL
{
    // Trong namespace DO_AN.BAL
    public class ThuongHieuBLL
    {
        ThuongHieuDAL dal = new ThuongHieuDAL();

        public List<ThuongHieu> ReadThuongHieu()
        {
            List<ThuongHieu> lstThuongHieu = dal.ReadThuongHieu();
            return lstThuongHieu;
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
        public bool NewThuongHieu(ThuongHieu thuonghieu)
        {
            try
            {
                if (ContainsSpecialCharacters(thuonghieu.TenThuongHieu))
                {
                    return false;
                }
                if (thuonghieu.TenThuongHieu == "")
                {
                    return false;
                }
                if (thuonghieu.Anh == "")
                {
                    return false;
                }
                dal.NewThuongHieu(thuonghieu);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteThuongHieu(ThuongHieu thuonghieu)
        {
            try
            {

                dal.DeleteThuongHieu(thuonghieu);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool EditThuongHieu(ThuongHieu thuonghieu)
        {
            try
            {
                if (ContainsSpecialCharacters(thuonghieu.TenThuongHieu))
                {
                    return false;
                }
                if (thuonghieu.TenThuongHieu == "")
                {
                    return false;
                }
                if (thuonghieu.Anh == "")
                {
                    return false;
                }
                dal.EditThuongHieu(thuonghieu);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
    }

}
