using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Users
    {
        string email;
        string password;
        string firstName;
        string lastName;
        string phone;
        int typeUsers;
        DateTime birthDay;
        string sex;
        public Users()
        {

        }
        public Users(string email, string password, string firstName, string lastName, string phone, int typeUsers, DateTime birthDay, string sex)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            TypeUsers = typeUsers;
            BirthDay = birthDay;
            Sex = sex;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public int TypeUsers { get => typeUsers; set => typeUsers = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string Sex { get => sex; set => sex = value; }

        public int Insert_New_Users(Users u)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_New_Users(u);
        }
        //public List<Users> Show_Users()
        //{

        //    DB_Services dbs = new DB_Services();
        //    List<Users> cList = dbs.Show_Users();
        //    return cList;

        //}
        public int Login_User(string email, string password)
        {
            DB_Services dbs = new DB_Services();
            
            return dbs.Login_User(email, password); ;

        }
    }
}