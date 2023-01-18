using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Liste;

namespace Antonia_Cozma_Examen.Pages.Motociclete
{
    public class DetailsModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public DetailsModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

      public Motocicleta Motocicleta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Motocicleta == null)
            {
                return NotFound();
            }

            var motocicleta = await _context.Motocicleta.FirstOrDefaultAsync(m => m.ID == id);
            if (motocicleta == null)
            {
                return NotFound();
            }
            else 
            {
                Motocicleta = motocicleta;
            }
            return Page();
        }
    }
}
