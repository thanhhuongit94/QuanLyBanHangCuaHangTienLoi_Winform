using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace QuanLyCuaHangCoffee
{
    public partial class frmTrangChuAdmin : Form
    {
        public static string Username = string.Empty;//Khai bao bien static du lay du lieu username tu form login sang
 
        public frmTrangChuAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xu ly luc load form
        /// </summary>
        private void frmTrangChuAdmin_Load(object sender, EventArgs e)
        {
            //Gan gia tri username len lam title cho form
            this.Text = "Xin chào admin: " + Username;

            //Doi mau nen cho form
            MdiClient ctlMDI;
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException)
                {
                    
                }
            }
        }

        int x = 12, y = 316, a = 1;
        Random ran = new Random();

        /// <summary>
        /// Xu ly cho lable chao mung di chuyen
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += a;
            lblThongBao.Location = new Point(x, y);
            if (x >= 185)
            {
                a = -1;
                //Cho doi mau 
                lblThongBao.ForeColor = Color.FromArgb(ran.Next(10, 200), ran.Next(0, 200), ran.Next(0, 200));
            }
            if (x <= 12)
            {
                a = 1;
                //Cho doi mau 
                lblThongBao.ForeColor = Color.FromArgb(ran.Next(10, 200), ran.Next(0, 200), ran.Next(0, 200));
            }
        }

        /// <summary>
        /// Xu ly luc chon menu muc he thong quan ly
        /// </summary>
        private void ToolStripMenuItemHeThong_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmAdmin));//mo from admin
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form trang chu
        }

        /// <summary>
        /// Mo form admin
        /// </summary>
        private void openFrmAdmin()
        {
            System.Windows.Forms.Application.Run(new frmHeThongQuanLy());
        }


        /// <summary>
        /// Su kien truoc khi dong form
        /// </summary>
        private void frmTrangChuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Sau khi dong form mo form login
        /// </summary>
        private void frmTrangChuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmLogin));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form admin
        }

        /// <summary>
        /// Mo form login
        /// </summary>
        private void openFrmLogin()
        {
            System.Windows.Forms.Application.Run(new frmLogin());
        }

        /// <summary>
        /// Thoat
        /// </summary>
        private void toolStripMenuItemThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Su kien doi mat khau cua admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemThayDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMK_Admin.userNV = Username;//gui du lieu thong tin username sang form doi mat khau
            Thread thread = new Thread(new ThreadStart(openFrmDoiMK));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form 
        }

        //Mo form xem chi tiet hoa don
        private void openFrmDoiMK()
        {
            System.Windows.Forms.Application.Run(new frmDoiMK_Admin());
        }

        /// <summary>
        /// Su kien xem chi tiet cac hoa don
        /// </summary>
        private void toolStripMenuItemXemCTHD_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmXemCTHD));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form 
        }

        //Mo form xem chi tiet hoa don
        private void openFrmXemCTHD()
        {
            System.Windows.Forms.Application.Run(new frmXemChiTietHD_Admin());
        }

        /// <summary>
        /// Mo HDSD phan mem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://drive.google.com/open?id=11xSvnKFLkvQwtAPPoG6KyA2TMwSJliH1");
            }
            catch
            {
                System.Diagnostics.Process.Start("https://drive.google.com/open?id=1c4n82PLNC9sMYycnFb8OhIu99QT99JYc");
            }
        }

        /// <summary>
        ///  Mo form xem thong tin phan mem
        /// </summary>
        private void ThongTinPMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem.username = Username;//gui thong tin username sang form xem thong tin phan mem
            Thread thread = new Thread(new ThreadStart(openFrmThongTinPM));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form admin
        }

        /// <summary>
        /// Mo form login
        /// </summary>
        private void openFrmThongTinPM()
        {
            System.Windows.Forms.Application.Run(new frmThongTinPhanMem());
        }

        //Chay vao he thong ban hang voi vai tro la admin
        private void BanHangStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhanVien.userNV = Username;
            Thread thread = new Thread(new ThreadStart(openFrmNhanVien));//mo from ban hang
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form trang chu
        }

        private void openFrmNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }

        private void HoaDonStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmHoaDon));//mo from hoa don
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form trang chu
        }

        //Mo form xem hoa don
        private void openFrmHoaDon()
        {
            System.Windows.Forms.Application.Run(new frmHoaDon());
        }
    }
}
