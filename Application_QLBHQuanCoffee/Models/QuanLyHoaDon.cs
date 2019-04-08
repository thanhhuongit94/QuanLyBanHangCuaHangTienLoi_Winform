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
    class QuanLyHoaDon: Database
    {
        private ArrayList listInvoice;
        //Contructor
        public QuanLyHoaDon()
        {
            listInvoice = new ArrayList();
        }

        //Lay hoa don co tong tien = 0
        public HoaDon searchInvoiceHaveTotalMoneyIs0()
        {
            HoaDon hd = new HoaDon();
            commandSql = new SqlCommand("sp_SearchHoaDonByTongTien", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                hd = new HoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetDateTime(3));
                dta.Close();
                return hd;
            }
            dta.Close();
            return null;
        }
        
         //Lay danh sach hoa don 
        public ArrayList getAllDataInvoice()
        {
            ArrayList listHD = new ArrayList();
            commandSql = new SqlCommand("sp_SelectAllHoaDon", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                listHD.Add(new HoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetDateTime(3), dta.GetString(4)));
            }
            dta.Close();
            return listHD;
        }

        //Them 1 hoa don moi voi tong tien mac dinh la 0
        public void insertInvoice(string employee_id, DateTime ngayLapHD, string ghiChu)
        {
            commandSql = new SqlCommand("sp_InsertHoaDon", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", employee_id);
            commandSql.Parameters.AddWithValue("@ngayLapHD", ngayLapHD);
            commandSql.Parameters.AddWithValue("@ghiChu", ghiChu);
            commandSql.ExecuteNonQuery();
        }

        //Update hoa don
        public int updateInvoice(int invoice_id, string employee_id, double total, DateTime datetime, string note)
        {
            commandSql = new SqlCommand("sp_UpdateHoaDon", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            commandSql.Parameters.AddWithValue("@maNV", employee_id);
            commandSql.Parameters.AddWithValue("@tongTien", total);
            commandSql.Parameters.AddWithValue("@ngayLapHD", datetime);
            commandSql.Parameters.AddWithValue("@ghiChu", note); 
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Tim kiem hoa don theo ma nhan vien
        public ArrayList searchInvoiceByEmployee_id(string employee_id)
        {
            listInvoice = new ArrayList();
            commandSql = new SqlCommand("sp_SearchHoaDonByMaNV", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", employee_id);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                listInvoice.Add(new HoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetDateTime(3), dta.GetString(4)));
            }
            dta.Close();
            return listInvoice;
        }

        //Tim hoa don co tong tien lon hon 0
        public ArrayList searchInvoiceHaveTotalMoneyGreaterThan_0()
        {
            dta = getAllDataFromTable("sp_SearchHoaDonTongTienLonHon_0");
            while (dta.Read())
            {
               listInvoice.Add(new HoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetDateTime(3), dta.GetString(4)));
            }
            dta.Close();
            return listInvoice;
        }

        //Tim hoa don theo ma hoa don
        public HoaDon searchInvoiceByInvoice_id(int invoice_id)
        {
            HoaDon hd = new HoaDon();
            commandSql = new SqlCommand("sp_SearchHoaDonByMaHD", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                hd = new HoaDon(dta.GetInt32(0), dta.GetString(1), dta.GetDouble(2), dta.GetDateTime(3));
                dta.Close();
                return hd;
            }
            dta.Close();
            return null;
        }

        //Delete hoa don theo ma nhan vien
        public int deleteInvoiceByEmployee_id(string employee_id)
        {
            commandSql = new SqlCommand("sp_DeleteHoaDonByMaNV", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", employee_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Delete hoa don theo ma hoa don
        public int deleteInvoiceByInvoice_id(int invoice_id)
        {
            commandSql = new SqlCommand("sp_DeleteHoaDonByMaHD", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maHD", invoice_id);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }
    }
}
