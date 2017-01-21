
namespace StudentsAndClasses.Contracts
{
    public interface IStudent
    {
        string Name { get; }
        int StudentID { get; }
        void JoinCourse(ICourse course);
        void LeaveCourse(ICourse course);

    }
}
