using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int? Id { get; set; }
    }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IRepositoryAsync<Student> _repository;
        
        public DeleteStudentCommandHandler(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(request.Id);

            if (student == null)
            {
                return false;
            }
            else 
            {
                await _repository.DeleteAsync(student);
                return true;
            }
        }
    }
}
