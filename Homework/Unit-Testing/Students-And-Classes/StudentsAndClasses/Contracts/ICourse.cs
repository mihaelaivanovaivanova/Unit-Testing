using System.Collections.Generic;

namespace StudentsAndClasses.Contracts
{
    public interface ICourse
    {
        IList<IStudent> StudentsInCourse { get; }
        void AddStudent(IStudent student);
        void RemoveStudent(IStudent student);
    }
}
