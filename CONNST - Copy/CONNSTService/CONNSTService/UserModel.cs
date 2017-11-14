using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONNSTService
{
    public class UserModel
    {
        private int userID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private DateTime dob;
        private int courseID;
        private int isActive;
        private int isBlocked;
        private int userLevelID;
        private int userTypeID;
        private DateTime createTime;
        private DateTime lastActiveTime;
        private string imagePath;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dob; }
            set { dob = value; }
        }

        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                if (value > 4 && value < 1)
                    userTypeID = 4;
                else
                    userTypeID = value;
            }
        }

        public int UserLevelID
        {
            get { return userLevelID; }
            set
            {
                if (value > 3 && value < 1)
                    userLevelID = 3;
                else
                    userLevelID = value;
            }
        }

        public DateTime LastActiveTime
        {
            get { return lastActiveTime; }
            set { lastActiveTime = value; }
        }


        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
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


        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public static UserModel Parse(DataRow dataRow)
        {
            if (dataRow == null)
                return null;

            UserModel userModel = new UserModel();
            userModel.UserID = (int)dataRow["user_id"];
            userModel.FirstName = dataRow["first_name"].ToString();
            userModel.LastName = dataRow["last_name"].ToString();
            userModel.Email = dataRow["email"].ToString();
            userModel.Phone = dataRow["phone"].ToString();
            userModel.Address = dataRow["address"].ToString();
            userModel.DateOfBirth = (DateTime)dataRow["dob"];
            userModel.CourseID = (int)dataRow["course_id"];
            userModel.UserLevelID = (int)dataRow["user_level_id"];
            userModel.UserTypeID = (int)dataRow["user_type_id"];
            userModel.LastActiveTime = (DateTime)dataRow["last_active_at"];
            userModel.CreateTime = (DateTime)dataRow["create_at"];
            userModel.IsActive = (int)dataRow["is_active"];
            userModel.IsBlocked = (int)dataRow["is_blocked"];
            userModel.ImagePath = dataRow["image"].ToString();

            return userModel;
        }

    }
}
