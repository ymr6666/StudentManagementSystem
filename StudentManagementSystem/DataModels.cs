//学生类
public class Student
{
    public int Id { get; set; }
    public string StudentId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Class { get; set; }
    public string Major { get; set; }
    public string PhoneNum { get; set; }
    public string Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
//课程类
public class Course
{
    public int Id { get; set; }
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }
    public string Teacher { get; set; }
}
//成绩类
public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public decimal Score { get; set; }
    public DateTime ExamDate { get; set; }
}
