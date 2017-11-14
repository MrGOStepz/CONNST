using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserProfile
    {
        private int userID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string dob;
        private int courseID;
        private int isActive;
        private int isBlocked;
        private int userLevelID;
        private int userTypeID;
        private string createTime;
        private string lastActiveTime;
        private string imagePath;
        private string userName;
        private string password;

        public UserProfile()
        {
            firstName = "";
            lastName = "";
            email = "";
            phone = "";
            address = "";
            dob = DateTime.Now.ToString("yyyy-MM-d HH:mm:ss");
            courseID = 1;
            isActive = 1;
            isBlocked = 0;
            userLevelID = 3;
            userTypeID = 4;
            createTime = DateTime.Now.ToString("yyyy-MM-d HH:mm:ss");
            lastActiveTime = DateTime.Now.ToString("yyyy-MM-d HH:mm:ss");
            imagePath = "";
            userName = "";
            password = "";
        }


        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }


        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                if (userTypeID > 4 && userTypeID < 1)
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
                if (userLevelID > 3 && userLevelID < 1)
                    userLevelID = 3;
                else
                    userLevelID = value;
            }
        }

        public string DateOfBirth
        {
            get { return dob; }
            set { dob = value; }
        }


        public string LastActiveTime
        {
            get { return lastActiveTime; }
            set { lastActiveTime = value; }
        }


        public string CreateTime
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


        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }


        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }



        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

    }
}
