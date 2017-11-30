using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace CONNSTService
{
    public class PostLogic
    {
        private DataTable _dataTable = new DataTable();
        private PostDAO _postDAO = new PostDAO();

        public List<PostModel> GetListOfPost()
        {
            List<PostModel> posts = new List<PostModel>();

            _dataTable = _postDAO.GetListOfPost();

            foreach (DataRow userRow in _dataTable.Rows)
            {
                PostModel post = PostModel.Parse(userRow);
                posts.Add(post);
            }

            return posts;
        }

        public List<PostModel> GetListOfActivePost()
        {
            List<PostModel> posts = new List<PostModel>();

            _dataTable = _postDAO.GetListOfActivePost();

            foreach (DataRow userRow in _dataTable.Rows)
            {
                PostModel post = PostModel.Parse(userRow);
                posts.Add(post);
            }

            return posts;
        }

        //public List<PostModel> GetListOfDeletePost()
        //{
        //    List<PostModel> posts = new List<PostModel>();

        //    _dataTable = _postDAO.GetListOfDeletePost();

        //    foreach (DataRow userRow in _dataTable.Rows)
        //    {
        //        PostModel post = PostModel.Parse(userRow);
        //        posts.Add(post);
        //    }

        //    return posts;
        //}

        public DataTable GetListOfDeletePost()
        {
            _dataTable = _postDAO.GetListOfDeletePost();

            return _dataTable;
        }

        //public List<PostModel> GetListOfReportPost()
        //{
        //    List<PostModel> posts = new List<PostModel>();

        //    _dataTable = _postDAO.GetListOfReportPost();

        //    foreach (DataRow userRow in _dataTable.Rows)
        //    {
        //        PostModel post = PostModel.Parse(userRow);
        //        posts.Add(post);
        //    }

        //    return posts;
        //}

        public DataTable GetListOfReportPost()
        {
            _dataTable = _postDAO.GetListOfReportPost();

            return _dataTable;
        }


        public int AddNewPost(PostDetail postDetail)
        {
            return _postDAO.AddNewPost(postDetail);
        }

        public int ReportPostbyPostID(int postID, int userID, string reportDetail, string reportDate)
        {
            return _postDAO.ReportPostbyPostID(postID, userID, reportDetail, reportDate);
        }

        public int DeletePostbyPostID(int postID, int userID, string description)
        {
            return _postDAO.DeletePostbyPostID(postID, userID, description);
        }

        public int EditPostbyUserID(PostDetail postDetail)
        {
            return _postDAO.EditPostbyUserID(postDetail);
        }

        public int ApprovePost(int postID)
        {
            return _postDAO.ApprovePost(postID);
        }

        public int UpdateBlockedPost(int postID, int isBlocked)
        {
            return _postDAO.UpdateBlockedPost(postID, isBlocked);
        }
    }
}
