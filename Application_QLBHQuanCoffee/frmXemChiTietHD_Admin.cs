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
using System.Collections;

namespace QuanLyCuaHangCoffee
{
    public partial class frmXemChiTietHD_Admin : Form
    {
        public frmXemChiTietHD_Admin()
        {
            InitializeComponent();
        }
        QuanLyChiTietHoaDon qlInvoiceDetail = new QuanLyChiTietHoaDon();
        QuanLyLoaiSanPham qlProductTypes = new QuanLyLoaiSanPham();
        QuanLySanPham qlProducts = new QuanLySanPham();
        QuanLyHoaDon qlInvoices = new QuanLyHoaDon();
        QuanLyNhanVien qlEmployees = new QuanLyNhanVien();

        //Xu ly luc load form
        private void frmXemChiTietHD_Admin_Load(object sender, EventArgs e)
        {
            //Do du lieu vao combobox HoaDon
            ArrayList listInvoice = qlInvoices.searchInvoiceHaveTotalMoneyGreaterThan_0();//Lay hoa don co tong tien lon hon 0(hoa don da duoc thanh toan)
            if (listInvoice.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào đã được thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (HoaDon hd in listInvoice)
            {
                cboHoaDon.Items.Add(hd.MaHD);
            }
            //Cai dat gia tri mac dinh cho combobox
            cboHoaDon.SelectedIndex = 0;
        }

        //Hien thi danh sach
        private void hienThi(ArrayList listCTHD, HoaDon hd)
        {
            //Lay ma nhan vien va ten nhan vien ban hang
            NhanVien nv = qlEmployees.searchEmployeeByMaNV(hd.MaNV);
            ArrayList listInvoice = qlInvoices.searchInvoiceHaveTotalMoneyGreaterThan_0();//Lay hoa don co tong tien lon hon 0(hoa don da duoc thanh toan) 
            //Hien thi
            foreach (ChiTietHoaDon ct in listCTHD)
            {
                //Hien thi ten san pham
                //Lay ten san pham
                if (ct.MaSP != string.Empty)
                {
                    SanPham sp = qlProducts.searchProductByID(ct.MaSP);
                    if (sp == null)
                    {
                        continue;
                    }
                    ListViewItem item = new ListViewItem();
                    item.Text = hd.MaHD.ToString();//hien thi ma hd
                    if (nv != null)
                    {
                        item.SubItems.Add(nv.MaNV);//hien thi ma nhan vien
                        item.SubItems.Add(nv.TenNV);//hien thi ten nhan vien
                    }
                    else
                    {
                        item.SubItems.Add("Admin");
                        item.SubItems.Add("Admin");
                    }
                    item.SubItems.Add(sp.TenSP);//Hien thi ten san pham
                    item.SubItems.Add(ct.NSLuong.ToString());//Hien thi so luong
                    item.SubItems.Add(ct.DonGia.ToString());//Hien thi don gia
                    item.SubItems.Add(ct.ThanhTien.ToString());//Hien thi thanh tien
                    foreach (HoaDon HD in listInvoice)
                    {
                        if (HD.MaHD == hd.MaHD)
                        {
                            item.SubItems.Add(HD.GhiChu);//Hien thi ghi chu
                            break;
                        }
                    }
                    lvwChiTiet.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Xu ly su kien khi thay doi item trong cbo
        /// </summary>
        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Xoa du lieu hien thi trong listview de hien thi thong tin cua hoa don khac
            foreach (ListViewItem it in lvwChiTiet.Items)
            {
                lvwChiTiet.Items.Remove(it);
            }
            //Hien thi chi tiet co ma hoa don duoc chon
            //Lay hoa don co ma duoc chon trong combo box
            HoaDon hd = qlInvoices.searchInvoiceByInvoice_id(int.Parse(cboHoaDon.SelectedItem.ToString()));

            //Hien thi tong tien
            txtTongTien.Text = hd.TongTien.ToString();

            //Lay chi tiet cua hoa don co ma duoc chon
            ArrayList listCTHD = qlInvoiceDetail.searchInvoiceDetailByInvoice_id(hd.MaHD);

            hienThi(listCTHD, hd);


        }

        /// <summary>
        /// Sau khi dong form mo lai trang chu
        /// </summary>
        private void frmXemChiTietHD_Admin_FormClosed(object sender, FormClosedEventArgs e)
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
