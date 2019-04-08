/*
 * Program: Define LoaiSanPham class
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
    class LoaiSanPham
    {
        //Properties
        private string maLoai;
        private string tenLoai;

        //Contructor
        public LoaiSanPham() { }

        public LoaiSanPham(string maLoai, string tenLoai)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
        }

        //Getter and setter
        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
    }
}
