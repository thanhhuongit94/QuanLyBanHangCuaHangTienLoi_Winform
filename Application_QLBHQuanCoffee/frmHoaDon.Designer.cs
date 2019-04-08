namespace QuanLyCuaHangCoffee
{
    partial class frmHoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.maHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXuatDS = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHD,
            this.maNV,
            this.tongTien,
            this.ngayLapHD,
            this.ghiChu});
            this.dgvHoaDon.Location = new System.Drawing.Point(45, 77);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(590, 191);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.Click += new System.EventHandler(this.dgvHoaDon_Click);
            // 
            // maHD
            // 
            this.maHD.DataPropertyName = "maHD";
            this.maHD.HeaderText = "Mã HD";
            this.maHD.Name = "maHD";
            this.maHD.Width = 70;
            // 
            // maNV
            // 
            this.maNV.DataPropertyName = "maNV";
            this.maNV.HeaderText = "Mã nhân viên";
            this.maNV.Name = "maNV";
            // 
            // tongTien
            // 
            this.tongTien.DataPropertyName = "tongTien";
            this.tongTien.HeaderText = "Tổng tiền";
            this.tongTien.Name = "tongTien";
            // 
            // ngayLapHD
            // 
            this.ngayLapHD.DataPropertyName = "ngayLapHD";
            this.ngayLapHD.HeaderText = "Ngày lập hóa đơn";
            this.ngayLapHD.Name = "ngayLapHD";
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "ghiChu";
            this.ghiChu.HeaderText = "Ghi chú";
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(128, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH CÁC HÓA ĐƠN";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(92, 289);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXuatDS
            // 
            this.btnXuatDS.Location = new System.Drawing.Point(236, 289);
            this.btnXuatDS.Name = "btnXuatDS";
            this.btnXuatDS.Size = new System.Drawing.Size(115, 40);
            this.btnXuatDS.TabIndex = 2;
            this.btnXuatDS.Text = "Xuất danh sách";
            this.btnXuatDS.UseVisualStyleBackColor = true;
            this.btnXuatDS.Click += new System.EventHandler(this.btnXuatDS_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(423, 289);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(91, 40);
            this.btnQuayLai.TabIndex = 2;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 341);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnXuatDS);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDon);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin các hóa đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoaDon_FormClosing);
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXuatDS;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
    }
}