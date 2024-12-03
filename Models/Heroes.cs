using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;

public class Heroe
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int Level { get; set; }
    public int ArchetypeId { get; set; }
    public  Archetype Archetype { get; set; }
    public List<Quest> Quests {get; set;}
    public List<Equipment> Equipment { get; set; }
}