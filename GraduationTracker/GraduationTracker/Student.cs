namespace GraduationTracker
{
    using System.Collections.Generic;

    public class Student : EntityBase
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;

        public Student() : base() { }
    }
}