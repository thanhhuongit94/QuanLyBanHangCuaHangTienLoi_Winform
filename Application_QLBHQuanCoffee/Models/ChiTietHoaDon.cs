/*
 * Program: Define ChiTietHoaDon class
 * Created by: 
 *      1. Nguyen Thi Thanh Huong_16211TT0035
 * Date : 27/04/2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangCoffee.Models
{
    class ChiTietHoaDon
    {
        /// <summary>
        /// Properties
        /// </summary>
        private int maHD;      
        private string maSP;        
        private double donGia;      
        private int nSLuong;  
        private double thanhTien;

        /// <summary>
        /// Contructor
        /// </summary>
        public ChiTietHoaDon() { }

        public ChiTietHoaDon(int maHD, string maSP, double donGia, int nSLuong, double thanhTien)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.donGia = donGia;
            this.nSLuong = nSLuong;
            this.thanhTien = thanhTien;
        }

        /// <summary>
        /// Getter and setter
        /// </summary>
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
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

        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
    }
}
