using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public Student Student { get; set; } = default!;
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IRepositoryAsync<Student> _repository;
        
        public UpdateStudentCommandHandler(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.UpdateAsync(request.Student);
            return true;
        }
    }
}
