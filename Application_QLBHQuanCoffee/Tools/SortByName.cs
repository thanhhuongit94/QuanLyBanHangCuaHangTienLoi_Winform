using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using QuanLyCuaHangCoffee.Models;

namespace QuanLyCuaHangCoffee.Tools
{
    class SortByName : IComparer //Tao 1 class sort theo ten
    {
        int IComparer.Compare(object x, object y)
        {
            NhanVien nv1 = x as NhanVien;
            NhanVien nv2 = y as NhanVien;
            string hoTenNV1 = nv1.TenNV;
            int index1 = hoTenNV1.LastIndexOf(' ');
            string tenNV1 = hoTenNV1.Substring(index1 + 1);

            string hoTenNV2 = nv2.TenNV;
            int index2 = hoTenNV2.LastIndexOf(' ');
            string tenNV2 = hoTenNV2.Substring(index2 + 1);
            return String.Compare(tenNV1, tenNV2);
        }
    }
}
