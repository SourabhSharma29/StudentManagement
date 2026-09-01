using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> bookModels = new List<BookModel>();
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog=StudentManagement; integrated security= true;");
            SqlCommand sqlCommand = new SqlCommand("select * from Books", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                BookModel bookModel = new BookModel();
                bookModel.ID = (int)sqlDataReader["ID"];
                bookModel.Title = sqlDataReader["Title"].ToString();
                bookModel.ISBN = sqlDataReader["ISBN"].ToString();
                bookModel.Category = sqlDataReader["Category"].ToString();

                bookModels.Add(bookModel);
            }
            sqlConnection.Close();
            return View(bookModels);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog =StudentManagement; integrated security = true;");
            SqlCommand sqlCommand = new SqlCommand(" insert into Books values('" + bookModel.Title + "','" + bookModel.Author + "','" + bookModel.ISBN + "','" + bookModel.Category + "')", sqlConnection); ;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return View(bookModel);
        }
        
        public ActionResult Edit(int ID)
        {
            BookModel bookModel = new BookModel();
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog=StudentManagement; integrated security= true;");
            SqlCommand sqlCommand = new SqlCommand("select * from Books where id=" + ID, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
               
                bookModel.ID = (int)sqlDataReader["ID"];
                bookModel.Title = sqlDataReader["Title"].ToString();
                bookModel.ISBN = sqlDataReader["ISBN"].ToString();
                bookModel.Author = sqlDataReader["Author"].ToString();
                bookModel.Category = sqlDataReader["Category"].ToString();
                 
            }
            sqlConnection.Close();
            return View(bookModel); 
        }

        [HttpPost]

        public ActionResult Edit(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog =StudentManagement; integrated security = true;");
            string query = " update Books set Title='" + bookModel.Title + "', Author='" + bookModel.Author + "',ISBN='" + bookModel.ISBN + "',Category='" + bookModel.Category + "' where id="+bookModel.ID;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection); ;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return View(bookModel);
        }
        public ActionResult Delete(int ID)
        {
            BookModel bookModel = new BookModel();
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog=StudentManagement; integrated security= true;");
            SqlCommand sqlCommand = new SqlCommand("select * from Books where id=" + ID, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                bookModel.ID = (int)sqlDataReader["ID"];
                bookModel.Title = sqlDataReader["Title"].ToString();
                bookModel.ISBN = sqlDataReader["ISBN"].ToString();
                bookModel.Author = sqlDataReader["Author"].ToString();
                bookModel.Category = sqlDataReader["Category"].ToString();

            }
            sqlConnection.Close();
            return View(bookModel);
        }
        [HttpPost]
        public ActionResult Delete(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(@"data source=ANIL; initial catalog =StudentManagement; integrated security = true;");
            string query = " delete from books where id=" + bookModel.ID;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection); ;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return RedirectToAction("Index");
        }          
    }
}