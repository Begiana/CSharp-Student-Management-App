using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public UpdateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        internal string errorMessage = "";
        public void OnGet()
        {
            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacher = service.GetTeacher(id);

                if (teacher != null)
                {
                    teacherDTO = ConvertToDTO(teacher);
                }
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
            teacherDTO.Id = int.Parse(Request.Form["id"]);
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            //validate
            errorMessage = TeacherValidator.Validate(teacherDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errorMessage = "Firstname or Lastname should not be less than 2 and 4 characters respectively";
                return;
            }
        }

        private TeacherDTO ConvertToDTO(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}
