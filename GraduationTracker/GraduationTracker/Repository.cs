namespace GraduationTracker
{
    using System.Collections.Generic;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        //Used dyanmic as var may only appear within a local variable declaration on in script code
        //Alternatively, it could be replaced with DBSet when using Entity Framework but that is beyond the scope of this test.
        dynamic entity;

        //Moved all the fetch request to the constructor.
        //Since this is acting as a repository, real-world projects would ideally use the "DBSet" with enity framework to select the table using the ORM
        //That being beyond the scope of the project, the constructor does exactly how the orm would behave, and holds all the data upon intialization
        public Repository()
        {
            var nameOfEntity = typeof(T).Name;

            switch (nameOfEntity)
            {
                case "StudentRepository":
                    {
                        this.entity = new List<Student>
                        {
                            new Student
                            {
                                Id = 1,
                                Courses = new List<Course>
                                {
                                    new Course{Id = 1, Name = "Math", Mark=95 },
                                    new Course{Id = 2, Name = "Science", Mark=95 },
                                    new Course{Id = 3, Name = "Literature", Mark=95 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                                }
                            },
                            new Student
                            {
                                Id = 2,
                                Courses = new List<Course>
                                {
                                    new Course{Id = 1, Name = "Math", Mark=80 },
                                    new Course{Id = 2, Name = "Science", Mark=80 },
                                    new Course{Id = 3, Name = "Literature", Mark=80 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                                }
                            },
                            new Student
                            {
                                Id = 3,
                                Courses = new List<Course>
                                {
                                    new Course{Id = 1, Name = "Math", Mark=50 },
                                    new Course{Id = 2, Name = "Science", Mark=50 },
                                    new Course{Id = 3, Name = "Literature", Mark=50 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                                }
                            },
                            new Student
                            {
                                Id = 4,
                                Courses = new List<Course>
                                {
                                    new Course{Id = 1, Name = "Math", Mark=40 },
                                    new Course{Id = 2, Name = "Science", Mark=40 },
                                    new Course{Id = 3, Name = "Literature", Mark=40 },
                                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                                }
                            }
                        };
                        break;
                    }
                case "DiplomaRepository":
                    {
                        this.entity = new List<Diploma>
                        {
                            new Diploma
                            {
                                Id = 1,
                                Credits = 4,
                                Requirements = new List<int>{100,102,103,104}
                            }
                        };
                        break;
                    }
                case "RequirementRepository":
                    {
                        this.entity = new List<Requirement>
                        {
                            new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new List<int>{1}, Credits=1 },
                            new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new List<int>{2}, Credits=1 },
                            new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new List<int>{3}, Credits=1},
                            new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new List<int>{4}, Credits=1 }
                        };
                        break;
                    }
            }
        }

        //Implemented the IRepository interface and defined a generic fuction that returns the results according to the parameter passed
        //Since the "entity" object behaves like the "DBSet" type, only the dynamic type could be used as "object" types would require casting and var has it's own requirements as in the comments above
        //We access the data using reflection since "Id" is not recognized at compile time due to it being anonymous
        public dynamic FetchRecordByID(int id)
        {
            return new List<object>() { this.entity.ToArray() }.AsEnumerable()
                .Where(item => item.GetType().GetProperty("Id").GetValue(item).Equals(id));
        }
    }

    public class StudentRepository
    {   
        private IRepository<Student> studentRepository;

        public StudentRepository(IRepository<Student> studentRepository) { this.studentRepository = studentRepository; }       
    }

    public class DiplomaRepository
    {
        private IRepository<Diploma> diplomaRepository;

        public DiplomaRepository(IRepository<Diploma> diplomaRepository) { this.diplomaRepository = diplomaRepository; }
    }

    public class RequirementRepository
    {
        private IRepository<Requirement> requirementRepository;

        public RequirementRepository(IRepository<Requirement> requirementRepository) { this.requirementRepository = requirementRepository; }
    }
}