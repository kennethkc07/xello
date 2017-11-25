namespace GraduationTracker
{
    using System;
    using System.Linq;

    public partial class GraduationTracker
    {
        /// <summary>
        /// Function calculates average of student and provides an appropriate standing based on the result
        /// </summary>
        /// <param name="diploma">Contains the IDs of Required Courses</param>
        /// <param name="student">Contains List of Courses the Student Undertook</param>
        /// <returns>A tuple value that contains a boolean value and the standing</returns>
        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student)
        {
            //Removed the variable "credits" as it wasn't used anywhere in the program.
            var average = 0;
            //Performed validations before executing the Expression to avoid any exceptions
            if (diploma != null && student != null && !student.Courses.Count().Equals(0))
                average = diploma.Requirements.Where(requirementId =>
                        new Repository<RequirementRepository>().FetchRecordByID(requirementId) != null)
                        .Select(requirementId =>
                            student.Courses.Where(courseSelector =>
                                courseSelector.Id.Equals(requirementId))
                                .Select(courseSelector => courseSelector.Mark)
                                .Sum()).Sum() / student.Courses.Count();
            //Renamed and Moved the "GetRequirement" function above the Student Loop to reduce the amount of database call
            //Adding the marks of the course selector imperatively as all the conditions statisfy and perform an average

            //Removed unecessary "standing" variable as the same can be achieved by directly accessing the enum-constant
            return
            average == 0 ? new Tuple<bool, Standing>(false, Standing.None) :
            average < 50 ? new Tuple<bool, Standing>(false, Standing.Remedial) :
            average < 80 ? new Tuple<bool, Standing>(true, Standing.Average) :
            average < 95 ? new Tuple<bool, Standing>(true, Standing.MagnaCumLaude) :
                            new Tuple<bool, Standing>(true, Standing.SumaCumLaude);
        }
    }
}