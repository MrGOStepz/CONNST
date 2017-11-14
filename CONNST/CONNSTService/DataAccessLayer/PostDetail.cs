using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostDetail
    {
        private int postID;
        private int userID;
        private string title;
        private string description;
        private int postType;
        private int isActive;
        private int isBlocked;
        private string postDate;
        private string editDate;
        private int approveStatus;

        public PostDetail()
        {
            editDate = DateTime.Now.ToString("yyyy-MM-d HH:mm:ss");
            postDate = DateTime.Now.ToString("yyyy-MM-d HH:mm:ss");
            approveStatus = 2;
            isActive = 0;
            isBlocked = 0;
            postType = 1;
        }

        public int ApproveStatus
        {
            get { return approveStatus; }
            set { approveStatus = value; }
        }


        public int UserID
        {
            get { return userID; }
            set { userID = value; }
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

        public string EditDate
        {
            get { return editDate; }
            set { editDate = value; }
        }


        public string PostDate
        {
            get { return postDate; }
            set { postDate = value; }
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }

    }
}
