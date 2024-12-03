using System.ComponentModel.DataAnnotations;

namespace Heroes.Models;
public class EquipmentType
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}