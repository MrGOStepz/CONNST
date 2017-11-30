using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace DataAccessLayer
{
    public class UserDAO
    {
        private MySqlConnection _conn;

        private const string TABLE_USER = "tb_user";
        private const string TABLE_USER_TYPE = "tb_user_type";
        private const string TABLE_USER_LEVEL = "tb_user_level";

        private const string TABLE_POST = "tb_post";
        private const string TABLE_POST_TYPE = "tb_post_type";
        private const string TABLE_POST_REPORT = "tb_post_report";

        private const string TABLE_MESSAGE = "tb_message";
        private const string TABLE_MESSAGE_TYPE = "tb_message_type";

        private const string TABLE_GROUP = "tb_group";
        private const string TABLE_GROUP_CHAT = "tb_group_chat";
        private const string TABLE_DELETE_GROUP_CHAT = "tb_delete_group_chat";

        private const string TABLE_APPROVE_STATUS = "tb_approve_status";
        private const string TABLE_COURSE = "tb_course";


        private void DatabaseOpen()
        {
            string connectionPath = "server=localhost;user id=root;persistsecurityinfo=True;database=connstdb;password=G4856162651O;";//ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //string connectionPath = ConfigurationManager.AppSettings["database"];
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        private void DatabaseClose()
        {
            _conn.Close();
        }

        public DataTable GetListOfUser()
        {
            try
            {
                DatabaseOpen();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_user", _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable GetUserType()
        {
            try
            {
                DatabaseOpen();
                string stringSQL = String.Format("SELECT name FROM {0}", TABLE_USER_TYPE);
                MySqlCommand cmd = new MySqlCommand(stringSQL, _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetUserLevel()
        {
            try
            {
                DatabaseOpen();
                string stringSQL = String.Format("SELECT * FROM {0}", TABLE_USER_LEVEL);
                MySqlCommand cmd = new MySqlCommand(stringSQL, _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public int AddNewUser(UserProfile userProfile)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" (first_name, last_name, email, phone, address, course_id, is_active, is_blocked, create_at," +
                    " last_active_at, user_level_id, dob, user_type_id, image, username, password)");
                stringSQL.Append(" VALUES (@firstName, @lastName, @email, @phone, @address, @course_id, @isActive, @isBlocked, @createAt," +
                    " @lastActiveAt, @userLevelID, @dob, @userTypeID, @imagePath, @userName, @password);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", userProfile.FirstName);
                cmd.Parameters.AddWithValue("@lastName", userProfile.LastName);
                cmd.Parameters.AddWithValue("@email", userProfile.Email);
                cmd.Parameters.AddWithValue("@phone", userProfile.Phone);
                cmd.Parameters.AddWithValue("@address", userProfile.Address);
                cmd.Parameters.AddWithValue("@course_id", userProfile.CourseID);
                cmd.Parameters.AddWithValue("@isActive", userProfile.IsActive);
                cmd.Parameters.AddWithValue("@isBlocked", userProfile.IsBlocked);
                cmd.Parameters.AddWithValue("@createAt", userProfile.CreateTime);
                cmd.Parameters.AddWithValue("@lastActiveAt", userProfile.LastActiveTime);
                cmd.Parameters.AddWithValue("@userLevelID", userProfile.UserLevelID);
                cmd.Parameters.AddWithValue("@dob", userProfile.DateOfBirth);
                cmd.Parameters.AddWithValue("@userTypeID", userProfile.UserTypeID);
                cmd.Parameters.AddWithValue("@imagePath", userProfile.ImagePath);
                cmd.Parameters.AddWithValue("@userName", userProfile.UserName);
                cmd.Parameters.AddWithValue("@password", userProfile.Password);

                //stringSQL.Append("INSERT INTO ");
                //stringSQL.Append(TABLE_USER);
                ////stringSQL.Append(" (first_name, last_name, email, phone, address, course_id, is_active, is_blocked, create_at," +
                ////    " last_active_id, dob, user_type_id, image, username, password)");
                //stringSQL.AppendFormat(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}," +
                //    " {9}, {10}, {11}, {12}, '{13}', '{14}', '{15}');",userProfile.FirstName,userProfile.LastName,userProfile.Email,userProfile.Phone,userProfile.Address
                //    ,userProfile.CourseID,userProfile.IsActive,userProfile.IsBlocked,userProfile.CreateTime,userProfile.LastActiveTime,userProfile.UserLevelID,userProfile.DateOfBirth
                //    ,userProfile.UserTypeID,userProfile.ImagePath,userProfile.UserName,userProfile.Password);

                //MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateNewPassword(int userID, string newPassword)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" SET password = @password");
                stringSQL.Append(" WHERE user_id = @userID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@password", newPassword);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateUserLastActiveByUserID(int userID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" SET last_active_at = @dateTimeNow");
                stringSQL.Append(" WHERE user_id = @userID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@dateTimeNow", DateTime.Now.ToString("yyyy-MM-d HH:mm:ss"));
                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateProfilebyUserID(UserProfile userProfile)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" SET first_name = @firstName, last_name = @lastName, email = @email, phone = @phone, address = @address" +
                    ", last_active_at = @lastActiveAt, dob = @dob, image = @imagePath ");
                stringSQL.Append("WHERE user_id = @userID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", userProfile.FirstName);
                cmd.Parameters.AddWithValue("@lastName", userProfile.LastName);
                cmd.Parameters.AddWithValue("@email", userProfile.Email);
                cmd.Parameters.AddWithValue("@phone", userProfile.Phone);
                cmd.Parameters.AddWithValue("@address", userProfile.Address);
                cmd.Parameters.AddWithValue("@lastActiveAt", userProfile.LastActiveTime);
                cmd.Parameters.AddWithValue("@dob", userProfile.DateOfBirth);
                cmd.Parameters.AddWithValue("@imagePath", userProfile.ImagePath);
                //cmd.Parameters.AddWithValue("@password", userProfile.Password);
                cmd.Parameters.AddWithValue("@userID", userProfile.UserID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetUserIDbyUserName(string userName)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                int userID = -1;
                DatabaseOpen();
                stringSQL.Append("SELECT user_id FROM ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" WHERE username LIKE @userName");
                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userID = (int)reader["user_id"];
                }
                cmd.Dispose();
                DatabaseClose();

                return userID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int GetUserIDbyUserAndPW(string userName, string password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                int userID = -1;
                DatabaseOpen();
                stringSQL.Append("SELECT user_id FROM ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" WHERE username LIKE @userName AND password LIKE @password");
                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userID = (int)reader["user_id"];
                }
                cmd.Dispose();
                DatabaseClose();

                return userID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }

}
