using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangCoffee.Tools
{
    class ChuanHoaChuoi
    {
        //Kiem tra ky tu nhap vao
        public static bool kiemTraKyTu(char [] ten)
        {
            for (int i = 0; i < ten.Length; i++)
            {
                if ('0' <= ten[i] && ten[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        //Ham cat khoang trang thua
        public static string catBoKhoangTrangGiua(string chuoiCanXuLy)
        {
            string chuoiDuocXuLy = chuoiCanXuLy.Trim();//Cat khoang trang thua dau va cuoi
            string ketQua = "";
            string tu = "";//luu tung ky tu 
            int nLanCat = 0;

            //Duyet chuoi da duoc cat bo khoang trang dau va cuoi
            for (int i = 0 ; i < chuoiDuocXuLy.Length; i++)
            {
                tu = chuoiDuocXuLy.Substring(i, 1);//lay tung ky tu trong chuoi
                if (tu == " ")
                {
                    nLanCat++;
                }
                else
                {
                    if (nLanCat > 0)
                    {
                        ketQua = ketQua + " " + tu;
                    }
                    else
                    {
                        ketQua = ketQua + tu;
                    }
                    nLanCat = 0;
                }
            }
            return ketQua;
        }
    }
}
