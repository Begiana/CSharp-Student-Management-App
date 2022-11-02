using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        internal List<Teacher> teachers = new();
        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO = new();
        internal string errorMessage = "";
        public void OnGet()
        {
            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service.GetOneCourse(id);

                if (course != null)
                {
                   courseDTO = ConvertToDTO(course);
                }
                teachers = service!.GetAllTeachers();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMessage = "";
            //Get DTO
            teachers = service!.GetAllTeachers();
            courseDTO.Id = int.Parse(Request.Form["id"]);
            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherId"]);
         

            //validate
            errorMessage = CourseValidator.Validate(courseDTO);

            if (!errorMessage.Equals("")) {
                teachers = service!.GetAllTeachers();
                return;
            }
            
            try
            {
                service.UpdateCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = "Course should not be less than 6 charachters";
                return;
            }
        }

        private CourseDTO ConvertToDTO(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Description = course.Description
                //TeacherId = course.TeacherId
            };
        }
    }
}
