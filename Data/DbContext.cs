
namespace Form.Data

{
    using Microsoft.EntityFrameworkCore;
    using Form.Models;
    //este es el contexto de base de datos, se configura para interactuar con base de datos y para proporcionar acceso a dbset
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define los DbSet para tus entidades
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

    }
}
