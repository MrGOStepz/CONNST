using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class PostDAO
    {
        private MySqlConnection _conn;

        private const string TABLE_USER = "tb_user";
        private const string TABLE_USER_TYPE = "tb_user_type";
        private const string TABLE_USER_LEVEL = "tb_user_level";

        private const string TABLE_POST = "tb_post";
        private const string TABLE_POST_TYPE = "tb_post_type";
        private const string TABLE_POST_REPORT = "tb_post_report";
        private const string TABLE_POST_DELETE = "tb_post_delete";

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

        public DataTable GetListOfPost()
        {
            try
            {
                DatabaseOpen();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_post", _conn);
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

        public DataTable GetListOfActivePost()
        {
            try
            {
                DatabaseOpen();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_post AS PT LEFT JOIN tb_post_delete AS PTD ON PT.post_id <> PTD.post_id WHERE approve_status_id = 1;", _conn);
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

        public DataTable GetListOfDeletePost()
        {
            try
            {
                DatabaseOpen();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_post_delete;", _conn);
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

        public DataTable GetListOfReportPost()
        {
            try
            {
                DatabaseOpen();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_post_report;", _conn);
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

        public int AddNewPost(PostDetail postDetail)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_POST);
                stringSQL.Append(" (user_id, post_at, edit_at, title_name, description, post_type_id, is_active, is_blocked, approve_status_id)");
                stringSQL.Append(" VALUES (@userID, @postDate, @editDate, @titleName, @description, @postType, @isActive, @isBlocked, @approveStatus);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@userID", postDetail.UserID);
                cmd.Parameters.AddWithValue("@postDate", postDetail.PostDate);
                cmd.Parameters.AddWithValue("@editDate", postDetail.EditDate);
                cmd.Parameters.AddWithValue("@titleName", postDetail.Title);
                cmd.Parameters.AddWithValue("@description", postDetail.Description);
                cmd.Parameters.AddWithValue("@postType", postDetail.PostType);
                cmd.Parameters.AddWithValue("@isActive", postDetail.IsActive);
                cmd.Parameters.AddWithValue("@isBlocked", postDetail.IsBlocked);
                cmd.Parameters.AddWithValue("@approveStatus", postDetail.ApproveStatus);

                cmd.ExecuteNonQuery();

                DatabaseClose();

                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int ReportPostbyPostID(int postID, int userID, string reportDetail, string reportDate)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_POST_REPORT);
                stringSQL.Append(" (post_id, user_id, report_detail, report_at, is_checked)");
                stringSQL.Append(" VALUES (@postID, @userID, @reportDetail, @reportAt), @isChecked;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@postID", postID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@reportDetail", reportDetail);
                cmd.Parameters.AddWithValue("@reportAt", reportDate);
                cmd.Parameters.AddWithValue("@isChecked", 0);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int EditPostbyUserID(PostDetail postDetail)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_POST);
                stringSQL.Append(" SET title_name = @titleName, description = @description, post_type_id = @postTypeID, is_active = @isActive, isBlocked = @isBlocked, approve_status_id = @approveStatus");
                stringSQL.Append(" WHERE post_id = @postID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@titleName", postDetail.Title);
                cmd.Parameters.AddWithValue("@description", postDetail.Description);
                cmd.Parameters.AddWithValue("@post_type_id", postDetail.PostType);
                cmd.Parameters.AddWithValue("@isActive", postDetail.IsActive);
                cmd.Parameters.AddWithValue("@isBlocked", postDetail.IsBlocked);
                cmd.Parameters.AddWithValue("@approveStatus", postDetail.ApproveStatus);
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int DeletePostbyPostID(int postID, int userID, string description)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_POST_DELETE);
                stringSQL.Append(" (post_id, user_id, delete_at, description)");
                stringSQL.Append(" VALUES (@postID, @userID, @deleteDate, @description);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@postID", postID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@deleteDate", DateTime.Now.ToString("yyyy-MM-d HH:mm:ss"));
                cmd.Parameters.AddWithValue("@description", description);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int ApprovePost(int postID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_POST);
                stringSQL.Append(" SET approve_status_id = @approveStatus");
                stringSQL.Append(" WHERE post_id = @postID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@approveStatus", 1);
                cmd.Parameters.AddWithValue("@postID", postID);
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int UpdateBlockedPost(int postID, int isBlocked)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_POST);
                stringSQL.Append(" SET is_blocked = @blocked");
                stringSQL.Append(" WHERE post_id = @postID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@blocked", isBlocked);
                cmd.Parameters.AddWithValue("@postID", postID);
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
