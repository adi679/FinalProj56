using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class ToDoList
    {
        string email;
        string task;
        DateTime dueDate;
        public ToDoList()
        {
            
        }
        public ToDoList(string email, string task, DateTime dueDate)
        {
            Email = email;
            Task = task;
            DueDate = dueDate;
        }

        public string Email { get => email; set => email = value; }
        public string Task { get => task; set => task = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public List<ToDoList> get_User_ToDoList(string email)
        {
            List<ToDoList> t = new List<ToDoList>();
            return t;
        }
    }
}