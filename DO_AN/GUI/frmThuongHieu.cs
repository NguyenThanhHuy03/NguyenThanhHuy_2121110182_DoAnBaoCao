using DO_AN.BAL;
using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DO_AN.GUI
{
    public partial class frmThuongHieu : Form
    {
        ThuongHieuBLL thuonghieuBLL = new ThuongHieuBLL();
        

        public frmThuongHieu()
        {
            InitializeComponent();
            dgvThuongHieu.CellClick += dgvThuongHieu_CellClick;
            dgvThuongHieu.SelectionChanged += dgvThuongHieu_SelectionChanged;
        }

        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            List<ThuongHieu> lstThuongHieu = thuonghieuBLL.ReadThuongHieu();
            foreach (ThuongHieu thuonghieu in lstThuongHieu)
            {
                dgvThuongHieu.Rows.Add(thuonghieu.MaThuongHieu, thuonghieu.TenThuongHieu, thuonghieu.GhiChu, thuonghieu.Anh);
            }
            
        }


        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
           
        }

        

        private bool CheckMaThuongHieuExists(string maThuongHieu)
        {
            foreach (DataGridViewRow row in dgvThuongHieu.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maThuongHieu)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }
        //Xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvThuongHieu_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            
        }
        private void txtTenThuongHieu_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void picAnh_Click(object sender, EventArgs e)
        {

        }
        //nút thêm ảnh
        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "All image files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.wepb";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAnh.ImageLocation = dlg.FileName;
                txtAnh.Text = dlg.FileName;
            }
        }
        //thêm
        private int hdCounter = 1;
        private string GenerateNewMaThuongHieu()
        {
            string newMaThuongHieu;
            do
            {
                hdCounter++;
                newMaThuongHieu = "TH" + hdCounter.ToString("00");
            }
            while (CheckMaThuongHieuExists(newMaThuongHieu)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaThuongHieu;
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string newMaThuongHieu = GenerateNewMaThuongHieu();
            txtMaThuongHieu.Text = newMaThuongHieu;
            string maThuongHieu = txtMaThuongHieu.Text;

            // Kiểm tra xem mã thuong hiệu đã tồn tại hay chưa
            bool isMaThuongHieuExist = false;
            foreach (DataGridViewRow row in dgvThuongHieu.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maThuongHieu)
                {
                    isMaThuongHieuExist = true;
                    break;
                }
            }

            if (isMaThuongHieuExist)
            {
                MessageBox.Show("Mã thương hiệu đã tồn tại. Vui lòng chọn mã hàng khác.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenThuongHieu.Text))
            {
                MessageBox.Show("Tên thương hiệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ThuongHieu thuonghieu = new ThuongHieu();
            thuonghieu.MaThuongHieu = txtMaThuongHieu.Text;
            thuonghieu.TenThuongHieu = txtTenThuongHieu.Text;
            thuonghieu.GhiChu = txtGhiChu.Text;
            thuonghieu.Anh = txtAnh.Text; ;

            thuonghieuBLL.NewThuongHieu(thuonghieu);

            MessageBox.Show("Thêm thành công!");

            dgvThuongHieu.Rows.Add(thuonghieu.MaThuongHieu, thuonghieu.TenThuongHieu, thuonghieu.GhiChu, thuonghieu.Anh);
        }
        //sua
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            ThuongHieu thuonghieu = new ThuongHieu();
            thuonghieu.MaThuongHieu = txtMaThuongHieu.Text;
            thuonghieu.TenThuongHieu = txtTenThuongHieu.Text;
            thuonghieu.GhiChu = txtGhiChu.Text;
            thuonghieu.Anh = txtAnh.Text;
            if (string.IsNullOrWhiteSpace(txtTenThuongHieu.Text))
            {
                MessageBox.Show("Tên thuong hiệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            thuonghieuBLL.EditThuongHieu(thuonghieu);

            MessageBox.Show("Chỉnh sửa thành công!");

            DataGridViewRow row = dgvThuongHieu.CurrentRow;
            row.Cells[0].Value = thuonghieu.MaThuongHieu;
            row.Cells[1].Value = thuonghieu.TenThuongHieu;
            row.Cells[2].Value = thuonghieu.GhiChu;
            row.Cells[3].Value = thuonghieu.Anh;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            ThuongHieu thuonghieu = new ThuongHieu();
            thuonghieu.MaThuongHieu = txtMaThuongHieu.Text;
            thuonghieu.TenThuongHieu = txtTenThuongHieu.Text;
            thuonghieu.GhiChu = txtGhiChu.Text;
            thuonghieu.Anh = txtAnh.Text;
            thuonghieuBLL.DeleteThuongHieu(thuonghieu);

            MessageBox.Show("Xóa thành công!");

            int idx = dgvThuongHieu.CurrentCell.RowIndex;
            dgvThuongHieu.Rows.RemoveAt(idx);
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenThuongHieu_TextChanged_1(object sender, EventArgs e)
        {
            string input = txtTenThuongHieu.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓÔỌỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóôọỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên thuong hiệu không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenThuongHieu.Text = filteredInput;
                txtTenThuongHieu.SelectionStart = filteredInput.Length;
            }
        }

        private void dgvThuongHieu_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvThuongHieu.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvThuongHieu.SelectedRows[0];

                // Lấy giá trị cột chứa đường dẫn ảnh (ví dụ: cột có tên "ImagePath")
                //string imagePath = selectedRow.Cells["Column7"].Value.ToString();

                // Hiển thị ảnh lên PictureBox
                //picAnh.Image = Image.FromFile(imagePath);
            }
        }

        private void dgvThuongHieu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvThuongHieu.Rows.Count)
            {
                DataGridViewRow row = dgvThuongHieu.Rows[e.RowIndex];

                // Lấy giá trị từ cột ThuongHieu (Cell 0)
                object cellValueMaThuongHieu = row.Cells[0].Value;
                string MaThuongHieu = cellValueMaThuongHieu != null ? cellValueMaThuongHieu.ToString() : "";

                // Lấy giá trị từ cột TenThuongHieu (Cell 1)
                object cellValueTenThuongHieu = row.Cells[1].Value;
                string TenThuongHieu = cellValueTenThuongHieu != null ? cellValueTenThuongHieu.ToString() : "";

                // Lấy giá trị từ cột GhiChu (Cell 2)
                object cellValueGhiChu = row.Cells[2].Value;
                string GhiChu = cellValueGhiChu != null ? cellValueGhiChu.ToString() : "";

                // Lấy giá trị từ cột Anh (Cell 3)
                object cellValueAnh = row.Cells[3].Value;
                string Anh = cellValueAnh != null ? cellValueAnh.ToString() : "";
                if (!string.IsNullOrEmpty(Anh))
                {
                    // Kiểm tra xem đường dẫn ảnh có hợp lệ hay không
                    if (File.Exists(Anh))
                    {
                        // Hiển thị ảnh lên PictureBox
                        picAnh.Image = Image.FromFile(Anh);
                    }
                    else
                    {
                        picAnh.Image = null;
                    }
                }
                // Hiển thị giá trị lên TextBox hoặc các controls tương ứng
                txtMaThuongHieu.Text = MaThuongHieu;
                txtTenThuongHieu.Text = TenThuongHieu; 
                txtGhiChu.Text = GhiChu;
                txtAnh.Text = Anh;
            }
            else
            {
                // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của TextBox và PictureBox)
                txtMaThuongHieu.Text = "";
                txtTenThuongHieu.Text = "";
                txtGhiChu.Text = "";
                txtAnh.Text = "";
                picAnh.Image = null; ;
            }
        }


    }
}
