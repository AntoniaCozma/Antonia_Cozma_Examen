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
    public class IndexModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public IndexModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

        public IList<Atv> Atv { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Atv != null)
            {
                Atv = await _context.Atv.Include(b=>b.Pret) 
                    ToListAsync();
            }
        }
    }
}
