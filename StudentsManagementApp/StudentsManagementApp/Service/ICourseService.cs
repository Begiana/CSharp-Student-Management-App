using StudentsManagementApp.DTO;
using StudentsManagementApp.Models;

namespace StudentsManagementApp.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// A method thar inserts a Course record to Courses table
        /// </summary>
        /// <param name="dto">
        /// CourseDTO object to be converted to course object</param>
        void InsertCourse(CourseDTO? dto);
        /// <summary>
        /// A method that updates a Course record to Courses table
        /// </summary>
        /// <param name="dto">CourseDTO object to be converted to course object</param>
        void UpdateCourse(CourseDTO? dto);
        /// <summary>
        /// A method that deletes a course from Courses table 
        /// </summary>
        /// <param name="dto">CourseDTO object to be converted to course object</param>
        /// <returns>The deleted course</returns>
        Course? DeleteCourse(CourseDTO? dto);

        /// <summary>
        /// A method that gets one course ,searched by id ,from Courses table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The course selected</returns>
        Course? GetOneCourse(int id);
        /// <summary>
        /// A method that makes a list with all courses that are in Courses table
        /// </summary>
        /// <returns>a list of all courses </returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// A method that makes a list with all teachers that are in Teachers table 
        /// </summary>
        /// <returns>A list of all teachers</returns>
        List<Teacher> GetAllTeachers();
    }
}
