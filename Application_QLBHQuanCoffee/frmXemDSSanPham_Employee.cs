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
using System.Collections;

namespace QuanLyCuaHangCoffee
{
    public partial class frmXemDSSanPham_Employee : Form
    {
        public frmXemDSSanPham_Employee()
        {
            InitializeComponent();
        }

        QuanLySanPham qlProducts = new QuanLySanPham();
        QuanLyLoaiSanPham qlProductTypes = new QuanLyLoaiSanPham();

        /// <summary>
        /// Hien thi toan bo danh sach san pham len form
        /// </summary>
        private void frmXemDSSanPham_Employee_Load(object sender, EventArgs e)
        {
            //Lay toan bo ds san pham
            hienThi(qlProducts.getAllProducts());

        }

        /// <summary>
        /// Hien thi len listview
        /// </summary>
        private void hienThi(ArrayList listSP)
        {
            foreach (SanPham sp in listSP)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sp.MaSP;
                item.ImageIndex = 0;
                item.SubItems.Add(sp.TenSP);
                item.SubItems.Add(sp.NSLuong.ToString());
                item.SubItems.Add(sp.DonGia.ToString());
                item.SubItems.Add(sp.TinhTrang);
                //Lay ten loai san pham
                LoaiSanPham lsp = qlProductTypes.searchProductTypeByID(sp.MaLoaiSP);//lay ten loai san pham thong qua ma loai
                item.SubItems.Add(lsp.TenLoai);
                lvwHienThiDSSP.Items.Add(item);
            }
        }

        //Mo form nhan vien
        private void openFormNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }

        /// <summary>
        /// Sau khi dong form mo lai form nhan vien
        /// </summary>
        private void frmXemDSSanPham_Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFormNhanVien));//mo from Tim kiem
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form dang nhap
        }
    }
}
