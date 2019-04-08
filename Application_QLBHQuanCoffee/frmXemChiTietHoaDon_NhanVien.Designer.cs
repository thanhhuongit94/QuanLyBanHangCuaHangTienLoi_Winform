namespace QuanLyCuaHangCoffee
{
    partial class frmXemChiTietHoaDon_NhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemChiTietHoaDon_NhanVien));
            this.label1 = new System.Windows.Forms.Label();
            this.lvwChiTiet = new System.Windows.Forms.ListView();
            this.colMaSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(149, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN CHI TIẾT HÓA ĐƠN";
            // 
            // lvwChiTiet
            // 
            this.lvwChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.lvwChiTiet.FullRowSelect = true;
            this.lvwChiTiet.GridLines = true;
            this.lvwChiTiet.Location = new System.Drawing.Point(22, 74);
            this.lvwChiTiet.Name = "lvwChiTiet";
            this.lvwChiTiet.Size = new System.Drawing.Size(594, 182);
            this.lvwChiTiet.SmallImageList = this.imageList1;
            this.lvwChiTiet.TabIndex = 1;
            this.lvwChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvwChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // colMaSP
            // 
            this.colMaSP.Text = "Mã sản phẩm";
            this.colMaSP.Width = 100;
            // 
            // colTenSP
            // 
            this.colTenSP.Text = "Tên sản phẩm";
            this.colTenSP.Width = 200;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "Số lượng";
            this.colSoLuong.Width = 80;
            // 
            // colDonGia
            // 
            this.colDonGia.Text = "Đơn giá";
            this.colDonGia.Width = 100;
            // 
            // colThanhTien
            // 
            this.colThanhTien.Text = "Thành tiền";
            this.colThanhTien.Width = 110;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lycaphe.jpg");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(267, 283);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(153, 25);
            this.txtTongTien.TabIndex = 3;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmXemChiTietHoaDon_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 338);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwChiTiet);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXemChiTietHoaDon_NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin chi tiết hóa đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXemChiTietHoaDon_FormClosed);
            this.Load += new System.EventHandler(this.frmXemChiTietHoaDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwChiTiet;
        private System.Windows.Forms.ColumnHeader colMaSP;
        private System.Windows.Forms.ColumnHeader colTenSP;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colThanhTien;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}