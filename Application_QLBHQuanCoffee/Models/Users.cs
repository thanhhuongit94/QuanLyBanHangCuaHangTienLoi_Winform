/*
 * Program: Define User class
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
    class Users
    {
        //Properties
        private string username;
        private string password;
        private int levelUser;

        //Contructor
        public Users() { }

        //Contructor has argument
        public Users(string username , string password, int level)
        {
            this.username = username;
            this.password = password;
            this.levelUser = level;
        }

        //Getter and setter 
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int LevelUser
        {
            get { return levelUser; }
            set { levelUser = value; }
        }
    }
}
