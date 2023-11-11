using DO_AN.DAL;
using NumToWords;
using NumberToWords;
using Humanizer;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using Humanizer.Localisation.NumberToWords;
using DO_AN.BAL;
using DO_AN.Model;
using OfficeOpenXml;

namespace DO_AN.GUI
{
    public partial class frmHoaDonBan : Form
    {
        HDBanBLL hdBanBLL = new HDBanBLL();
        public frmHoaDonBan()
        {
            InitializeComponent();
            cboGiamGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvHDBanHang.CellClick += dgvHang_CellClick;
            txtDonGia.TextChanged += UpdateThanhTien;
            txtSoLuong.TextChanged += UpdateThanhTien;
            cboGiamGia.SelectedIndexChanged += UpdateThanhTien;

            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }
        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvHDBanHang.Rows.Count)
            {
                DataGridViewRow row = dgvHDBanHang.Rows[e.RowIndex];

                // Lấy giá trị từ cột MaHoaDon (Cell 0)
                object cellValueMaHoaDon = row.Cells[0].Value;
                string MaHoaDon = cellValueMaHoaDon != null ? cellValueMaHoaDon.ToString() : "";

                // Lấy giá trị từ cột MaNhanVien (Cell 1)
                object cellValueMaNhanVien = row.Cells[1].Value;
                string MaNhanVien = cellValueMaNhanVien != null ? cellValueMaNhanVien.ToString() : "";

                // Lấy giá trị từ cột NgayBan (Cell 2)
                object cellValueNgayBan = row.Cells[2].Value;
                DateTime NgayBan = cellValueNgayBan != null ? Convert.ToDateTime(cellValueNgayBan) : DateTime.MinValue;

                // Lấy giá trị từ cột MaKhachHang (Cell 3)
                object cellValueMaKhachHang = row.Cells[3].Value;
                string MaKhachHang = cellValueMaKhachHang != null ? cellValueMaKhachHang.ToString() : "";

                // Lấy giá trị từ cột TenKhachHang (Cell 4)
                object cellValueTenKhachHang = row.Cells[4].Value;
                string TenKhachHang = cellValueTenKhachHang != null ? cellValueTenKhachHang.ToString() : "";

                // Lấy giá trị từ cột MaHang (Cell 5)
                object cellValueMaHang = row.Cells[5].Value;
                string MaHang = cellValueMaHang != null ? cellValueMaHang.ToString() : "";

                // Lấy giá trị từ cột TenHang (Cell 6)
                object cellValueTenHang = row.Cells[6].Value;
                string TenHang = cellValueTenHang != null ? cellValueTenHang.ToString() : "";

                // Lấy giá trị từ cột SoLuong (Cell 7)
                object cellValueSoLuong = row.Cells[7].Value;
                int SoLuong = cellValueSoLuong != null ? Convert.ToInt32(cellValueSoLuong) : 0;

                // Lấy giá trị từ cột ThanhTien (Cell 8)
                object cellValueThanhTien = row.Cells[8].Value;
                string ThanhTien = cellValueThanhTien != null ? cellValueThanhTien.ToString() : "";

                if (!string.IsNullOrEmpty(MaHang))
                {
                    // Hiển thị thông tin lên các controls tương ứng
                    txtMaHDBan.Text = MaHoaDon;
                    cboMaNhanVien.Text = MaNhanVien;
                    dtpNgayBan.Value = NgayBan;
                    cboMaKhach.Text = MaKhachHang;
                    txtTenKhachHang.Text = TenKhachHang;
                    cboMaHang.Text = MaHang;
                    txtTenHang.Text = TenHang;
                    txtSoLuong.Text = SoLuong.ToString();
                    txtThanhTien.Text = ThanhTien;
                }
            }
            else
            {
                // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của các controls)
                txtMaHDBan.Text = "";
                cboMaNhanVien.Text = "";
                dtpNgayBan.Value = DateTime.Now;
                cboMaKhach.Text = "";
                txtTenKhachHang.Text = "";
                cboMaHang.Text = "";
                txtTenHang.Text = "";
                txtSoLuong.Text = "";
                txtThanhTien.Text = "";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
                
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            List<HDBan> lstHDBan = hdBanBLL.ReadHDBan();
            foreach (HDBan hdBan in lstHDBan)
            {
                dgvHDBanHang.Rows.Add(
                    hdBan.MaHoaDon,
                    hdBan.MaNhanVien,
                    hdBan.NgayBan,
                    hdBan.MaKhachHang,
                    hdBan.TenKhachHang,
                    hdBan.MaHang,
                    hdBan.TenHang,
                    hdBan.SoLuong,
                    hdBan.ThanhTien
                );
            }

            HDBanDAL hDBanDAL = new HDBanDAL();
            List<Tuple<string, string>> nhanVienInfoList = hDBanDAL.GetNhanVienList();
            cboMaNhanVien.DataSource = nhanVienInfoList;
            cboMaNhanVien.DisplayMember = "Item1";

            List<Tuple<string, string, string, string>> khachHangInfoList = hDBanDAL.GetKhachHangList();
            cboMaKhach.DataSource = khachHangInfoList;
            cboMaKhach.DisplayMember = "Item1";

            List<Tuple<string, string, string>> hanghoaInfoList = hDBanDAL.GetHangHoaList();
            cboMaHang.DataSource = hanghoaInfoList;
            cboMaHang.DisplayMember = "Item1";

        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<string, string> selectedNhanVien = (Tuple<string, string>)cboMaNhanVien.SelectedItem;
            txtTenNhanVien.Text = selectedNhanVien.Item2;
        }

        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<string, string, string, string> selectedKhachHang = (Tuple<string, string, string, string>)cboMaKhach.SelectedItem;
            txtTenKhachHang.Text = selectedKhachHang.Item2;
            txtDiaChi.Text = selectedKhachHang.Item3;
            mtbDienThoai.Text = selectedKhachHang.Item4;

        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<string, string, string> selectedHangHoa = (Tuple<string, string, string>)cboMaHang.SelectedItem;
            txtTenHang.Text = selectedHangHoa.Item2;
            txtDonGia.Text = selectedHangHoa.Item3;
            
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu kí tự không phải là số và không phải là phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Hủy sự kiện để ngăn việc hiển thị kí tự không phải số
                e.Handled = true;
            }
        }

        private void txtMaHDBan_TextChanged(object sender, EventArgs e)
        {

        }
        private void UpdateThanhTien(object sender, EventArgs e)
        {
            if (double.TryParse(txtDonGia.Text.Replace("VND", "").Trim(), out double gia) &&
         double.TryParse(txtSoLuong.Text, out double soLuong))
            {

                double giamGia = 0.0;

                // Lấy giá trị giảm giá từ ComboBox cboGiamGia
                if (cboGiamGia.SelectedItem != null)
                {
                    string giamGiaStr = cboGiamGia.SelectedItem.ToString();
                    giamGiaStr = giamGiaStr.Replace("%", ""); // Loại bỏ dấu %
                    if (double.TryParse(giamGiaStr, out double giamGiaValue))
                    {
                        giamGia = giamGiaValue;
                    }
                }

                double thanhTien = (gia * soLuong) * (1 - giamGia / 100);
                string formattedThanhTien = (thanhTien / 1000).ToString("N0") + ".000 VND";
                txtThanhTien.Text = formattedThanhTien;

            }
            else
            {
                txtThanhTien.Text = "0 VND"; // Hoặc thông báo lỗi khác
            }

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
          

            //if (decimal.TryParse(txtThanhTien.Text, out decimal amount))
            //{
            //    string amountInWords = ConvertToWords(amount);
            //    lblBangChu.Text = "Bằng chữ: " + amountInWords;
            //}
            //else
            //{
            //    lblBangChu.Text = "Bằng chữ: Số không hợp lệ";
            //}
        }
        //in hóa đơn
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Đặt nội dung bạn muốn in tại đây
            string contentToPrint = "Nội dung hóa đơn của bạn";

            // Tạo một Font cho văn bản in
            Font font = new Font("Arial", 12);

            // Tạo một Brush để màu văn bản
            Brush brush = Brushes.Black;

            // Xác định vị trí bắt đầu in
            float startX = 10;
            float startY = 10;

            // In nội dung vào trang
            e.Graphics.DrawString(contentToPrint, font, brush, startX, startY);
        }
        private PrintDocument printDocument = new PrintDocument();
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Đặt tỷ lệ khung hình mong muốn
            float scaleWidth = 1.5f; // Tỷ lệ chiều rộng, ví dụ: 1.5 lần

            int newWidth = (int)(this.Width * scaleWidth);
            int newHeight = this.Height;

            Bitmap bmp = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // Xóa nền trắng để đảm bảo không có nội dung cũ
                g.ScaleTransform(scaleWidth, 1); // Chỉ áp dụng tỷ lệ cho chiều rộng
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, pe) =>
            {
                pe.Graphics.DrawImage(bmp, 0, 0);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                MessageBox.Show("Quá trình in hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private int hdCounter = 1;
        private string GenerateNewMaHDBan()
        {
            string newMaHDBan;
            do
            {
                hdCounter++;
                newMaHDBan = "HD" + hdCounter.ToString("00");
            }
            while (CheckMaHDBanExists(newMaHDBan)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHDBan;
        }

        private bool CheckMaHDBanExists(string maHDBan)
        {
            foreach (DataGridViewRow row in dgvHDBanHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHDBan)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }

        //thêm  
        private void btnThem_Click(object sender, EventArgs e)
        {
            string newMaHDBan = GenerateNewMaHDBan();
            txtMaHDBan.Text = newMaHDBan;
            string maHoaDon = txtMaHDBan.Text;


            // Kiểm tra xem mã hóa đơn đã tồn tại hay chưa
            bool isMaHoaDonExist = false;
            foreach (DataGridViewRow row in dgvHDBanHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHoaDon)
                {
                    isMaHoaDonExist = true;
                    break;
                }
            }

            if (isMaHoaDonExist)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại. Vui lòng chọn mã hóa đơn khác.");
                return;
            }
          
            HDBan hdBan = new HDBan();
            hdBan.MaHoaDon = txtMaHDBan.Text;
            hdBan.MaNhanVien = cboMaNhanVien.Text;
            hdBan.NgayBan = dtpNgayBan.Value;
            hdBan.MaKhachHang = cboMaKhach.Text;
            hdBan.TenKhachHang = txtTenKhachHang.Text;
            hdBan.MaHang = cboMaHang.Text;
            hdBan.TenHang = txtTenHang.Text;
            hdBan.SoLuong = int.Parse(txtSoLuong.Text);
            hdBan.ThanhTien = txtThanhTien.Text;

            hdBanBLL.NewHDBan(hdBan);

            MessageBox.Show("Thêm thành công!");

            dgvHDBanHang.Rows.Add(
                hdBan.MaHoaDon,
                hdBan.MaNhanVien,
                hdBan.NgayBan,
                hdBan.MaKhachHang,
                hdBan.TenKhachHang,
                hdBan.MaHang,
                hdBan.TenHang,
                hdBan.SoLuong,
                hdBan.ThanhTien
            );
        }
        //xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            HDBan hdBan = new HDBan();
            hdBan.MaHoaDon = txtMaHDBan.Text;
            hdBan.MaNhanVien = cboMaNhanVien.Text;
            hdBan.NgayBan = dtpNgayBan.Value;
            hdBan.MaKhachHang = cboMaKhach.Text;
            hdBan.TenKhachHang = txtTenKhachHang.Text;
            hdBan.MaHang = cboMaHang.Text;
            hdBan.TenHang = txtTenHang.Text;
            hdBan.SoLuong = int.Parse(txtSoLuong.Text);
            hdBan.ThanhTien = txtThanhTien.Text;

            hdBanBLL.DeleteHDBan(hdBan);

            MessageBox.Show("Xóa thành công!");

            int idx = dgvHDBanHang.CurrentCell.RowIndex;
            dgvHDBanHang.Rows.RemoveAt(idx);
        }
        //sữa
        private void btnSua_Click(object sender, EventArgs e)
        {
            HDBan hdBan = new HDBan();
            hdBan.MaHoaDon = txtMaHDBan.Text;
            hdBan.MaNhanVien = cboMaNhanVien.Text;
            hdBan.NgayBan = dtpNgayBan.Value;
            hdBan.MaKhachHang = cboMaKhach.Text;
            hdBan.TenKhachHang = txtTenKhachHang.Text;
            hdBan.MaHang = cboMaHang.Text;
            hdBan.TenHang = txtTenHang.Text;
            hdBan.SoLuong = int.Parse(txtSoLuong.Text);
            hdBan.ThanhTien = txtThanhTien.Text;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hdBanBLL.EditHDBan(hdBan);

            MessageBox.Show("Chỉnh sửa thành công!");

            DataGridViewRow row = dgvHDBanHang.CurrentRow;
            row.Cells[0].Value = hdBan.MaHoaDon;
            row.Cells[1].Value = hdBan.MaNhanVien;
            row.Cells[2].Value = hdBan.NgayBan;
            row.Cells[3].Value = hdBan.MaKhachHang;
            row.Cells[4].Value = hdBan.TenKhachHang;
            row.Cells[5].Value = hdBan.MaHang;
            row.Cells[6].Value = hdBan.TenHang;
            row.Cells[7].Value = hdBan.SoLuong;
            row.Cells[8].Value = hdBan.ThanhTien;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    // Đổ tiêu đề cột từ DataGridView
                    for (int i = 0; i < dgvHDBanHang.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dgvHDBanHang.Columns[i].HeaderText;
                    }

                    // Đổ dữ liệu từ DataGridView
                    for (int row = 0; row < dgvHDBanHang.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvHDBanHang.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dgvHDBanHang.Rows[row].Cells[col].Value;
                        }
                    }

                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(excelFile);
                }

                MessageBox.Show("Xuất thành công!");
            }
        }

        private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvHDBanHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
     
        }

        private void txtThanhTien_TextChanged_1(object sender, EventArgs e)
        {
            CalculateTotalAndDisplay();
        }
        private void CalculateTotalAndDisplay()
        {
            int total = 0;

            foreach (DataGridViewRow row in dgvHDBanHang.Rows)
            {
                if (row.Cells["Column9"].Value != null)
                {
                    string valueString = row.Cells["Column9"].Value.ToString();
                    valueString = valueString.Replace(".", "").Replace(" VND", "");

                    if (int.TryParse(valueString, out int value))
                    {
                        total += value;
                    }
                }
            }

            string formattedTotal = $"{total:N0} VND";
            txtTongTien.Text = formattedTotal;

            // Chuyển tổng số tiền thành chữ và hiển thị cạnh lblBangChu
            string totalInWords = NumberToWords(total);
            lblBangChu.Text = $"Bằng chữ: {totalInWords}";
        }
        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "Không";

            string[] ones = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín", "Mười", "Mười Một", "Mười Hai", "Mười Ba", "Mười Bốn", "Mười Lăm", "Mười Sáu", "Mười Bảy", "Mười Tám", "Mười Chín" };
            string[] powers = { "", "Nghìn", "Triệu", "Tỷ" };

            string words = "";
            int count = 0;
            while (number > 0)
            {
                int currentGroup = number % 1000;
                if (currentGroup > 0)
                {
                    string groupWords = ConvertGroupToWords(currentGroup);
                    if (!string.IsNullOrEmpty(groupWords))
                    {
                        words = $"{groupWords} {powers[count]} {words}";
                    }
                }
                number /= 1000;
                count++;
            }

            return words.Trim();
        }

        private static string ConvertGroupToWords(int group)
        {
            string[] ones = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            int hundreds = group / 100;
            int tens = (group % 100) / 10;
            int onesDigit = group % 10;

            string words = "";

            if (hundreds > 0)
            {
                words += $"{ones[hundreds]} Trăm ";
            }

            if (tens == 0)
            {
                if (onesDigit > 0)
                {
                    words += $"{ones[onesDigit]}";
                }
            }
            
            else
            {
                words += $"{ones[tens]} Mươi ";
                if (onesDigit > 0)
                {
                    words += $"{ones[onesDigit]}";
                }
            }

            return words;
        }

    }
}

