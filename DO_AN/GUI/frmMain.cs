using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN.GUI
{
    public partial class x : Form
    {
        public x()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void x_Load(object sender, EventArgs e)
        {

        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            frmDMChatLieu frmChatLieu = new frmDMChatLieu();
            frmChatLieu.Enabled = true;
            frmChatLieu.ShowDialog(); 
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmnhanvien = new frmDMNhanVien();
            frmnhanvien.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmkhachhang = new frmDMKhachHang();
            frmkhachhang.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa frmhanghoa = new frmDMHangHoa();
            frmhanghoa.ShowDialog();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmhoadonban = new frmHoaDonBan();
            frmhoadonban.ShowDialog();
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmtimhdban = new frmTimHDBan();
            frmtimhdban.ShowDialog();
        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {
            frmTimHangHoa frmtimhanghoa = new frmTimHangHoa();
            frmtimhanghoa.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

