using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class File
    {
        string email;
        string filetype;
        string remark ;
        string fileName;
        int score;
        public File()
        {

        }
        public File(string filetype, string remark, string fileName, int score,string email)
        {
            Filetype = filetype;
            Remark = remark;
            FileName = fileName;
            Score = score;
            Email = email;
        }

        public string Filetype { get => filetype; set => filetype = value; }
        public string Remark { get => remark; set => remark = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public int Score { get => score; set => score = value; }
        public string Email { get => email; set => email = value; }
    }
    

    //public int SaveFiles(List<File> f)
    //{
    //    DB_Services dbs = new DB_Services();

    //    return dbs.SaveFiles(f);
    //}




}