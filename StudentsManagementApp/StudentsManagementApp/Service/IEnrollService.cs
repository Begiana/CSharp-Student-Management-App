using StudentsManagementApp.Models;
using StudentsManagementApp.DTO;

namespace StudentsManagementApp.Service
{
    public interface IEnrollService
    {

        /// <summary>
        /// It inserts a record to Student Course Table 
        /// </summary>
        /// <param name="dto">DTOenroll object to be converted to enroll object</param>
        void InsertEnroll(EnrollDTO? dto);

        /// <summary>
        /// It deletes a record to Student Course table
        /// </summary>
        /// <param name="dto"> DTOenroll object to be converted to enroll object</param>
        /// <returns>Returns the deleted object</returns>
        Enroll? DeleteEnroll(EnrollDTO? dto);

        
        /// <returns> returns a list with all Enroll objects</returns>
        List<Enroll> GetAllEnrollments();


        /// <returns> returns a list with all Course objects</returns>
        List<Course> GetAllCourses();

        /// <returns> returns a list with all Student objects</returns>
        List<Student> GetAllStudents();

    }
}
