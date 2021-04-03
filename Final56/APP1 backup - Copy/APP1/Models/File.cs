﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class File
    {
        string filetype;
        string remark ;
        string fileName;
        int score;
        public File()
        {

        }
        public File(string filetype, string remark, string fileName, int score)
        {
            Filetype = filetype;
            Remark = remark;
            FileName = fileName;
            Score = score;
        }

        public string Filetype { get => filetype; set => filetype = value; }
        public string Remark { get => remark; set => remark = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public int Score { get => score; set => score = value; }
    }
}