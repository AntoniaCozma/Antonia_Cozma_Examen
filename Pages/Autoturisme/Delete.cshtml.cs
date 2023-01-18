using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Models;

namespace Antonia_Cozma_Examen.Pages.Autoturisme
{
    public class DeleteModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public DeleteModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Autoturism Autoturism { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Autoturism == null)
            {
                return NotFound();
            }

            var autoturism = await _context.Autoturism.FirstOrDefaultAsync(m => m.ID == id);

            if (autoturism == null)
            {
                return NotFound();
            }
            else 
            {
                Autoturism = autoturism;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Autoturism == null)
            {
                return NotFound();
            }
            var autoturism = await _context.Autoturism.FindAsync(id);

            if (autoturism != null)
            {
                Autoturism = autoturism;
                _context.Autoturism.Remove(Autoturism);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
