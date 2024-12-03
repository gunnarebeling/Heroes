using Heroes.Models;
using Microsoft.EntityFrameworkCore;

public class HeroesDbContext : DbContext
{
    public DbSet<EquipmentType> EquipmentTypes {get; set;}
    public DbSet<Archetype> Archetypes { get; set; }
    public DbSet<Equipment> Equipment {get; set;}
    public DbSet<Quest> Quests { get; set; }
    public DbSet<Heroe> Heroes {get; set;}

    public HeroesDbContext(DbContextOptions<HeroesDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentType>().HasData(new EquipmentType[]
        {
            new EquipmentType { Id = 1, Name = "Sword" },
            new EquipmentType { Id = 2, Name = "Shield" },
            new EquipmentType { Id = 3, Name = "Bow and Arrows" },
            new EquipmentType { Id = 4, Name = "Magic Staff" },
            new EquipmentType { Id = 5, Name = "potions" }
        });




        modelBuilder.Entity<Archetype>().HasData(new Archetype[]
        {
            new Archetype { Id = 1, Name = "Warrior" },
            new Archetype { Id = 2, Name = "Mage" },
            new Archetype { Id = 3, Name = "Rogue" },
            new Archetype { Id = 4, Name = "Cleric" }
        });

        modelBuilder.Entity<Heroe>().HasData(new Heroe[]
        {
            new Heroe
            {
                Id = 1,
                Name = "Arthas",
                Description = "A brave warrior seeking redemption.",
                Level = 15,
                ArchetypeId = 1, // Warrior
            },
            new Heroe
            {
                Id = 2,
                Name = "Merlin",
                Description = "A wise mage with unparalleled arcane knowledge.",
                Level = 20,
                ArchetypeId = 2, // Mage
            
            },
            new Heroe
            {
                Id = 3,
                Name = "Lyra",
                Description = "A cunning rogue skilled in infiltration and assassination.",
                Level = 12,
                ArchetypeId = 3, // Rogue
            },
            new Heroe
            {
                Id = 4,
                Name = "Elenora",
                Description = "A devout cleric who heals her allies with divine power.",
                Level = 18,
                ArchetypeId = 4 // Cleric
            }
            
        });

        modelBuilder.Entity<Equipment>().HasData(new Equipment[]
        {
            new Equipment
            {
                Id = 1,
                Name = "Excalibur",
                Description = "A legendary sword of unparalleled sharpness and strength.",
                EquipmentTypeId = 1, // Sword
                Weight = 10,
                QuestId = 2

            },
            new Equipment
            {
                Id = 2,
                Name = "Arcane Staff",
                Description = "A staff imbued with powerful magical energy.",
                EquipmentTypeId = 4, // Magic Staff
                Weight = 7,
                QuestId = 3

            },
            new Equipment
            {
                Id = 3,
                Name = "Shadow Dagger",
                Description = "A lightweight dagger designed for stealth attacks.",
                EquipmentTypeId = 1, // Dagger
                Weight = 2,
                QuestId = 5

            },
            new Equipment
            {
                Id = 4,
                Name = "Holy Shield",
                Description = "A shield blessed by divine power to repel evil.",
                EquipmentTypeId = 2, // Shield
                Weight = 15,
                QuestId = 4

            }
            
        });
        
        modelBuilder.Entity<Quest>().HasData(new Quest[]
        {
            new Quest
            {
                Id = 1,
                Name = "Rescue the Princess",
                Description = "Save the princess from the dragon's lair deep in the mountains.",
                Complete = false
            },
            new Quest
            {
                Id = 2,
                Name = "Defend the Village",
                Description = "Protect the village from an impending goblin attack.",
                Complete = false
            },
            new Quest
            {
                Id = 3,
                Name = "Retrieve the Sacred Relic",
                Description = "Locate and return the ancient relic from the cursed ruins.",
                Complete = false
            },
            new Quest
            {
                Id = 4,
                Name = "Slay the Demon King",
                Description = "Defeat the Demon King and end his reign of terror over the kingdom.",
                Complete = false
            },
            new Quest
            {
                Id = 5,
                Name = "Escort the Merchant",
                Description = "Safely escort the merchant and his goods through dangerous territory.",
                Complete = true
            }
            
        });

        modelBuilder.Entity<Heroe>()
        
            .HasMany(heroe => heroe.Quests)
            .WithMany(quests => quests.Heroes)
            .UsingEntity(j => j.HasData(
                new { HeroesId = 2, QuestsId = 2 },
                new { HeroesId = 2, QuestsId = 3 },
                new { HeroesId = 3, QuestsId = 3 }));
            

        

        
    }
}