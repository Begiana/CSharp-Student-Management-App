using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Enrollments
{
    public class DeleteModel : PageModel
    {
        private readonly IEnrollDAO enrollDAO = new EnrollDAOImpl();
        private readonly IEnrollService service;

        public DeleteModel()
        {
            service = new EnrollServiceImpl(enrollDAO);
        }

        internal List<Course> courses = new();
        internal List<Student> students = new();
        internal string errorMessage = "";
        public void OnGet()
        {
           EnrollDTO enrollDTO = new EnrollDTO();
            try
            {

                Enroll? enroll;

                int id = Int32.Parse(Request.Query["id"]);
                int id1 = Int32.Parse(Request.Query["id1"]);
                enrollDTO.StudentId = id;
                enrollDTO.CourseId = id1;
                enroll = service!.DeleteEnroll(enrollDTO);
                Response.Redirect("/Enrollments/Index");


            }
            catch (Exception e)
            {   
                errorMessage = e.Message;
                return;
            }
        }
    }
}
