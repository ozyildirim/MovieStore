using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class Actor
{
    [Key]
    public int ActorId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool isActive { get; set; } = true;
    public ICollection<ActorMovie> ActorMovies { get; set; }
}
