using System;
using Microsoft.EntityFrameworkCore;
using UpmessageMVCNETCore.Model;
using System.Data;
using System.Data.SqlClient;

namespace UpmessageMVCNETCore.Model
{

    public class PostDBAccessLayer
    {
        private static HatunWillanaContext db;
        private static DbContextOptionsBuilder ob = new DbContextOptionsBuilder<HatunWillanaContext>();

        SqlConnection conn = new SqlConnection("Server=WFK9A4TGVD\\SQLEXPRESS;Database=HatunWillana;User Id = GigaBotsSqlWeb;Password=D69F7Threez;MultipleActiveResultSets=true;");
        public string AddPostRecord(Post post)
        {
            try { 
                SqlCommand comm = new SqlCommand("sp_Add_Toplevel_Post", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Title", post.Title);
                comm.Parameters.AddWithValue("@Body", post.Body);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return ("Data saved successfully");
            }
            catch(Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return (ex.Message.ToString());
            }
        }

    }
}
