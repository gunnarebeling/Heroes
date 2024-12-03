using System.ComponentModel.DataAnnotations;

namespace Heroes.Models.DTOs;

public class AllHeroesDTO
{
    public int Id { get; set; }
    public string Name { get; set; }  
    public int ArchetypeId { get; set; }
    public  ArchetypeDTO Archetype { get; set; }
}

public class HeroeDetailsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public int ArchetypeId { get; set; }
    public  ArchetypeDTO Archetype { get; set; }
    public int? QuestId { get; set; }
    public QuestForHeroesDTO Quest {get; set;}
    public List<EquipmentForHeroDTO> Equipment { get; set; }
}