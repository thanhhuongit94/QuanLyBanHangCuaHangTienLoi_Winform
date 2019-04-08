using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using QuanLyCuaHangCoffee.Models;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace QuanLyCuaHangCoffee
{
    public partial class frmNhanVien : Form
    {
        public static string userNV = string.Empty;//Lay du lieu username tu form login gui sang
        public frmNhanVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khai bao cac doi tuong cua cac lop
        /// </summary>
        QuanLyNhanVien qlEmployees = new QuanLyNhanVien();
        QuanLyLoaiSanPham qlProductTypes = new QuanLyLoaiSanPham();
        QuanLySanPham qlProducts = new QuanLySanPham();
        QuanLyHoaDon qlInvoices = new QuanLyHoaDon();
        QuanLyChiTietHoaDon qlInvoiceDetail = new QuanLyChiTietHoaDon();

        //Thuc hien khi form load
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            timer1.Start();
            loadForm();
            if (userNV != "huongntt")
            {
                //Hien thi ten nhan vien len form 
                NhanVien nv = qlEmployees.searchEmployeeByUsername(userNV);
                //Neu username do khong thuoc ve bat ki nhan vien nao
                if (nv == null)
                {
                    this.Text = "Xin chào: " + userNV;
                    btnTTCaNhan.Enabled = false;
                    btnXemHD.Enabled = false;
                    btnThongTinPM.Enabled = false;
                    return;
                }
                this.Text = "Xin chào: " + nv.TenNV;
            }
            else
            {
                this.Text = "Xin chào: Admin";
                //An nut xem thong tin ca nhan
                btnTTCaNhan.Enabled = false;
                return;
            }
        }


        //Hien thi luc form load
        private void loadForm()
        {
            //Load du lieu len combo box loai san pham va combobox san pham
            cboLoai.DataSource = qlProductTypes.getAllProductTypes();//lay danh sach loai san pham
            cboLoai.DisplayMember = "tenLoai";
            cboLoai.ValueMember = "maLoai";
            //Do du lieu len combo box thuc don
            cboThucDon.DataSource = qlProducts.searchProduct(cboLoai.SelectedValue.ToString());
            //An nut thanh toan
            btnThanhToan.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongDateString() + "\n" + DateTime.Now.ToLongTimeString(); ;
        }

        //Mo form xem thong tin ca nhan
        private void openThongTinCaNhan()
        {
            System.Windows.Forms.Application.Run(new frmThongTinCaNhan());
        }

        /// <summary>
        /// Xu ly nut xem thong tin ca nhan
        /// </summary>
        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan.usernameNV = userNV;//gui thong tin username cua nhan vien dang dang nhap sang form thong tin ca nhan
            Thread thread = new Thread(new ThreadStart(openThongTinCaNhan));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        /// <summary>
        /// Xem chi tiet hoa don ma nhan vien dang dang da ban
        /// </summary>
        private void btnXemHD_Click(object sender, EventArgs e)
        {
            NhanVien nv = qlEmployees.searchEmployeeByUsername(userNV);//tim nhan vien co username nhu dang dnag nhap
            frmXemChiTietHoaDon_NhanVien.maNhanVien = nv.MaNV;//gui thong tin ma nhan vien cua nhan vien dang dang nhap sang form xem chi tiet hoa don
            Thread thread = new Thread(new ThreadStart(openFormXemChiTiet));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }

        //Mo form xem chi tiet don hang
        private void openFormXemChiTiet()
        {
            System.Windows.Forms.Application.Run(new frmXemChiTietHoaDon_NhanVien());
        }

        /// <summary>
        /// Xu ly su kien moi lan thay doi lua chon trong combobox Loai se do vao combobox san pham dung loai da chon
        /// </summary>
        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {  
            cboThucDon.DisplayMember = "tenSP";
            cboThucDon.ValueMember = "maSP";
            cboThucDon.DataSource = qlProducts.searchProduct(cboLoai.SelectedValue.ToString());
        }

        /// <summary>
        /// Xu ly su kien nut save chi tiet cac san pham vao hoa don
        ///</summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Hien thi nut thanh toan va nut xoa
            btnThanhToan.Enabled = true;
            btnXoa.Enabled = true;
            //Lay ma hoa don co tong tien bang 0
            int maHD = new QuanLyHoaDon().searchInvoiceHaveTotalMoneyIs0().MaHD;
            string s = "";
            string t = "Thông báo";
            //Lay thong tin
            string maSP = cboThucDon.SelectedValue.ToString();
            double donGia = 0;
            int soLuong = int.Parse(numUpd.Value.ToString());//lay so luong
            double thanhTien = 0;

            //Lay don gia va ma san pham
            SanPham sp = qlProducts.searchProductByID(maSP);
            donGia = sp.DonGia;
            //Kiem tra so luong con trong kho co du ban khong
            if (soLuong > sp.NSLuong)
            {
                s = "Số lượng trong kho không đủ bán! Số lượng còn lại của sản phẩm là " + sp.NSLuong;
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            thanhTien = sp.DonGia * soLuong;
            //tinh tong tien cua hoa don do
            double tongTienHD = 0.0;

            /*Kiem tra san pham trong chitiethoadon da ton tai chua  , neu ton tai thi tien hanh cap nhat so luong
            Neu chua thi them san pham do vao chitiethoadon
         */
            bool check = false;//Khong co san pham bi trung
            foreach (ListViewItem item in lvwChiTiet.Items)
            {
                if (maSP.CompareTo(item.SubItems[0].Text) == 0)
                {
                    //Neu san pham ton tai thi tien hanh cho update so luong
                    soLuong = int.Parse(numUpd.Value.ToString());
                    //xoa san pham bi trung
                    lvwChiTiet.Items.Remove(item);
                    //Hien thi chi tiet cac san pham len listview
                    hienThiCT(new ChiTietHoaDon(maHD, maSP, donGia, soLuong, thanhTien));
                    check = true;
                }

            }

            //Tinh lai tong tien
            if (check == true)
            {
                foreach (ListViewItem item in lvwChiTiet.Items)
                {
                    tongTienHD += double.Parse(item.SubItems[4].Text);
                }
            }
            if (check == false)
            {
                ////Xoa listview de hien thi
                ListView.SelectedListViewItemCollection listVW = lvwChiTiet.SelectedItems;
                //Hien thi chi tiet cac san pham len listview

                hienThiCT(new ChiTietHoaDon(maHD, maSP, donGia, soLuong, thanhTien));
                numUpd.Value = 1;
                //Tinh lai tong tien luu hoa don
                listVW = lvwChiTiet.SelectedItems;
                foreach (ListViewItem item in lvwChiTiet.Items)
                {
                    tongTienHD += double.Parse(item.SubItems[4].Text);
                }
                txtTongTien.Text = tongTienHD.ToString();//hien thi tong tien len textbox
                return;
            }
            txtTongTien.Text = tongTienHD.ToString();//hien thi tong tien len textbox
        }

        //Hien thi chi tiet hoa don len listview
        private void hienThiCT(ChiTietHoaDon cthd)
        {
            ListViewItem item = new ListViewItem();
            //Duyet lay ten san pham de hien thi
            SanPham sp = qlProducts.searchProductByID(cthd.MaSP);
            item.Text = sp.MaSP;
            item.SubItems.Add(sp.TenSP);
            item.SubItems.Add(cthd.NSLuong.ToString());
            item.SubItems.Add(cthd.DonGia.ToString());
            item.SubItems.Add(cthd.ThanhTien.ToString());
            lvwChiTiet.Items.Add(item);
        }

        /// <summary>
        /// Xoa 1 san pham ra khoi lua chon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection list = lvwChiTiet.SelectedItems;
            if (list.Count != 0)
            {
                foreach (ListViewItem item in list)
                {
                    lvwChiTiet.Items.Remove(item);
                }

                //Cap nhat lai tong tien
                double tongTien = 0;
                foreach (ListViewItem item in lvwChiTiet.Items)
                {
                    tongTien += double.Parse(item.SubItems[4].Text);
                }
                txtTongTien.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /// <summary>
        /// Xu ly nut thanh toan
        /// </summary>
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string s = "";
            string t = "Thông báo";
            if (lvwChiTiet.Items.Count == 0)
            {
                s = "Bạn chưa chọn sản phẩm";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maHD = qlInvoices.searchInvoiceHaveTotalMoneyIs0().MaHD;//Lay ma hoa don co tong tien  = 0;
            double tienKHTra = double.Parse(txtTienKhachDua.Text);
            double tienPhaiTra = double.Parse(txtTongTien.Text);
            if (tienKHTra < tienPhaiTra)
            {
                s = "Số tiền không đủ để thanh toán";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn tiếp tục thanh toán", t,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                {
                    //Delete cac lua chon hien thi tren listview
                    foreach (ListViewItem item in lvwChiTiet.Items)
                    {
                        lvwChiTiet.Items.Remove(item);
                    }
                    txtTongTien.Text = "0.0";
                    txtTienKhachDua.Text = "0.0";
                    txtTienTraLai.Text = "0.0";
                    return;
                }
                return;
            }

            //Nguoc lai tiep tuc thanh toan hoac tien khach dua du thanh toan
            string maSP = "";
            double donGia = 0;
            int soLuong = 0;
            double thanhTien = 0;
            //lay danh sach cac chi tiet san pham tren listview
            foreach (ListViewItem item in lvwChiTiet.Items)
            {
                //Lay ma san pham, so luong, don gia, thanh tien
                maSP = item.SubItems[0].Text;
                soLuong = int.Parse(item.SubItems[2].Text);
                donGia = double.Parse(item.SubItems[3].Text);
                thanhTien = double.Parse(item.SubItems[4].Text);

                //Insert lan luot vao ChiTietHoaDon
                qlInvoiceDetail.insertNewInvoiceDetail(maHD, maSP, donGia, soLuong, thanhTien);


                //Update lai so luong va tinh trang hang cua san pham
                //Lay don gia va ma san pham
                SanPham sp = qlProducts.searchProductByID(maSP);//tim san pham bang maSP
                int soLuongConLai = sp.NSLuong - soLuong;

                //Thuc hien update lai so luong san pham trong kho cua san pham do
                qlProducts.updateAmountProduct(sp.MaSP, soLuongConLai);//Update so luong hang
                //Cap nhat lai tinh trang hang trong kho
                if (sp.NSLuong == 0)
                {
                    qlProducts.updateProductStatus(maSP, "Hết hàng");
                }
                else if (sp.NSLuong < 10)
                {
                    qlProducts.updateProductStatus(maSP, " Sắp hết hàng");
                }
                else
                {
                    qlProducts.updateProductStatus(maSP, "Còn hàng");
                }
                maSP = "";
            }

            //Thuc hien lay thong tin de update hoa don
            txtTienTraLai.Text = (tienKHTra - tienPhaiTra).ToString();
            //Luu hoa don
            double tongTien = double.Parse(txtTongTien.Text);
            DateTime ngayLapHD = DateTime.Now;//ngay lap hoa don
            string ghiChu = "";
            //lay ma nhan vien de luu vao hoa don
            string maNV = "";
            NhanVien nv = qlEmployees.searchEmployeeByUsername(userNV);//tim nhan vien bang username
            //Neu username do khong thuoc ve bat ki nhan vien nao
            if (nv == null)
            {
                maNV = "Admin";
                ghiChu = "Hóa đơn do username: " + userNV + " thực hiện";
            }
            else
            {
                maNV = nv.MaNV;
            }
            
            qlInvoices.updateInvoice(maHD, maNV, tongTien, ngayLapHD, ghiChu);//Luu vao hoa don

            //Sau khi thanh toan tao ra 1 hoa don moi voi tong tien bang 0 de phuc vu lan thanh toan tiep theo
            qlInvoices.insertInvoice(maNV, ngayLapHD, ghiChu);//Tao hoa don co tong tien = 0

            s = "Thanh toán thành công";
            MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Xoa sach du lieu tren listview de phuc vu lan dat hang tiep theo
            foreach (ListViewItem item in lvwChiTiet.Items)
            {
                lvwChiTiet.Items.Remove(item);
            }
            //Xoa cac textbox
            txtTongTien.Text = "0.0";
            txtTongTien.ForeColor = Color.Red;
            txtTienKhachDua.Text = "0.0";
            txtTienKhachDua.ForeColor = Color.Red;
            txtTienTraLai.Text = "0.0";
            txtTienTraLai.ForeColor = Color.Red;
            numUpd.Value = 1;
        }

        /// <summary>
        /// Su kien click vao listview hien thi lai len combobox
        /// </summary>
        private void lvwChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwChiTiet.SelectedItems.Count == 0)
            {
                return;
            }
            //Duyet lay ten loai

            ListViewItem item = lvwChiTiet.SelectedItems[0];
            SanPham sp = qlProducts.searchProductByName(item.SubItems[1].Text);
            LoaiSanPham lsp = qlProductTypes.searchProductTypeByID(sp.MaLoaiSP);
            cboLoai.SelectedItem = lsp.TenLoai;
            cboThucDon.SelectedItem = item.SubItems[1].Text;
            numUpd.Value = int.Parse(item.SubItems[2].Text);
            btnXoa.Enabled = true;
        }

        /// <summary>
        /// Xem danh sach cac san pham
        /// </summary>
        private void btnXemDSSP_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFormXemDSSanPham));//mo from xem ds san pham
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form nhan vien
        }

        /// <summary>
        /// Mo form xem danh sach san pham
        /// </summary>
        private void openFormXemDSSanPham()
        {
            System.Windows.Forms.Application.Run(new frmXemDSSanPham_Employee());
        }


        /// <summary>
        /// Xu ly su kien nut xem thong tin phan mem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThongTinPM_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem.username = userNV;//Gui du lieu sang form xem thong tin phan mem
            Thread thread = new Thread(new ThreadStart(openFormThongTinPM));//mo from xem thong tin phan mem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form nhan vien
        }

        /// <summary>
        /// Mo form xem thong tin phan mem
        /// </summary>
        private void openFormThongTinPM()
        {
            System.Windows.Forms.Application.Run(new frmThongTinPhanMem());
        }

        /// <summary>
        /// Xu ly logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r != DialogResult.No)
            {
                //Neu la admin thi tro lai form trang chu
                if (userNV == "huongntt")
                {
                    Thread thread = new Thread(new ThreadStart(openFormTrangChuAdmin));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else
                {
                    Thread thread = new Thread(new ThreadStart(openFormLogin));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                System.Windows.Forms.Application.ExitThread(); 
            }
        }

        //Mo form login
        private void openFormLogin()
        {
            System.Windows.Forms.Application.Run(new frmLogin());
        }

        //Mo form trang chu admin
        private void openFormTrangChuAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }

        /// <summary>
        /// Xu ly su kien truoc khi dong form
        /// </summary>
        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            //Neu la admin thi tro lai form trang chu
            if (userNV == "huongntt")
            {
                Thread thread = new Thread(new ThreadStart(openFormTrangChuAdmin));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(openFormLogin));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        /// <summary>
        /// Delete trong context menu
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa_Click(this, e);
        }

        /// <summary>
        /// Thay doi che do xem danh sach tren listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwChiTiet.View = View.List;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwChiTiet.View = View.Details;
        }


        /// <summary>
        /// Thay doi mau chu tren listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            lvwChiTiet.ForeColor = color.Color;
        }

        /// <summary>
        /// Thay doi font chu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            lvwChiTiet.Font = font.Font;
        }
    }
}

