namespace QuanLyCuaHangCoffee
{
    partial class frmXemChiTietHD_Admin
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
            this.cboHoaDon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwChiTiet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(215, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN CHI TIẾT CÁC HÓA ĐƠN";
            // 
            // cboHoaDon
            // 
            this.cboHoaDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoaDon.FormattingEnabled = true;
            this.cboHoaDon.Location = new System.Drawing.Point(340, 72);
            this.cboHoaDon.Name = "cboHoaDon";
            this.cboHoaDon.Size = new System.Drawing.Size(192, 27);
            this.cboHoaDon.TabIndex = 1;
            this.cboHoaDon.SelectedIndexChanged += new System.EventHandler(this.cboHoaDon_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hóa đơn";
            // 
            // lvwChiTiet
            // 
            this.lvwChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwChiTiet.FullRowSelect = true;
            this.lvwChiTiet.GridLines = true;
            this.lvwChiTiet.Location = new System.Drawing.Point(28, 147);
            this.lvwChiTiet.Name = "lvwChiTiet";
            this.lvwChiTiet.Size = new System.Drawing.Size(775, 184);
            this.lvwChiTiet.TabIndex = 3;
            this.lvwChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvwChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã HĐ";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã NV";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên nhân viên";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên sản phẩm";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đơn giá";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Thành tiền";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ghi chú";
            this.columnHeader8.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(368, 364);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(164, 30);
            this.txtTongTien.TabIndex = 5;
            this.txtTongTien.Text = "0.0";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmXemChiTietHD_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 419);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwChiTiet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboHoaDon);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXemChiTietHD_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin chi tiết các hóa đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXemChiTietHD_Admin_FormClosed);
            this.Load += new System.EventHandler(this.frmXemChiTietHD_Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwChiTiet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}