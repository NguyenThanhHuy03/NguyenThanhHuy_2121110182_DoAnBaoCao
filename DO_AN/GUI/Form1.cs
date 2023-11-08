

using DO_AN.GUI;
using System.Data.SqlClient;
using static DO_AN.BAL.dangnhap;

namespace DO_AN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool isAuthenticated = false; // Thêm thuộc tính để theo dõi trạng thái đăng nhập

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set { isAuthenticated = value; }
        }

        public void btlogin_Click(object sender, EventArgs e)
        {
            string username = btTk.Text;
            string password = btMk.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!");
                return;
            }
            // kiem tra tk mk dung hay k 
            bool isAuthenticated = BusinessLogicLayer.ValidateLoginCredentials(username, password);

            
            if (isAuthenticated)
            {
                
                //giaodien giaodien = new giaodien();
                //giaodien.ShowDialog();
                x menu = new x();
                menu.ShowDialog();
                
            }
            else
            {
              
                MessageBox.Show("Thông tin đăng nhập không chính xác!");
            }
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void btMk_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void btTk_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetUsername(string username)
        {
            btTk.Text = username;
        }
        public void SetPassword(string password)
        {
            btMk.Text = password;
        }
    }
    }
