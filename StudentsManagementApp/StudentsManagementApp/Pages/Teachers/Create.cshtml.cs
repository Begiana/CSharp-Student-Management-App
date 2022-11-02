using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public CreateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDto = new();
        internal string errorMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            teacherDto.Firstname = Request.Form["firstname"];
            teacherDto.Lastname = Request.Form["lastname"];

            errorMessage =TeacherValidator.Validate(teacherDto);
            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertTeacher(teacherDto);
                Response.Redirect("/Teachers/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
