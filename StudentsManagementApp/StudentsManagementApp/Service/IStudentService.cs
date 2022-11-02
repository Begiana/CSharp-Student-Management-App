using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// A method that returns a list with all the students
        /// </summary>
        /// <returns> A list of Student objects</returns>
        List<Student> GetAllStudents();
        /// <summary>
        /// A method that inserts a record (student) with values Id,Firstname,Lastname at
        /// the students table
        /// </summary>
        /// <param name="dto"> DTOStudent object that is to be 
        /// converted to Student</param>
        void InsertStudent(StudentDTO? dto);
        /// <summary>
        /// A method that updates a record (Student) with values Firstname,Lastname at 
        /// the Students table
        /// </summary>
        /// <param name="dto">
        /// DTOStudent that is to be 
        /// converted to Student</param>
        void UpdateStudent(StudentDTO? dto);

        /// <summary>
        /// A method that brings one student ,searched by Id, from the student table
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns> a Student object</returns>
        Student? GetStudent(int id);

        /// <summary>
        /// It deletes a student record  from Students table 
        /// </summary>
        /// <param name="dto">
        /// DTOStudent Object that is to be 
        /// converted to Student</param>
        /// <returns>Returns the deleted Student </returns>
        Student? DeleteStudent(StudentDTO? dto);    
    }
}
