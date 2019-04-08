using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangCoffee.Models
{
    class QuanLyUsers: Database
    {
        private ArrayList listUsers;

        //Contructor
        public QuanLyUsers()
        {
            listUsers = new ArrayList();
        }

        //Lay danh sach Users
        public ArrayList getAllUsers()
        {
            listUsers = new ArrayList();
            dta = getAllDataFromTable("sp_SelectAllUsers");
            while (dta.Read())
            {
                listUsers.Add(new Users(dta.GetString(0), dta.GetString(1), dta.GetInt32(2)));
            }
            dta.Close();
            return listUsers;
        }

        //Lay 1 user theo dieu kien (kiem tra dieu kien dang nhap)
        public Users getOneUser(string username, string password, int level)
        {
            Users user = new Users();
            commandSql = new SqlCommand("sp_SelectOneUser", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            commandSql.Parameters.AddWithValue("@password", password);
            commandSql.Parameters.AddWithValue("@levelUser", level);
            dta = commandSql.ExecuteReader();
            if(dta.Read())
            {
                user = new Users(dta.GetString(0), dta.GetString(1), dta.GetInt32(2));
                dta.Close();
                return user;
            }
            dta.Close();
            return null;
        }

        //Tim kiem 1 user theo username
        public Users getOneUserByUsername(string username)
        {
            Users user = new Users();
            commandSql = new SqlCommand("sp_SearchUserByUsername", conn);
            commandSql.CommandType = System.Data.CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            dta = commandSql.ExecuteReader();
            if (dta.Read())
            {
                user = new Users(dta.GetString(0), dta.GetString(1), dta.GetInt32(2));
                dta.Close();
                return user;
            }
            dta.Close();
            return null;
        }

        //Them 1 user moi vao danh sach Users
        public int insertDataUser(string username, string password, int level)
        {
            commandSql = new SqlCommand("sp_InsertUsers", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            commandSql.Parameters.AddWithValue("@password", password);
            commandSql.Parameters.AddWithValue("@levelUser", level);
            int result = commandSql.ExecuteNonQuery();//Thuc thi
            return result;
        }

        //Update du lieu cho 1 user duoc chon (chi duoc phep update password)
        public int updatePasswordUser(string username, string password)
        {
            commandSql = new SqlCommand("sp_UpdateUser", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            commandSql.Parameters.AddWithValue("@password", password);
            int result = commandSql.ExecuteNonQuery();//Thuc thi
            return result;
        }

        /*Delete du lieu user duoc chon(khong duoc phep delete tai khoan admin)
        va khong duoc xoa tai khoan cua nhan vien dang ton tai*/
        public int deleteUser(string username)
        {
            commandSql = new SqlCommand("sp_DeleteUser", conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            commandSql.Parameters.AddWithValue("@username", username);
            int result = commandSql.ExecuteNonQuery();//Thuc thi
            return result;
        }
    }
    
}
