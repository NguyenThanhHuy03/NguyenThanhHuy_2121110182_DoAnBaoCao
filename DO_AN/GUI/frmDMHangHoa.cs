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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
namespace DO_AN.GUI
{
    public partial class frmDMHangHoa : Form
    {
        HangBLL hangBLL = new HangBLL();
        public frmDMHangHoa()
        {
            InitializeComponent();
            dgvHang.CellClick += dgvHang_CellClick;
            dgvHang.SelectionChanged += dgvHangHoa_SelectionChanged;
            cboMaChatLieu.DropDownStyle = ComboBoxStyle.DropDownList;


        }
                private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvHang.Rows.Count)
                    {
                        DataGridViewRow row = dgvHang.Rows[e.RowIndex];

                        // Lấy giá trị từ cột MaHang (Cell 0)
                        object cellValueMaHang = row.Cells[0].Value;
                        string MaHang = cellValueMaHang != null ? cellValueMaHang.ToString() : "";

                        // Lấy giá trị từ cột TenHang (Cell 1)
                        object cellValueTenHang = row.Cells[1].Value;
                        string TenHang = cellValueTenHang != null ? cellValueTenHang.ToString() : "";

                        // Lấy giá trị từ cột ChatLieu (Cell 2)
                        object cellValueMaChatLieu = row.Cells[2].Value;
                        string MaChatLieu = cellValueMaChatLieu != null ? cellValueMaChatLieu.ToString() : "";

                        // Lấy giá trị từ cột SoLuong (Cell 3)
                        object cellValueSoLuong = row.Cells[3].Value;
                        int SoLuong = cellValueSoLuong != null ? Convert.ToInt32(cellValueSoLuong) : 0;

                        // Lấy giá trị từ cột DonGiaNhap (Cell 4)
                        object cellValueDonGiaNhap = row.Cells[4].Value;
                        string DonGiaNhap = cellValueDonGiaNhap != null ? cellValueDonGiaNhap.ToString() : "";

                        // Lấy giá trị từ cột DonGiaBan (Cell 5)
                        object cellValueDonGiaBan = row.Cells[5].Value;
                        string DonGiaBan = cellValueDonGiaBan != null ? cellValueDonGiaBan.ToString() : "";

                        // Lấy giá trị từ cột Anh (Cell 6)
                        object cellValueAnh = row.Cells[6].Value;
                        string Anh = cellValueAnh  != null ? cellValueAnh.ToString() : "";

                        // Lấy giá trị từ cột GhiChu (Cell 7)
                        object cellValueGhiChu = row.Cells[7].Value;
                        string GhiChu = cellValueGhiChu != null ? cellValueGhiChu.ToString() : "";
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
                        txtMaHang.Text = MaHang;
                        txtTenHang.Text = TenHang;
                        cboMaChatLieu.Text = MaChatLieu;
                        txtSoLuong.Text = SoLuong.ToString();
                        txtDonGiaNhap.Text = DonGiaNhap;
                        txtDonGiaBan.Text = DonGiaBan;
                        txtAnh.Text = Anh;
                
                        txtGhiChu.Text = GhiChu;
                    }
                    else
                    {
                        // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                        // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của TextBox và PictureBox)
                        txtMaHang.Text = "";
                        txtTenHang.Text = "";
                        cboMaChatLieu.Text = "";
                        txtSoLuong.Text = "";
                        txtDonGiaNhap.Text = "";
                        txtDonGiaBan.Text = "";
                        txtAnh.Text = "";
                        txtGhiChu.Text = "";
                        picAnh.Image = null;;
                    }
                }
        private void frmDMHangHoa_Load(object sender, EventArgs e)
        {
            List<Hang> lstHang = hangBLL.ReadHang();
            foreach (Hang hang in lstHang)
            {
                dgvHang.Rows.Add(hang.MaHang, hang.TenHang, hang.MaChatLieu, hang.SoLuong, hang.DonGiaNhap, hang.DonGiaBan, hang.Anh, hang.GhiChu);
            }
            HangDAL hangDAL = new HangDAL();
            List<string> maChatLieuList = hangDAL.GetMaChatLieuList();
            cboMaChatLieu.DataSource = maChatLieuList;
        }


        //thêm
        private int hdCounter = 1;
        private string GenerateNewMaHDBan()
        {
            string newMaHDBan;
            do
            {
                hdCounter++;
                newMaHDBan = "SP" + hdCounter.ToString("00");
            }
            while (CheckMaHDBanExists(newMaHDBan)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHDBan;
        }

        private bool CheckMaHDBanExists(string maHDBan)
        {
            foreach (DataGridViewRow row in dgvHang.Rows)
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
           
            string newMaHang = GenerateNewMaHDBan();
            txtMaHang.Text = newMaHang;
            string maHang = txtMaHang.Text;

            // Kiểm tra xem mã hàng đã tồn tại hay chưa
            bool isMaHangExist = false;
            foreach (DataGridViewRow row in dgvHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHang)
                {
                    isMaHangExist = true;
                    break;
                }
            }

            if (isMaHangExist)
            {
                MessageBox.Show("Mã hàng đã tồn tại. Vui lòng chọn mã hàng khác.");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Nhập đơn giá nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGiaBan.Text))
            {
                MessageBox.Show("Nhập đơn giá bán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hang hang = new Hang();
            hang.MaHang = txtMaHang.Text;   
            hang.TenHang = txtTenHang.Text;
            hang.MaChatLieu = cboMaChatLieu.Text;
            hang.SoLuong = int.Parse(txtSoLuong.Text);
            hang.DonGiaNhap = txtDonGiaNhap.Text;
            hang.DonGiaBan = txtDonGiaBan.Text;
            hang.Anh = txtAnh.Text; ;
            hang.GhiChu = txtGhiChu.Text;

            hangBLL.NewHang(hang);

            MessageBox.Show("Thêm thành công!");

            dgvHang.Rows.Add(hang.MaHang, hang.TenHang, hang.MaChatLieu, hang.SoLuong, hang.DonGiaNhap, hang.DonGiaBan, hang.Anh, hang.GhiChu);
        }
            //xóa
            private void button5_Click(object sender, EventArgs e)
            {
                Hang hang = new Hang();
                hang.MaHang = txtMaHang.Text;
                hang.TenHang = txtTenHang.Text;
                hang.MaChatLieu = cboMaChatLieu.Text;
                hang.SoLuong = int.Parse(txtSoLuong.Text);
                hang.DonGiaNhap = txtDonGiaNhap.Text;
                hang.DonGiaBan = txtDonGiaBan.Text;
                hang.Anh = txtAnh.Text;
                hang.GhiChu = txtGhiChu.Text;
                hangBLL.DeleteHang(hang);

                MessageBox.Show("Xóa thành công!");

                int idx = dgvHang.CurrentCell.RowIndex;
                dgvHang.Rows.RemoveAt(idx);
            }
        //Sữa
        private void button4_Click(object sender, EventArgs e)
        {
            Hang hang = new Hang();
            hang.MaHang = txtMaHang.Text;
            hang.TenHang = txtTenHang.Text;
            hang.MaChatLieu = cboMaChatLieu.Text;
            hang.SoLuong = int.Parse(txtSoLuong.Text);
            hang.DonGiaNhap = txtDonGiaNhap.Text;
            hang.DonGiaBan = txtDonGiaBan.Text;
            hang.Anh = txtAnh.Text;
            hang.GhiChu = txtGhiChu.Text;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Nhập đơn giá nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGiaBan.Text))
            {
                MessageBox.Show("Nhập đơn giá bán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hangBLL.EditHang(hang);

            MessageBox.Show("Chỉnh sửa thành công!");

            DataGridViewRow row = dgvHang.CurrentRow;
            row.Cells[0].Value = hang.MaHang;
            row.Cells[1].Value = hang.TenHang;
            row.Cells[2].Value = hang.MaChatLieu;
            row.Cells[3].Value = hang.SoLuong;
            row.Cells[4].Value = hang.DonGiaNhap;
            row.Cells[5].Value = hang.DonGiaBan;
            row.Cells[6].Value = hang.Anh;
            row.Cells[7].Value = hang.GhiChu;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "All image files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.wepb" ;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAnh.ImageLocation = dlg.FileName;
                txtAnh.Text = dlg.FileName;
            }
        }

        private void dgvHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHang.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvHang.SelectedRows[0];

                // Lấy giá trị cột chứa đường dẫn ảnh (ví dụ: cột có tên "ImagePath")
                //string imagePath = selectedRow.Cells["Column7"].Value.ToString();

                // Hiển thị ảnh lên PictureBox
                //picAnh.Image = Image.FromFile(imagePath);
            }
        }


        private void cboMaChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picAnh_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimHangHoa frmtimhanghoa = new frmTimHangHoa();
            frmtimhanghoa.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
 

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGiaNhap.Text))
            {
                // Xóa các dấu phân cách hiện có, như dấu phẩy
                string input = txtDonGiaNhap.Text.Replace(",", "");

                // Chuyển đổi thành số nguyên
                if (int.TryParse(input, out int amount))
                {
                    // Định dạng số tiền theo định dạng VND
                    string formattedAmount = string.Format("{0:N0} VND", amount);

                    // Lưu vị trí con trỏ hiện tại
                    int selectionStart = txtDonGiaNhap.SelectionStart;

                    // Gán lại giá trị và vị trí con trỏ
                    txtDonGiaNhap.Text = formattedAmount;
                    if (selectionStart > txtDonGiaNhap.Text.Length)
                    {
                        selectionStart = txtDonGiaNhap.Text.Length;
                    }
                    txtDonGiaNhap.SelectionStart = selectionStart;
                }
            }

        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDonGiaNhap.Text))
            {
                // Xóa các dấu phân cách hiện có, như dấu phẩy
                string input = txtDonGiaBan.Text.Replace(",", "");

                // Chuyển đổi thành số nguyên
                if (int.TryParse(input, out int amount))
                {
                    // Định dạng số tiền theo định dạng VND
                    string formattedAmount = string.Format("{0:N0} VND", amount);

                    // Lưu vị trí con trỏ hiện tại
                    int selectionStart = txtDonGiaBan.SelectionStart;

                    // Gán lại giá trị và vị trí con trỏ
                    txtDonGiaBan.Text = formattedAmount;
                    if (selectionStart > txtDonGiaBan.Text.Length)
                    {
                        selectionStart = txtDonGiaBan.Text.Length;
                    }
                    txtDonGiaBan.SelectionStart = selectionStart;
                }
            }
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenHang.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓÔỌỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóôọỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên chất liệu không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHang.Text = filteredInput;
                txtTenHang.SelectionStart = filteredInput.Length;
            }
       
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
       
        }
    }
}
