namespace QuanLyCuaHangCoffee
{
    partial class frmDoiMK_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMK_Admin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMKCu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMKMoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(205, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "THAY ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // txtMKCu
            // 
            this.txtMKCu.Location = new System.Drawing.Point(210, 50);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.Size = new System.Drawing.Size(231, 26);
            this.txtMKCu.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Location = new System.Drawing.Point(210, 95);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.Size = new System.Drawing.Size(231, 26);
            this.txtMKMoi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Xác nhận mật khẩu";
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(210, 143);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.Size = new System.Drawing.Size(231, 26);
            this.txtXacNhanMK.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(270, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHide
            // 
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.Location = new System.Drawing.Point(472, 53);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(33, 23);
            this.btnHide.TabIndex = 4;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // frmDoiMK_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 272);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMKCu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDoiMK_Admin";
            this.Text = "Thay đổi mật khẩu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDoiMK_Admin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMKCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMKMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHide;
    }
}