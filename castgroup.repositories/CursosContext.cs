using castgroup.models;
using Microsoft.EntityFrameworkCore;

namespace castgroup.repositories
{
    internal class CursosContext: DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public CursosContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=cursos;Username=postgres;Password=vi492412VI");
    }
}
