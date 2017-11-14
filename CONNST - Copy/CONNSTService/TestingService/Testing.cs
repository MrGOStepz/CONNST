using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONNSTService;
using DataAccessLayer;

namespace TestingService
{
    public partial class fmTesting : Form
    {
        public fmTesting()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.UserName = txtAddUserName.Text;
            userProfile.Password = txtAddPassword.Text;
            userProfile.FirstName = txtAddFirstName.Text;
            userProfile.LastName = txtAddLastName.Text;
            userProfile.Email = txtAddEmail.Text;
            userProfile.Phone = txtAddPhone.Text;
            userProfile.Address = txtAddAddress.Text;

            UserLogic userLogic = new UserLogic();
            userLogic.AddNewUser(userProfile);
            dgvListOfUser.DataSource = userLogic.GetListOfUser();
        }

        private void fmTesting_Load(object sender, EventArgs e)
        {

        }
    }
}
