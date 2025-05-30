using Application.Features.Students.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IMediator? _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>()!;

        public IList<Student> Students { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Students = await Mediator.Send(new GetAllStudentsQuery());
        }
    }
}
