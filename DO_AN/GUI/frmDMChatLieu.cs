using DO_AN.BAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DO_AN.GUI
{
    public partial class frmDMChatLieu : Form
    {
        ChatLieuBLL clBLL = new ChatLieuBLL();
        public frmDMChatLieu()
        {
            InitializeComponent();
            dgvChatLieu.CellClick += dgvChatLieu_CellClick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTenChatLieu_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenChatLieu.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓÔỌỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọôỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên chất liệu không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenChatLieu.Text = filteredInput;
                txtTenChatLieu.SelectionStart = filteredInput.Length;
            }
        }

        private void txtMaChatLieu_TextChanged(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text.Length > 4)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Mã chất liệu không được nhập quá 5 kí tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //chọn lấy thông tin từng hàng
        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvChatLieu.Rows.Count)
            {
                DataGridViewRow row = dgvChatLieu.Rows[e.RowIndex];

                // Lấy giá trị từ cột MaChatLieu (Cell 0)
                object cellValueMaChatLieu = row.Cells[0].Value;
                string MaChatLieu = cellValueMaChatLieu != null ? cellValueMaChatLieu.ToString() : "";

                // Lấy giá trị từ cột TenChatLieu (Cell 1)
                object cellValueTenChatLieu = row.Cells[1].Value;
                string TenChatLieu = cellValueTenChatLieu != null ? cellValueTenChatLieu.ToString() : "";

                // Hiển thị giá trị lên TextBox
                txtMaChatLieu.Text = MaChatLieu;
                txtTenChatLieu.Text = TenChatLieu;
            }
            else
            {
                // Nếu người dùng click vào khoảng trống cuối cùng của hàng,
                // bạn có thể làm gì đó ở đây (ví dụ: xóa giá trị của TextBox)
                txtMaChatLieu.Text = "";
                txtTenChatLieu.Text = "";
            }
        }



        //thêm
       
        private void btnThem_Click(object sender, EventArgs e)
        {
           
           
            string MaChatLieu = txtMaChatLieu.Text;
            // Kiểm tra xem mã hàng đã tồn tại hay chưa
            bool isMaChatLieuExist = false;
            foreach (DataGridViewRow row in dgvChatLieu.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == MaChatLieu)
                {
                    isMaChatLieuExist = true;
                    break;
                }
            }
            
        

            if (isMaChatLieuExist)
            {
                MessageBox.Show("Mã chất liệu đã tồn tại.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaChatLieu.Text))
            {
                MessageBox.Show("Mã chất liệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenChatLieu.Text))
            {
                MessageBox.Show("Tên chất liệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            ChatLieu cus = new ChatLieu();
            cus.MaChatLieu = txtMaChatLieu.Text;
            cus.TenChatLieu = txtTenChatLieu.Text;

            clBLL.NewChatLieu(cus);
            MessageBox.Show("Thêm thành công!");

            dgvChatLieu.Rows.Add(cus.MaChatLieu, cus.TenChatLieu);


            //----------------//
           
        }
        //xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChatLieu cus = new ChatLieu();
            cus.MaChatLieu = txtMaChatLieu.Text;
            cus.TenChatLieu = txtTenChatLieu.Text;

            clBLL.DeleteChatLieu(cus);
            MessageBox.Show("Xóa thành công!");

            int idx = dgvChatLieu.CurrentCell.RowIndex;
            dgvChatLieu.Rows.RemoveAt(idx);
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
      
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDMChatLieu_Load(object sender, EventArgs e)
        {
            List<ChatLieu> lstCus = clBLL.ReadChatLieu();
            foreach (ChatLieu cus in lstCus)
            {
                dgvChatLieu.Rows.Add(cus.MaChatLieu, cus.TenChatLieu);

            }
        }
        //sữa
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            ChatLieu cus = new ChatLieu();
            cus.MaChatLieu = txtMaChatLieu.Text;
            cus.TenChatLieu = txtTenChatLieu.Text;


            string MaChatLieu = txtMaChatLieu.Text;
            int editingRowIndex = dgvChatLieu.CurrentCell.RowIndex;
            bool isMaChatLieuExist = false;

            for (int i = 0; i < dgvChatLieu.Rows.Count; i++)
            {
                if (i != editingRowIndex)
                {
                    DataGridViewRow currentRow = dgvChatLieu.Rows[i];  // Đổi tên biến row thành currentRow
                    if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value.ToString() == MaChatLieu)
                    {
                        isMaChatLieuExist = true;
                        break;
                    }
                }
            }

            if (isMaChatLieuExist)
            {
                MessageBox.Show("Mã chất liệu đã tồn tại.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaChatLieu.Text))
            {
                MessageBox.Show("Mã chất liệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenChatLieu.Text))
            {
                MessageBox.Show("Tên chất liệu không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clBLL.EditChatLieu(cus); // Gọi phương thức EditChatLieu để chỉnh sửa thông tin chất liệu

            // Kiểm tra sau khi chỉnh sửa thành công
            MessageBox.Show("Chỉnh sửa thành công!");

           
            DataGridViewRow row = dgvChatLieu.CurrentRow;
            row.Cells[0].Value = cus.MaChatLieu;
            row.Cells[1].Value = cus.TenChatLieu;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ChatLieu cus = new ChatLieu();
            cus.MaChatLieu = txtMaChatLieu.Text;
            cus.TenChatLieu = txtTenChatLieu.Text;

            clBLL.LuuChatLieu(cus); 

       
            MessageBox.Show("Lưu thành công!");

           
            DataGridViewRow row = dgvChatLieu.CurrentRow;
            row.Cells[0].Value = cus.MaChatLieu;
            row.Cells[1].Value = cus.TenChatLieu;
        }
    }
}
