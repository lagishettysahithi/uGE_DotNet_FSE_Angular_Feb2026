using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
    }
}
