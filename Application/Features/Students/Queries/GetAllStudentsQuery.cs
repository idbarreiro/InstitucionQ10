using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IRepositoryAsync<Student> _repository;

        public GetAllStudentsQueryHandler(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListAsync();
        }
    }
}
