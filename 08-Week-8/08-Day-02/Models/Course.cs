namespace WebApplication1.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }

        // Navigation
        public List<Student>? Students { get; set; }
    
}
}
