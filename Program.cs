using Heroes.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Heroes.Models.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HeroesDbContext>(builder.Configuration["HeroesDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/heroes", (HeroesDbContext db) => 
{
    return db.Heroes.Select(heroe => new AllHeroesDTO
    {
        Id = heroe.Id,
        Name = heroe.Name,
        ArchetypeId = heroe.ArchetypeId,
        Archetype = new ArchetypeDTO{Id = heroe.Archetype.Id, Name = heroe.Archetype.Name}
    });
});

app.MapGet("/api/heroes/{id}", (HeroesDbContext db, int id) => 
{
            return db.Heroes.Select(heroe => new HeroeDetailsDTO
            {
                Id = heroe.Id,
                Name = heroe.Name,
                Description = heroe.Description,
                Level = heroe.Level,
                ArchetypeId = heroe.ArchetypeId,
                Archetype = new ArchetypeDTO{Id = heroe.Archetype.Id, Name = heroe.Archetype.Name},
                Quests = heroe.Quests.Select(q => new QuestForHeroesDTO
                {
                    Id = q.Id,
                    Name = q.Name,
                    Description = q.Description,
                    Complete = q.Complete
                }).ToList(),
                Equipment = heroe.Equipment.Select(e => new EquipmentForHeroDTO
                {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                EquipmentTypeId = e.EquipmentTypeId,
                EquipmentType = new EquipmentTypeDTO{Id = e.EquipmentType.Id, Name = e.EquipmentType.Name},
                Weight = e.Weight
                }).ToList()
            }).Single(hero => hero.Id == id);
});

app.MapGet("/api/equipment", (HeroesDbContext db) => 
{
    return db.Equipment.Select(e => new EquipmentDTO
    {
        Id = e.Id,
        Name = e.Name,
        Description = e.Description,
        EquipmentTypeId = e.EquipmentTypeId,
        QuestId = e.QuestId,
        Quest = new SimpleQuestDTO {Id = e.Quest.Id, Complete = e.Quest.Complete},
        EquipmentType = new EquipmentTypeDTO{Id = e.EquipmentType.Id, Name = e.EquipmentType.Name}
    });
});


app.MapGet("/api/quests", (HeroesDbContext db, IMapper mapper) => 
{
    return db.Quests.Include(q => q.Heroes).ProjectTo<SimpleQuestDTO>(mapper.ConfigurationProvider).ToList();
});

app.MapGet("/api/quests/{id}", (HeroesDbContext db, IMapper mapper, int id) => 
{
    return db.Quests.Include(q => q.Heroes).ProjectTo<AllQuestsDTO>(mapper.ConfigurationProvider).Single(q => q.Id == id);
});

app.MapPost("/api/quests", (HeroesDbContext db, PostQuestDTO quest) => 
{
    Quest theQuest = new Quest{Name = quest.Name, Description = quest.Description};
    db.Quests.Add(theQuest);
    db.SaveChanges();
    return Results.Created($"/api/quests/{theQuest.Id}", theQuest);
});


app.MapPut("/api/quests/{id}", (HeroesDbContext db, int id, int? heroId) =>
{
   Heroe heroToUpdate = db.Heroes.Include(h => h.Quests).FirstOrDefault(st => st.Id == heroId);
   Quest quest = db.Quests.Include(q => q.Heroes).FirstOrDefault(q => q.Id == id);
   if (heroToUpdate == null || quest == null)
   {
        return Results.BadRequest();
    
   } 
   quest.Heroes.Add(heroToUpdate);
   db.SaveChanges();
   return Results.NoContent();

   
});

app.MapPut("/api/quests/{id}/complete", (HeroesDbContext db, int id) =>
{
   Quest questToUpdate = db.Quests.FirstOrDefault(st => st.Id == id);
   if (questToUpdate == null)
   {
        return Results.BadRequest();
    
   } 
   questToUpdate.Complete = true;
   db.SaveChanges();
   return Results.NoContent();

   
});

app.MapPost("/api/equipment", (HeroesDbContext db, EquipmentPostDTO equipment, IMapper mapper) => 
{
    Equipment newEquipment = mapper.Map<Equipment>(equipment);
    db.Equipment.Add(newEquipment);
    db.SaveChanges();
    return Results.Created($"/api/quests/{newEquipment.Id}", newEquipment);
});

app.MapPut("/api/heroes/{id}/equipment/{equipmentId}", (HeroesDbContext db, int id, int equipmentId) =>
{
   Equipment equipmentToUpdate = db.Equipment.Include(e => e.Quest).FirstOrDefault(st => st.Id == equipmentId);
   Heroe heroe = db.Heroes.FirstOrDefault(h => h.Id == id);
   if (equipmentToUpdate == null || !equipmentToUpdate.Available)
   {
        return Results.BadRequest("equipment not available");
    
   }
   if (heroe.Equipment != null && heroe.Equipment.Any(e => e.Id == equipmentId))
   {    
        return Results.BadRequest("heroe already is equiped with that");
   } 
   equipmentToUpdate.HeroeId = id;
   db.SaveChanges();
   return Results.NoContent();

   
});

app.MapDelete("/api/equipment/{id}", (HeroesDbContext db, int id) => 
{
    Equipment equipmentToDelete = db.Equipment.FirstOrDefault(e => e.Id == id);
    if (equipmentToDelete == null)
    {
        return Results.BadRequest();
    }
    db.Equipment.Remove(equipmentToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/api/heroes/{id}", (HeroesDbContext db, int id) => 
{
    Heroe heroe = db.Heroes.Include(h => h.Equipment).FirstOrDefault(e => e.Id == id);
    if (heroe == null)
    {
        return Results.BadRequest();
    }
    

    db.Heroes.Remove(heroe);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/api/quests/{id}", (HeroesDbContext db, int id) => 
{
    Quest quest = db.Quests.Include(q => q.Heroes).SingleOrDefault(q => q.Id ==id);
    if (quest == null)
    {
        return Results.BadRequest();
    }
    

    db.Quests.Remove(quest);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();

