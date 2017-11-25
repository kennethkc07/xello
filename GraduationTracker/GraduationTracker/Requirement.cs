namespace GraduationTracker
{
    using System.Collections.Generic;

    public class Requirement : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public List<int> Courses { get; set; }

        public Requirement() : base() { }
    }
}