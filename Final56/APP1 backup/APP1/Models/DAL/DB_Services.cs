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

        //public List<Favorites> Get_Favorites_By_email(string email)
        //{
        //    SqlConnection con = null;
        //    Favorites MY_Favorites = new Favorites(); ;

        //    try
        //    {
        //        con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

        //        String selectSTR = "SELECT * FROM Favorites where Favorites.email=" + email;
        //        SqlCommand cmd = new SqlCommand(selectSTR, con);

        //        // get a reader
        //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

        //        while (dr.Read())
        //        {   // Read till the end of the data into a row
        //            MY_Favorites.Email = (string)dr["Email"];
        //            MY_Favorites.UniversityType = Convert.ToInt32(dr["UniversityType"]);
        //            MY_Favorites.Precent = Convert.ToInt32(dr["Precent"]);
        //            MY_Favorites.PriceMAX = Convert.ToInt32(dr["PriceMAX"]);
        //            MY_Favorites.Sit = Convert.ToInt32(dr["Sit"]);
        //            MY_Favorites.UniversityLevel = Convert.ToInt32(dr["UniversityLevel"]);
        //            MY_Favorites.UniversitySize = Convert.ToInt32(dr["UniversitySize"]);
        //        }

        //        return MY_Favorites;
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //}
        //======================================================================
        //===============================District/region========================
        //======================================================================
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
        //======================================================================
        //===============================Locale========================
        //======================================================================
        public int Insert_arr_Locale(List<UsersLocale> us)
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

            String cStr = BuildInsertListUsersLocale(us);      // helper method to build the insert string

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
        private String BuildInsertListUsersLocale(List<UsersLocale> us)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < us.Count; i++)
            {
                if (i == 0)
                    sbud = "Values('" + us[i].Email + "', '" + us[i].Locale + "', '" + us[i].Id + "')";
                else
                {
                    tmp = ",('" + us[i].Email + "', '" + us[i].Locale + "', '" + us[i].Id + "')";
                    sbud = append(sbud, tmp);
                }
            }
            String prefix_UsersDistrict = "INSERT INTO [UsersLocale] " + "(Email,Locale, Id)";
            String delete = "DELETE FROM [UsersLocale] WHERE Email='" + us[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersLocale] WHERE Email = '" + us[0].Email + "' ) DELETE FROM [UsersLocale] WHERE Email = '" + us[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;
            return command;
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
                    ul.Id = (string)dr["Id"];



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
        //======================================================================
        //===============================State========================
        //======================================================================

        public List<University> getR()
        {
            List<University> list_of_div_school = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University Rank = new University();

                    Rank.UniversityLevel = (string)dr["UniversityLevel"];

                    list_of_div_school.Add(Rank);
                }
                return list_of_div_school;

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
        public List<University> getdiv()
        {
            List<University> list_of_div_school = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM [NCAAUniversities]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University div = new University();

                   div.UniversityLevel = (string)dr["UniversityLevel"];

                    list_of_div_school.Add(div);
                }
                return list_of_div_school;

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


        // getdiv()"SELECT * FROM [NCAAUniversities]";

        public List<UsersStates> get_User_States(string email)
        {
            List<UsersStates> list_of_user_States = new List<UsersStates>();
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
        //======================================================================
        //===============================Favorites========================
        //======================================================================
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
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", f.Email, f.UniversitySize, f.UniversityLevel, f.UniversityType, f.PriceMAX, f.Sat);
            String prefix = "INSERT INTO [UsersFavorites] " + "(Email,UniversitySize, UniversityLevel ,UniversityType ,PriceMAX, SAT)";

            prefix = "IF EXISTS(select* from UsersFavorites where email= '" + f.Email + "') begin UPDATE UsersFavorites SET UniversitySize = " + f.UniversitySize + " ,UniversityLevel ='" + f.UniversityLevel + "' ,UniversityType = '" + f.UniversityType + "',PriceMAX =" + f.PriceMAX + ",SAT = " + f.Sat + " WHERE Email = '" + f.Email + "' END else begin " + prefix ; 


            command = prefix + sb.ToString() + "end";

            return command;

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

        //======================================================================
        //===============================Users========================
        //======================================================================

        public List<Users> Show_Users()
        {
            List<Users> list_of_user= new List<Users>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users left JOIN UsersStatus ON Users.Email = UsersStatus.Email ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    Users ul = new Users();
                    ul.FirstName = (string)dr["FirstName"];
                    ul.Email = (string)dr["Email"];
                    ul.TypeUsers = Convert.ToInt32(dr["TypeUsers"]);
                    ul.Sex = (string)dr["sex"];
                    ul.LastName = (string)dr["LastName"];
                    ul.Phone = (string)dr["Phone"];
                    ul.Position = (string)dr["Position"];
                    ul.BirthDay = (DateTime)dr["birthDay"];
                    ul.Register = (DateTime)dr["Register"];
                    ul.Address = (string)dr["Address"];
                    ul.Password = (string)dr["Password"];
                    if (dr["Status"] == null)
                    {
                        ul.Status = (string)dr["Status"];

                    }
                    if (dr["Id"] == null)
                    {
                        ul.StatusId = Convert.ToInt32(dr["Id"]);
                    }

                

                    

                    list_of_user.Add(ul);
                }
                Users ule = new Users();
                return list_of_user;

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
        public int Login_User(string email, string password)
        {

            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users where Users.Email='" + email + " ' and Users.password='" + password + "'";
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

        private String BuildInsertCommandUsers(Users u)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            string status = "INSERT INTO UsersStatus (Email, Status, ID)Values('" + u.Email + "', 'candidate', 0)"; 
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}')", u.Email, u.BirthDay, u.Sex, u.Phone, u.Password, u.LastName, u.FirstName, u.TypeUsers, u.Position, DateTime.Now.ToString("MM/dd/yyyy HH:mm"));
            String prefix = "INSERT INTO Users " + "( Email , BirthDay , Sex ,Phone ,Password ,LastName ,FirstName, TypeUsers,Position,Register) ";
            command = prefix + sb.ToString();

            return command+ status;
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
            List<UsersDistrict> list_of_user_district = new List<UsersDistrict>();
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

        public Favorites Get_Favorites_By_email(string email)
        {
            Favorites uf = new Favorites();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from UsersFavorites where email='"+email+"'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    

                    uf.Email = (string)dr["Email"];
                    uf.UniversitySize = Convert.ToInt32(dr["UniversitySize"]);
                    uf.UniversityLevel = (string)dr["UniversityLevel"];
                    uf.PriceMAX = Convert.ToInt32(dr["PriceMAX"]);
                    uf.UniversityType = (string)dr["UniversityType"];
                    uf.Sat = Convert.ToInt32(dr["Sat"]);


                   
                }
                return uf;

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
        //======================================================================
        //===============================function========================
        //======================================================================


        public List<University> getWish(string email)
        {
            List<University> wishlist = new List<University>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from UsersUniversity where email='"+ email+"'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    University ul = new University();
                    ul.UniversityName = (string)dr["UniversityName"];
                    ul.Id = Convert.ToInt32(dr["id"]);
                    wishlist.Add(ul);
                }
                University ule = new University();
                return wishlist;

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












        public int SaveWishList(List <University> u)
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

            String cStr = BuildInsertWishList(u);      // helper method to build the insert string

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


        private String BuildInsertWishList(List <University> u)
        {
            String command;
            string tmp;
            string sbud = "";
            StringBuilder append_UsersDistrict = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < u.Count; i++)
            {
                if (i == 0) // הראשון
                    sbud = "Values('" + u[i].Email + "', '" + u[i].UniversityName + "', '" + u[i].Id + "')";
                else
                {
                    tmp = ",('" + u[i].Email + "', '" + u[i].UniversityName + "', '" + u[i].Id + "')";
                    sbud = append(sbud, tmp);

                }
            }



            String prefix_UsersDistrict = "INSERT INTO [UsersUniversity] " + "(Email,UniversityName, Id)";


            String delete = "DELETE FROM [UsersUniversity] WHERE Email='" + u[0].Email + "' ";
            delete = " IF EXISTS (SELECT * FROM [UsersUniversity] WHERE Email = '" + u[0].Email + "' ) DELETE FROM [UsersUniversity] WHERE Email = '" + u[0].Email + "'";
            command = delete + prefix_UsersDistrict + sbud;

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
        private String append(string str, string app)
        {
            string append;

            append = str + app;
            return append;
        }





        ////////////////////////////////////////
          public int Insert(File file)
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

            String cStr = BuildInsertCommand(file);      // helper method to build the insert string

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


        private String BuildInsertCommand(File file)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}')", file.Email, file.Filetype, file.Score, file.Remark, file.FileName.Replace("'", "''"));
            String prefix = "INSERT INTO UsersFile " + "( EMAIL , FILETYPE , SCORE ,REMARK ,FILENAME) ";
            command = prefix + sb.ToString();

            return command;
        }



        
        //public List<Users> ShowU()
        //{
        //    SqlConnection con = null;
        //    List<Campaign> userList = new List<Users>();

        //    try
        //    {
        //        con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

        //        String selectSTR = "SELECT * FROM [Users] ";
        //        SqlCommand cmd = new SqlCommand(selectSTR, con);

        //        // get a reader
        //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

        //        while (dr.Read())
        //        {   // Read till the end of the data into a row

        //            Users u = new Users();
                    
        //            u.Email = (string)dr["Email"];
        //            u.Email = (string)dr["Password"];
        //            u.FirstName = (string)dr["FirstName"];
        //            u.LastName = (string)dr["LastName"];
        //            u.Phone = (string)dr["Phone"];
        //            u.TypeUsers = Convert.ToInt32(dr["Type"]);
        //            u.BirthDay = Convert.ToDateTime(dr["BirthDay"]);
        //            u.Sex = (string)dr["Sex"];
                  

        //            userList.Add(u);

        //        }

        //        return userList;
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //}




        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

           cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

          cmd.CommandTimeout = 60;           // Time to wait for the execution' The default is 30 seconds

    cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

    return cmd;
        }


         public List<Users> Show()
        {
            SqlConnection con = null;
           // List<Users> uList = new List<Users>();             
            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Users c = new Users();

                    c.Email = (string)dr["Email"];
                    c.Password = (string)dr["Password"];
                    c.FirstName = (string)dr["FirstName"];
                    c.LastName = (string)dr["LastName"];
                    c.Phone = (string)dr["Phone"];
                    c.TypeUsers = Convert.ToInt32(dr["TypeUsers"]);
                    c.BirthDay =Convert.ToDateTime(dr["BirthDay"]);                  
                    c.Sex = (string)dr["Sex"];
                    c.Register = (string)dr["Register"];
                    c.Position =Convert.ToDateTime(dr["Position"]);
                    uList.Add(c);
                }

                return uList;
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