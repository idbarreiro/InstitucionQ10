using Application.Interfaces;
using Application.Specification;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Queries
{
    public class GetSubjectsByCreditsQuery : IRequest<List<Subject>>
    {
        public int Credits { get; set; }
    }

    public class GetSubjectsByCreditsQueryHandler : IRequestHandler<GetSubjectsByCreditsQuery, List<Subject>>
    {
        private readonly IRepositoryAsync<Subject> _repository;

        public GetSubjectsByCreditsQueryHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<List<Subject>> Handle(GetSubjectsByCreditsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _repository.ListAsync(new SubjectSpecification(request.Credits));
            return subjects;
        }
    }
}
