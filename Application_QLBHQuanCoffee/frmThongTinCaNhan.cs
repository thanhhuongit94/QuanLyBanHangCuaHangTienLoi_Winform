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
using QuanLyCuaHangCoffee.Tools;

namespace QuanLyCuaHangCoffee
{
    public partial class frmThongTinCaNhan : Form
    {
        public static string usernameNV = "";//Nhan du lieu tu form nhan vien gui sang
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        QuanLyNhanVien qlEmployees = new QuanLyNhanVien();
        //Hien thi thong tin
        private void hienThi()
        {
            //Lay du lieu nhan vien de hien thi
            NhanVien nv = qlEmployees.searchEmployeeByUsername(usernameNV);//Tim nhan vien co username dang dang nhap
            this.Text = "Xin chào: " + nv.TenNV;//Hien thi thong tin len tieu de
            //Hien thi len textbox
            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.TenNV;
            if (nv.GioiTinh == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
            txtCMND.Text = nv.CMND1;
            txtDiaChi.Text = nv.DiaChi;
            txtSDT.Text = nv.SDT1;
            txtHeSoLuong.Text = nv.HeSoLuong.ToString();
            txtLuongCB.Text = nv.LuongCB.ToString();
            txtTaiKhoan.Text = nv.Username;
        }

        string cmndBanDau;//Luu so chung minh nhan dan ban dau luc chua sua du lieu
        /// <summary>
        /// Hien thi thong tin len textbox luc form load
        /// </summary>
        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            hienThi();
            cmndBanDau = txtCMND.Text;
        }

        //Mo form nhan vien
        private void openFormDoiMK()
        {
            System.Windows.Forms.Application.Run(new frmDoiMatKhau());
        }
        /// <summary>
        /// Xu ly su kien doi mat khau
        /// </summary>
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            //Gui du lieu sang form doi mat khau
            frmDoiMatKhau.usern = usernameNV;
            Thread thread = new Thread(new ThreadStart(openFormDoiMK));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        //Mo form nhan vien
        private void openFormNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }

        //Su kien xay ra sau khi dong form
        private void frmThongTinCaNhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFormNhanVien));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        /// <summary>
        /// Xu ly su kien nut sua thong tin
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "";
            try
            {
                //Lay du lieu tu form 
                string maNV = txtMaNV.Text;
                string tenNV = txtTenNV.Text.Trim();
                if (tenNV == string.Empty)
                {
                    s = "Tên nhân viên không được bỏ trống!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Kiem tra xem ten nhan vien co ky tu nao khac ky tu chu va khoang trang khong
                if (ChuanHoaChuoi.kiemTraKyTu(tenNV.ToCharArray()) == true)
                {
                    s = "Tên nhân viên không được có số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ChuanHoaChuoi.catBoKhoangTrangGiua(tenNV);//Cat bo khoang trang thua o giua

                string gioiTinh = "";
                if (rdNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nu";
                }
                string soCMND = txtCMND.Text;//lay so cmnd tu form

                //Kiem tra so chung minh nhan dan dung chuan khong
                if (soCMND.Length < 9)
                {
                    s = "Số chứng minh nhân dân phải là 9 chữ số";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Cau lenh truy van 
                NhanVien nv = qlEmployees.searchEmployeeByIDCard(soCMND);//lay nhan vien co so cmnd giong tren textbox tren form

                if (nv != null && soCMND.CompareTo(cmndBanDau) != 0)
                {
                    s = "Số chứng minh nhân dân trùng khớp";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string diaChi = txtDiaChi.Text.Trim();
                if (diaChi == string.Empty)
                {
                    s = "Địa chỉ không được bỏ trống";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ChuanHoaChuoi.catBoKhoangTrangGiua(diaChi);

                string soDT = txtSDT.Text;
                //So dien phai la so co 
                if (soDT.Length != 10 && soDT.Length != 11)
                {
                    s = "Số điện thoại phải 10 hoặc 11 số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Tien hanh update du lieu
                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn sửa đổi thông tin?", "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r != DialogResult.No)
                {
                    int kq = qlEmployees.updateEmployeeExpectLuongCB_HSLuong(maNV, tenNV, gioiTinh, soCMND, diaChi, soDT);//Tien hanh sua du lieu nhan vien
                    if (kq > 0)
                    {
                        s = "Update thành công";
                        t = "Thông báo!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        s = "Số chứng minh nhân dân trùng khớp";
                        t = "Thông báo!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                //hien thi lai
                hienThi();
            }
            catch (FormatException)
            {
                s = "Hệ số lương và lương cơ bản phải là số";
                t = "Thông báo!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
