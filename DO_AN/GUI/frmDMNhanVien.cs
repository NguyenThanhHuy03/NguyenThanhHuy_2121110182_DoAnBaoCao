using DO_AN.BAL;
using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN.GUI
{
    public partial class frmDMNhanVien : Form
    {
        NhanVienBLL nvBLL = new NhanVienBLL();
        public frmDMNhanVien()
        {
            InitializeComponent();
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvNhanVien_CellFormatting);

        }
        //chọn lấy thông tin từng hàng
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Lấy giá trị từ cột MaNhanVien (Cell 0)
                object cellValueMaNhanVien = row.Cells[0].Value;
                string MaNhanVien = cellValueMaNhanVien != null ? cellValueMaNhanVien.ToString() : "";

                // Lấy giá trị từ cột TenNhanVien (Cell 1)
                object cellValueTenNhanVien = row.Cells[1].Value;
                string TenNhanVien = cellValueTenNhanVien != null ? cellValueTenNhanVien.ToString() : "";

                // Lấy giá trị từ cột GioiTinh (Cell 2)
                object cellValueGioiTinh = row.Cells[2].Value;
                bool GioiTinh = cellValueGioiTinh != null ? Convert.ToBoolean(cellValueGioiTinh) : false;

                // Lấy giá trị từ cột DiaChi (Cell 3)
                object cellValueDiaChi = row.Cells[3].Value;
                string DiaChi = cellValueDiaChi != null ? cellValueDiaChi.ToString() : "";

                // Lấy giá trị từ cột DienThoai (Cell 4)
                object cellValueDienThoai = row.Cells[4].Value;
                string DienThoai = cellValueDienThoai != null ? cellValueDienThoai.ToString() : "";

                // Lấy giá trị từ cột NgaySinh (Cell 5)
                object cellValueNgaySinh = row.Cells[5].Value;
                DateTime NgaySinh;
                if (cellValueNgaySinh != null && DateTime.TryParse(cellValueNgaySinh.ToString(), out NgaySinh))
                {
                    // Ngày sinh hợp lệ, gán giá trị
                }
                else
                {
                    // Nếu ngày sinh không hợp lệ, bạn có thể gán giá trị mặc định hoặc xử lý sai sót khác
                    NgaySinh = DateTime.MinValue;
                }

                // Hiển thị giá trị lên TextBox
                txtMaNhanVien.Text = MaNhanVien;
                txtTenNhanVien.Text = TenNhanVien;
                chkGioiTinh.Checked = GioiTinh;
                txtDiaChi.Text = DiaChi;
                mtbDienThoai.Text = DienThoai;
                mskNgaySinh.Text = NgaySinh.ToString("dd/MM/yyyy"); // Hiển thị theo định dạng dd/MM/yyyy
            }
            else
            {
                // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của TextBox)
                txtMaNhanVien.Text = "";
                txtTenNhanVien.Text = "";
                chkGioiTinh.Checked = false;
                txtDiaChi.Text = "";
                mtbDienThoai.Text = "";
                mskNgaySinh.Text = "";
            }

        }
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvNhanVien.Columns["Column3"].Index && e.Value != null)
            {
                if (e.Value is bool gioiTinhValue)
                {
                    e.Value = gioiTinhValue ? "Nam" : "Nữ";
                    e.FormattingApplied = true;
                }
            }
        }

        //Thêm
        private int hdCounter = 1;
        private string GenerateNewMaHDBan()
        {
            string newMaHDBan;
            do
            {
                hdCounter++;
                newMaHDBan = "P" + hdCounter.ToString("00");
            }
            while (CheckMaHDBanExists(newMaHDBan)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHDBan;
        }

        private bool CheckMaHDBanExists(string maHDBan)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
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
            string newMaNhanVien = GenerateNewMaHDBan();
            txtMaNhanVien.Text = newMaNhanVien;
            string maNv = txtMaNhanVien.Text;

            // Kiểm tra xem mã hàng đã tồn tại hay chưa
            bool isNhanVienExist = false;
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maNv)
                {
                    isNhanVienExist = true;
                    break;
                }
            }

            if (isNhanVienExist)
            {
                MessageBox.Show("Mã hàng đã tồn tại. Vui lòng chọn mã hàng khác.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text;
            nv.TenNhanVien = txtTenNhanVien.Text;
            nv.GioiTinh = chkGioiTinh.Checked;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = mtbDienThoai.Text;

          
            DateTime ngaySinh;
            if (DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
            {
                nv.NgaySinh = ngaySinh;
            }
            else
            {
                // Nếu ngày sinh không hợp lệ, bạn có thể xử lý sai sót khác hoặc đưa ra thông báo lỗi
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return; // Không thêm Nhân viên nếu ngày sinh không hợp lệ
            }

            // Gọi phương thức NewNhanVien để thêm Nhân viên vào cơ sở dữ liệu
            nvBLL.NewNhanVien(nv);

            // Thông báo thành công và thêm dòng mới vào DataGridView
            MessageBox.Show("Thêm thành công!");
            dgvNhanVien.Rows.Add(nv.MaNhanVien, nv.TenNhanVien, nv.GioiTinh, nv.DiaChi, nv.DienThoai, nv.NgaySinh.ToString("dd/MM/yyyy"));
        }

        //Xóa
        private void button5_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text;
            nv.TenNhanVien = txtTenNhanVien.Text;
            nv.GioiTinh = chkGioiTinh.Checked;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = mtbDienThoai.Text;

            // Xử lý ngày sinh: chuyển đổi từ kiểu chuỗi sang kiểu DateTime
            DateTime ngaySinh;
            if (DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
            {
                nv.NgaySinh = ngaySinh;
            }
            else
            {
                // Nếu ngày sinh không hợp lệ, bạn có thể xử lý sai sót khác hoặc đưa ra thông báo lỗi
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return; // Không xóa Nhân viên nếu ngày sinh không hợp lệ
            }

            // Gọi phương thức DeleteNhanVien để xóa Nhân viên khỏi cơ sở dữ liệu
            nvBLL.DeleteNhanVien(nv);

            // Thông báo thành công và xóa dòng khỏi DataGridView
            MessageBox.Show("Xóa thành công!");
            int idx = dgvNhanVien.CurrentCell.RowIndex;
            dgvNhanVien.Rows.RemoveAt(idx);
        }
        //sữa
        private void button4_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = txtMaNhanVien.Text;
            nv.TenNhanVien = txtTenNhanVien.Text;
            nv.GioiTinh = chkGioiTinh.Checked;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = mtbDienThoai.Text;

            // Xử lý ngày sinh: chuyển đổi từ kiểu chuỗi sang kiểu DateTime
            DateTime ngaySinh;
            if (DateTime.TryParseExact(mskNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
            {
                nv.NgaySinh = ngaySinh;
            }
            else
            {
                // Nếu ngày sinh không hợp lệ, bạn có thể xử lý sai sót khác hoặc đưa ra thông báo lỗi
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return; // Không chỉnh sửa Nhân viên nếu ngày sinh không hợp lệ
            }
            if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Gọi phương thức EditNhanVien để chỉnh sửa thông tin Nhân viên
            nvBLL.EditNhanVien(nv);

            // Thông báo chỉnh sửa thành công và cập nhật DataGridView với thông tin mới
            MessageBox.Show("Chỉnh sửa thành công!");

            DataGridViewRow row = dgvNhanVien.CurrentRow;
            row.Cells[0].Value = nv.MaNhanVien;
            row.Cells[1].Value = nv.TenNhanVien;
            row.Cells[2].Value = nv.GioiTinh;
            row.Cells[3].Value = nv.DiaChi;
            row.Cells[4].Value = nv.DienThoai;
            row.Cells[5].Value = nv.NgaySinh.ToString("dd/MM/yyyy");
        }

        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien> lstNhanVien = nvBLL.ReadNhanVien();
            foreach (NhanVien nv in lstNhanVien)
            {
                dgvNhanVien.Rows.Add(nv.MaNhanVien, nv.TenNhanVien, nv.GioiTinh, nv.DiaChi, nv.DienThoai, nv.NgaySinh);
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void txtTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenNhanVien.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌÔỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóôọỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên nhân viên không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNhanVien.Text = filteredInput;
                txtTenNhanVien.SelectionStart = filteredInput.Length;
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void mtbDienThoai_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
