using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool isActive { get; set; } = true;
}
