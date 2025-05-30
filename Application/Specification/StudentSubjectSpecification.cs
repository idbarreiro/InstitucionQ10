using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class StudentSubjectSpecification : Specification<StudentSubject>
    {
        public StudentSubjectSpecification(int? studentId)
        {
            Query.Where(ss => ss.StudentId == studentId)
                .OrderBy(ss => ss.SubjectId);
        }
    }
}
