using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Antonia_Cozma_Examen.Data;
using Antonia_Cozma_Examen.Liste;

namespace Antonia_Cozma_Examen.Pages.Atv_uri
{
    public class DetailsModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public DetailsModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

      public Atv Atv { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Atv == null)
            {
                return NotFound();
            }

            var atv = await _context.Atv.FirstOrDefaultAsync(m => m.ID == id);
            if (atv == null)
            {
                return NotFound();
            }
            else 
            {
                Atv = atv;
            }
            return Page();
        }
    }
}
