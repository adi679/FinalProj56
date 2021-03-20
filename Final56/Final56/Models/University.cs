using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class University
    {

        string universityName;
        string states;
        string district;
        string url;
        int priceMAX ;
        int priceMIN;
        int universitySize;
        int universityLevel;
        int zip;
        public University()
        {

        }
        public University(string universityName, string states, string district, string url, int priceMAX, int priceMIN, int universitySize, int universityLevel, int zip)
        {
            UniversityName = universityName;
            States = states;
            District = district;
            Url = url;
            PriceMAX = priceMAX;
            PriceMIN = priceMIN;
            UniversitySize = universitySize;
            UniversityLevel = universityLevel;
            Zip = zip;
        }

        public string UniversityName { get => universityName; set => universityName = value; }
        public string States { get => states; set => states = value; }
        public string District { get => district; set => district = value; }
        public string Url { get => url; set => url = value; }
        public int PriceMAX { get => priceMAX; set => priceMAX = value; }
        public int PriceMIN { get => priceMIN; set => priceMIN = value; }
        public int UniversitySize { get => universitySize; set => universitySize = value; }
        public int UniversityLevel { get => universityLevel; set => universityLevel = value; }
        public int Zip { get => zip; set => zip = value; }
    }
}