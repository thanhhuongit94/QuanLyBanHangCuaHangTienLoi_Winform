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

namespace QuanLyCuaHangCoffee
{
    public partial class frmXemChiTietHoaDon_NhanVien : Form
    {
        public static string maNhanVien = "";//Nhan du lieu tu form nhan vien gui sang
        public frmXemChiTietHoaDon_NhanVien()
        {
            InitializeComponent();
        }

        QuanLyChiTietHoaDon qlInvoiceDetail = new QuanLyChiTietHoaDon();
        QuanLyHoaDon qlInvoices = new QuanLyHoaDon();
        QuanLySanPham qlProducts = new QuanLySanPham();

        /// <summary>
        /// Load len danh sach chi tiet cac san pham da ban
        /// </summary>
        private void frmXemChiTietHoaDon_Load(object sender, EventArgs e)
        {
            ArrayList listHD = qlInvoices.searchInvoiceByEmployee_id(maNhanVien);//chua tat ca cac hoa don nhan vien dang dang nhap ban
           
            ArrayList listInvoiceDetails = new ArrayList();
            if(listHD.Count != 0)
            {
                double tongTien = 0.0;
                foreach (HoaDon hd in listHD)
                {
                    //tim cac chi tiet hoa bang theo ma hoa don(tim xem chi tiet hoa don thuoc hoa don nao)
                    listInvoiceDetails = qlInvoiceDetail.searchInvoiceDetailByInvoice_id(hd.MaHD);
                    //Hien thi list len listview
                    foreach (ChiTietHoaDon ct in listInvoiceDetails)
                    {
                        if (ct.NSLuong != 0)
                        {
                            tongTien += ct.ThanhTien;
                            ListViewItem item = new ListViewItem();
                            item.Text = ct.MaSP;
                            item.ImageIndex = 0;

                            //Lay ten san pham de hien thi
                            SanPham sp = new SanPham();
                            sp = qlProducts.searchProductByID(ct.MaSP);//Lay san pham theo ma san pham
                            item.SubItems.Add(sp.TenSP.ToString());//Hien thi ten san pham
                            item.SubItems.Add(ct.NSLuong.ToString());
                            item.SubItems.Add(ct.DonGia.ToString());
                            item.SubItems.Add(ct.ThanhTien.ToString());
                            lvwChiTiet.Items.Add(item);
                        }
                    }
                }
                txtTongTien.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa bán được sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread thread = new Thread(new ThreadStart(openFormNhanVien));//mo from Tim kiem
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
            }
        }


        //Mo form xem chi tiet don hang
        private void openFormNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }
        /// <summary>
        /// xu ly sau khi dong form bat lai form nhan vien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXemChiTietHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFormNhanVien));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }
    }
}
