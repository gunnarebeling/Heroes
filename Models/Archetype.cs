using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;
public class Archetype
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}