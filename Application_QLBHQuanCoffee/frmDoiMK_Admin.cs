using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangCoffee.Models;
using System.Threading;

namespace QuanLyCuaHangCoffee
{
    public partial class frmDoiMK_Admin : Form
    {
        public static string userNV = "";
        public frmDoiMK_Admin()
        {
            InitializeComponent();
        }

        QuanLyUsers qlUsers = new QuanLyUsers();
        /// <summary>
        /// Xu ly nut Save
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMKCu.Text.Trim();
            string mkMoi = txtMKMoi.Text.Trim();
            string mkXacNhan = txtXacNhanMK.Text.Trim();

            Users user = new Users();
            user = qlUsers.getOneUserByUsername(userNV);
            if (user.Password.CompareTo(matKhauCu) != 0)
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (mkMoi.Length < 6 || mkMoi.Length > 20)
            {
                MessageBox.Show("Mật khẩu phải từ 6->20 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (mkXacNhan.CompareTo(mkMoi) != 0)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (user.Password.CompareTo(mkMoi) == 0)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn thay đổi mật khẩu?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                //Update password
                qlUsers.updatePasswordUser(userNV, mkMoi);
                MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Vui lòng đăng nhập lại hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Mo lai form login
                Thread thread = new Thread(new ThreadStart(openFrmLogin));//mo from login
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                System.Windows.Forms.Application.ExitThread(); //dong form doi mat khau
            }
        }

        /// <summary>
        /// Mo form login
        /// </summary>
        private void openFrmLogin()
        {
            System.Windows.Forms.Application.Run(new frmLogin());
        }

        /// <summary>
        /// An mat khau nhap vao
        /// </summary>
        private void btnHide_Click(object sender, EventArgs e)
        {
            txtMKCu.PasswordChar = '*';
            txtMKMoi.PasswordChar = '*';
            txtXacNhanMK.PasswordChar = '*';
        }

        private void frmDoiMK_Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmTrangChuAdmin));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.Exit(); //dong form admin
        }

        //Mo form trang chu
        private void openFrmTrangChuAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }
    }
}
