using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace QuanLyCuaHangCoffee.Models
{
    class Database
    {
        protected static SqlConnection conn = null;
        protected static string connectionString = @"Data Source=HQ\SQLEXPRESS;Initial Catalog=QuanLyCuaHangCoffee;Integrated Security=True";
        //protected static string connectionString = @"Data Source=B002C-41;Initial Catalog=QuanLyCuaHangCoffee;Integrated Security=True";
        protected static SqlCommand commandSql = null;
        protected static SqlDataReader dta = null;

        //Contructor : Ket noi CSDL
        protected Database()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch
            {
                string s = "Kết nối CSDL thất bại!";
                string t = "Thông báo!";
                MessageBox.Show(s, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Lay du lieu tu CSDL
        protected SqlDataReader getAllDataFromTable(string spName)
        {
            commandSql = new SqlCommand(spName, conn);
            commandSql.CommandType = CommandType.StoredProcedure;
            dta = commandSql.ExecuteReader();
            return dta;
        }
    }
}
