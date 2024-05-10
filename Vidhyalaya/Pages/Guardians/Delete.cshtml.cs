using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vidhyalaya.Pages_Guardians
{
    public class DeleteModel : PageModel
    {
        private readonly VidhyalayaDbContext _context;

        public DeleteModel(VidhyalayaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guardian Guardian { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardian = await _context.GuardianDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (guardian == null)
            {
                return NotFound();
            }
            else
            {
                Guardian = guardian;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardian = await _context.GuardianDetails.FindAsync(id);
            if (guardian != null)
            {
                Guardian = guardian;
                _context.GuardianDetails.Remove(Guardian);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
