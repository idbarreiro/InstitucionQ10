using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentSubjects.Commands
{
    public class CreateStudentSubjectCommand : IRequest<bool>
    {
        public StudentSubject StudentSubject { get; set; } = default!;
    }

    public class CreateStudentSubjectCommandHandler : IRequestHandler<CreateStudentSubjectCommand, bool>
    {
        private readonly IRepositoryAsync<StudentSubject> _repository;

        public CreateStudentSubjectCommandHandler(IRepositoryAsync<StudentSubject> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateStudentSubjectCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.AddAsync(request.StudentSubject);
            return true;
        }
    }
}
