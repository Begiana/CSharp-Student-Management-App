using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly IEnrollDAO enrollDAO = new EnrollDAOImpl();
        private readonly IEnrollService service;

        public CreateModel()
        {
            service = new EnrollServiceImpl(enrollDAO);
        }

        internal List<Course> courses = new();
        internal List<Student> students = new();
        internal EnrollDTO enrollDto = new();
        internal string errorMessage = "";
        public void OnGet()
        {
            try
            {
                students = service!.GetAllStudents();
                courses = service!.GetAllCourses();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void OnPost()
        {

            students = service!.GetAllStudents();
            courses = service!.GetAllCourses();
          
            if (!errorMessage.Equals("")) return;

            try
            {
                enrollDto.StudentId = int.Parse(Request.Form["studentId"]);
                enrollDto.CourseId = int.Parse(Request.Form["courseId"]);
                service.InsertEnroll(enrollDto);
                Response.Redirect("/Enrollments/Index");

            }
            catch (Exception e)
            {
                errorMessage = "This student already attends this course";
                return;
            }
        }
    }
}
