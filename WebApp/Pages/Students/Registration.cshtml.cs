using Application.Features.Students.Queries;
using Application.Features.StudentSubjects.Commands;
using Application.Features.StudentSubjects.Queries;
using Application.Features.Subjects.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Students
{
    public class RegistrationModel : PageModel
    {
        private readonly IMediator? _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>()!;

        [TempData]
        public string WarningMessage { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public int SelectedSubjectId { get; set; }

        public Student Student { get; set; } = null!;
        public StudentSubject StudentSubject { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public List<Subject> RegisteredSubjects { get; set; } = new();
        public List<StudentSubject> StudentSubjects { get; set; } = new();
        public List<SelectListItem> AvailableSubjects { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            WarningMessage = null;

            await LoadData();
            if (Student == null)
                return NotFound();
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            StudentSubjects = await Mediator.Send(new GetSubjectsByIdStudentQuery { StudentId = Id });
            foreach (var subject in StudentSubjects)
            {
                var subjectDetails = await Mediator.Send(new GetSubjectByIdQuery { Id = subject.SubjectId });
                if (subjectDetails.Credits > 4)
                {
                    RegisteredSubjects.Add(new Subject
                    {
                        Name = subjectDetails.Name,
                        Code = subjectDetails.Code,
                        Credits = subjectDetails.Credits
                    });
                }
            }
            Subject = await Mediator.Send(new GetSubjectByIdQuery { Id = SelectedSubjectId });

            if ((RegisteredSubjects.Count < 3 && Subject.Credits > 4) || Subject.Credits < 5)
            {
                StudentSubject = new StudentSubject
                {
                    StudentId = Id,
                    SubjectId = SelectedSubjectId
                };

                await Mediator.Send(new CreateStudentSubjectCommand { StudentSubject = StudentSubject });
            }
            else
            {
                WarningMessage = "You cannot register for more than 3 subjects with more than 4 credits.";
                StudentSubjects = new List<StudentSubject>();
                RegisteredSubjects = new List<Subject>();
                AvailableSubjects = new List<SelectListItem>();
                await LoadData();
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadData()
        {
            Student = await Mediator.Send(new GetStudentByIdQuery { Id = Id });

            
            StudentSubjects = await Mediator.Send(new GetSubjectsByIdStudentQuery { StudentId = Id });
            if (StudentSubjects.Any())
            {
                foreach (var subject in StudentSubjects)
                {
                    var subjectDetails = await Mediator.Send(new GetSubjectByIdQuery { Id = subject.SubjectId });

                    RegisteredSubjects.Add(new Subject
                    {
                        Name = subjectDetails.Name,
                        Code = subjectDetails.Code,
                        Credits = subjectDetails.Credits
                    });
                }
            }

            var subjects = await Mediator.Send(new GetAllSubjectsQuery());
            AvailableSubjects = subjects
                .Where(s => !StudentSubjects.Any(ss => ss.SubjectId == s.Id))
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.Name} ({s.Code})"
                })
                .ToList();
        }
    }
}
