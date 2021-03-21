using APP1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Favorites
    {
        string email;
        int price;
        int universitySize;
        int universityLevel;
        int priceMAX;
        int universityType;
        int sit;
        int precent;
        public Favorites(){ }
        public Favorites(string email,int price, int universitySize, int universityLevel, int priceMAX, int universityType, int sit, int precent)
        {
            Email = email;
            Price = price;
            UniversitySize = universitySize;
            UniversityLevel = universityLevel;
            PriceMAX = priceMAX;
            UniversityType = universityType;
            Sit = sit;
            Precent = precent;
            
        }

        public int Price { get => price; set => price = value; }
        public int UniversitySize { get => universitySize; set => universitySize = value; }
        public int UniversityLevel { get => universityLevel; set => universityLevel = value; }
        public int PriceMAX { get => priceMAX; set => priceMAX = value; }
        public int UniversityType { get => universityType; set => universityType = value; }
        public int Sit { get => sit; set => sit = value; }
        public int Precent { get => precent; set => precent = value; }
        public string Email { get => email; set => email = value; }

        public int Insert_Favorites(Favorites f)
        {
            DB_Services dbs = new DB_Services();

            return dbs.Insert_Favorites(f);
        }
    }
}