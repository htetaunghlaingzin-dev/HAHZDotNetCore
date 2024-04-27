using Dapper;
using HAHZDotNetCore.ConsoleAPP.Dtos;
using HAHZDotNetCore.ConsoleAPP.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HAHZDotNetCore.ConsoleAPP.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
            Edit(1);
            Edit(11);
            Create("Title", "Author", "Content");
            Updaate(13, "Title", "Author", "Content");
            Delete(13);
        }
        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("---------------------");
            }
        }
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("Item not Found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("---------------------");
        }
        private void Create(string title, string author, string content)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            int result = db.Execute(query, item);
            string message = result > 0 ? "Saving Successful." : "Saving failed.";
            Console.WriteLine(message);
        }
        private void Updaate(int id, string title, string author, string content)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";
            int result = db.Execute(query, item);
            string message = result > 0 ? "Updating Successful." : "Updating failed.";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = new BlogDto
            {
                BlogId = id
            };
            string query = @"DELETE [dbo].[Tbl_Blog] WHERE BlogId=@BlogId";
            int result = db.Execute(query, item);
            string message = result > 0 ? "Deleting Successful." : "Deleting failed.";
            Console.WriteLine(message);
        }
    }
}
