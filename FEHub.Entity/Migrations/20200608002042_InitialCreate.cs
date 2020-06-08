using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FEHub.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    AccessoryType = table.Column<int>(type: "INTEGER", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NameKanji = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Company = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    IsExclusive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAvailableAsSacredSeal = table.Column<bool>(type: "INTEGER", nullable: false),
                    SkillPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillType = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponRefineType = table.Column<int>(type: "INTEGER", nullable: true),
                    Might = table.Column<int>(type: "INTEGER", nullable: true),
                    Range = table.Column<int>(type: "INTEGER", nullable: true),
                    Cooldown = table.Column<int>(type: "INTEGER", nullable: true),
                    HitPointsModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    AttackModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    SpeedModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    DefenseModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    ResistanceModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NameKanji = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceActors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Origin = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsLegendaryHero = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMythicHero = table.Column<bool>(type: "INTEGER", nullable: false),
                    Element = table.Column<int>(type: "INTEGER", nullable: true),
                    LegendaryHeroBoostType = table.Column<int>(type: "INTEGER", nullable: true),
                    MythicHeroBoostType = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDuoHero = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsResplendentHero = table.Column<bool>(type: "INTEGER", nullable: false),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    Weapon = table.Column<int>(type: "INTEGER", nullable: false),
                    MovementType = table.Column<int>(type: "INTEGER", nullable: false),
                    BVID = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseHitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    HitPointsGrowthRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackGrowthRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeedGrowthRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseDefense = table.Column<int>(type: "INTEGER", nullable: false),
                    DefenseGrowthRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseResistance = table.Column<int>(type: "INTEGER", nullable: false),
                    ResistanceGrowthRate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillMovementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MovementType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMovementTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillMovementTypes_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillWeaponEffectivenesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WeaponEffectivenessType = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageType = table.Column<int>(type: "INTEGER", nullable: true),
                    MovementType = table.Column<int>(type: "INTEGER", nullable: true),
                    Weapon = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillWeaponEffectivenesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillWeaponEffectivenesses_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillWeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    Weapon = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillWeaponTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillWeaponTypes_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultRarity = table.Column<int>(type: "INTEGER", nullable: true),
                    UnlockRarity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroSkills_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroVoiceActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VoiceActorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    Sort = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroVoiceActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroVoiceActors_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroVoiceActors_VoiceActors_VoiceActorId",
                        column: x => x.VoiceActorId,
                        principalTable: "VoiceActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_ArtistId",
                table: "Heroes",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkills_HeroId",
                table: "HeroSkills",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkills_SkillId",
                table: "HeroSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroVoiceActors_HeroId",
                table: "HeroVoiceActors",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroVoiceActors_VoiceActorId",
                table: "HeroVoiceActors",
                column: "VoiceActorId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillMovementTypes_SkillId",
                table: "SkillMovementTypes",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillWeaponEffectivenesses_SkillId",
                table: "SkillWeaponEffectivenesses",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillWeaponTypes_SkillId",
                table: "SkillWeaponTypes",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "HeroSkills");

            migrationBuilder.DropTable(
                name: "HeroVoiceActors");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SkillMovementTypes");

            migrationBuilder.DropTable(
                name: "SkillWeaponEffectivenesses");

            migrationBuilder.DropTable(
                name: "SkillWeaponTypes");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "VoiceActors");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
