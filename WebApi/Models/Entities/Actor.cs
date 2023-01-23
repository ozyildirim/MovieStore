using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class Actor
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
    public bool isActive { get; set; } = true;
}
