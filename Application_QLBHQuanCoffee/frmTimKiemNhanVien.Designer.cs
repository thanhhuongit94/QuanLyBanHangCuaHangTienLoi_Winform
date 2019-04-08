namespace QuanLyCuaHangCoffee
{
    partial class frmTimKiemNhanVien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemNhanVien));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLuaChonTimKiem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThongTinCanTim = new System.Windows.Forms.TextBox();
            this.lvwThongTinTimKiem = new System.Windows.Forms.ListView();
            this.colMaNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMND = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLuongCB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÌM KIẾM NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // cboLuaChonTimKiem
            // 
            this.cboLuaChonTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuaChonTimKiem.FormattingEnabled = true;
            this.cboLuaChonTimKiem.Items.AddRange(new object[] {
            "Mã nhân viên",
            "Tên nhân viên",
            "Địa chỉ"});
            this.cboLuaChonTimKiem.Location = new System.Drawing.Point(397, 64);
            this.cboLuaChonTimKiem.Name = "cboLuaChonTimKiem";
            this.cboLuaChonTimKiem.Size = new System.Drawing.Size(147, 23);
            this.cboLuaChonTimKiem.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập thông tin cần tìm";
            // 
            // txtThongTinCanTim
            // 
            this.txtThongTinCanTim.Location = new System.Drawing.Point(150, 63);
            this.txtThongTinCanTim.Name = "txtThongTinCanTim";
            this.txtThongTinCanTim.Size = new System.Drawing.Size(186, 23);
            this.txtThongTinCanTim.TabIndex = 1;
            this.txtThongTinCanTim.TextChanged += new System.EventHandler(this.txtThongTinCanTim_TextChanged);
            // 
            // lvwThongTinTimKiem
            // 
            this.lvwThongTinTimKiem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaNV,
            this.colTenNV,
            this.colCMND,
            this.colGioiTinh,
            this.colDiaChi,
            this.colSDT,
            this.colHeSoLuong,
            this.colLuongCB,
            this.colUsername});
            this.lvwThongTinTimKiem.FullRowSelect = true;
            this.lvwThongTinTimKiem.GridLines = true;
            this.lvwThongTinTimKiem.Location = new System.Drawing.Point(34, 123);
            this.lvwThongTinTimKiem.Name = "lvwThongTinTimKiem";
            this.lvwThongTinTimKiem.Size = new System.Drawing.Size(539, 196);
            this.lvwThongTinTimKiem.SmallImageList = this.imageList1;
            this.lvwThongTinTimKiem.TabIndex = 4;
            this.lvwThongTinTimKiem.UseCompatibleStateImageBehavior = false;
            this.lvwThongTinTimKiem.View = System.Windows.Forms.View.Details;
            // 
            // colMaNV
            // 
            this.colMaNV.Text = "Mã nhân viên";
            // 
            // colTenNV
            // 
            this.colTenNV.Text = "Tên nhân viên";
            this.colTenNV.Width = 100;
            // 
            // colCMND
            // 
            this.colCMND.Text = "CMND";
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Text = "Giới tính";
            this.colGioiTinh.Width = 40;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Text = "Địa chỉ";
            // 
            // colSDT
            // 
            this.colSDT.Text = "SĐT";
            // 
            // colHeSoLuong
            // 
            this.colHeSoLuong.Text = "Hệ số lương";
            // 
            // colLuongCB
            // 
            this.colLuongCB.Text = "Lương CB";
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "employees.jpg");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // frmTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 352);
            this.Controls.Add(this.lvwThongTinTimKiem);
            this.Controls.Add(this.txtThongTinCanTim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboLuaChonTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTimKiemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm nhân viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTimKiemNhanVien_FormClosed);
            this.Load += new System.EventHandler(this.frmTimKiemNhanVien_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLuaChonTimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThongTinCanTim;
        private System.Windows.Forms.ListView lvwThongTinTimKiem;
        private System.Windows.Forms.ColumnHeader colMaNV;
        private System.Windows.Forms.ColumnHeader colTenNV;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colGioiTinh;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ColumnHeader colSDT;
        private System.Windows.Forms.ColumnHeader colHeSoLuong;
        private System.Windows.Forms.ColumnHeader colLuongCB;
        private System.Windows.Forms.ColumnHeader colUsername;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}