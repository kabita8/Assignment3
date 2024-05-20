using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vidhyalaya.Pages_Grades
{
    public class IndexModel : PageModel
    {
        private readonly VidhyalayaDbContext _context;

        public IndexModel(VidhyalayaDbContext context)
        {
            _context = context;
        }

        public IList<Grade> Grade { get;set; } = default!;
        [BindProperty(SupportsGet =true)]
        public int? Year {get; set;}
        public async Task OnGetAsync()
        {
            Console.WriteLine($"Filtering by Year: {Year}");
            var grades = from g in _context.Grades
                         select g;

            if (Year.HasValue)
            {
                grades = grades.Where(g => g.SessionYear.Year == Year.Value);
            }
            Grade = await grades.ToListAsync();
        }
    }
}
