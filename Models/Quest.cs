using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;
public class Quest
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public bool Complete { get; set; }
    public List<Heroe> Heroes { get; set; }
}