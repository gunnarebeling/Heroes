﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Heroes.Migrations
{
    [DbContext(typeof(HeroesDbContext))]
    [Migration("20241203192144_addedAvailable2")]
    partial class addedAvailable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HeroeQuest", b =>
                {
                    b.Property<int>("HeroesId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestsId")
                        .HasColumnType("integer");

                    b.HasKey("HeroesId", "QuestsId");

                    b.HasIndex("QuestsId");

                    b.ToTable("HeroeQuest");

                    b.HasData(
                        new
                        {
                            HeroesId = 2,
                            QuestsId = 2
                        },
                        new
                        {
                            HeroesId = 2,
                            QuestsId = 3
                        },
                        new
                        {
                            HeroesId = 3,
                            QuestsId = 3
                        });
                });

            modelBuilder.Entity("Heroes.Models.Archetype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Archetypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Warrior"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mage"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rogue"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cleric"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EquipmentTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("HeroeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuestId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("HeroeId");

                    b.HasIndex("QuestId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A legendary sword of unparalleled sharpness and strength.",
                            EquipmentTypeId = 1,
                            Name = "Excalibur",
                            QuestId = 2,
                            Weight = 10
                        },
                        new
                        {
                            Id = 2,
                            Description = "A staff imbued with powerful magical energy.",
                            EquipmentTypeId = 4,
                            Name = "Arcane Staff",
                            QuestId = 3,
                            Weight = 7
                        },
                        new
                        {
                            Id = 3,
                            Description = "A lightweight dagger designed for stealth attacks.",
                            EquipmentTypeId = 1,
                            Name = "Shadow Dagger",
                            QuestId = 5,
                            Weight = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "A shield blessed by divine power to repel evil.",
                            EquipmentTypeId = 2,
                            Name = "Holy Shield",
                            QuestId = 4,
                            Weight = 15
                        });
                });

            modelBuilder.Entity("Heroes.Models.EquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sword"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shield"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bow and Arrows"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Magic Staff"
                        },
                        new
                        {
                            Id = 5,
                            Name = "potions"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Heroe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArchetypeId = 1,
                            Description = "A brave warrior seeking redemption.",
                            Level = 15,
                            Name = "Arthas"
                        },
                        new
                        {
                            Id = 2,
                            ArchetypeId = 2,
                            Description = "A wise mage with unparalleled arcane knowledge.",
                            Level = 20,
                            Name = "Merlin"
                        },
                        new
                        {
                            Id = 3,
                            ArchetypeId = 3,
                            Description = "A cunning rogue skilled in infiltration and assassination.",
                            Level = 12,
                            Name = "Lyra"
                        },
                        new
                        {
                            Id = 4,
                            ArchetypeId = 4,
                            Description = "A devout cleric who heals her allies with divine power.",
                            Level = 18,
                            Name = "Elenora"
                        });
                });

            modelBuilder.Entity("Heroes.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Complete")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Complete = false,
                            Description = "Save the princess from the dragon's lair deep in the mountains.",
                            Name = "Rescue the Princess"
                        },
                        new
                        {
                            Id = 2,
                            Complete = false,
                            Description = "Protect the village from an impending goblin attack.",
                            Name = "Defend the Village"
                        },
                        new
                        {
                            Id = 3,
                            Complete = false,
                            Description = "Locate and return the ancient relic from the cursed ruins.",
                            Name = "Retrieve the Sacred Relic"
                        },
                        new
                        {
                            Id = 4,
                            Complete = false,
                            Description = "Defeat the Demon King and end his reign of terror over the kingdom.",
                            Name = "Slay the Demon King"
                        },
                        new
                        {
                            Id = 5,
                            Complete = true,
                            Description = "Safely escort the merchant and his goods through dangerous territory.",
                            Name = "Escort the Merchant"
                        });
                });

            modelBuilder.Entity("HeroeQuest", b =>
                {
                    b.HasOne("Heroes.Models.Heroe", null)
                        .WithMany()
                        .HasForeignKey("HeroesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes.Models.Quest", null)
                        .WithMany()
                        .HasForeignKey("QuestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Heroes.Models.Equipment", b =>
                {
                    b.HasOne("Heroes.Models.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes.Models.Heroe", "Heroe")
                        .WithMany("Equipment")
                        .HasForeignKey("HeroeId");

                    b.HasOne("Heroes.Models.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");

                    b.Navigation("Heroe");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("Heroes.Models.Heroe", b =>
                {
                    b.HasOne("Heroes.Models.Archetype", "Archetype")
                        .WithMany()
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archetype");
                });

            modelBuilder.Entity("Heroes.Models.Heroe", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
