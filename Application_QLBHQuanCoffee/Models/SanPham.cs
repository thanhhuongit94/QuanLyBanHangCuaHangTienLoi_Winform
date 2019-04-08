/*
 * Program: Define SanPham class
 * Created by: 
 *      1. Nguyen Thi Thanh Huong_16211TT0035
 *      2. Vo Ngoc Phu_16211TT0016
 * Date : 27/04/2018
 * Update 1: 01/05/2018
 * Update 2: 06/05/2018
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangCoffee.Models
{
    class SanPham
    {
        //Properties
        private string maSP;
        private string tenSP;
        private double donGia;
        private int nSLuong;
        private string tinhTrang;
        private string maLoaiSP;

        //Contructor
        public SanPham() { }

        public SanPham(string maSP, string tenSP, double donGia, int nSLuong, string tinhTrang, string maLoaiSP)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.donGia = donGia;
            this.nSLuong = nSLuong;
            this.tinhTrang = tinhTrang;
            this.maLoaiSP = maLoaiSP;
        }

        //Getter and setter
        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public int NSLuong
        {
            get { return nSLuong; }
            set { nSLuong = value; }
        }

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

        public string MaLoaiSP
        {
            get { return maLoaiSP; }
            set { maLoaiSP = value; }
        }
    }
}
