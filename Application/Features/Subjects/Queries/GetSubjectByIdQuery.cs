using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Queries
{
    public class GetSubjectByIdQuery : IRequest<Subject>
    {
        public int? Id { get; set; }
    }

    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, Subject>
    {
        private readonly IRepositoryAsync<Subject> _repository;

        public GetSubjectByIdQueryHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var subject = await _repository.GetByIdAsync(request.Id);
            return subject;
        }
    }
}
