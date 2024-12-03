using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;
public class Equipment
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int EquipmentTypeId { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public int Weight { get; set; }
    public int QuestId {get; set;}
    public Quest Quest {get; set;}
    public bool Available 
    {
        get
        {
            if (Quest.Complete)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    public int? HeroeId { get; set; }
    public Heroe Heroe {get; set;}
}