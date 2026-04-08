using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        // ✅ Students with Course
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            using (var db = GetConnection())
            {
                db.Open(); // 🔥 ensure connection opens

                string sql = @"SELECT 
                               s.StudentId, 
                               s.StudentName, 
                               s.CourseId,
                               c.CourseName
                               FROM Student s
                               INNER JOIN Course c
                               ON s.CourseId = c.CourseId";

                return db.Query<Student>(sql).ToList();
            }
        }

        // ✅ Courses with Students
        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = GetConnection())
            {
                db.Open(); // 🔥 important

                string sql = @"SELECT 
                               c.CourseId, 
                               c.CourseName,
                               s.StudentId, 
                               s.StudentName, 
                               s.CourseId
                               FROM Course c
                               LEFT JOIN Student s
                               ON c.CourseId = s.CourseId";

                var dict = new Dictionary<int, Course>();

                db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!dict.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            dict.Add(currentCourse.CourseId, currentCourse);
                        }

                        if (student != null && student.StudentId != 0)
                        {
                            currentCourse.Students.Add(student);
                        }

                        return currentCourse;
                    },
                    splitOn: "StudentId"
                );

                return dict.Values.ToList();
            }
        }
    }
}