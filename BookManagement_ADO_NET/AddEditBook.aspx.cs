using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BookManagement_ADO_NET
{
    public partial class AddEditBook : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["BookBankDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int nId = Convert.ToInt32(Request.QueryString["id"]);
                    BooksInfo(nId);
                }
            }
        }

        public void BooksInfo(int nId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string strQuery = "SELECT * FROM Books WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(strQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Id", nId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUser.Text = reader["UserName"].ToString();
                        txtTitle.Text = reader["Title"].ToString();
                        txtAuthor.Text = reader["Author"].ToString();
                        txtISBN.Text = reader["ISBN"].ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                UpdateBook();
            }
            else
            {
                InsertBook();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void InsertBook()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string strQuery = "INSERT INTO Books (UserName, Title, Author, ISBN) VALUES (@UserName, @Title, @Author, @ISBN)";
                using (SqlCommand cmd = new SqlCommand(strQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("BookList.aspx");
        }

        private void UpdateBook()
        {
            int nId = Convert.ToInt32(Request.QueryString["id"]);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string strQuery = "UPDATE Books SET Title = @Title, UserName = @UserName, Author = @Author, ISBN = @ISBN WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(strQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                    cmd.Parameters.AddWithValue("@Id", nId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("BookList.aspx");
        }
    }
}