using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Models;

namespace Antonia_Cozma_Examen.Pages.Autoturisme
{
    public class EditModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public EditModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Autoturism Autoturism { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Autoturism == null)
            {
                return NotFound();
            }

            var autoturism =  await _context.Autoturism.FirstOrDefaultAsync(m => m.ID == id);
            if (autoturism == null)
            {
                return NotFound();
            }
            Autoturism = autoturism;
            iewData["PretID"] = new SelectList(_context.Set<Pret>(), "ID", "Pret");
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

            _context.Attach(Autoturism).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoturismExists(Autoturism.ID))
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

        private bool AutoturismExists(int id)
        {
          return _context.Autoturism.Any(e => e.ID == id);
        }
    }
}
