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

namespace QuanLyCuaHangCoffee
{
    public partial class frmThongTinPhanMem : Form
    {
        public static string username = ""; 
        public frmThongTinPhanMem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// xu ly su kien sau khi dong form mo form nhan vien tro lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmThongTinPhanMem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (username.CompareTo("huongntt") == 0)
            {
                Thread thread = new Thread(new ThreadStart(openFormAdmin));//mo from admin
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                System.Windows.Forms.Application.ExitThread(); //dong form xem thong tin phan mem
            }
            else
            {
                Thread thread1 = new Thread(new ThreadStart(openFormNhanVien));//mo from nhan vien
                thread1.SetApartmentState(ApartmentState.STA);
                thread1.Start();
                System.Windows.Forms.Application.ExitThread(); //dong form xem thong tin phan mem
            }
        }

        /// <summary>
        /// Mo form xem thong tin phan mem
        /// </summary>
        private void openFormNhanVien()
        {
            System.Windows.Forms.Application.Run(new frmNhanVien());
        }

        /// <summary>
        /// Mo form xem thong tin phan mem
        /// </summary>
        private void openFormAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }

        /// <summary>
        /// Dan link den dia chi facebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://facebook.com/thanhhuongit94");
        }

        private void frmThongTinPhanMem_Load(object sender, EventArgs e)
        {

        }
    }
}
