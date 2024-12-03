using System.ComponentModel.DataAnnotations;

namespace Heroes.Models.DTOs;
public class EquipmentForHeroDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int EquipmentTypeId { get; set; }
    public EquipmentTypeDTO EquipmentType { get; set; }
    public int Weight { get; set; }

}

public class EquipmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int EquipmentTypeId { get; set; }
    public EquipmentTypeDTO EquipmentType { get; set; }

}

