using DO_AN.BAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN.GUI
{
    public partial class frmDMKhachHang : Form
    {
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        public frmDMKhachHang()
        {
            InitializeComponent();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                // Lấy giá trị từ cột MaKhach (Cell 0)
                object cellValueMaKhach = row.Cells[0].Value;
                string MaKhach = cellValueMaKhach != null ? cellValueMaKhach.ToString() : "";

                // Lấy giá trị từ cột TenKhach (Cell 1)
                object cellValueTenKhach = row.Cells[1].Value;
                string TenKhach = cellValueTenKhach != null ? cellValueTenKhach.ToString() : "";

                // Lấy giá trị từ cột DiaChi (Cell 2)
                object cellValueDiaChi = row.Cells[2].Value;
                string DiaChi = cellValueDiaChi != null ? cellValueDiaChi.ToString() : "";

                // Lấy giá trị từ cột DienThoai (Cell 3)
                object cellValueDienThoai = row.Cells[3].Value;
                string DienThoai = cellValueDienThoai != null ? cellValueDienThoai.ToString() : "";

                // Hiển thị giá trị lên TextBox hoặc các controls tương ứng
                txtMaKhach.Text = MaKhach;
                txtTenKhach.Text = TenKhach;
                txtDiaChi.Text = DiaChi;
                mtbDienThoai.Text = DienThoai;
            }
            else
            {
                // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của TextBox)
                txtMaKhach.Text = "";
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                mtbDienThoai.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            List<KhachHang> lstKhachHang = khachHangBLL.ReadKhachHang();
            foreach (KhachHang khachHang in lstKhachHang)
            {
                dgvKhachHang.Rows.Add(khachHang.MaKhach, khachHang.TenKhach, khachHang.DiaChi, khachHang.DienThoai);
            }

        }
        private int hdCounter = 1;
        private string GenerateNewMaHDBan()
        {
            string newMaHDBan;
            do
            {
                hdCounter++;
                newMaHDBan = "KH" + hdCounter.ToString("00");
            }
            while (CheckMaHDBanExists(newMaHDBan)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHDBan;
        }

        private bool CheckMaHDBanExists(string maHDBan)
        {
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHDBan)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }
        private void button6_Click(object sender, EventArgs e)
        {

            {
                string newMaKhach = GenerateNewMaHDBan();
                txtMaKhach.Text = newMaKhach;
                string maKhach = txtMaKhach.Text;

                // Kiểm tra xem mã khách đã tồn tại hay chưa
                bool isMaKhachExist = false;
                foreach (DataGridViewRow row in dgvKhachHang.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maKhach)
                    {
                        isMaKhachExist = true;
                        break;
                    }
                }

                if (isMaKhachExist)
                {
                    MessageBox.Show("Mã khách đã tồn tại. Vui lòng chọn mã khách khác.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenKhach.Text))
                {
                    MessageBox.Show("Tên khách hàng không được bỏ trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!mtbDienThoai.MaskFull)
                {
                    MessageBox.Show("Nhập số điện thoại đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                KhachHang khachHang = new KhachHang();
                khachHang.MaKhach = txtMaKhach.Text;
                khachHang.TenKhach = txtTenKhach.Text;
                khachHang.DiaChi = txtDiaChi.Text;
                khachHang.DienThoai = mtbDienThoai.Text;

                khachHangBLL.NewKhachHang(khachHang);

                MessageBox.Show("Thêm thành công!");

                dgvKhachHang.Rows.Add(khachHang.MaKhach, khachHang.TenKhach, khachHang.DiaChi, khachHang.DienThoai);

            }

     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.MaKhach = txtMaKhach.Text;

            khachHangBLL.DeleteKhachHang(khachHang);

            MessageBox.Show("Xóa thành công!");

            int idx = dgvKhachHang.CurrentCell.RowIndex;
            dgvKhachHang.Rows.RemoveAt(idx);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.MaKhach = txtMaKhach.Text;
            khachHang.TenKhach = txtTenKhach.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            khachHang.DienThoai = mtbDienThoai.Text;
            if (string.IsNullOrWhiteSpace(txtTenKhach.Text))
            {
                MessageBox.Show("Tên khách hàng không được bỏ trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Nhập địa chỉ khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!mtbDienThoai.MaskFull)
            {
                MessageBox.Show("Nhập số điện thoại đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            khachHangBLL.EditKhachHang(khachHang);

            MessageBox.Show("Chỉnh sửa thành công!");

            DataGridViewRow row = dgvKhachHang.CurrentRow;
            row.Cells[0].Value = khachHang.MaKhach;
            row.Cells[1].Value = khachHang.TenKhach;
            row.Cells[2].Value = khachHang.DiaChi;
            row.Cells[3].Value = khachHang.DienThoai;
        }

        private void txtTenKhach_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenKhach.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌÔỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọôỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên chất liệu không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhach.Text = filteredInput;
                txtTenKhach.SelectionStart = filteredInput.Length;
            }
        }
    }
}
