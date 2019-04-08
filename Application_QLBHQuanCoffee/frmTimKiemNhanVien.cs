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
    public partial class frmTimKiemNhanVien : Form
    {
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
        }

        QuanLyNhanVien qlEmployees = new QuanLyNhanVien();

        private void frmTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            cboLuaChonTimKiem.SelectedIndex = 0;
            foreach (NhanVien nv in qlEmployees.getAllDataEmployees())
            {
                hienThiKetQuaTimKiem(nv);
            }
        }

        /// <summary>
        /// Mo form he thong quan ly
        /// </summary>
        private void openHeThongQLy()
        {
            System.Windows.Forms.Application.Run(new frmHeThongQuanLy());
        }

        /// <summary>
        /// Xu ly su kien sau khi dong form tim kiem, mo form he thong quan ly len
        /// </summary>
        private void frmTimKiemNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openHeThongQLy));//mo from he thong quan ly
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.Exit(); //dong form tim kiem
        }

        /// <summary>
        /// Hien thi ket qua tim kiem duoc len listview
        /// </summary>
        /// <param name="listNV"></param>
        private void hienThiKetQuaTimKiem(NhanVien nv)
        {
            ListViewItem item = new ListViewItem();
            item.Text = nv.MaNV;
            item.ImageIndex = 0;//chen icon vao listview
            item.SubItems.Add(nv.TenNV);
            item.SubItems.Add(nv.CMND1);
            item.SubItems.Add(nv.GioiTinh);
            item.SubItems.Add(nv.DiaChi);
            item.SubItems.Add(nv.SDT1);
            item.SubItems.Add(nv.HeSoLuong.ToString());
            item.SubItems.Add(nv.LuongCB.ToString());
            item.SubItems.Add(nv.Username);
            lvwThongTinTimKiem.Items.Add(item);
        }

        private void txtThongTinCanTim_TextChanged(object sender, EventArgs e)
        {
            if (cboLuaChonTimKiem.SelectedItem.ToString() == "Mã nhân viên")
            {
                //Reset listview de hien thi
                foreach (ListViewItem item in lvwThongTinTimKiem.Items)
                {
                    item.Remove();
                }
                ArrayList listNV = qlEmployees.searchEmployeeLIKE_id(txtThongTinCanTim.Text);
             
                //Ton tai nhan vien co ma nhu da nhap. cho hien thi thong tin len listview 
                foreach (NhanVien nv in listNV)
                {
                    hienThiKetQuaTimKiem(nv);
                }
            }
            else if (cboLuaChonTimKiem.SelectedItem.ToString() == "Tên nhân viên")
            {
                //Reset listview de hien thi
                foreach (ListViewItem item in lvwThongTinTimKiem.Items)
                {
                    item.Remove();
                }
                //lay toan bo danh sach nhan vien
                ArrayList listNV = qlEmployees.searchEmployeeByLIKEname(txtThongTinCanTim.Text);
                foreach (NhanVien nv in listNV)
                {
                    hienThiKetQuaTimKiem(nv);
                }
            }
            else
            {
                //Reset listview de hien thi
                foreach (ListViewItem item in lvwThongTinTimKiem.Items)
                {
                    item.Remove();
                }
                ArrayList listNV = qlEmployees.searchEmployeeByAddress(txtThongTinCanTim.Text);
                foreach (NhanVien nv in listNV)
                {
                    hienThiKetQuaTimKiem(nv);
                }
            }
        }
    }
}
