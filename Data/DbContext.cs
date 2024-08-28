using Microsoft.EntityFrameworkCore;
using Form.Models;

namespace Form.Data

{
 
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
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<PermisoAudit> PermisoAudits { get; set; } // Añadir PermisoAudit al contexto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la clave compuesta para RolPermiso
            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolPermisos)
                .HasForeignKey(rp => rp.RolId);

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany()
                .HasForeignKey(rp => rp.PermisoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
