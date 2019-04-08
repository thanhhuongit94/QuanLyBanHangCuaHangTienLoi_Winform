/*
 * Program: Define NhanVien class
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
    class NhanVien
    {
        //Properties
        private string maNV;
        private string tenNV;
        private string gioiTinh;
        private string CMND;
        private string diaChi;
        private string SDT;
        private double heSoLuong;
        private double luongCB;
        private string username;

        //Contructor
        public NhanVien() { }

        public NhanVien(string maNV, string tenNV, string gioiTinh, string CMND, string diaChi, string SDT, double heSoLuong, double luongCB, string username)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.gioiTinh = gioiTinh;
            this.CMND = CMND;
            this.diaChi = diaChi;
            this.SDT = SDT;
            this.heSoLuong = heSoLuong;
            this.luongCB = luongCB;
            this.username = username;
        }

        //Getter and setter
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string CMND1
        {
            get { return CMND; }
            set { CMND = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }

        public double HeSoLuong
        {
            get { return heSoLuong; }
            set { heSoLuong = value; }
        }

        public double LuongCB
        {
            get { return luongCB; }
            set { luongCB = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

    }
}
