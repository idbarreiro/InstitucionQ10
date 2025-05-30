using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int? Id { get; set; }
    }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IRepositoryAsync<Student> _repository;

        public GetStudentByIdQueryHandler(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(request.Id);
            return student;
        }
    }
}
