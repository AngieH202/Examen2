using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen2.Models;
[Table("tareas")]

public class Tareas
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("nombre")]

    public string Nombre { get; set; }
    [Column("descripcion")]

    public string Descripcion { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }



}

