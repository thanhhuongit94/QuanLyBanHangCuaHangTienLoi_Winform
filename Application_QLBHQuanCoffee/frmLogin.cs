using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using QuanLyCuaHangCoffee.Models;
using System.Threading;

namespace QuanLyCuaHangCoffee
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        QuanLyUsers qlUsers = new QuanLyUsers();

        /// <summary>
        /// Xu ly su kien click cho nut Login
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Lay du lieu tu form             
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();
            string thongBao = string.Empty;

            //Kiem tra du lieu duoc nhap chua
            if (username == string.Empty)
            {
                thongBao = "Bạn chưa nhập thông tin tài khoản!";
            }
            if (password == string.Empty)
            {
                thongBao += "\nBạn chưa nhập mật khẩu!";
            }

            if (thongBao != string.Empty)
            {
                MessageBox.Show(thongBao, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int level = 0;
            if (rdAdmin.Checked == true)
            {
                level = 1;
            }
            else
            {
                level = 2;
            }

            //Lay du lieu thong tin cac tai khoan tu csdl         
            Users user = qlUsers.getOneUser(username, password, level);//lay user tu csdl
            if (user != null)
            {
                //Kiem tra xem username / password nhap vao co trung khop khong
                //Admin
                if (level == 1)
                {
                    frmTrangChuAdmin.Username = username;//Gui du lieu username dang dang nhap sang form Trang chu Admin thong qua bien satic
                    Thread thread = new Thread(new ThreadStart(openFrmTrangChuAdmin));//mo from admin
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
                    return;
                }
                //Employee
                if (level == 2)
                {
                    frmNhanVien.userNV = username;//Gui du lieu username dang dang nhap sang form nhanvien
                    Thread thread = new Thread(new ThreadStart(openFrmNhanVien));//mo from nhanvien
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
                    return;
                }
            }
            else
            {
                string s = "Tài khoản hoặc mật khẩu không đúng";
                string t = "Thông báo!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Mo form admin
        /// </summary>
        private void openFrmTrangChuAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }

        /// <summary>
        /// Mo from nhanvien
        /// </summary>
        private void openFrmNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }

        /// <summary>
        /// Su kien xay ra truoc khi dong form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Xu ly su kien cho nut reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            rdNhanVien.Checked = true;
            txtUsername.ResetText();
            txtPass.ResetText();
            txtUsername.Focus();
        }
    }
}
