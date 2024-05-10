using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Vidhyalaya.Pages_Guardians
{
    public class EditModel : PageModel
    {
        private readonly VidhyalayaDbContext _context;

        public EditModel(VidhyalayaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guardian Guardian { get; set; } = default!;
        public List<SelectListItem> Students { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Students=_context.Students
            .Select(x=> new SelectListItem{Text=x.Name, Value=x.Id.ToString()})
            .ToList();
            if (id == null)
            {
                return NotFound();
            }

            var guardian =  await _context.GuardianDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (guardian == null)
            {
                return NotFound();
            }
            Guardian = guardian;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Guardian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuardianExists(Guardian.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GuardianExists(int id)
        {
            return _context.GuardianDetails.Any(e => e.Id == id);
        }
    }
}
