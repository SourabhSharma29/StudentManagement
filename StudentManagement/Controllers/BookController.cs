using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> bookModels = new List<BookModel>();
            SqlConnection sqlConnection = new SqlConnection(@"data source=SOURABH\SQLEXPRESS; initial catalog=StudentManagement; integrated security= true;");
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
            SqlConnection sqlConnection = new SqlConnection(@"data source=SOURABH\SQLEXPRESS; initial catalog =StudentManagement; integrated security = true;");
            SqlCommand sqlCommand = new SqlCommand(" insert into Books values('" + bookModel.Title + "','" + bookModel.Author + "','" + bookModel.ISBN + "','" + bookModel.Category + "')", sqlConnection); ;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return View(bookModel);
        }

        public ActionResult Edit(int ID)
        {
            return View();
        }

        [HttpPost]

        public ActionResult Edit(BookModel bookModel)
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            return View();
        }

        [HttpPost]

        public ActionResult Delete(BookModel bookModel)
        {
            return View();
        }
    }
}