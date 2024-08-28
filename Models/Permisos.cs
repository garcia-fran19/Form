using System.ComponentModel.DataAnnotations.Schema;

namespace Form.Models
{
    [Table("permiso")]
    public class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    [Table("rolpermiso")]
    public class RolPermiso
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int PermisoId { get; set; }
        public Permiso Permiso { get; set; }
    }

    [Table("permisoaudits")]
    public class PermisoAudit
    {
        public int Id { get; set; }
        public string Accion { get; set; } // Ejemplo: "Crear", "Actualizar", "Eliminar"
        public int PermisoId { get; set; }
        public string NombrePermiso { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Usuario { get; set; } // Puede ser el nombre del usuario que hizo el cambio
    }
}
