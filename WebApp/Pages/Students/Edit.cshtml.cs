using Application.Features.Students.Commands;
using Application.Features.Students.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IMediator? _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>()!;

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student =  await Mediator.Send(new GetStudentByIdQuery { Id = id });

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
                
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await Mediator.Send(new UpdateStudentCommand { Student = Student });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;                
            }

            return RedirectToPage("./Index");
        }
    }
}
