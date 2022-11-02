using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public interface ITeacherService
    {   /// <summary>
        /// A method that returns a list with all the teachers
        /// </summary>
        /// <returns> A list of Teacher objects</returns>
        List<Teacher> GetAllTeachers();
        /// <summary>
        /// A method that inserts a record (teacher) with values Id,Firstname,Lastname at
        /// the teachers table
        /// </summary>
        /// <param name="dto"> DTOTeacher object that is to be 
        /// converted to Teacher</param>
        void InsertTeacher(TeacherDTO? dto);
        /// <summary>
        /// A method that updates a record (Teacher) with values Firstname,Lastname at 
        /// the teachers table
        /// </summary>
        /// <param name="dto">
        /// DTOTeacher that is to be 
        /// converted to Teacher</param>
        void UpdateTeacher(TeacherDTO? dto);
        /// <summary>
        /// A method that brings one teacher ,searched by Id, from the teacher table
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        /// <returns> a Teacher object</returns>
        Teacher? GetTeacher(int id);

        /// <summary>
        /// It deletes a teacher record  from Teachers table 
        /// </summary>
        /// <param name="dto">
        /// DTOTeacher Object that is to be 
        /// converted to Teacher</param>
        /// <returns>Returns the deleted Teacher </returns>
        Teacher? DeleteTeacher(TeacherDTO? dto);
    }
}
