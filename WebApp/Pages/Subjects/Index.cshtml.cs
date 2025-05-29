using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Context;

namespace WebApp.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly Persistence.Context.ApplicationDbContext _context;

        public IndexModel(Persistence.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subject> Subjects { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Subjects = await _context.Subjects.ToListAsync();
        }
    }
}
