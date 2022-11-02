using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();
        public IndexModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }
        public void OnGet()
        {
            try
            {
                teachers = service!.GetAllTeachers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
