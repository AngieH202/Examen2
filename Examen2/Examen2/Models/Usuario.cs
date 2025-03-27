using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.Models;
[Table("usuario")]


public class Usuario
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("correo")]
    public string Correo { get; set; }

    [Column("contraseña")]
    public string Contraseña { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

}
