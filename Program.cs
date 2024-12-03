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
        QuestId = heroe.QuestId,
        Quest = new QuestForHeroesDTO{Id = heroe.Quest.Id, Name = heroe.Quest.Name, Description = heroe.Quest.Description, Complete = heroe.Quest.Complete},
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



app.Run();

