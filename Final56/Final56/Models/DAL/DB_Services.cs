﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace APP1.Models.DAL
{
    public class DB_Services
    {

        public int Insert_Favorites(Favorites f)
        {
            
                SqlConnection con;
                SqlCommand cmd;

                try
                {
                    con = connect("DBConnectionString"); // create the connection
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

                String cStr = BuildInsertFavorites(f);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command

                try
                {
                    int numEffected = cmd.ExecuteNonQuery(); // execute the command
                    return numEffected;
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

                finally
                {
                    if (con != null)
                    {
                        // close the db connection
                        con.Close();
                    }
                }

            }



        

        private String BuildInsertFavorites(Favorites f)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", f.Email, f.UniversitySize, f.UniversityLevel,f.UniversityType, f.PriceMAX, f.Sit, f.Precent);
            String prefix = "INSERT INTO [Favorites] " + "(Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SIT, Precent)";
            command = prefix + sb.ToString();

            return command;

        }



        public int Login_User(string email,string password) {
           
                SqlConnection con = null;

                try
                {
                    con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                    String selectSTR = "SELECT * FROM Users where Users.Email='"+ email + " ' and Users.password='" + password+"'";
                    SqlCommand cmd = new SqlCommand(selectSTR, con);

                    // get a reader
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                    while (dr.Read())
                    {   // Read till the end of the data into a row
                    return Convert.ToInt32(dr["TypeUsers"]);
                    }
                    return -1;

                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
           

        }

        public List<Users> Show_User()
        {


             
                List<Users> allUsers = new List<Users>();
            return allUsers;
        }





        public int Insert_New_Users(Users u)
        {
           
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommandUsers(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
            
        }

        private String BuildInsertCommandUsers(Users u)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}')", u.Email.Replace("'", "''"), u.BirthDay, u.Sex, u.Phone, u.Password, u.LastName, u.FirstName);
            String prefix = "INSERT INTO Users " + "( Email , BirthDay , Sex ,Phone ,Password ,LastName ,FirstName) ";
            command = prefix + sb.ToString();

            return command;
        }

        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 60;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

    }
}


private String BuildInsertCustommand(Users user)
{
    String command;

    StringBuilder sb = new StringBuilder();

    // use a string builder to create the dynamic string
    sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}','{7}')", Users.FirstName, Users.FastName, Users.Email, Users.Password, Users.Phone, Users.TypeUsers, Users.BirthDay, Users.Sex);
    String prefix = "INSERT INTO [Users] " + "(FirstName, FastName, Email ,password ,phone, TypeUsers, sex)";
    command = prefix + sb.ToString();

    return command;

}