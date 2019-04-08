using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangCoffee.Models
{
    class QuanLySanPham : Database
    {
        private ArrayList listProduct;
        //Contructor
        public QuanLySanPham()
        {
            listProduct = new ArrayList();
        }

        //Lay danh sach san pham
        public ArrayList getAllProducts()
        {
            listProduct = new ArrayList();
            dta = getAllDataFromTable("sp_SelectAllSanPham");
            while(dta.Read())
            {
                listProduct.Add(new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5)));
            }
            dta.Close();
            return listProduct;
        }

        //Tim san pham bang ma san pham
        public SanPham searchProductByID(string product_id)
        {
            SanPham product = new SanPham();
            commandSql = new SqlCommand("sp_SearchSanPhamByID", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                product = new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5));
                dta.Close();
                return product;
            }
            dta.Close();
            return null;
        }

        //Tim san pham bang ten san pham
        public SanPham searchProductByName(string product_name)
        {
            SanPham product = new SanPham();
            commandSql = new SqlCommand("sp_SearchSanPhamByName", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@tenSP", product_name);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                product = new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5));
                dta.Close();
                return product;
            }
            dta.Close();
            return null;
        }

        //Them san pham moi vao danh sach
        public int insertNewProduct(string product_id, string product_name, double product_price, int product_quality, string product_status, string productType_id)
        {
            commandSql = new SqlCommand("sp_InsertSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            commandSql.Parameters.AddWithValue("@tenSP", product_name);
            commandSql.Parameters.AddWithValue("@donGia", product_price);
            commandSql.Parameters.AddWithValue("@soLuong", product_quality);
            commandSql.Parameters.AddWithValue("@tinhTrang", product_status);
            commandSql.Parameters.AddWithValue("@maLoaiSP", productType_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Update san pham 
        public int updateProduct(string product_id, string product_name, double product_price, int product_quality, string product_status, string productType_id)
        {
            commandSql = new SqlCommand("sp_UpdateSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            commandSql.Parameters.AddWithValue("@tenSP", product_name);
            commandSql.Parameters.AddWithValue("@donGia", product_price);
            commandSql.Parameters.AddWithValue("@soLuong", product_quality);
            commandSql.Parameters.AddWithValue("@tinhTrang", product_status);
            commandSql.Parameters.AddWithValue("@maLoaiSP", productType_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Delete loai san pham duoc chon
        public int deleteProduct(string product_id)
        {
            commandSql = new SqlCommand("sp_DeleteSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Sap xep danh sach san pham tang dan theo ma san pham
        public ArrayList sortProductByProduct_id()
        {
            ArrayList list = new ArrayList();
            dta = getAllDataFromTable("sp_SortSanPhamASCByMaSP");
            while (dta.Read())
            {
                list.Add(new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5)));
            }
            dta.Close();
            return list;
        }

        //Sap xep danh sach san pham tang dan theo ten san pham
        public ArrayList sortProductByProduct_name()
        {
            ArrayList list = new ArrayList();
            dta = getAllDataFromTable("sp_SortSanPhamASCByTenSP");
            while (dta.Read())
            {
                list.Add(new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5)));
            }
            dta.Close();
            return list;
        }

        //Tim san pham bang ten san pham LIKE
        public ArrayList searchProductLIKEByName(string product_name)
        {
            ArrayList listProd = new ArrayList();
            commandSql = new SqlCommand("sp_SearchSanPhamByLikeProduct_name", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@tenSP", product_name);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                listProd.Add(new SanPham(dta.GetString(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetString(4), dta.GetString(5)));
            }
            dta.Close();
            return listProd;
        }

        //Tim san pham bang ma loai san pham
        public DataTable searchProduct(string productType_id)
        {
            commandSql = new SqlCommand("sp_SearchSanPhamByMaLoaiSP", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maLoaiSP", productType_id);
            SqlDataAdapter adapter = new SqlDataAdapter(commandSql);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        //Update so luong san pham
        public int updateAmountProduct(string product_id, int product_quality)
        {
            commandSql = new SqlCommand("sp_UpdateSoLuongSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            commandSql.Parameters.AddWithValue("@soLuong", product_quality);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Update tinh trang san pham
        public int updateProductStatus(string product_id, string product_status)
        {
            commandSql = new SqlCommand("sp_UpdateTinhTrangSanPham", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            commandSql.Parameters.AddWithValue("@tinhTrang", product_status);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }
    }
}
