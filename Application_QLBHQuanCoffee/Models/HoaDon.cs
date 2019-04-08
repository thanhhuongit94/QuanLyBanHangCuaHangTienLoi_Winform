/*
 * Program: Define HoaDon class
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
    class HoaDon
    {
        //Properties
        private int maHD;
        private string maNV;
        private double tongTien;
        private DateTime ngayLapHD;
        private string ghiChu;

        //Contructor
        public HoaDon() { }

        public HoaDon(int maHD, string maNV, double tongTien, DateTime ngayLapHD)
        {
            this.maHD = maHD;
            this.maNV = maNV;
            this.tongTien = tongTien;
            this.ngayLapHD = ngayLapHD;
        }

        public HoaDon(int maHD, string maNV, double tongTien, DateTime ngayLapHD, string ghiChu)
        {
            this.maHD = maHD;
            this.maNV = maNV;
            this.tongTien = tongTien;
            this.ngayLapHD = ngayLapHD;
            this.ghiChu = ghiChu;
        }

        //Getter and setter
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public double TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        public DateTime NgayLapHD
        {
            get { return ngayLapHD; }
            set { ngayLapHD = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }
}
