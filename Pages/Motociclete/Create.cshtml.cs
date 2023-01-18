using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Liste;
using Antonia_Cozma_Examen.Pages.Autoturisme;

namespace Antonia_Cozma_Examen.Pages.Motociclete
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
        public Motocicleta Motocicleta { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Motocicleta.Add(Motocicleta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
