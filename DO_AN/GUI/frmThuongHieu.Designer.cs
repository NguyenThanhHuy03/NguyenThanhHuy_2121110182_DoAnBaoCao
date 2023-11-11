namespace DO_AN.GUI
{
    partial class frmThuongHieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMaThuongHieu = new System.Windows.Forms.TextBox();
            this.txtTenThuongHieu = new System.Windows.Forms.TextBox();
            this.dgvThuongHieu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.Ảnh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(439, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "THƯƠNG HIỆU";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDong.Location = new System.Drawing.Point(823, 643);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(175, 38);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.Location = new System.Drawing.Point(327, 643);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(175, 38);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sữa thương hiệu";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.Location = new System.Drawing.Point(577, 643);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(175, 38);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa thương thiệu";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.Location = new System.Drawing.Point(60, 643);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(175, 38);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm thương hiệu";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // txtMaThuongHieu
            // 
            this.txtMaThuongHieu.Location = new System.Drawing.Point(173, 104);
            this.txtMaThuongHieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaThuongHieu.Name = "txtMaThuongHieu";
            this.txtMaThuongHieu.Size = new System.Drawing.Size(262, 27);
            this.txtMaThuongHieu.TabIndex = 10;
            // 
            // txtTenThuongHieu
            // 
            this.txtTenThuongHieu.Location = new System.Drawing.Point(173, 166);
            this.txtTenThuongHieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenThuongHieu.Name = "txtTenThuongHieu";
            this.txtTenThuongHieu.Size = new System.Drawing.Size(262, 27);
            this.txtTenThuongHieu.TabIndex = 11;
            this.txtTenThuongHieu.TextChanged += new System.EventHandler(this.txtTenThuongHieu_TextChanged_1);
            // 
            // dgvThuongHieu
            // 
            this.dgvThuongHieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuongHieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuongHieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvThuongHieu.Location = new System.Drawing.Point(-6, 338);
            this.dgvThuongHieu.Name = "dgvThuongHieu";
            this.dgvThuongHieu.RowHeadersWidth = 51;
            this.dgvThuongHieu.RowTemplate.Height = 29;
            this.dgvThuongHieu.Size = new System.Drawing.Size(1197, 269);
            this.dgvThuongHieu.TabIndex = 14;
            this.dgvThuongHieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuongHieu_CellClick_1);
            this.dgvThuongHieu.SelectionChanged += new System.EventHandler(this.dgvThuongHieu_SelectionChanged_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Thương Hiệu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Thương Hiệu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ghi chú";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ảnh";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã thương hiệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(25, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tên thương hiệu";
            // 
            // picAnh
            // 
            this.picAnh.BackColor = System.Drawing.Color.DarkGray;
            this.picAnh.Location = new System.Drawing.Point(904, 92);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(202, 218);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 22;
            this.picAnh.TabStop = false;
            this.picAnh.Click += new System.EventHandler(this.picAnh_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(173, 228);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(262, 72);
            this.txtGhiChu.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(25, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ghi chú";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOpen.Location = new System.Drawing.Point(792, 92);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(95, 35);
            this.btnOpen.TabIndex = 23;
            this.btnOpen.Text = "Chọn ảnh";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click_1);
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(527, 109);
            this.txtAnh.Multiline = true;
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(225, 79);
            this.txtAnh.TabIndex = 25;
            // 
            // Ảnh
            // 
            this.Ảnh.AutoSize = true;
            this.Ảnh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Ảnh.Location = new System.Drawing.Point(479, 108);
            this.Ảnh.Name = "Ảnh";
            this.Ảnh.Size = new System.Drawing.Size(42, 23);
            this.Ảnh.TabIndex = 24;
            this.Ảnh.Text = "Ảnh";
            // 
            // frmThuongHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1203, 695);
            this.Controls.Add(this.txtAnh);
            this.Controls.Add(this.Ảnh);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.picAnh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvThuongHieu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenThuongHieu);
            this.Controls.Add(this.txtMaThuongHieu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Name = "frmThuongHieu";
            this.Text = "frmThuongHieu";
            this.Load += new System.EventHandler(this.frmThuongHieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnDong;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtMaThuongHieu;
        private TextBox txtTenThuongHieu;
        private DataGridView dgvThuongHieu;
        private Label label2;
        private Label label3;
        private PictureBox picAnh;
        private TextBox txtGhiChu;
        private Label label4;
        private Button btnOpen;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private TextBox txtAnh;
        private Label Ảnh;
    }
}