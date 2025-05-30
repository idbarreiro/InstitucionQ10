using Application.Features.Students.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Commands
{
    public class UpdateSubjectCommand : IRequest<bool>
    {
        public Subject Subject { get; set; } = default!;
    }

    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, bool>
    {
        private readonly IRepositoryAsync<Subject> _repository;

        public UpdateSubjectCommandHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.UpdateAsync(request.Subject);
            return true;
        }
    }
}
