using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Antonia_Cozma_Examen.Models;
using Antonia_Cozma_Examen.Liste;

namespace Antonia_Cozma_Examen.Data
{
    public class Antonia_Cozma_ExamenContext : DbContext
    {
        public Antonia_Cozma_ExamenContext (DbContextOptions<Antonia_Cozma_ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Antonia_Cozma_Examen.Models.Autoturism> Autoturism { get; set; } = default!;

        public DbSet<Antonia_Cozma_Examen.Liste.Motocicleta> Motocicleta { get; set; }

        public DbSet<Antonia_Cozma_Examen.Liste.Atv> Atv { get; set; }
    }
}
