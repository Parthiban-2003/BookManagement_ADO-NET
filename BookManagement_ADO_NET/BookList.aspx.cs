﻿using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System;

namespace BookManagement_ADO_NET
{
    public partial class BookList : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BookBankDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridViewed.DataSource = dt;
                GridViewed.DataBind();
            }
        }
        protected void btn_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("AddEditBook.aspx");
        }

        protected void Edit_Book(object sender, GridViewEditEventArgs e)
        {
            int bookId = Convert.ToInt32(GridViewed.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"AddEditBook.aspx?id={bookId}");
        }

        protected void Delete_Book(object sender, EventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)sender;
            int bookId = Convert.ToInt32(lnkDelete.CommandArgument);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            BindGrid();
        }
    }
}
