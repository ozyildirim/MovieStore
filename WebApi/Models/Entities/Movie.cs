using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public DateTime? Year { get; set; }
    public int? DirectorId { get; set; }
    public Director? Director { get; set; }
    public double? Price { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<ActorMovie>? ActorMovies { get; set; }
}
