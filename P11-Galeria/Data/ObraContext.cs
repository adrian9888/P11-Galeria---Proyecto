using Microsoft.EntityFrameworkCore;
using P11_Galeria.Models;

namespace P11_Galeria.Data
{
    public class ObraContext:DbContext
    {
        public ObraContext(DbContextOptions<ObraContext> o) : base(o) { }
        public DbSet<Obra> ObraColl { get; set; }
    }
}
