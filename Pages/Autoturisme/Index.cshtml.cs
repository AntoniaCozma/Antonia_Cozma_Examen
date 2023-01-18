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
    public class IndexModel : PageModel
    {
        private readonly Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext _context;

        public IndexModel(Antonia_Cozma_Examen.Data.Antonia_Cozma_ExamenContext context)
        {
            _context = context;
        }

        public IList<Autoturism> Autoturism { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Autoturism != null)
            {
                Autoturism = await _context.Autoturism.Include.(b=>b.Pret)
                    object value = ToListAsync();
            }
        }

        private object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
