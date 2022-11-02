using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        internal List<Teacher> teachers = new();
        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";
        public void OnGet()
        {
            try
            {
                teachers = service!.GetAllTeachers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OnPost()
        {
            courseDto.Description = Request.Form["description"];
            courseDto.TeacherId = int.Parse(Request.Form["teacherId"]);

            errorMessage = CourseValidator.Validate(courseDto);
            if (!errorMessage.Equals(""))
            {
                teachers = service!.GetAllTeachers();
                return;
            }

            try
            {
                service.InsertCourse(courseDto);
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
