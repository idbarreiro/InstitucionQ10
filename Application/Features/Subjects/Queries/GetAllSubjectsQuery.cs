using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Queries
{
    public class GetAllSubjectsQuery : IRequest<List<Subject>>
    {
    }

    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, List<Subject>>
    {
        private readonly IRepositoryAsync<Subject> _repository;

        public GetAllSubjectsQueryHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<List<Subject>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListAsync();
        }
    }
}
