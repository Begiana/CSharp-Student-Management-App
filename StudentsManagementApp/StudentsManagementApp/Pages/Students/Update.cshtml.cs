using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsManagementApp.DAO;
using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;
using StudentsManagementApp.Service;
using StudentsManagementApp.Validator;

namespace StudentsManagementApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";
        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);

                if (student != null)
                {
                    studentDTO = ConvertToDTO(student);
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
            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            //validate
            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = "Firstname or Lastname should not be less than 2 and 4 characters respectively";
                return;
            }
        }

        private StudentDTO ConvertToDTO(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
