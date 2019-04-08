using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace QuanLyCuaHangCoffee.Models
{
    class QuanLyLoaiSanPham: Database
    {
        private ArrayList listProductTypes;
        //Contructor
        public QuanLyLoaiSanPham()
        {
            listProductTypes = new ArrayList();
        }

        //Lay danh sach loai san pham
        public ArrayList getAllProductTypes()
        {
            listProductTypes = new ArrayList();
            dta = getAllDataFromTable("sp_SelectAllLoaiSanPham");
            while (dta.Read())
            {
                listProductTypes.Add(new LoaiSanPham(dta.GetString(0), dta.GetString(1)));
            }
            dta.Close();
            return listProductTypes;
        }

        //Them loai san pham moi vao danh sach
        public int insertNewProductType(string productType_id, string productType_name)
        {
            commandSql = new SqlCommand("sp_InsertLoaiSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maLoai", productType_id);
            commandSql.Parameters.AddWithValue("@tenLoai", productType_name);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Tim kiem loai san pham theo ma loai san pham
        public LoaiSanPham searchProductTypeByID(string idProductType)
        {
            LoaiSanPham productType = new LoaiSanPham();
            commandSql = new SqlCommand("sp_SearchLoaiSanPhamByID", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maLoai", idProductType);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                productType = new LoaiSanPham(dta.GetString(0), dta.GetString(1));
                dta.Close();
                return productType;
            }
            dta.Close();
            return null;
        }

        //Tim kiem loai san pham theo ten loai san pham
        public LoaiSanPham searchLoaiSPByName(string productType_name)
        {
            LoaiSanPham productType = new LoaiSanPham();
            commandSql = new SqlCommand("sp_SearchLoaiSPByName", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@tenLoai", productType_name);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                productType = new LoaiSanPham(dta.GetString(0), dta.GetString(1));
                dta.Close();
                return productType;
            }
            dta.Close();
            return null;
        }

        //Update loai san pham duoc chon
        public int updateProductType(string productType_id, string productType_name)
        {
            commandSql = new SqlCommand("sp_UpdateLoaiSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maLoai", productType_id);
            commandSql.Parameters.AddWithValue("@tenLoai", productType_name);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Delete loai san pham duoc chon
        public int deleteProductType(string productType_id)
        {
            commandSql = new SqlCommand("sp_DeleteLoaiSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maLoai", productType_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Lay danh sach loai san pham tang dan theo ma loai san pham
        public ArrayList sortProductTypeByProductType_id()
        {
            listProductTypes = new ArrayList();
            dta = getAllDataFromTable("sp_SortLoaiSanPhamByMaLoai");
            while (dta.Read())
            {
                listProductTypes.Add(new LoaiSanPham(dta.GetString(0), dta.GetString(1)));
            }
            dta.Close();
            return listProductTypes;
        }

        //Lay danh sach loai san pham tang dan theo ten loai san pham
        public ArrayList sortProductTypeByProductType_name()
        {
            listProductTypes = new ArrayList();
            dta = getAllDataFromTable("sp_SortLoaiSanPhamByTenLoai");
            while (dta.Read())
            {
                listProductTypes.Add(new LoaiSanPham(dta.GetString(0), dta.GetString(1)));
            }
            dta.Close();
            return listProductTypes;
        }
    }
}
