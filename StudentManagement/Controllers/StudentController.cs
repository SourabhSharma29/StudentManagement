using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source =SOURABH\SQLEXPRESS; initial catalog = StudentManagement; integrated security = true;");
            SqlCommand sqlCommand = new SqlCommand("select * from Student", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                StudentModel studentModel = new StudentModel();
                studentModel.ID = (int)sqlDataReader["ID"];
                studentModel.Name = sqlDataReader["Name"].ToString();
                studentModel.Email = sqlDataReader["Email"].ToString();
                studentModel.MobileNumber = sqlDataReader["MobileNumber"].ToString();

                students.Add(studentModel);
            }
            sqlConnection.Close();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            SqlConnection sqlConnection = new SqlConnection(@"data source=SOURABH\SQLEXPRESS; initial catalog=StudentManagement; integrated security=true;");
            SqlCommand sqlCommand = new SqlCommand("insert into Student values('"+studentModel.Name + "','"+studentModel.Email+"','"+studentModel.MobileNumber+"') ", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return View(studentModel);
        }

        public ActionResult Edit(int ID)
        {
            return View();
        }

        [HttpPost]

        public ActionResult Edit(StudentModel studentModel)
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            return View();
        }

        [HttpPost]

        public ActionResult Delete(StudentModel studentModel)
        {
            return View();
        }

    }
}