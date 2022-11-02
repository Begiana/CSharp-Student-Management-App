using Microsoft.AspNetCore.Mvc.ApplicationModels;
using StudentsManagementApp.DAO.DBUtil;
using StudentsManagementApp.Models;
using System.Data.SqlClient;

namespace StudentsManagementApp.DAO
{
    public class StudentDAOImpl : IStudentDAO
    {
        public Student? Delete(Student? student)
        {
            if (student == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql1 = "DELETE FROM STUDENT_COURSE WHERE STUDENT_ID = @id";
                string sql2 = "DELETE FROM STUDENTS WHERE ID = @id";

                using SqlCommand command1 = new(sql1, conn);
                using SqlCommand command2 = new(sql2, conn);

                command1.Parameters.AddWithValue("@id", student.Id);
                command2.Parameters.AddWithValue("@id", student.Id);

                command1.ExecuteNonQuery();
                int rowsAffected = command2.ExecuteNonQuery();
                return (rowsAffected > 0) ? student : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                                               
                    };
                    students.Add(student);
                }
                return students;

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            Student? student = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM STUDENTS WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
               
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)

                    };
                    
                }
                return student;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Student? student)
        {
            if (student==null) return; 
            
            try {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                } else { return; }
                string sql = "INSERT INTO STUDENTS " + 
                            "(FIRSTNAME,LASTNAME) VALUES" + 
                            "(@firstname,@lastname)";

                using SqlCommand command = new SqlCommand(sql, conn);   
                command.Parameters.AddWithValue("@firstname", student.Firstname);
                command.Parameters.AddWithValue("@lastname", student.Lastname);

                command.ExecuteNonQuery(); //ekteleitai to insert

            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Student? student)
        {
            if (student == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                if (conn != null)
                {
                    conn.Open();
                }
                else { return; }
                string sql = "UPDATE STUDENTS SET FIRSTNAME = @firstname, " +
                    "LASTNAME = @lastname WHERE ID = @id";
                           

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@firstname", student.Firstname);
                command.Parameters.AddWithValue("@lastname", student.Lastname);
                command.Parameters.AddWithValue("@id", student.Id);

                command.ExecuteNonQuery(); 

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
