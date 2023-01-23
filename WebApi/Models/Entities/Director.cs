using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Entities;

public class Director
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
    public bool isActive { get; set; } = true;
}
