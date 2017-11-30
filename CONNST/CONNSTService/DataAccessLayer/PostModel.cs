using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostModel
    {
        private int postID;
        private int userID;
        private string title;
        private string description;
        private int postType;
        private int isActive;
        private int isBlocked;
        private DateTime postDate;
        private DateTime editDate;
        private int approveStatus;

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int ApproveStatus
        {
            get { return approveStatus; }
            set { approveStatus = value; }
        }

        public int IsBlocked
        {
            get { return isBlocked; }
            set { isBlocked = value; }
        }


        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }


        public int PostType
        {
            get { return postType; }
            set { postType = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime EditDate
        {
            get { return editDate; }
            set { editDate = value; }
        }


        public DateTime PostDate
        {
            get { return postDate; }
            set { postDate = value; }
        }




        public static PostModel Parse(DataRow dataRow)
        {
            if (dataRow == null)
                return null;

            PostModel postModel = new PostModel();
            postModel.UserID = (int)dataRow["user_id"];
            postModel.PostID = (int)dataRow["post_id"];
            postModel.PostDate = (DateTime)dataRow["post_at"];
            postModel.EditDate = (DateTime)dataRow["edit_at"];
            postModel.Title = dataRow["title_name"].ToString();
            postModel.Description = dataRow["description"].ToString();
            postModel.PostType = (int)dataRow["post_type_id"];
            postModel.IsActive = (int)dataRow["is_active"];
            postModel.IsBlocked = (int)dataRow["is_blocked"];
            postModel.ApproveStatus = (int)dataRow["approve_status_id"];

            return postModel;
        }
    }
}
