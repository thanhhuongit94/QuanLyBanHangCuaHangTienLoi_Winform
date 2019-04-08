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
using QuanLyCuaHangCoffee.Models;

namespace QuanLyCuaHangCoffee
{
    public partial class frmDoiMatKhau : Form
    {
        public static string usern = "";
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        QuanLyUsers qlUsers = new QuanLyUsers();
        //Mo form thong tin ca nhan
        private void openFormThongTin()
        {
            System.Windows.Forms.Application.Run(new frmThongTinCaNhan());
        }

        /// <summary>
        /// Su kien xay ra sau khi dong form
        /// </summary>
        private void frmDoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFormThongTin));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        /// <summary>
        /// Xu ly su kien doi mat khau
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMKCu.Text.Trim();
            string matKhauMoi = txtMKMoi.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();
            string s = "";
            string t = "Thông báo";
            if (matKhauCu.Length == 0)
            {
                s = "Bạn chưa nhập mật khẩu cũ";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (matKhauMoi.Length < 6 || matKhauMoi.Length > 20)
            {
                s = "Mật khẩu phải từ 6-> 20 ký tự";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra mat khau cu co nhap trung khop khong
            Users user = qlUsers.getOneUserByUsername(usern);
            if (matKhauCu.CompareTo(user.Password) != 0)
            {
                s = "Mật khẩu cũ không đúng!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra mat khau xac nhan co trung khop voi mat khau moi nhap khong
            if (matKhauMoi.CompareTo(xacNhan) != 0)
            {
                s = "Xác nhận mật khẩu không đúng!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra mat khau moi co bi trung vơi mat khau cu khong
            if (matKhauMoi.CompareTo(matKhauCu) == 0)
            {
                s = "Bạn hãy chọn mật khẩu khác mật khẩu cũ!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                qlUsers.updatePasswordUser(usern, matKhauMoi);//Tien hanh sua du lieu user
                s = "Đổi mật khẩu thành công";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Dang xuat vao bat login lai
                s = "Vui lòng đăng nhập lại";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread thread = new Thread(new ThreadStart(openFormLogin));//mo from Tim kiem
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
            }

        }
        //Mo form login
        private void openFormLogin()
        {
            System.Windows.Forms.Application.Run(new frmLogin());
        }

        //Luc form load
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.Text = "Xin chào: " + usern;
        }

    }
}
