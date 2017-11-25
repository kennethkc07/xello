using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new List<int> { 100, 102, 103, 104 }
            };

            var students = new List<Student>
            {
               new Student
               {
                   Id = 1,
                   Courses = new List<Course>
                   {
                        new Course{Id = 100, Name = "Math", Mark=95 },
                        new Course{Id = 102, Name = "Science", Mark=95 },
                        new Course{Id = 103, Name = "Literature", Mark=95 },
                        new Course{Id = 104, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new List<Course>
                   {
                        new Course{Id = 100, Name = "Math", Mark=80 },
                        new Course{Id = 102, Name = "Science", Mark=80 },
                        new Course{Id = 103, Name = "Literature", Mark=80 },
                        new Course{Id = 104, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new List<Course>
                {
                    new Course{Id = 100, Name = "Math", Mark=50 },
                    new Course{Id = 102, Name = "Science", Mark=50 },
                    new Course{Id = 103, Name = "Literature", Mark=50 },
                    new Course{Id = 104, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new List<Course>
                {
                    new Course{Id = 100, Name = "Math", Mark=40 },
                    new Course{Id = 102, Name = "Science", Mark=40 },
                    new Course{Id = 103, Name = "Literature", Mark=40 },
                    new Course{Id = 104, Name = "Physichal Education", Mark=40 }
                }
            }


            //tracker.HasGraduated()
        };
            Assert.IsTrue(students.Select(student => tracker.HasGraduated(diploma, student)).Any());
        }

        [TestMethod]
        public void TestNull()
        {
            var tracker = new GraduationTracker();

            var result = tracker.HasGraduated(null, null);

            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void TestEmptyListItems()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma();
            var student = new Student();

            var result = tracker.HasGraduated(diploma, student);

            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void TestIfCourseIsOffRequirements()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma()
            {
                Id = 1,
                Credits = 4,
                Requirements = new List<int> { 1, 2, 3, 4 }
            };

            var student = new Student()
            {
                Id = 34,
                Courses = new List<Course>()
                {
                    new Course{Id = 100, Name = "Math", Mark=50 },
                    new Course{Id = 102, Name = "Science", Mark= 97 },
                    new Course{Id = 103, Name = "Literature", Mark=76 },
                    new Course{Id = 104, Name = "Physichal Education", Mark=48 }
                }
            };

            Assert.IsFalse(tracker.HasGraduated(diploma, student).Item1);
        }

        [TestMethod]
        public void TestIfStandingIsSumaCumLaude()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma()
            {
                Id = 1,
                Credits = 4,
                Requirements = new List<int> { 100, 102, 103, 104 }
            };

            var student = new Student()
            {
                Id = 34,
                Courses = new List<Course>()
                {
                    new Course{Id = 100, Name = "Math", Mark=98 },
                    new Course{Id = 102, Name = "Science", Mark= 97 },
                    new Course{Id = 103, Name = "Literature", Mark=93 },
                    new Course{Id = 104, Name = "Physichal Education", Mark=98 }
                }
            };

            Assert.AreEqual(tracker.HasGraduated(diploma, student).Item2, Standing.SumaCumLaude);
        }
    }
}
