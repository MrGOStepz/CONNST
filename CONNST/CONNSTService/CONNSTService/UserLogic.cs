using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace CONNSTService
{
    public class UserLogic
    {
        private DataTable _dataTable;
        private UserDAO _userDAO;

        public UserLogic()
        {
            _userDAO = new UserDAO();
            _dataTable = new DataTable();
        }


        public List<UserModel> GetListOfUser()
        {
            List<UserModel> users = new List<UserModel>();

            _dataTable = _userDAO.GetListOfUser();

            foreach (DataRow userRow in _dataTable.Rows)
            {
                UserModel user = UserModel.Parse(userRow);
                users.Add(user);
            }

            return users;
        }

        public int AddNewUser(UserProfile userProfile)
        {
            MD5 md5 = new MD5();
            userProfile.Password = md5.EncodePassword(userProfile.Password);
            return _userDAO.AddNewUser(userProfile);
        }

        public int UpdateUserPassword(int userID, string newPassword)
        {
            MD5 md5 = new MD5();
            newPassword = md5.EncodePassword(newPassword);
            return _userDAO.UpdateNewPassword(userID, newPassword);
        }

        public int GetUserIDbyUserName(string userName)
        {
            return _userDAO.GetUserIDbyUserName(userName);
        }

        public int UpdateUserProfileByUserID(UserProfile userProfile)
        {
            return _userDAO.UpdateProfilebyUserID(userProfile);
        }
        
        //TODO MD5 for password 1. Create New user 2.Change password
        //Encode before sent to Data Access Layer
    }
}
