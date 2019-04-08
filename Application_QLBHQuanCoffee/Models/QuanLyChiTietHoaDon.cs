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
    class QuanLyChiTietHoaDon: Database
    {
        private ArrayList listCTHD;
        //Contructor
        public QuanLyChiTietHoaDon()
        {
            listCTHD = new ArrayList();
        }

        //Lay danh sach cac chi tiet hoa don
        public int insertNewInvoiceDetail(int invoice_id, string product_id, double price, int quality, double total)
        {
            commandSql = new SqlCommand("sp_InsertChiTietHD", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            commandSql.Parameters.AddWithValue("@maSP", product_id);
            commandSql.Parameters.AddWithValue("@donGia", price);
            commandSql.Parameters.AddWithValue("@soLuong", quality);
            commandSql.Parameters.AddWithValue("@thanhTien", total);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Tim cac chi tiet hoa don thuoc ma hoa don can tim
        public ArrayList searchInvoiceDetailByInvoice_id(int invoice_id)
        {
            listCTHD = new ArrayList();
            commandSql = new SqlCommand("sp_SelectChiTietHDByInvoiceID", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                listCTHD.Add(new ChiTietHoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetDouble(4)));
            }
            dta.Close();
            return listCTHD;
        }

        //Lay toan bo danh sach cac chi tiet hoa don
        public ArrayList getAllDataInvoiceDetails()
        {
            listCTHD = new ArrayList();
            commandSql = new SqlCommand("sp_SelectChiTietHD", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                listCTHD.Add(new ChiTietHoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetInt32(3), dta.GetDouble(4)));
            }
            dta.Close();
            return listCTHD;
        } 

        //Delete cac chi tiet hoa don theo ma hoa don
        public int deleteInvoiceDetailByInvoice_id(int invoice_id)
        {
            commandSql = new SqlCommand("sp_DeleteChiTietHDByMaHD", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }
    }
}
