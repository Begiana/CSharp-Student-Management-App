using StudentsManagementApp.DTO;

namespace StudentsManagementApp.Validator
{
    public class StudentValidator
    {
        //checks if a DΤΟ is valid  -  U T I L I T Y   C L A S S

        private StudentValidator(){ }


        public static string Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length <=2) || (dto!.Lastname!.Length <= 4))
            {
                return "Firstname or Lastname should not be less than 2 and 4 characters respectively";
            }
            return "";
        } 


    }
}
