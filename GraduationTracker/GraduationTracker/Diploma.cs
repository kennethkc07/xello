/// <summary>
/// Holds Identities of Courses for a particular Diploma Program
/// </summary>
namespace GraduationTracker
{
    using System.Collections.Generic;

    public class Diploma : EntityBase
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public List<int> Requirements { get; set; }

        public Diploma() : base() { }
    }
}