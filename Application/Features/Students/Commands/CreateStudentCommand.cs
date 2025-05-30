using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public Student Student { get; set; } = default!;
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IRepositoryAsync<Student> _repository;

        public CreateStudentCommandHandler(IRepositoryAsync<Student> repository)
        {
            _repository = repository; 
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.AddAsync(request.Student);
            return true;
        }
    }
}
