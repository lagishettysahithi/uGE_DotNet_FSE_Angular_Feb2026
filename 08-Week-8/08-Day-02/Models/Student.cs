namespace WebApplication1.Models
{
    public class Student
    {

        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int CourseId { get; set; }

        // Navigation
        public string? CourseName { get; set; }
    }
}
