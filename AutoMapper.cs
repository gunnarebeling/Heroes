using AutoMapper;
using Heroes.Models;
using Heroes.Models.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        CreateMap<Heroe,AllHeroesDTO >();
        CreateMap<AllHeroesDTO, Heroe>();
        CreateMap<Heroe, HeroeDetailsDTO>();
        CreateMap<HeroeDetailsDTO, Heroe>();
        CreateMap<Equipment, EquipmentForHeroDTO>();
        CreateMap<EquipmentForHeroDTO, Equipment>();
        CreateMap<Equipment, EquipmentDTO>();
        CreateMap<EquipmentDTO, Equipment>();
        CreateMap<Archetype, ArchetypeDTO>();
        CreateMap<ArchetypeDTO, Archetype>();
        CreateMap<Quest, QuestForHeroesDTO>();
        CreateMap<QuestForHeroesDTO, Quest>();
        CreateMap<Quest, AllQuestsDTO>();
        CreateMap<AllQuestsDTO, Quest>();
        CreateMap<Quest, SimpleQuestDTO>();
        CreateMap<SimpleQuestDTO, Quest>();
        CreateMap<EquipmentType, EquipmentTypeDTO>();
        CreateMap<EquipmentTypeDTO, EquipmentType>();
    }
}