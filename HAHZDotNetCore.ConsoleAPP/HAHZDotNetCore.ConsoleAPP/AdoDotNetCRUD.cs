using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace HAHZDotNetCore.ConsoleApp
{
    internal class AdoDotNetCRUD
    {
        private SqlConnectionStringBuilder _connectionStringBuilder=new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBth4",
            UserID = "sa",
            Password = "ZwehtetZ@18"
        };
        public void Read()
        {
            
           
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("connection is run.");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            Console.WriteLine("connection is stop.");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("blogId =>" + dr["BlogId"]);
                Console.WriteLine("blogTitle =>" + dr["BlogTitle"]);
                Console.WriteLine("blogAuthor =>" + dr["BlogAuthor"]);
                Console.WriteLine("blogContent =>" + dr["BlogContent"]);
                Console.WriteLine("------------------------");
            }
        }
        public void Edit(int id)
        {

            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Blogid", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }
            DataRow dr= dt.Rows[0];
                Console.WriteLine("blogId =>" + dr["BlogId"]);
                Console.WriteLine("blogTitle =>" + dr["BlogTitle"]);
                Console.WriteLine("blogAuthor =>" + dr["BlogAuthor"]);
                Console.WriteLine("blogContent =>" + dr["BlogContent"]);
                Console.WriteLine("------------------------");
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd=new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BLogTitle", title);
            cmd.Parameters.AddWithValue("@BLogAuthor", author);
            cmd.Parameters.AddWithValue("@BLogContent", content);
            int result=cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving failed.";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content) 
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BLogId", id);     
            cmd.Parameters.AddWithValue("@BLogTitle", title);
            cmd.Parameters.AddWithValue("@BLogAuthor", author);
            cmd.Parameters.AddWithValue("@BLogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating failed.";
            Console.WriteLine(message); 
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BLogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Deleting Successful." : "Deleting failed.";
            Console.WriteLine(message);
        }
    }
}
