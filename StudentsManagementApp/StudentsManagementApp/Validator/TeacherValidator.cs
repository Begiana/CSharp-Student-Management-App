using StudentsManagementApp.DTO;

namespace StudentsManagementApp.Validator
{
    public class TeacherValidator
    {

        private TeacherValidator() { }


        public static string Validate(TeacherDTO? dto)
        {
            if ((dto!.Firstname!.Length <= 2) || (dto!.Lastname!.Length <= 4))
            {
                return "Firstname or Lastname should not be less than 2 and 4 characters respectively";
            }
            return "";
        }

    }
}
