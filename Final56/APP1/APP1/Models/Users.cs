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
        string fastName;
        string phone ;
         int typeUsers;
        DateTime birthDay;
        string sex;
        public Users()
        {

        }
        public Users(string email, string password, string firstName, string fastName, string phone, int typeUsers, DateTime birthDay, string sex)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            FastName = fastName;
            Phone = phone;
            TypeUsers = typeUsers;
            BirthDay = birthDay;
            Sex = sex;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FastName { get => fastName; set => fastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public int TypeUsers { get => typeUsers; set => typeUsers = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string Sex { get => sex; set => sex = value; }
    }
    public void Insert()
    {
        //DBServices dbs = new DBServices();
        //dbs.Insert(this);
    }
}