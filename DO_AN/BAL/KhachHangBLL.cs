using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN.BAL
{
    internal class KhachHangBLL
    {
        KhachHangDAL dal = new KhachHangDAL();
        public List<KhachHang> ReadKhachHang()
        {
            List<KhachHang> lstKhachHang = dal.ReadKhachHang();
            return lstKhachHang;
        }

        public void NewKhachHang(KhachHang khachHang)
        {
            dal.NewKhachHang(khachHang);
        }

        public void DeleteKhachHang(KhachHang khachHang)
        {
            dal.DeleteKhachHang(khachHang);
        }

        public void EditKhachHang(KhachHang khachHang)
        {
            dal.EditKhachHang(khachHang);
        }
    }
}
