namespace QuanLyCuaHangCoffee
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.txtMKMoi = new System.Windows.Forms.TextBox();
            this.txtMKCu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(169, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Xác nhận mật khẩu";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(371, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtXacNhan
            // 
            this.txtXacNhan.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhan.Location = new System.Drawing.Point(159, 150);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.PasswordChar = '.';
            this.txtXacNhan.Size = new System.Drawing.Size(193, 30);
            this.txtXacNhan.TabIndex = 6;
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKMoi.Location = new System.Drawing.Point(159, 107);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.PasswordChar = '.';
            this.txtMKMoi.Size = new System.Drawing.Size(193, 30);
            this.txtMKMoi.TabIndex = 4;
            // 
            // txtMKCu
            // 
            this.txtMKCu.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKCu.Location = new System.Drawing.Point(159, 61);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.PasswordChar = '.';
            this.txtMKCu.Size = new System.Drawing.Size(193, 30);
            this.txtMKCu.TabIndex = 2;
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMKCu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDoiMatKhau_FormClosed);
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.TextBox txtMKMoi;
        private System.Windows.Forms.TextBox txtMKCu;
    }
}