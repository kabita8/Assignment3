using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vidhyalaya.Pages_Guardians
{
    public class IndexModel : PageModel
    {
        private readonly VidhyalayaDbContext _context;

        public IndexModel(VidhyalayaDbContext context)
        {
            _context = context;
        }

        public IList<Guardian> Guardian { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Guardian = await _context.GuardianDetails
                .Include(g => g.Student).ToListAsync();
        }
    }
}
