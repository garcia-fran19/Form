using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Form.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }

        // Relación con el Rol
        public int? RolId { get; set; } //foreign key, nullable
        public Rol Rol { get; set; }  // asocia esta tabla con la tabla Rol
    }


}


