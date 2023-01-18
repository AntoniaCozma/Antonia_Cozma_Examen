using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Models;
using System.Security.Policy;

namespace Antonia_Cozma_Examen.Pages.Autoturisme
{
    public class CreateModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public CreateModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PretID"] = new SelectList(_context.Set<Pret>(), "ID", "Pret");
            return Page();
        }

        [BindProperty]
        public Autoturism Autoturism { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Autoturism.Add(Autoturism);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
