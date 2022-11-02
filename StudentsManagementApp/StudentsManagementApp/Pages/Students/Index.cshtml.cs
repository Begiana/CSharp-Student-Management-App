using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? service;

        internal List<Student> students = new();

        public IndexModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }
        public IActionResult OnGet()
        {
            students = service!.GetAllStudents();
            return Page();

        }
    }
}
