using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class UsersLocale
    {
        int id;
        string email;
        string locale;

        public UsersLocale() { }

        public UsersLocale(int id, string email, string locale)
        {
            Id = id;
            Email = email;
            Locale = locale;
        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Locale { get => locale; set => locale = value; }

        public int Insert_arry_Locale(List<UsersLocale> ul)
        {
            DB_Services db = new DB_Services();
            return db.insert_arr_Locale(ul);
        }


        public List<UsersDistrict> get_User_Locale(string email)
        {
            DB_Services db = new DB_Services();
            return db.get_User_Locale(email);
        }

    }
    
}