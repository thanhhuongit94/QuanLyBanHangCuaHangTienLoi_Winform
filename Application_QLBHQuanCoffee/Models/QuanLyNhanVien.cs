using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using QuanLyCuaHangCoffee.Tools;

namespace QuanLyCuaHangCoffee.Models
{
    class QuanLyNhanVien: Database
    {
        ArrayList listEmployee;

        //Contructor
        public QuanLyNhanVien()
        {
            listEmployee = new ArrayList();
        }

        // Lay danh sach nhan vien
        public ArrayList getAllDataEmployees()
        {
            listEmployee = new ArrayList();
            dta = getAllDataFromTable("sp_SelectAllNhanVien");
            while (dta.Read())
            {
                listEmployee.Add(new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8)));
            }
            dta.Close();
            return listEmployee;
        }

        //Tim nhan vien bang CMND
        public NhanVien searchEmployeeByIDCard(string idCard)
        {
            NhanVien nv = new NhanVien();
            commandSql = new SqlCommand("sp_SelectOneNhanVienByCMND", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@CMND", idCard);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                nv = new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8));
                dta.Close();
                return nv;
            }
            dta.Close();
            return null;
        }

        //Insert nhan vien moi vao danh sach
        public int insertNewEmployee(string maNV, string tenNV, string gioiTinh, string CMND, string diaChi, string SDT, double heSoLuong, double luongCB, string username)
        {
            commandSql = new SqlCommand("sp_InsertNhanVien", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", maNV);
            commandSql.Parameters.AddWithValue("@tenNV", tenNV);
            commandSql.Parameters.AddWithValue("@gioiTinh", gioiTinh);
            commandSql.Parameters.AddWithValue("@CMND", CMND);
            commandSql.Parameters.AddWithValue("@diaChi", diaChi);
            commandSql.Parameters.AddWithValue("@SDT", SDT);
            commandSql.Parameters.AddWithValue("@heSoLuong", heSoLuong);
            commandSql.Parameters.AddWithValue("@luongCB", luongCB);
            commandSql.Parameters.AddWithValue("@username", username);
            return commandSql.ExecuteNonQuery();
        }

        //Update nhan vien duoc chon
        public int updateEmployee(string maNV, string tenNV, string gioiTinh, string CMND, string diaChi, string SDT, double heSoLuong, double luongCB)
        {
            commandSql = new SqlCommand("sp_UpdateNhanVien", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", maNV);
            commandSql.Parameters.AddWithValue("@tenNV", tenNV);
            commandSql.Parameters.AddWithValue("@gioiTinh", gioiTinh);
            commandSql.Parameters.AddWithValue("@CMND", CMND);
            commandSql.Parameters.AddWithValue("@diaChi", diaChi);
            commandSql.Parameters.AddWithValue("@SDT", SDT);
            commandSql.Parameters.AddWithValue("@heSoLuong", heSoLuong);
            commandSql.Parameters.AddWithValue("@luongCB", luongCB);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //delete nhan vien duoc chon
        public int deleteEmployee(string maNV)
        {
            commandSql = new SqlCommand("sp_DeleteNhanVien", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", maNV);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Tim nhan vien bang ma nhan vien
        public NhanVien searchEmployeeByMaNV(string idCard)
        {
            NhanVien nv = new NhanVien();
            commandSql = new SqlCommand("sp_SelectNhanVienByMaNV", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", idCard);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                nv = new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8));
                dta.Close();
                return nv;
            }
            dta.Close();
            return null;
        }

        //Tim nhan vien theo ten nhan vien dung like su dung trong tim kiem tuong doi
        public ArrayList searchEmployeeByLIKEname(string name)
        {
            ArrayList list = new ArrayList();
            commandSql = new SqlCommand("sp_SelectNhanVienByLIKEtenNV", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@tenNV", name);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                list.Add(new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8)));
            }
            dta.Close();
            return list;
        }

         //Tim nhan vien theo dia chi
        public ArrayList searchEmployeeByAddress(string address)
        {
            ArrayList list = new ArrayList();
            commandSql = new SqlCommand("sp_SelectNhanVienByAddress", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@diaChi", address);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                list.Add(new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8)));
            }
            dta.Close();
            return list;
        }

        //Tim nhan vien theo ma LIKE
        public ArrayList searchEmployeeLIKE_id(string employee_id)
        {
            ArrayList list = new ArrayList();
            commandSql = new SqlCommand("sp_SelectNhanVienLIKEMaNV", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", employee_id);
            dta = commandSql.ExecuteReader();
            while (dta.Read())
            {
                list.Add(new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8)));
            }
            dta.Close();
            return list;
        }

        //Tim nhan vien bang username
        public NhanVien searchEmployeeByUsername(string username)
        {
            NhanVien nv = new NhanVien();
            commandSql = new SqlCommand("sp_SearchNhanVienByUsername", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                nv = new NhanVien(dta.GetString(0), dta.GetString(1), dta.GetString(2), dta.GetString(3), dta.GetString(4), dta.GetString(5), dta.GetDouble(6), dta.GetDouble(7), dta.GetString(8));
                dta.Close();
                return nv;
            }
            dta.Close();
            return null;
        }

         //Update nhan vien khong update he so luong, luong co ban, username
        public int updateEmployeeExpectLuongCB_HSLuong(string maNV, string tenNV, string gioiTinh, string CMND, string diaChi, string SDT)
        {
            commandSql = new SqlCommand("sp_UpdateNhanVienLoaiTruLuongCB_HSLuong", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@maNV", maNV);
            commandSql.Parameters.AddWithValue("@tenNV", tenNV);
            commandSql.Parameters.AddWithValue("@gioiTinh", gioiTinh);
            commandSql.Parameters.AddWithValue("@CMND", CMND);
            commandSql.Parameters.AddWithValue("@diaChi", diaChi);
            commandSql.Parameters.AddWithValue("@SDT", SDT);
            int result = commandSql.ExecuteNonQuery();
            return result;
        }

        //Sap xep tang dan theo ten nhan vien
        public ArrayList sortASCByName()
        {
            listEmployee.Sort(new SortByName());
            return listEmployee;
        }
    }
}
