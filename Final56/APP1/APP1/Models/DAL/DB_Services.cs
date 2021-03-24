using System;
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


        public void Insert_University_Email (List<University> IUE)
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
            String delete = "DELETE FROM [UsersUniversity] WHERE Email=" + IUE[0].Email+ " ";
            command = delete +" "+ prefix + sb.ToString();

            return command;

        

    }
        public Favorites Get_Favorites_By_email(string email)
        {
            SqlConnection con = null;
            Favorites MY_Favorites=new Favorites(); ;

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

            StringBuilder sb = new StringBuilder();
            StringBuilder append = new StringBuilder();
            // use a string builder to create the dynamic string
            for (int i = 0; i < ud.Count; i++)
            {
                append.Append(sb.AppendFormat("Values('{0}', '{1}', '{2}')", ud[i].Email, ud[i].District, ud[i].Id));
            }

            String prefix = "INSERT INTO [UsersDistrict] " + "(Email,District, Id)";
            String delete = "DELETE FROM [UsersDistrict] WHERE Email=" + ud[0].Email + " ";
            command = delete + prefix + append.ToString();

            return command;

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

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            for (int i = 0; i < us.Count; i++)
            {
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", us[i].Email, us[i].States, us[i].Id);
            }

            String prefix = "INSERT INTO [UsersStates] " + "(Email,District, Id)";
            String delete = "DELETE FROM [UsersStates] WHERE Email=" + us[0].Email + " ";
            command = prefix + sb.ToString();

            return command;

        }






        private String BuildInsertFavorites(Favorites f)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", f.Email, f.UniversitySize, f.UniversityLevel, f.UniversityType, f.PriceMAX, f.Sit, f.Precent);
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
            sb.AppendFormat("Values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}')", u.Email, u.BirthDay, u.Sex, u.Phone, u.Password, u.LastName, u.FirstName,u.TypeUsers);
            String prefix = "INSERT INTO Users " + "( Email , BirthDay , Sex ,Phone ,Password ,LastName ,FirstName, TypeUsers) ";
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