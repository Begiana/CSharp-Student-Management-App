using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly IEnrollDAO enrollDAO = new EnrollDAOImpl();
        private readonly IEnrollService? service;

        internal List<Enroll> enrollments = new();
        internal List<Course> courses = new();
        internal List<Student> students = new();

        public IndexModel()
        {
            service = new EnrollServiceImpl(enrollDAO);
        }
        public void OnGet()
        {
            courses = service!.GetAllCourses();
            students = service!.GetAllStudents();
            enrollments = service!.GetAllEnrollments();
            
        }
    }
}
