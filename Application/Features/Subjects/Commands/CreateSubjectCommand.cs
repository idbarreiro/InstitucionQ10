using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<bool>
    {
        public Subject Subject { get; set; } = default!;
    }

    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, bool>
    {
        private readonly IRepositoryAsync<Subject> _repository;

        public CreateSubjectCommandHandler(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.AddAsync(request.Subject);
            return true;
        }
    }
}
