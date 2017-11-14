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
            List<UserModel> users = new List<UserModel>(); //build empty list first

            _dataTable = _userDAO.GetListOfUser(); //fill userTable from our userDAO

            //for each row in our user table...
            foreach (DataRow userRow in _dataTable.Rows)
            {
                //conver that row to a userModel and add it to the list
                UserModel user = UserModel.Parse(userRow);
                users.Add(user);
            }

            return users; //return list of users :D
        }

        public int AddNewUser(UserProfile userProfile)
        {
            return _userDAO.AddNewUser(userProfile);
        }
    }
}
