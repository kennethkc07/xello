/// <summary>
/// Holds Course Information Per Student
/// </summary>
namespace GraduationTracker
{
    public class Course : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Credits { get; }

        public Course() : base() { }
    }
}