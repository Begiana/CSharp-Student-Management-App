using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;

namespace StudentsManagementApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        public DeleteModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal string errorMessage = "";
        public void OnGet()
        {
            CourseDTO courseDTO = new CourseDTO();
            try
            {

                Course? course;
                
                int id = int.Parse(Request.Query["id"]);
                courseDTO.Id = id;
                course = service.DeleteCourse(courseDTO);
                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
