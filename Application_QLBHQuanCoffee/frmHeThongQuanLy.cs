/*
 * Program: Form He thong quan ly cua admin
 * Created by: 
 *      1. Nguyen Thi Thanh Huong_16211TT0035
 *      2. Vo Ngoc Phu_16211TT0016
 * Date : 27/04/2018
 * Update 1: 01/05/2018
 * Update 2: 06/05/2018
 * Update 3: 14/05/2018
 * Update 4: 22/05/2018
 * 
 */
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
using System.Collections;
using QuanLyCuaHangCoffee.Models;
using QuanLyCuaHangCoffee.Tools;
using System.IO;
using System.Data.SqlClient;

namespace QuanLyCuaHangCoffee
{
    public partial class frmHeThongQuanLy : Form
    {
        public frmHeThongQuanLy()
        {
            InitializeComponent();
        }

        QuanLyUsers qlUsers = new QuanLyUsers();
        QuanLyNhanVien qlEmployees = new QuanLyNhanVien();
        QuanLyLoaiSanPham qlProductTypes = new QuanLyLoaiSanPham();
        QuanLySanPham qlProducts = new QuanLySanPham();

        /// <summary>
        /// Thuc thi luc form duoc load len
        /// </summary>
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            hienThiDSUsers();//Hien thi danh sach user
            hienThiNV();//Hien thi danh sach nhan vien
            hienThiDSLoaiSP();//Hien thi sanh sach cac loai san pham
            hienThiDSSanPham(qlProducts.getAllProducts());//Hien thi danh sach san pham

            //An cac nut sua va xoa
            btnSuaUser.Enabled = false;
            btnXoaUser.Enabled = false;
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnSuaSP.Enabled = false;
            btnXoaSP.Enabled = false;
            btnSuaLoaiSP.Enabled = false;
            btnXoaLoaiSP.Enabled = false;

            //Cai dat mac dinh giá tri cho cac combo box
            cboSapXepNV.SelectedIndex = 0;
            cboSapXepSP.SelectedIndex = 0;
            
            cboSXLoaiSP.SelectedIndex = 0;
            cboTimLoaiSP.SelectedIndex = 0;

            //do du lieu vao comboc ten loai san pham
            cboTenLoaiSP.DisplayMember = "tenLoai";
            cboTenLoaiSP.ValueMember = "maLoai";
            cboTenLoaiSP.DataSource = qlProductTypes.getAllProductTypes();
            cboTenLoaiSP.SelectedIndex = 0;
        }

