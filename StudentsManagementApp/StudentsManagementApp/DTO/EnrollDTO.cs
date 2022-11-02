namespace StudentsManagementApp.DTO
{
    public class EnrollDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public override string ToString() => $"{StudentId}, {CourseId}";
    }
}
 