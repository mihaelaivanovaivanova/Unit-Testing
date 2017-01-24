
using StudentsAndClasses.Models;

namespace StudentsAndClasses.Contracts
{
    public interface IStudent
    {
        string Name { get; }
        int StudentID { get; }

        School School { get; }
        void JoinCourse(ICourse course);
        void LeaveCourse(ICourse course);

    }
}
