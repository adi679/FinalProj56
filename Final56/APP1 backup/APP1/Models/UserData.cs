using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class UserData
    {
        string gender;
        string email;
        int national;
        int Cnational;
        int league;
        int champions;
        int cups;
        int tofel;
        int sat;
        float gpa;
        string position;
        int goals;
        int assists;
        int gametime;
        int shootsToGoal;
        int dribel;
        int acuuratePasses;
        int tackels;
        int yellowCards;
        int redCards;
        int showes;

        public UserData(string gender, string email, int national, int cnational1, int league, int champions, int cups, int tofel, int sat, float gpa, string position, int goals, int assists, int gametime, int shootsToGoal, int dribel, int acuuratePasses, int tackels, int yellowCards, int redCards, int showes)
        {
            Gender = gender;
            Email = email;
            National = national;
            Cnational1 = cnational1;
            League = league;
            Champions = champions;
            Cups = cups;
            Tofel = tofel;
            Sat = sat;
            Gpa = gpa;
            Position = position;
            Goals = goals;
            Assists = assists;
            Gametime = gametime;
            ShootsToGoal = shootsToGoal;
            Dribel = dribel;
            AcuuratePasses = acuuratePasses;
            Tackels = tackels;
            YellowCards = yellowCards;
            RedCards = redCards;
            Showes = showes;
        }

        public UserData() {}

    public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public int National { get => national; set => national = value; }
        public int Cnational1 { get => Cnational; set => Cnational = value; }
        public int League { get => league; set => league = value; }
        public int Champions { get => champions; set => champions = value; }
        public int Cups { get => cups; set => cups = value; }
        public int Tofel { get => tofel; set => tofel = value; }
        public int Sat { get => sat; set => sat = value; }
        public float Gpa { get => gpa; set => gpa = value; }
        public string Position { get => position; set => position = value; }
        public int Goals { get => goals; set => goals = value; }
        public int Assists { get => assists; set => assists = value; }
        public int Gametime { get => gametime; set => gametime = value; }
        public int ShootsToGoal { get => shootsToGoal; set => shootsToGoal = value; }
        public int Dribel { get => dribel; set => dribel = value; }
        public int AcuuratePasses { get => acuuratePasses; set => acuuratePasses = value; }
        public int Tackels { get => tackels; set => tackels = value; }
        public int YellowCards { get => yellowCards; set => yellowCards = value; }
        public int RedCards { get => redCards; set => redCards = value; }
        public int Showes { get => showes; set => showes = value; }


    }
}