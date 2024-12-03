using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Complete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    ArchetypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EquipmentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    HeroeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Heroes_HeroeId",
                        column: x => x.HeroeId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroeQuest",
                columns: table => new
                {
                    HeroesId = table.Column<int>(type: "integer", nullable: false),
                    QuestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroeQuest", x => new { x.HeroesId, x.QuestsId });
                    table.ForeignKey(
                        name: "FK_HeroeQuest_Heroes_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroeQuest_Quests_QuestsId",
                        column: x => x.QuestsId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Archetypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Warrior" },
                    { 2, "Mage" },
                    { 3, "Rogue" },
                    { 4, "Cleric" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sword" },
                    { 2, "Shield" },
                    { 3, "Bow and Arrows" },
                    { 4, "Magic Staff" },
                    { 5, "potions" }
                });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "Complete", "Description", "Name" },
                values: new object[,]
                {
                    { 1, false, "Save the princess from the dragon's lair deep in the mountains.", "Rescue the Princess" },
                    { 2, false, "Protect the village from an impending goblin attack.", "Defend the Village" },
                    { 3, false, "Locate and return the ancient relic from the cursed ruins.", "Retrieve the Sacred Relic" },
                    { 4, false, "Defeat the Demon King and end his reign of terror over the kingdom.", "Slay the Demon King" },
                    { 5, true, "Safely escort the merchant and his goods through dangerous territory.", "Escort the Merchant" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Description", "EquipmentTypeId", "HeroeId", "Name", "QuestId", "Weight" },
                values: new object[,]
                {
                    { 1, "A legendary sword of unparalleled sharpness and strength.", 1, null, "Excalibur", 2, 10 },
                    { 2, "A staff imbued with powerful magical energy.", 4, null, "Arcane Staff", 3, 7 },
                    { 3, "A lightweight dagger designed for stealth attacks.", 1, null, "Shadow Dagger", 5, 2 },
                    { 4, "A shield blessed by divine power to repel evil.", 2, null, "Holy Shield", 4, 15 }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "ArchetypeId", "Description", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A brave warrior seeking redemption.", 15, "Arthas" },
                    { 2, 2, "A wise mage with unparalleled arcane knowledge.", 20, "Merlin" },
                    { 3, 3, "A cunning rogue skilled in infiltration and assassination.", 12, "Lyra" },
                    { 4, 4, "A devout cleric who heals her allies with divine power.", 18, "Elenora" }
                });

            migrationBuilder.InsertData(
                table: "HeroeQuest",
                columns: new[] { "HeroesId", "QuestsId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeId",
                table: "Equipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_HeroeId",
                table: "Equipment",
                column: "HeroeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_QuestId",
                table: "Equipment",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroeQuest_QuestsId",
                table: "HeroeQuest",
                column: "QuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_ArchetypeId",
                table: "Heroes",
                column: "ArchetypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "HeroeQuest");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Archetypes");
        }
    }
}
