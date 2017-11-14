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
            string connectionPath = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
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

        public int AddNewUser(UserProfile userProfile)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_USER);
                stringSQL.Append(" VALUES (@firstName, @lastName, @email, @phone, @address, @course_id, @isActive, @isBlocked, @createAt," +
                    " @lastActiveAt, @userLevelID, @dob, @userTypeID, @imagePath, @userName, @password)");

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
                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
