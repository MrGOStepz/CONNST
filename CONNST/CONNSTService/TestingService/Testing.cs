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

        private void fmTesting_Load(object sender, EventArgs e)
        {
            UserLogic userLogic = new UserLogic();
            PostLogic postLogic = new PostLogic();
            dgvListOfUser.DataSource = userLogic.GetListOfUser();
            dgvPost.DataSource = postLogic.GetListOfPost();
            dgvDeletePost.DataSource = postLogic.GetListOfDeletePost();
            dgvActivePost.DataSource = postLogic.GetListOfActivePost();
            dgvPostReport.DataSource = postLogic.GetListOfReportPost();
        }

        #region User
        private void ClearTextBoxAddUser()
        {
           txtAddUserName.Text = "";
           txtAddPassword.Text = "";
           txtAddFirstName.Text = "";
           txtAddLastName.Text = "";
           txtAddEmail.Text = "";
           txtAddPhone.Text = "";
           txtAddAddress.Text = "";
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
            ClearTextBoxAddUser();
        }

        private void btnUpdaptePW_Click(object sender, EventArgs e)
        {
            UserLogic userLogic = new UserLogic();
            userLogic.UpdateUserPassword(int.Parse(lbAddUserID.Text), txtUpdaptePW.Text);
            txtUpdaptePW.Text = "";
            dgvListOfUser.DataSource = userLogic.GetListOfUser();
        }

        private void dgvListOfUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                UserLogic userLogic = new UserLogic();
                //tssLabel.Text = userLogic.GetUserIDbyUserName(dgvListOfUser.Rows[e.RowIndex].Cells["UserName"].Value.ToString()).ToString();
                lbAddUserID.Text = dgvListOfUser.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UserLogic userLogic = new UserLogic();
            UserProfile userProfile = new UserProfile();

            userProfile.UserID = int.Parse(lbAddUserID.Text);
            userProfile.Password = txtAddPassword.Text;
            userProfile.FirstName = txtAddFirstName.Text;
            userProfile.LastName = txtAddLastName.Text;
            userProfile.Email = txtAddEmail.Text;
            userProfile.Phone = txtAddPhone.Text;

            userLogic.UpdateUserProfileByUserID(userProfile);

            dgvListOfUser.DataSource = userLogic.GetListOfUser();
            ClearTextBoxAddUser();

        }
        #endregion

        #region Post

        #endregion

        private void Post_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                DataGridView dataGridView = (DataGridView)sender;
                PostLogic postLogic = new PostLogic();

                if (dataGridView.Name == "dgvPost")
                {         
                    txtPostID.Text = dgvPost.Rows[e.RowIndex].Cells["PostID"].Value.ToString();
                    txtPostUserID.Text = dgvPost.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                    txtPostTitle.Text = dgvPost.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    txtPostDescription.Text = dgvPost.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                }
                else if (dataGridView.Name == "dgvDeletePost")
                {
                    txtPostID.Text = dgvDeletePost.Rows[e.RowIndex].Cells["PostID"].Value.ToString();
                    txtPostUserID.Text = dgvDeletePost.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                }
                else if (dataGridView.Name == "dgvActivePost")
                {
                    txtPostID.Text = dgvActivePost.Rows[e.RowIndex].Cells["PostID"].Value.ToString();
                }
                else if (dataGridView.Name == "dgvPostReport")
                {
                    txtPostID.Text = dgvPostReport.Rows[e.RowIndex].Cells["PostID"].Value.ToString();
                    txtPostUserID.Text = dgvPostReport.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                }
            }
        }

        private void btnPostAdd_Click(object sender, EventArgs e)
        {
            PostLogic postLogic = new PostLogic();
            PostDetail postDetail = new PostDetail();

            postDetail.UserID = int.Parse(txtPostUserID.Text);
            postDetail.Title = txtPostTitle.Text;
            postDetail.Description = txtPostDescription.Text;

            postLogic.AddNewPost(postDetail);
            dgvPost.DataSource = postLogic.GetListOfPost();
        }

        private void btnPostUpdate_Click(object sender, EventArgs e)
        {
            PostLogic postLogic = new PostLogic();
            PostDetail postDetail = new PostDetail();

            postDetail.PostID = int.Parse(txtPostID.Text);
            postDetail.UserID = int.Parse(txtPostUserID.Text);
            postDetail.Title = txtPostTitle.Text;
            postDetail.Description = txtPostDescription.Text;

            postLogic.EditPostbyUserID(postDetail);
            dgvPost.DataSource = postLogic.GetListOfPost();
        }

        private void btnPostDelete_Click(object sender, EventArgs e)
        {
            PostLogic postLogic = new PostLogic();
            postLogic.DeletePostbyPostID(int.Parse(txtPostID.Text), int.Parse(txtPostUserID.Text), txtPostDescription.Text);
            dgvDeletePost.DataSource = postLogic.GetListOfDeletePost();
        }

        private void btnPostActive_Click(object sender, EventArgs e)
        {
            PostLogic postLogic = new PostLogic();
            postLogic.ApprovePost(int.Parse(txtPostID.Text));
            dgvActivePost.DataSource = postLogic.GetListOfActivePost();
        }

        private void btnPostBlock_Click(object sender, EventArgs e)
        {

        }
    }
}
