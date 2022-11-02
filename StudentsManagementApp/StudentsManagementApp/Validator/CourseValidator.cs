using StudentsManagementApp.DTO;

namespace StudentsManagementApp.Validator
{
    public class CourseValidator
    {
        private CourseValidator() { }


        public static string Validate(CourseDTO? dto)
        {
            
            if (dto!.Description!.Length <= 6)
            {
             
                return "Course should not be less than 6 characters ";
            }
            else return "";
        }
    }
}
