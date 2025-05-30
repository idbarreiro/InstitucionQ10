using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class SubjectSpecification : Specification<Subject>
    {
        public SubjectSpecification(int credits)
        {
            Query.Where(s => s.Credits == credits);
        }
    }
}