        /// <summary>
        /// Xay ra truoc khi dong form
        /// </summary>
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Su kien sau khi dong form
        /// </summary>
        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmTrangChuAdmin));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.Exit(); //dong form admin
        }

        /// <summary>
        /// Mo form login
        /// </summary>
        private void openFrmTrangChuAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }

        /*-----------------------------------------------------NHAN VIEN-------------------------------------------------------------------------------*/

        /// <summary>
        /// Do du lieu vao datagirdview
        /// </summary>
        private void hienThiNV()
        {
            ArrayList listEmployee = qlEmployees.getAllDataEmployees();//Lay danh sach nhan vien
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("CMND");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Hệ số lương");
            dt.Columns.Add("Lương cơ bản");
            dt.Columns.Add("Username");

            dgvDSNhanVien.DataSource = dt;

            //Cai dat do rong cho cac cot
            dgvDSNhanVien.Columns[0].Width = 100;
            dgvDSNhanVien.Columns[1].Width = 152;
            dgvDSNhanVien.Columns[2].Width = 100;
            dgvDSNhanVien.Columns[3].Width = 120;
            dgvDSNhanVien.Columns[4].Width = 150;
            dgvDSNhanVien.Columns[5].Width = 100;
            dgvDSNhanVien.Columns[6].Width = 110;
            dgvDSNhanVien.Columns[7].Width = 100;
            dgvDSNhanVien.Columns[8].Width = 100;

            DataRow row;
            foreach (NhanVien nv in listEmployee)
            {
                row = dt.NewRow();
                row["Mã NV"] = nv.MaNV;
                row["Tên nhân viên"] = nv.TenNV;
                row["Giới tính"] = nv.GioiTinh;
                row["CMND"] = nv.CMND1;
                row["Địa chỉ"] = nv.DiaChi;
                row["SĐT"] = nv.SDT1;
                row["Hệ số lương"] = nv.HeSoLuong;
                row["Lương cơ bản"] = nv.LuongCB;
                row["Username"] = nv.Username;
                dt.Rows.Add(row);
            }
            dgvDSNhanVien.AllowUserToAddRows = false;//Loai bo dong du lieu du phia duoi bang
        }

        /// <summary>
        /// Click vao dong nao tren datagirdview thi no se do du lieu dong do len cac textbox, radio button
        /// </summary>
        private void dgvDSNhanVien_Click(object sender, EventArgs e)
        {
            int index = dgvDSNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvDSNhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNV.Text = dgvDSNhanVien.Rows[index].Cells[1].Value.ToString();
            //Hien thi gioi tinh
            string gioiTinh = dgvDSNhanVien.Rows[index].Cells[2].Value.ToString();
            int kq = string.Compare(gioiTinh, "Nam");
            if (kq == 0)
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
            txtCMND.Text = dgvDSNhanVien.Rows[index].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvDSNhanVien.Rows[index].Cells[4].Value.ToString();
            txtSDT.Text = dgvDSNhanVien.Rows[index].Cells[5].Value.ToString();
            txtHeSoLuong.Text = dgvDSNhanVien.Rows[index].Cells[6].Value.ToString();
            txtLuongCB.Text = dgvDSNhanVien.Rows[index].Cells[7].Value.ToString();
            txtUserNV.Text = dgvDSNhanVien.Rows[index].Cells[8].Value.ToString();

            //Mo lai button sua, xoa
            btnSuaNV.Enabled = true;
            btnXoaNV.Enabled = true;
            btnThemNV.Enabled = false;
        }

        /// <summary>
        /// Xu ly nut reset tab nhan vien. 
        /// </summary>
        private void btnResetNV_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            rdNam.Checked = true;
            txtCMND.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtHeSoLuong.ResetText();
            txtLuongCB.ResetText();
            txtUserNV.ResetText();
            txtTenNV.Focus();//Dua con tro ve textbox ten
            hienThiNV();//Hien thi danh sach nhan vien
            //Khoa nut sua va nut xoa
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnThemNV.Enabled = true;
        }

        /// <summary>
        /// Them du lieu nhan vien vao trong database
        /// </summary>
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "";
            try
            {
                //Ma nhan vien duoc tao tu dong theo nguyen tac "NV + so" / so = la du lieu duoc tao tang tu dong tu 01 tro len
                ArrayList listNV = new ArrayList();
                listNV = qlEmployees.getAllDataEmployees();//Lay danh sach nhan vien duoc sap xep tang dan theo ma nhan vien
                //Lay nhan vien co ma so lon nhat(cuoi danh sach)
                string maNV;
                //Neu danh sach nhan vien chua co nhan vien nao thi ma nhan vien se bat dau la "NV01"
                if (listNV.Count == 0)
                {
                    maNV = "NV01";
                }
                else
                {
                    NhanVien nv = (NhanVien)listNV[listNV.Count - 1];//Lay nhan vien cuoi cung trong danh sach da duoc sap xep tang theo maNV
                    int soDuoi = int.Parse(nv.MaNV.Substring(2)) + 1;//Lay so duoi cua ma nhan vien
                    if (soDuoi <= 9)
                    {
                        maNV = "NV0" + soDuoi;
                    }
                    else
                    {
                        maNV = "NV" + soDuoi;
                    }
                }
                //Lay du lieu tu form 
                string tenNV = txtTenNV.Text.Trim();
                if (tenNV == string.Empty)
                {
                    s = "Bạn chưa nhập tên!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //kiem tra ten co so khong
                char [] ten = tenNV.ToCharArray();
                if (ChuanHoaChuoi.kiemTraKyTu(ten) == true)
                {
                    s = "Tên nhân viên không được có số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Xu ly cat bo khoang trang thua trong ten
                tenNV = ChuanHoaChuoi.catBoKhoangTrangGiua(tenNV);

                string gioiTinh = "";
                if (rdNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nu";
                }
                string soCMND = txtCMND.Text.Trim();//Lay so cmnd tu form
                //Kiem tra so chung minh nhan dan dung chuan khong
                if (soCMND.Length < 9)
                {
                    s = "Số chứng minh nhân dân phải là 9 chữ số";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string diaChi = txtDiaChi.Text;

                if (diaChi.Trim().Length == 0)
                {
                    s = "Địa chỉ không được bỏ trống";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Cat bo khoang trang thua trong dia chi
                ChuanHoaChuoi.catBoKhoangTrangGiua(diaChi);

                string SDT = txtSDT.Text.Trim();
                //So dien phai la so co 
                if (SDT.Length != 10 && SDT.Length != 11)
                {
                    s = "Số điện thoại phải 10 hoặc 11 số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double heSoLuong = double.Parse(txtHeSoLuong.Text);
                double luongCB = double.Parse(txtLuongCB.Text);
                if (heSoLuong < 0 || luongCB < 0)
                {
                    s = "Hệ số lương và lương cơ bản phải lớn hơn 0!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Username duoc tao tu dong bang cach tenNV bo dau  + ma nhan vien-> chuyen ve chu thuong
                int index = tenNV.Trim().LastIndexOf(' ');//Tim vi tri cuoi cung xuat hien dau ' '
                string usernameNV = (new Unicode().boDauTiengViet(tenNV.Substring(index + 1)) + maNV).ToLower();

                //Them du lieu vao danh sach users, username duoc tao tu dong, password tao tu dong la day so : 123456 , level mac dinh = 2
                qlUsers.insertDataUser(usernameNV, "123456", 2);

                //Tien hanh them du lieu vao du lieu nhan vien
                int kq = qlEmployees.insertNewEmployee(maNV, tenNV, gioiTinh, soCMND, diaChi, SDT, heSoLuong, luongCB, usernameNV);
                if (kq > 0)
                {
                    s = "Thêm dữ liệu thành công!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    hienThiDSUsers();//Hien thi danh sach Users len datagirdview
                    hienThiNV();//Hien thi danh sach Nhan vien len datagirdview
                }
                else
                {
                    s = "Thêm dữ liệu thất bại! Số chứng minh nhân dân đã tồn tại";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Reset lai cac textbox
                txtTenNV.ResetText();
                txtCMND.ResetText();
                txtDiaChi.ResetText();
                txtSDT.ResetText();
                txtHeSoLuong.ResetText();
                txtLuongCB.ResetText();
                rdNam.Checked = true;
            }
            catch (FormatException)
            {
                s = "Hệ số lương và lương cơ bản phải là số";
                t = "Thông báo!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Sua du lieu nhan vien
        /// </summary>
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "Thông báo";
            int index = dgvDSNhanVien.CurrentRow.Index;//index vi tri dong duoc chon
            if (index < 0)
            {
                s = "Bạn chưa chọn dữ liệu để sửa đổi!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //Lay du lieu tu form 
                string maNV = txtMaNV.Text;
                string tenNV = txtTenNV.Text.Trim();
                if (tenNV == string.Empty)
                {
                    s = "Bạn chưa nhập tên!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //kiem tra ten co ky tu dac biet hoac co so khong
                char[] ten = tenNV.ToCharArray();
                if (ChuanHoaChuoi.kiemTraKyTu(ten) == true)
                {
                    s = "Tên nhân viên không được có số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Xu ly cat bo khoang trang thua trong ten
                tenNV = ChuanHoaChuoi.catBoKhoangTrangGiua(tenNV);

                string gioiTinh = "";
                if (rdNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nu";
                }
                string soCMND = txtCMND.Text.Trim();//lay so cmnd tu form
                //Kiem tra cmnd co bi trung khong
                if (qlEmployees.searchEmployeeByIDCard(soCMND) != null && soCMND.CompareTo(dgvDSNhanVien.Rows[index].Cells[3].Value.ToString()) != 0)//lay nhan vien co so cmnd nhu da nhap
                {
                    s = "Số chứng minh nhân dân trùng khớp";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (soCMND.Trim().Length < 9)
                {
                    s = "Số chứng minh nhân dân phải là 9 chữ số";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string diaChi = txtDiaChi.Text.Trim();
                if (diaChi.Length == 0)
                {
                    s = "Địa chỉ không được bỏ trống";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Cat bo khoang trang thua trong dia chi
                ChuanHoaChuoi.catBoKhoangTrangGiua(diaChi);

                string soDT = txtSDT.Text;
                //So dien phai la so co hop le khong
                if (soDT.Length != 10 && soDT.Length != 11)
                {
                    s = "Số điện thoại phải 10 hoặc 11 số!";
                    t = "Thông báo!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                double heSoLuong = double.Parse(txtHeSoLuong.Text);
                double luongCB = double.Parse(txtLuongCB.Text);

                //Kiem tra he so luong hop le khong
                if (heSoLuong < 0 || luongCB < 0)
                {
                    s = "Hệ số lương và lương cơ bản phải lớn hơn 0!";
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
                    //Tien hanh sua doi du lieu
                    int kq = qlEmployees.updateEmployee(maNV, tenNV, gioiTinh, soCMND, diaChi, soDT, heSoLuong, luongCB);
                    if (kq > 0)
                    {
                        hienThiNV();//hien thi lai danh sach
                        s = "Update dữ liệu thành công!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        s = "Update dữ liệu thất bại!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //Reset lai cac textbox
                    txtMaNV.ResetText();
                    txtUserNV.ResetText();
                    txtTenNV.ResetText();
                    txtCMND.ResetText();
                    txtDiaChi.ResetText();
                    txtSDT.ResetText();
                    txtHeSoLuong.ResetText();
                    txtLuongCB.ResetText();
                    rdNam.Checked = true;
                    //An nut sua va nut xoa
                    btnSuaNV.Enabled = false;
                    btnXoaNV.Enabled = false;
                    btnThemNV.Enabled = true;
                }
            }
            catch (FormatException)
            {
                s = "Hệ số lương và lương cơ bản phải là số";
                t = "Thông báo!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Xoa du lieu nhan vien duoc chon
        /// </summary>
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;// ma dong duoc chon
            string username = txtUserNV.Text;
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                //Tim nhung hoa don ma nhan vien dinh xoa da lap
                ArrayList listHD = new QuanLyHoaDon().searchInvoiceByEmployee_id(maNV);
                if(listHD.Count > 0)
                {
                    MessageBox.Show("Tồn tại hóa đơn do nhân viên này lập! Sau khi xóa dữ liệu các hóa đơn thuộc nhân viên này sẽ chuyển về cho tài khoản Admin", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Xac nhan 
                    r = MessageBox.Show("Bạn có muốn tiếp tục xóa dữ liệu?", "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        luuTruHoaDon();//Luu tru hoa don khi can thiet ra file truoc khi xoa
                        luuTruChiTietHoaDon(); //Luu tru file chi tiet cua cac hoa don
                        
                        MessageBox.Show("Đã lưu trữ một file hóa đơn và chi tiết hóa đơn kèm theo thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Chuyen thong tin ve tai khoan admin
                        //Tim hoa don cua nhan vien chuan bi xoa
                        QuanLyHoaDon qlInvoices = new QuanLyHoaDon();
                        ArrayList listInvoice = qlInvoices.searchInvoiceByEmployee_id(maNV);
                        //Ghi chu
                        string note = "Hóa đơn thuộc nhân viên:" + maNV + " " + txtTenNV.Text; 
                        //Tien hanh chuyen tai khoan
                        foreach (HoaDon hd in listInvoice)
                        {
                            qlInvoices.updateInvoice(hd.MaHD, "Admin", hd.TongTien, hd.NgayLapHD, note);
                        }

                        //Xoa du lieu nhan vien duoc chon
                        if (qlEmployees.deleteEmployee(maNV) > 0)
                        {
                            hienThiNV();//Hien thi lai danh sach
                            MessageBox.Show("Xóa dữ liệu nhân viên và các chuyển đổi các dữ liệu liên quan thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Dong thoi tien hanh xoa tai khoan dang nhap cua nhan vien duoc xoa khoi danh sach
                            qlUsers.deleteUser(username);
                            hienThiDSUsers();//Hien thi lai danh sach
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã không chọn xóa dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //Xoa du lieu nhan vien duoc chon
                if (qlEmployees.deleteEmployee(maNV) > 0)
                {
                    hienThiNV();//Hien thi lai danh sach
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Dong thoi tien hanh xoa tai khoan dang nhap cua nhan vien duoc xoa khoi danh sach
                    qlUsers.deleteUser(username);
                    hienThiDSUsers();//Hien thi lai danh sach
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Reset lai cac textbox
                txtMaNV.ResetText();
                txtUserNV.ResetText();
                txtTenNV.ResetText();
                txtCMND.ResetText();
                txtDiaChi.ResetText();
                txtSDT.ResetText();
                txtHeSoLuong.ResetText();
                txtLuongCB.ResetText();
                rdNam.Checked = true;
                btnSuaNV.Enabled = false;
                btnXoaNV.Enabled = false;
                btnThemNV.Enabled = true;
            }
        }

        //Xuat danh sach hoa don da ban(luu tru de khi thuc hien xoa du lieu thi van con danh sach bang file de xem)
        private void luuTruHoaDon()
        {

            //Lay danh sach de in
            ArrayList listHD = new QuanLyHoaDon().getAllDataInvoice();
            try
            {
                string fileName = "HoaDon.txt";
                FileStream output = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);

                writeFile.WriteLine("Ngày: " + DateTime.Now);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH HÓA ĐƠN");
                writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}", "Mã HD", "Mã NV", "Tổng tiền", "Ngày lập HD", "Ghi chú");
                writeFile.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                foreach (HoaDon hd in listHD)
                {
                    writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}", hd.MaHD, hd.MaNV, hd.TongTien, hd.NgayLapHD, hd.GhiChu);
                }
                writeFile.Close();
                output.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        //Xuat danh sach chi tiet hoa don da ban(luu tru de khi thuc hien xoa du lieu thi van con danh sach bang file de xem)
        private void luuTruChiTietHoaDon()
        {

            //Lay danh sach chi tiet hoa don de in
            ArrayList listCTHD = new QuanLyChiTietHoaDon().getAllDataInvoiceDetails();
            try
            {
                string fileName = "ChiTietHoaDon.txt";
                FileStream output = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);

                writeFile.WriteLine("Ngày: " + DateTime.Now);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH CHI TIẾT CÁC HÓA ĐƠN");
                writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Mã HD", "Mã SP", "Đơn giá", "Số lượng", "Thành tiền");
                writeFile.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                foreach (ChiTietHoaDon cthd in listCTHD)
                {
                    writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", cthd.MaHD, cthd.MaSP, cthd.DonGia, cthd.NSLuong, cthd.ThanhTien);
                }
                writeFile.Close();
                output.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Xu ly nut tim kiem/ Mo form moi
        /// </summary>
        private void btnTimNV_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openTimKiem));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        /// <summary>
        /// Mo form tim kiem de thuc hien cac thao tac
        /// </summary>
        private void openTimKiem()
        {
            System.Windows.Forms.Application.Run(new frmTimKiemNhanVien());
        }

        /// <summary>
        /// Sap xep danh sach nhan vien
        /// </summary>
        private void btnSapXepNV_Click(object sender, EventArgs e)
        {
            //Kiem tra nguoi dung chon tieu chi sap xep chua
            if (cboSapXepNV.Text.CompareTo("--Select--") == 0)
            {
                MessageBox.Show("Bạn chưa chọn tiêu chí sắp xếp!", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            //Nguoi dung chon tieu chi sap xep theo ma nhan vien
            if (cboSapXepNV.Text.CompareTo("Mã nhân viên") == 0)
            {
                hienThiNV();
            }
            else
            {
                dgvDSNhanVien.DataSource = "";
                //Hien thi du lieu
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Tên nhân viên");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("CMND");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("SĐT");
                dt.Columns.Add("Hệ số lương");
                dt.Columns.Add("Lương cơ bản");
                dt.Columns.Add("Username");

                dgvDSNhanVien.DataSource = dt;

                //Cai dat do rong cho cac cot
                dgvDSNhanVien.Columns[0].Width = 100;
                dgvDSNhanVien.Columns[1].Width = 152;
                dgvDSNhanVien.Columns[2].Width = 100;
                dgvDSNhanVien.Columns[3].Width = 120;
                dgvDSNhanVien.Columns[4].Width = 150;
                dgvDSNhanVien.Columns[5].Width = 100;
                dgvDSNhanVien.Columns[6].Width = 110;
                dgvDSNhanVien.Columns[7].Width = 100;
                dgvDSNhanVien.Columns[8].Width = 100;
                
                DataRow row;
                ArrayList listEmployee = qlEmployees.sortASCByName();
                foreach (NhanVien nv in listEmployee)
                {
                    row = dt.NewRow();
                    row["Mã NV"] = nv.MaNV;
                    row["Tên nhân viên"] = nv.TenNV;
                    row["Giới tính"] = nv.GioiTinh;
                    row["CMND"] = nv.CMND1;
                    row["Địa chỉ"] = nv.DiaChi;
                    row["SĐT"] = nv.SDT1;
                    row["Hệ số lương"] = nv.HeSoLuong;
                    row["Lương cơ bản"] = nv.LuongCB;
                    row["Username"] = nv.Username;
                    dt.Rows.Add(row);
                }
                dgvDSNhanVien.AllowUserToAddRows = false;//Loai bo dong du lieu du phia duoi bang
            }
        }

        /// <summary>
        /// In danh sach ra file
        /// </summary>
        private void btnXuatDSNV_Click(object sender, EventArgs e)
        {
            //Lay danh sach de in
            ArrayList listNV = qlEmployees.getAllDataEmployees();
            try
            {
                string fileName = "NhanVien.txt";
                FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH NHÂN VIÊN");
                foreach (NhanVien nv in listNV)
                {
                    writeFile.WriteLine("{0}, {1},   {2},   {3},   {4},   {5},   {6},   {7},   {8}", nv.MaNV, nv.TenNV, nv.GioiTinh, nv.CMND1, nv.SDT1, nv.DiaChi, nv.HeSoLuong, nv.LuongCB, nv.Username);
                }
                MessageBox.Show("Xuất danh sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writeFile.Close();
                output.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Xu ly context menu/ nut delete
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoaNV_Click(this, e);
        }

        /// <summary>
        /// Xu ly su kien chua nhap du lieu cho textbox ten nhan vien
        /// </summary>
        private void txtTenNV_Leave(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtTenNV, "Bạn phải nhập tên nhân viên!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /// <summary>
        /// Xu ly su kien roi di ma chua nhap CMND
        /// </summary>
        private void txtCMND_Leave(object sender, EventArgs e)
        {
            if (txtCMND.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtCMND, "Bạn phải nhập chứng minh nhân dân!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /// <summary>
        /// Xu ly su kien roi di ma chua nhap dia chi
        /// </summary>
        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtDiaChi, "Bạn phải nhập địa chỉ!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /// <summary>
        /// Xu ly su kien roi di ma chua nhap he so luong
        /// </summary>
        private void txtHeSoLuong_Leave(object sender, EventArgs e)
        {
            if (txtHeSoLuong.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtHeSoLuong, "Bạn phải nhập hệ số lương!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /// <summary>
        /// Xu ly su kien roi di ma chua nhap luong co ban
        /// </summary>
        private void txtLuongCB_Leave(object sender, EventArgs e)
        {
            if (txtLuongCB.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtLuongCB, "Bạn phải nhập lương cơ bản!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /*-----------------------------------------------------USERS--------------------------------------------------*/
        /// <summary>
        /// Hien thi danh sach user len datagirdview
        /// </summary>
        private void hienThiDSUsers()
        {
            ArrayList listUser = qlUsers.getAllUsers();
            //Gan tung dong du lieu len datagirdview theo y muon
            //Tao Tiêu đề cho các column
            DataTable dt = new DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Level");
            dgvDSUser.DataSource = dt;
            //Cai dat do rong cho cac cot
            dgvDSUser.Columns[0].Width = 300;
            dgvDSUser.Columns[1].Width = 165;
            dgvDSUser.Columns[2].Width = 220;

            DataRow row;
            foreach (Users user in listUser)
            {
                row = dt.NewRow();
                row["Username"] = user.Username;
                row["Password"] = user.Password;
                if (user.LevelUser == 1)
                {
                    row["Level"] = "Admin";
                }
                else
                {
                    row["Level"] = "Nhân viên";
                }
                dt.Rows.Add(row);
            }
            dgvDSUser.AllowUserToAddRows = false;//Loai bo dong du lieu du phia duoi bang
        }

        /// <summary>
        /// Su kien click vao 1 dong tren datagirdview dsUsers thi se do du lieu len textbox tuong ung
        /// </summary>
        private void dgvDSUser_Click(object sender, EventArgs e)
        {
            int index = dgvDSUser.CurrentRow.Index;//Lay vi tri dong duoc chon
            txtUsername.Text = dgvDSUser.Rows[index].Cells[0].Value.ToString();
            txtPassword.Text = dgvDSUser.Rows[index].Cells[1].Value.ToString();
            btnSuaUser.Enabled = true;//Hien nut sua
            btnXoaUser.Enabled = true;//Hien nu xoa
            btnThemUser.Enabled = false;
            txtUsername.Enabled = false;
        }

        /// <summary>
        /// Xu ly nut reset
        /// </summary>
        private void btnResetUser_Click(object sender, EventArgs e)
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtXacNhanMK.ResetText();
            hienThiDSUsers();//Hien thi lai danh sach user
            btnSuaUser.Enabled = false;
            btnXoaUser.Enabled = false;
            btnThemUser.Enabled = true;
            txtThongTinCTUser.Text = "Nhập username cần tìm...";
            txtUsername.Enabled = true;
        }

        //Xu ly su kien nhap username 
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            char[] ten = txtUsername.Text.ToCharArray();
            for (int i = 0; i < ten.Length; i++)
            {
                if (ten[i] == ' ')
                {
                    MessageBox.Show("Username không được có khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        //Xu ly su kien nhap password
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            char[] pass = txtPassword.Text.ToCharArray();
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] == ' ')
                {
                    MessageBox.Show("Password không được có khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        /// <summary>
        /// Xu ly nut them user moi vao csdl
        /// </summary>
        private void btnThemUser_Click(object sender, EventArgs e)
        {
            //Lay du lieu tu form
            string username = txtUsername.Text.Trim().ToLower();
            string pass = txtPassword.Text.Trim(); ;
            string confirmPass = txtXacNhanMK.Text.Trim();

            //Kiem tra xem ng dung nhap du lieu username hay chua
            string s = "";
            string t = "Thông báo";
            if (username.Length < 5 || username.Length > 50)
            {
                s = "Username tối thiểu phải 5 ký tự!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra xem username co ton tai trong danh sach chua
            Users user = qlUsers.getOneUserByUsername(username);
            if (user != null)
            {
                s = "Username đã tồn tại trong ứng dụng";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (pass.Length < 6 || pass.Length > 20)
            {
                s = "Password phải từ 6-> 20 ký tự";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (confirmPass.CompareTo(pass) != 0)
            {
                s = "Xác nhận password không trùng khớp";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Them du user moi vao danh sach user
            int kq = qlUsers.insertDataUser(username, pass, 2);//mac dinh user duoc them vao la nhan vien level = 2
            if (kq > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!");
                hienThiDSUsers();//Hien thi lai danh sach user
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại!");
            }

            //Reset cac textbox
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtXacNhanMK.ResetText();
        }

        /// <summary>
        /// Xu ly su kien roi khoi textbox ma chua nhap du lieu username
        /// </summary>
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0)
            {
                this.errorProviderNV.SetError(txtUsername, "Bạn phải nhập username!");
            }
            else
            {
                this.errorProviderNV.Clear();
            }
        }

        /// <summary>
        /// Xu ly su kien nut sua du lieu cho User/ chi duoc doi mat khau
        /// </summary>
        private void btnSuaUser_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "Thông báo";
            int index = dgvDSUser.CurrentRow.Index;//Vi tri dong du lieu duoc click
            if (index < 0)
            {
                s = "Bạn chưa chọn dữ liệu để xóa";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Lay du lieu de update
            string username = dgvDSUser.Rows[index].Cells[0].Value.ToString();
            string passCu = dgvDSUser.Rows[index].Cells[1].Value.ToString();
            string pass = txtPassword.Text.Trim();
            string confirmPass = txtXacNhanMK.Text;

            //Kiem tra xem nguoi dung nhap password chua
            if (pass.Length == 0)
            {
                s = "Bạn chưa nhập passowrd mới";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra xem password co it nhat 6 ky tu khong
            if (pass.Length < 6 || pass.Length > 20)
            {
                s = "Password phải từ 6-> 20 ký tự";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra corfimPass co trung khop voi pass khong
            if (pass != confirmPass)
            {
                s = "Xác nhận lại mật khẩu sai!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra mat khau moi co trung mat khau cu khong
            if (passCu.CompareTo(pass) == 0)
            {
                s = "Mật khẩu mới phải khác mật khẩu cũ!";
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
                if (qlUsers.updatePasswordUser(username, pass) > 0)
                {
                    s = "Update dữ liệu thành công!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDSUsers();//Hien thi lai du lieu
                }
                else
                {
                    s = "Update dữ liệu thất bại!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Reset cac textbox
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtXacNhanMK.ResetText();
            //An nut sua , xoa
            btnSuaUser.Enabled = false;
            btnXoaUser.Enabled = false;
            btnThemUser.Enabled = true;
            txtUsername.Enabled = true;
        }

        /// <summary>
        /// Xu ly su kien xoa du lieu user
        /// </summary>
        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            int index = dgvDSUser.CurrentRow.Index;
            string username = dgvDSUser.Rows[index].Cells[0].Value.ToString();
            if (username == "huongntt")
            {
                MessageBox.Show("Không được phép xóa tài khoản admin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Tien hanh xoa du lieu
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn xoá thông tin?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                if (qlUsers.deleteUser(username) > 0)
                {
                    string s = "Xóa dữ liệu thành công!";
                    MessageBox.Show(s, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDSUsers();//Hien thi lai danh sach user
                }
                else
                {
                    string s = "Xóa dữ liệu thất bại!Bạn không được phép xóa tài khoản của nhân viên đang tồn tại trong danh sách";
                    MessageBox.Show(s, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Reset cac textbox
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtXacNhanMK.ResetText();
            //An nut sua va nut xoa
            btnSuaUser.Enabled = false;
            btnXoaUser.Enabled = false;
            btnThemUser.Enabled = true;
            txtUsername.Enabled = true;
        }

        /// <summary>
        /// Xu ly su kien cho contextMenu trong dgvUsers
        /// </summary>
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnXoaUser_Click(this, e);
        }


        /// <summary>
        /// Xu lys su kien nuts tim kiem user
        /// </summary>
        private void btnTimUser_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "Thông báo";
            if (txtThongTinCTUser.Text.Trim() == "Nhập username cần tìm...")
            {
                s = "Bạn chưa nhập thông tin cần tìm kiếm";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Users user = qlUsers.getOneUserByUsername(txtThongTinCTUser.Text);
            if (user == null)
            {
                s = "Không tồn tại username bạn đang cần tìm";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Hien thi len datagirdview
            //Gan tung dong du lieu len datagirdview theo y muon
            //Tao Tiêu đề cho các col
            DataTable dt = new DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Level");
            dgvDSUser.DataSource = dt;
            //Cai dat do rong cho cac cot
            dgvDSUser.Columns[0].Width = 300;
            dgvDSUser.Columns[1].Width = 165;
            dgvDSUser.Columns[2].Width = 220;

            DataRow row;
            row = dt.NewRow();
            row["Username"] = user.Username;
            row["Password"] = user.Password;
            if (user.LevelUser == 1)
            {
                row["Level"] = "Admin";
            }
            else
            {
                row["Level"] = "Nhân viên";
            }
            dt.Rows.Add(row);
        }

        private void txtThongTinCTUser_MouseClick(object sender, MouseEventArgs e)
        {
            txtThongTinCTUser.ResetText();
        }


        /// <summary>
        /// Xu ly su kien cho nut xuat danh sach user 
        /// </summary>
        private void btnXuatDSUser_Click(object sender, EventArgs e)
        {
            //Lay danh sach de in
            ArrayList listUser = qlUsers.getAllUsers();
            try
            {
                string fileName = "Users.txt";
                FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH TÀI KHOẢN");
                writeFile.WriteLine("Username\t\tPassword\t\tLevel");
        
                string level = "";
                foreach (Users user in listUser)
                {
                    if (user.LevelUser == 1)
                    {
                        level = "Admin";
                    }
                    else
                    {
                        level = "Nhân viên";
                    }
                    writeFile.WriteLine("{0}, {1}, {2}", user.Username, user.Password, level);
                }
                MessageBox.Show("Xuất danh sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writeFile.Close();
                output.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------------------------LOAI SAN PHAM--------------------------------------------------------------
        /// <summary>
        /// Hien thi danh sach loai san pham len datagirdview
        /// </summary>
        private void hienThiDSLoaiSP()
        {
            dgvDSLoaiSanPham.DataSource = qlProductTypes.getAllProductTypes();
        }

        /// <summary>
        /// Click vao dong nao tren datagirdview thi no se do du lieu dong do len cac textbox
        /// </summary>
        private void dgvDSLoaiSanPham_Click(object sender, EventArgs e)
        {
            int index = dgvDSLoaiSanPham.CurrentRow.Index;
            txtMaLoai.Text = dgvDSLoaiSanPham.Rows[index].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvDSLoaiSanPham.Rows[index].Cells[1].Value.ToString();

            //Mo lai nut sua, xoa
            btnSuaLoaiSP.Enabled = true;
            btnXoaLoaiSP.Enabled = true;
            btnThemLoaiSP.Enabled = false;
            txtMaLoai.Enabled = false;
        }

        /// <summary>
        /// Xu ly su kien nut reset
        /// </summary>
        private void btnResetLoaiSP_Click(object sender, EventArgs e)
        {
            txtMaLoai.ResetText();
            txtTenLoai.ResetText();
            hienThiDSLoaiSP();//Hien thi danh sach
            btnSuaLoaiSP.Enabled = false;
            btnXoaLoaiSP.Enabled = false;
            btnThemLoaiSP.Enabled = true;
            txtMaLoai.Enabled = true;
        }

        /// <summary>
        /// Them loai san pham moi
        /// </summary>
        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            //Lay du lieu can them tu textbox
            string maLoaiSP = txtMaLoai.Text.Trim();
            string tenLoaiSP = txtTenLoai.Text.Trim();

            //Kiem tra xem ma loai san pham da ton tai chua
            string s = "";
            string t = "Thông báo";

            if (maLoaiSP.Length == 0)
            {
                s = "Mã loại sản phẩm không được bỏ trống";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Cat bo khoang trang thua o giua chuoi
            ChuanHoaChuoi.catBoKhoangTrangGiua(maLoaiSP);
            //Kiem tra ma loai san pham ton tai chua
            LoaiSanPham lsp = qlProductTypes.searchProductTypeByID(maLoaiSP);
            if (lsp != null)
            {
                s = "Mã loại sản phẩm đã tồn tại";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Kiem tra ten loai san pham duoc nhap chua
            if (tenLoaiSP.Length == 0)
            {
                s = "Tên loại sản phẩm không được bỏ trống";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Cat bo khoang trang thua
            ChuanHoaChuoi.catBoKhoangTrangGiua(tenLoaiSP);

            //Kiem tra ten loai san pham da ton tai chua(ten loai san pham la duy nhat)
            lsp = qlProductTypes.searchLoaiSPByName(tenLoaiSP);
            if (lsp != null)
            {
                s = "Tên loại sản phẩm đã tồn tại";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Them du lieu moi vao danh sach loai san pham
            if (qlProductTypes.insertNewProductType(maLoaiSP, tenLoaiSP) > 0)
            {
                s = "Thêm dữ liệu thành công!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDSLoaiSP();//hien thi lai danh sach
            }
            else
            {
                s = "Thêm dữ liệu thất bại!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Do du lieu vao combo box ten loai san pham tren tab quan ly san pham
            //Do du lieu
            cboTenLoaiSP.DataSource = qlProductTypes.getAllProductTypes();
            cboTenLoaiSP.DisplayMember = "tenLoai";
            cboTenLoaiSP.ValueMember = "maLoai";
            cboTenLoaiSP.SelectedIndex = 0;//cai dat mac dinh cho combobox tab quan ly san pham
            txtMaLoai.ResetText();
            txtTenLoai.ResetText();
        }

        /// <summary>
        /// Sua thong tin loai san pham nao do
        /// </summary>
        private void btnSuaLoaiSP_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "Thông báo";
            //Lay du lieu can them tu textbox
            string maLoaiSP = txtMaLoai.Text.Trim();
            string tenLoaiSP = txtTenLoai.Text.Trim();

            if (maLoaiSP == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm cần sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tenLoaiSP.Length == 0)
            {
                s = "Tên loại sản phẩm không được bỏ trống";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Cat bo khoang trang thua
            ChuanHoaChuoi.catBoKhoangTrangGiua(tenLoaiSP);

            int index = dgvDSLoaiSanPham.CurrentRow.Index;

            //Kiem tra ten loai san pham da ton tai chua(ten loai san pham la duy nhat)
             LoaiSanPham lsp = qlProductTypes.searchLoaiSPByName(tenLoaiSP);
            //Kiem tra san pham do co trong csdl chua, va ten loai san pham trong textbox khac voi ten a loai san pham cua dong duoc chon de sua trong datagird 
            if (lsp != null && tenLoaiSP.ToLower().CompareTo(dgvDSLoaiSanPham.Rows[index].Cells[1].Value.ToString().ToLower()) != 0)
            {
                s = "Tên loại sản phẩm đã tồn tại";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Tien hanh sua du lieu
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn sửa đổi thông tin?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                if (qlProductTypes.updateProductType(maLoaiSP, tenLoaiSP) > 0)
                {
                    s = "Sửa dữ liệu thành công!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDSLoaiSP();//Hien thi lai danh sach loai san pham
                    hienThiDSSanPham(qlProducts.getAllProducts());//Hien thi lai danh sach san pham
                    //Do du lieu vao combo box ten loai san pham tren tab quan ly san pham
                    //Do du lieu
                    cboTenLoaiSP.DataSource = qlProductTypes.getAllProductTypes();
                    cboTenLoaiSP.DisplayMember = "tenLoai";
                    cboTenLoaiSP.ValueMember = "maLoai";
                    cboTenLoaiSP.SelectedIndex = 0;
                }
                else
                {
                    s = "Sửa dữ liệu thất bại! Bạn chỉ được update tên loại sản phẩm";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMaLoai.ResetText();
                txtTenLoai.ResetText();
                btnSuaLoaiSP.Enabled = false;
                btnXoaLoaiSP.Enabled = false;
                btnThemLoaiSP.Enabled = true;
                txtMaLoai.Enabled = true;
            }
        }

        /// <summary>
        /// Xu ly nut xoa du lieu trong loai san pham
        /// </summary>
        private void btnXoaLoaiSP_Click(object sender, EventArgs e)
        {
                string maLoai = txtMaLoai.Text;
                if (maLoai.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã sản phẩm cần sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin?", "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r != DialogResult.No)
                {
                    if (qlProductTypes.deleteProductType(maLoai) < 0)
                    {
                        MessageBox.Show("Xóa loại sản phẩm !Tồn tại sản phẩm thuộc loại sản phẩm này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        hienThiDSLoaiSP();//Hien thi lai danh sach loai san pham
                        hienThiDSSanPham(qlProducts.getAllProducts());//Hien thi lai danh sach san pham
                        //Do du lieu
                        cboTenLoaiSP.DataSource = qlProductTypes.getAllProductTypes();
                        cboTenLoaiSP.DisplayMember = "tenLoai";
                        cboTenLoaiSP.ValueMember = "maLoai";
                        cboTenLoaiSP.SelectedIndex = 0;
                    }
                }
                txtMaLoai.ResetText();
                txtTenLoai.ResetText();
                btnSuaLoaiSP.Enabled = false;
                btnXoaLoaiSP.Enabled = false;
                btnThemLoaiSP.Enabled = true;
                txtMaLoai.Enabled = true;
        }

        /// <summary>
        /// Tim kiem san pham theo tieu chi 
        /// </summary>
        private void btnTimLoaiSP_Click(object sender, EventArgs e)
        {
            string thongTin = txtTimLoaiSP.Text;
            string s = "";
            string t = "Thông báo";
            ArrayList list = new ArrayList();
            if (txtTimLoaiSP.Text == "Nhập thông tin cần tìm...")
            {
                s = "Bạn chưa nhập thông tin cần tìm";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboTimLoaiSP.SelectedItem.ToString().CompareTo("Mã loại") == 0)
            {
                list.Add(qlProductTypes.searchProductTypeByID(thongTin));
            }
            else
            {
                list.Add(qlProductTypes.searchLoaiSPByName(thongTin));
            }
            //Hien thi thong tin tim duoc len datagird
            dgvDSLoaiSanPham.DataSource = list;
        }

        /// <summary>
        /// Su kien click vao o tim kiem
        /// </summary>
        private void txtTimLoaiSP_Click(object sender, EventArgs e)
        {
            if (txtTimLoaiSP.Text == "Nhập thông tin cần tìm...")
            {
                txtTimLoaiSP.ResetText();
            }
        }

        /// <summary>
        /// Xu ly nut sap xep danh sach loai san pham theo tieu chi
        /// </summary>
        private void btnSapXepLoaiSP_Click(object sender, EventArgs e)
        {
            ArrayList listSX = new ArrayList();
            if (cboSXLoaiSP.SelectedItem.ToString().CompareTo("Mã loại") == 0)
            {
                listSX = qlProductTypes.sortProductTypeByProductType_id();
            }
            else
            {
                listSX = qlProductTypes.sortProductTypeByProductType_name();
            }
            //hien thi danh sach da sap xep
            dgvDSLoaiSanPham.DataSource = listSX;
        }

        /// <summary>
        /// Xuat danh sach loai san pham
        /// </summary>
        private void btnXuatDSLoaiSP_Click(object sender, EventArgs e)
        {
            ArrayList listLoaiSP = qlProductTypes.getAllProductTypes();
            string fileName = "LoaiSanPham.txt";
            FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writeFile = new StreamWriter(output);
            writeFile.WriteLine("\t\t\t\tDANH SÁCH LOẠI SẢN PHẨM");
            writeFile.WriteLine("\t\tMã loại\t\tTên loại sản phẩm");
            foreach (LoaiSanPham lsp in listLoaiSP)
            {
                writeFile.WriteLine("{0}, {1}", lsp.MaLoai, lsp.TenLoai);
            }
            MessageBox.Show("Xuất danh sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            writeFile.Close();
            output.Close();
        }

        /// <summary>
        /// Xu ly su kien click cho contextmenu
        /// </summary>
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnXoaLoaiSP_Click(this, e);
        }
        //--------------------------------------------------------SAN PHAM---------------------------------------------
        /// <summary>
        /// Hien thi danh sach san pham len datagirdview
        /// </summary>
        private void hienThiDSSanPham(ArrayList listSP)
        {
            //Gan tung dong du lieu len datagirdview theo y muon
            //Tao Tiêu đề cho các col
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sản phẩm");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Đơn giá");
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Tình trạng");
            dt.Columns.Add("Loại sản phẩm");
            dgvDSSanPham.DataSource = dt;
            //Cai dat do rong cho cac cot
            dgvDSSanPham.Columns[0].Width = 150;
            dgvDSSanPham.Columns[1].Width = 250;
            dgvDSSanPham.Columns[2].Width = 150;
            dgvDSSanPham.Columns[3].Width = 130;
            dgvDSSanPham.Columns[4].Width = 150;
            dgvDSSanPham.Columns[5].Width = 250;
            DataRow row;
            foreach (SanPham sp in listSP)
            {
                row = dt.NewRow();
                row["Mã sản phẩm"] = sp.MaSP;
                row["Tên sản phẩm"] = sp.TenSP;
                row["Đơn giá"] = sp.DonGia;
                row["Số lượng"] = sp.NSLuong;
                row["Tình trạng"] = sp.TinhTrang;

                //Lay ten loai san pham
                foreach (LoaiSanPham lsp in qlProductTypes.getAllProductTypes())
                {
                    if (sp.MaLoaiSP.CompareTo(lsp.MaLoai) == 0)
                    {
                        row["Loại sản phẩm"] = lsp.TenLoai;
                    }
                }
                dt.Rows.Add(row);
                dgvDSSanPham.AllowUserToAddRows = false;//Loai bo dong du lieu du phia duoi bang
            }
        }

        /// <summary>
        /// Su kien click vao 1 dong tren datagird view
        /// </summary>
        private void dgvDSSanPham_Click(object sender, EventArgs e)
        {
            int index = dgvDSSanPham.CurrentRow.Index;
            txtMaSP.Text = dgvDSSanPham.Rows[index].Cells[0].Value.ToString();
            txtTenSP.Text = dgvDSSanPham.Rows[index].Cells[1].Value.ToString();
            txtDonGia.Text = dgvDSSanPham.Rows[index].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvDSSanPham.Rows[index].Cells[3].Value.ToString();
            txtTinhTrang.Text = dgvDSSanPham.Rows[index].Cells[4].Value.ToString();
            cboTenLoaiSP.Text = dgvDSSanPham.Rows[index].Cells[5].Value.ToString();

            //Mo nut sua va xoa
            btnSuaSP.Enabled = true;
            btnXoaSP.Enabled = true;
            btnThemSP.Enabled = false;
            txtMaSP.Enabled = false;
        }

        /// <summary>
        /// Xu ly su kien nut reset
        /// </summary>
        private void btnResetSP_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonGia.ResetText();
            txtSoLuong.ResetText();
            txtTinhTrang.ResetText();
            cboTenLoaiSP.SelectedIndex = 0;
            hienThiDSSanPham(qlProducts.getAllProducts());//hien thi lai danh sach san pham
            btnXoaSP.Enabled = false;
            btnSuaSP.Enabled = false;
            btnThemSP.Enabled = true;
            txtMaSP.Enabled = true;
        }

        /// <summary>
        /// Xu ly su kien cho nut them san pham
        /// </summary>
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            //Lay du lieu tu form
            string s = "";
            string t = "Thông báo";
            try
            {
                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                double donGia = Double.Parse(txtDonGia.Text);
                int soLuong = int.Parse(txtSoLuong.Text);

                //Kiem tra co nhap du lieu hay chua
                if (maSP.Length == 0)
                {
                    s = "Bạn chưa nhập mã sản phẩm";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ChuanHoaChuoi.catBoKhoangTrangGiua(maSP);

                //Kiem tra ma san pham da ton tai chua
                if (qlProducts.searchProductByID(maSP) != null)
                {
                    s = "Mã sản phẩm đã tồn tại";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (tenSP.Length == 0)
                {
                    s = "Bạn chưa nhập tên sản phẩm";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Cat bo khoang trang thua
                ChuanHoaChuoi.catBoKhoangTrangGiua(tenSP);

                //Kiem tra xem ten san pham da ton tai chua(ten san pham la duy nhat)
                if (qlProducts.searchProductByName(tenSP) != null)
                {
                    s = "Tên sản phẩm đã tồn tại";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Kiem tra so sluong hop le khong
                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Kiem tra so sluong hop le khong
                if (donGia <= 0)
                {
                    MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Tinh trang san pham dưa vao so luong san pham
                string tinhTrang = "";
                if (soLuong < 10)
                {
                    tinhTrang = "Sắp hết hàng";
                }
                else
                {
                    tinhTrang = "Còn hàng";
                }
                //Lay thong tin ma loai san pham
                string maLoai = cboTenLoaiSP.SelectedValue.ToString();;

                //Tien hanh them san pham vao danh sach
                if (qlProducts.insertNewProduct(maSP, tenSP, donGia, soLuong, tinhTrang, maLoai) > 0)
                {
                    s = "Thêm dữ liệu thành công!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDSSanPham(qlProducts.getAllProducts());//Hien thi lai danh sach san pham
                }
                else
                {
                    s = "Thêm dữ liệu thất bại!";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Reset textbox
                txtMaSP.ResetText();
                txtTenSP.ResetText();
                txtDonGia.ResetText();
                txtSoLuong.ResetText();
                txtMaLoai.ResetText();
                txtTinhTrang.ResetText();
            }
            catch (FormatException)
            {
                s = "Dữ liệu của đơn giá phải là số thực, số lượng phải là số nguyên";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Xu ly su kien sua thong tin 1 san pham bat ky
        /// </summary>
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            //Lay du lieu tu form
            string s = "";
            string t = "Thông báo";
            int index = dgvDSSanPham.CurrentRow.Index;//Lay vi tri dong duoc click
            try
            {
                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();

                //Kiem tra co nhap du lieu hay chua
                if (maSP.Length == 0)
                {
                    s = "Bạn chưa nhập mã sản phẩm";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (tenSP.Length == 0)
                {
                    s = "Bạn chưa nhập tên sản phẩm";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ChuanHoaChuoi.catBoKhoangTrangGiua(tenSP);//cat bo khoang trang thua

                //Kiem tra xem ten san pham da ton tai chua(ten san pham la duy nhat)
                if (qlProducts.searchProductByName(tenSP) != null && tenSP.ToLower().CompareTo(dgvDSSanPham.Rows[index].Cells[1].Value.ToString().ToLower()) != 0)
                {
                    s = "Tên sản phẩm đã tồn tại";
                    MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                double donGia = Double.Parse(txtDonGia.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                //Kiem tra so luong co hop le khong
                if (soLuong < 0)
                {
                    MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Kiem tra so sluong hop le khong
                if (donGia <= 0)
                {
                    MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Tinh trang san pham dưa vao so luong san pham
                string tinhTrang = "";
                if (soLuong < 10)
                {
                    tinhTrang = "Sắp hết hàng";
                }
                else
                {
                    tinhTrang = "Còn hàng";
                }
                //Lay thong tin ma loai san pham
                string maLoai = cboTenLoaiSP.SelectedValue.ToString();

                //Sua du lieu
                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn sửa thông tin?", "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r != DialogResult.No)
                {
                    if (qlProducts.updateProduct(maSP, tenSP, donGia, soLuong, tinhTrang, maLoai) > 0)
                    {
                        s = "Cập nhật thành công!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDSSanPham(qlProducts.getAllProducts());//Hien thi lai danh sach san pham
                    }
                    else
                    {
                        s = "Cập nhật thất bại!";
                        MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //Reset textbox
                    txtMaSP.ResetText();
                    txtTenSP.ResetText();
                    txtDonGia.ResetText();
                    txtSoLuong.ResetText();
                    txtMaLoai.ResetText();
                    txtTinhTrang.ResetText();

                    //An nut sua va nut xoa
                    btnSuaSP.Enabled = false;
                    btnXoaSP.Enabled = false;
                    btnThemSP.Enabled = true;
                    txtMaSP.Enabled = true;
                }
            }
            catch (FormatException)
            {
                s = "Dữ liệu của đơn giá phải là số thực, số lượng phải là số nguyên";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /// <summary>
        /// Xu ly su kien nut xoa san pham
        /// </summary>
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            if (maSP.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm cần sửa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn xoá thông tin?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                if (qlProducts.deleteProduct(maSP) > 0)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDSSanPham(qlProducts.getAllProducts());
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại! Tồn tại chi tiết hóa đơn chứa sản phẩm này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Reset textbox
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonGia.ResetText();
            txtSoLuong.ResetText();
            txtMaLoai.ResetText();
            txtTinhTrang.ResetText();

            //An nut sua va nut xoa
            btnSuaSP.Enabled = false;
            btnXoaSP.Enabled = false;
            btnThemSP.Enabled = true;
            txtMaSP.Enabled = true;
        }

        /// <summary>
        /// Xu ly su kien sap xep danh sach san pham
        /// </summary>
        private void btnSapXepSP_Click(object sender, EventArgs e)
        {
            ArrayList listSX = new ArrayList();
            //Tang dan theo ma san pham
            if (cboSapXepSP.SelectedItem.ToString().CompareTo("Mã sản phẩm") == 0)
            {
                listSX = qlProducts.sortProductByProduct_id();//sap xep tang dan theo ma san pham
            }
            else if (cboSapXepSP.SelectedItem.ToString().CompareTo("Tên sản phẩm") == 0)
            {
                listSX = qlProducts.sortProductByProduct_name();//sap xep tang dan theo ten san pham
            }
            //Hien thi danh sach san pham sau sap xep
            hienThiDSSanPham(listSX);
        }

        /// <summary>
        /// Xuat danh sach san pham
        /// </summary>
        private void btnXuatDSSP_Click(object sender, EventArgs e)
        {
            //Lay danh sach de in
            ArrayList listSP = qlProducts.getAllProducts();
            try
            {
                string fileName = "SanPham.txt";
                FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH SẢN PHẨM");
               
                foreach (SanPham sp in listSP)
                {
                    //Lay ten loai san pham
                    string tenLoai = "";
                    qlProductTypes.searchProductTypeByID(sp.MaLoaiSP);
                    writeFile.WriteLine("{0}, {1},  {2},  {3},  {4},  {5}", sp.MaSP, sp.TenSP, sp.NSLuong, sp.DonGia, sp.TinhTrang, tenLoai);
                }
                MessageBox.Show("Xuất danh sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writeFile.Close();
                output.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Xu ly su kien cho contextmenu
        /// </summary>
        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnXoaSP_Click(this, e);
        }

        /// <summary>
        /// Su kien click vao textbox search
        /// </summary>
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text == "Nhập thông tin cần tìm...")
            {
                txtSearch.ResetText();
            }
        }

        /// <summary>
        /// Tim kiem
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            hienThiDSSanPham(qlProducts.searchProductLIKEByName(txtSearch.Text));
        }

        /// <summary>
        /// Khi roi khoi text box search
        /// </summary>
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "Nhập thông tin cần tìm...";
            hienThiDSSanPham(qlProducts.getAllProducts());//hien thi thong tin san pham can tim
        }

    }
}
