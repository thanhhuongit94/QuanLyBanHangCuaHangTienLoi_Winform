namespace QuanLyCuaHangCoffee
{
    partial class frmXemDSSanPham_Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemDSSanPham_Employee));
            this.label1 = new System.Windows.Forms.Label();
            this.lvwHienThiDSSP = new System.Windows.Forms.ListView();
            this.colMaSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTinhTrang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(296, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // lvwHienThiDSSP
            // 
            this.lvwHienThiDSSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colTinhTrang,
            this.colLoai});
            this.lvwHienThiDSSP.FullRowSelect = true;
            this.lvwHienThiDSSP.GridLines = true;
            this.lvwHienThiDSSP.Location = new System.Drawing.Point(35, 73);
            this.lvwHienThiDSSP.Name = "lvwHienThiDSSP";
            this.lvwHienThiDSSP.Size = new System.Drawing.Size(763, 233);
            this.lvwHienThiDSSP.SmallImageList = this.imageList1;
            this.lvwHienThiDSSP.TabIndex = 1;
            this.lvwHienThiDSSP.UseCompatibleStateImageBehavior = false;
            this.lvwHienThiDSSP.View = System.Windows.Forms.View.Details;
            // 
            // colMaSP
            // 
            this.colMaSP.Text = "Mã sản phẩm";
            this.colMaSP.Width = 110;
            // 
            // colTenSP
            // 
            this.colTenSP.Text = "Tên sản phẩm";
            this.colTenSP.Width = 200;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "Số lượng";
            this.colSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoLuong.Width = 100;
            // 
            // colDonGia
            // 
            this.colDonGia.Text = "Đơn giá";
            this.colDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDonGia.Width = 100;
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.Text = "Tình trạng";
            this.colTinhTrang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTinhTrang.Width = 120;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại sản phẩm";
            this.colLoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLoai.Width = 130;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cupcoffee.png");
            // 
            // frmXemDSSanPham_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 341);
            this.Controls.Add(this.lvwHienThiDSSP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXemDSSanPham_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem danh sách sản phẩm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXemDSSanPham_Employee_FormClosed);
            this.Load += new System.EventHandler(this.frmXemDSSanPham_Employee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwHienThiDSSP;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader colMaSP;
        private System.Windows.Forms.ColumnHeader colTenSP;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colTinhTrang;
        private System.Windows.Forms.ColumnHeader colLoai;
    }
}