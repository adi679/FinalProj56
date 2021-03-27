using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace APP1.Models.DAL
{
    public class DB_Services
    {

        //===============================University========================
        public void Insert_University_Email(List<University> IUE)
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

            String cStr = BuildInsert_University_Email(IUE);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command

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

        private String BuildInsert_University_Email(List<University> IUE)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            for (int i = 0; i < IUE.Count; i++)
            {
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", IUE[i].Email, IUE[i].UniversityName, IUE[i].Id);
            }

            String prefix = "INSERT INTO [UsersUniversity] " + "(Email,UniversityName, Id)";
            String delete = "DELETE FROM [UsersUniversity] WHERE Email=" + IUE[0].Email + " ";
            command = delete + " " + prefix + sb.ToString();

            return command;



        }

        //===============================Favorites========================

        public Favorites Get_Favorites_By_email(string email)
        {
            SqlConnection con = null;
            Favorites MY_Favorites = new Favorites(); ;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Favorites where Favorites.email=" + email;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    MY_Favorites.Email = (string)dr["Email"];
                    MY_Favorites.UniversityType = Convert.ToInt32(dr["UniversityType"]);
                    MY_Favorites.Precent = Convert.ToInt32(dr["Precent"]);
                    MY_Favorites.PriceMAX = Convert.ToInt32(dr["PriceMAX"]);
                    MY_Favorites.Sit = Convert.ToInt32(dr["Sit"]);
                    MY_Favorites.UniversityLevel = Convert.ToInt32(dr["UniversityLevel"]);
                    MY_Favorites.UniversitySize = Convert.ToInt32(dr["UniversitySize"]);
                }

                return MY_Favorites;
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
        //===============================District/region========================
        public int insert_arr_region(List<UsersDistrict> ud)
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

            String cStr = BuildInsertListUsersDistrict(ud);      // helper method to build the insert string

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

        private String BuildInsertListUsersDistrict(List<UsersDistrict> ud)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < ud.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + ud[i].Email + "', '" + ud[i].District + "', '" + ud[i].Id + "')";
                else
                {
                    tmp = ",('" + ud[i].Email + "', '" + ud[i].District + "', '" + ud[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersDistrict] " + "(Email,District, Id)";


            String delete = "DELETE FROM [UsersDistrict] WHERE Email='" + ud[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersDistrict] WHERE Email = '" + ud[0].Email + "' ) DELETE FROM [UsersDistrict] WHERE Email = '" + ud[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;

        }





        //===============================Locale========================
        public int insert_arr_Locale(List<UsersLocale> ul)
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

            String cStr = BuildInsertListUsersLocale(ul);      // helper method to build the insert string

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

        private String BuildInsertListUsersLocale(List<UsersLocale> ul)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < ul.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + ul[i].Email + "', '" + ul[i].Locale + "', '" + ul[i].Id + "')";
                else
                {
                    tmp = ",('" + ul[i].Email + "', '" + ul[i].Locale + "', '" + ul[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersLocale] " + "(Email,Locale, Id)";


            String delete = "DELETE FROM [UsersLocale] WHERE Email='" + ul[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersLocale] WHERE Email = '" + ul[0].Email + "' ) DELETE FROM [UsersLocale] WHERE Email = '" + ul[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;

        }









        //===============================State========================


        public int Insert_arr_states(List<UsersStates> us)
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

            String cStr = BuildInsertListUsersStates(us);      // helper method to build the insert string

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

        private String BuildInsertListUsersStates(List<UsersStates> us)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < us.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + us[i].Email + "', '" + us[i].States + "', '" + us[i].Id + "')";
                else
                {
                    tmp = ",('" + us[i].Email + "', '" + us[i].States + "', '" + us[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersStates] " + "(Email,States, Id)";


            String delete = "DELETE FROM [UsersStates] WHERE Email='" + us[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersStates] WHERE Email = '" + us[0].Email + "' ) DELETE FROM [UsersStates] WHERE Email = '" + us[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

            return command;

        }








        //===============================Favorites========================



        private String BuildInsertFavorites(Favorites f)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", f.Email, f.UniversitySize, f.UniversityLevel, f.UniversityType, f.PriceMAX, f.Sit);
            String prefix = "INSERT INTO [[UsersFavorites] " + "(Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SIT)";
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


        public int getDivision(int d)
        {

            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities] where Division='" + d;
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


        public List<UsersDistrict> get_User_district(string email)
        {
            List <UsersDistrict>  list_of_user_district = new List <UsersDistrict>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersDistrict where UsersDistrict.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersDistrict ud = new UsersDistrict();

                    ud.District = (string)dr["District"];
                    ud.Email = (string)dr["Email"];
                    ud.Id = Convert.ToInt32(dr["Id"]);
                   


                    list_of_user_district.Add(ud);
                }
                return list_of_user_district;

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



        public List<UsersLocale> get_User_Locale(string email)
        {
            List<UsersLocale> list_of_user_locale = new List<UsersLocale>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersLocale where UsersLocale.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersLocale ul = new UsersLocale();

                    ul.Locale = (string)dr["Locale"];
                    ul.Email = (string)dr["Email"];
                    ul.Id = Convert.ToInt32(dr["Id"]);



                    list_of_user_locale.Add(ul);
                }
                return list_of_user_locale;

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



        public List<UsersStates> get_User_States(string email)
        {
            List <UsersStates>  list_of_user_States = new List <UsersStates>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM UsersStates where UsersStates.Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    UsersStates us = new UsersStates();

                    us.States = (string)dr["States"];
                    us.Email = (string)dr["Email"];
                    us.Id = Convert.ToInt32(dr["Id"]);
                   


                    list_of_user_States.Add(us);
                }
                return list_of_user_States;

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

        public List<Favorites> get_User_fav(int UniversityLevel)
        {
            List<Favorites> list_of_user_fav = new List<Favorites>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities] where NCAAUniversities.Division='" + UniversityLevel + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    Favorites uf = new Favorites();

                    uf.Email = (string)dr["Email"];
                    uf.Price = Convert.ToInt32(dr["Id"]);
                    uf.UniversitySize = Convert.ToInt32(dr["Id"]);
                    uf.UniversityLevel = Convert.ToInt32(dr["Id"]);
                    uf.PriceMAX = Convert.ToInt32(dr["Id"]);
                    uf.UniversityType = Convert.ToInt32(dr["Id"]);
                    uf.Sit = Convert.ToInt32(dr["Id"]);
                    uf.Precent = Convert.ToInt32(dr["Id"]);


                    list_of_user_fav.Add(uf);
                }
                return list_of_user_fav;

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





        private String BuildInsertCommandUsers(Users u)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}')", u.Email, u.BirthDay, u.Sex, u.Phone, u.Password, u.LastName, u.FirstName,u.TypeUsers);
            String prefix = "INSERT INTO Users " + "( Email , BirthDay , Sex ,Phone ,Password ,LastName ,FirstName, TypeUsers) ";
            command = prefix + sb.ToString();

            return command;
        }



        //===============================function========================
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
        private String append(string str, string app)
        {
            string append;

            append = str + app;
            return append;
        }

    }
}