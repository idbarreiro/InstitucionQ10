using Application.Interfaces;
using Application.Specification;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentSubjects.Queries
{
    public class GetSubjectsByIdStudentQuery : IRequest<List<StudentSubject>>
    {
        public int? StudentId { get; set; }
    }

    public class GetSubjectsByIdStudentQueryHandler : IRequestHandler<GetSubjectsByIdStudentQuery, List<StudentSubject>>
    {
        private readonly IRepositoryAsync<StudentSubject> _repository;

        public GetSubjectsByIdStudentQueryHandler(IRepositoryAsync<StudentSubject> repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentSubject>> Handle(GetSubjectsByIdStudentQuery request, CancellationToken cancellationToken)
        {
            var studentSubjects = await _repository.ListAsync(new StudentSubjectSpecification(request.StudentId));
            return studentSubjects;
        }
    }
}
