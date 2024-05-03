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

        public async Task OnGetAsync()
        {
            Grade = await _context.Grade.ToListAsync();
        }
    }
}
