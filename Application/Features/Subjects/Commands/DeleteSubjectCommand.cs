using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Commands
{
    public class DeleteSubjectCommand : IRequest<bool>
    {
        public int? Id { get; set; }
    }

    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly IRepositoryAsync<Subject> _repository;
        
        public DeleteSubjectCommandHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }
     
        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _repository.GetByIdAsync(request.Id);

            if (subject == null)
            {
                return false;
            }
            else
            {
                await _repository.DeleteAsync(subject);
                return true;
            }
        }
    }
}
