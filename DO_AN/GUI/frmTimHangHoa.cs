using DO_AN.BAL;
using DO_AN.Model;
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
    public partial class frmTimHangHoa : Form
    {
        public frmTimHangHoa()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;

            // Gọi phương thức tìm kiếm từ BLL và hiển thị kết quả trong DataGridView
            HangBLL hangBLL = new HangBLL();
            List<Hang> searchResults = hangBLL.SearchHangByMaAndTen(maHang, tenHang);

            if (searchResults.Count > 0)
            {
                dgvHang.DataSource = searchResults;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHang.DataSource = null; // Xóa dữ liệu hiển thị trên DataGridView
            }
        }


        private void btnTimLai_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;

            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimHangHoa_Load(object sender, EventArgs e)
        {

        }
        
    }
}
