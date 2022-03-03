using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarDb.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numeric = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CharOnline = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    Channel = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CapeInfo = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    Merchant = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    GuildIndex = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    ClassInfo = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    AffectInfo = table.Column<int>(type: "int", nullable: false),
                    QuestInfo = table.Column<short>(type: "smallint", nullable: false),
                    Gold = table.Column<uint>(type: "int unsigned", nullable: false),
                    Unk1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exp = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    InvExtra = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    Unk2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Item547 = table.Column<short>(type: "smallint", nullable: false),
                    ChaosPoints = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CurrentKill = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TotalKill = table.Column<short>(type: "smallint", nullable: false),
                    Unk3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Learn = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    StatusPoint = table.Column<short>(type: "smallint", nullable: false),
                    MasterPoint = table.Column<short>(type: "smallint", nullable: false),
                    SkillPoint = table.Column<short>(type: "smallint", nullable: false),
                    Critical = table.Column<int>(type: "int", nullable: false),
                    SaveMana = table.Column<int>(type: "int", nullable: false),
                    SkillBar1 = table.Column<int>(type: "int", nullable: false),
                    Unk4 = table.Column<int>(type: "int", nullable: false),
                    ResistFire = table.Column<int>(type: "int", nullable: false),
                    ResistIce = table.Column<int>(type: "int", nullable: false),
                    ResistHoly = table.Column<int>(type: "int", nullable: false),
                    ResistThunder = table.Column<int>(type: "int", nullable: false),
                    Unk5 = table.Column<int>(type: "int", nullable: false),
                    MagicIncrement = table.Column<short>(type: "smallint", nullable: false),
                    Unk6 = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<short>(type: "smallint", nullable: false),
                    SkillBar2 = table.Column<int>(type: "int", nullable: false),
                    Unk7 = table.Column<int>(type: "int", nullable: false),
                    Hold = table.Column<uint>(type: "int unsigned", nullable: false),
                    Unk8 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterAffect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    EfIndex = table.Column<int>(type: "int", nullable: false),
                    EfMaster = table.Column<int>(type: "int", nullable: false),
                    EfValue = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    EfTime = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAffect_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterBag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Ef1 = table.Column<int>(type: "int", nullable: false),
                    Efv1 = table.Column<int>(type: "int", nullable: false),
                    Ef2 = table.Column<int>(type: "int", nullable: false),
                    Efv2 = table.Column<int>(type: "int", nullable: false),
                    Ef3 = table.Column<int>(type: "int", nullable: false),
                    Efv3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterBag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterBag_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterEquip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Ef1 = table.Column<int>(type: "int", nullable: false),
                    Efv1 = table.Column<int>(type: "int", nullable: false),
                    Ef2 = table.Column<int>(type: "int", nullable: false),
                    Efv2 = table.Column<int>(type: "int", nullable: false),
                    Ef3 = table.Column<int>(type: "int", nullable: false),
                    Efv3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEquip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterEquip_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterLastPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<short>(type: "smallint", nullable: false),
                    Y = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterLastPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterLastPosition_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Merchant = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    MobSpeed = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Direction = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    ChaosRate = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    MaxHP = table.Column<uint>(type: "int unsigned", nullable: false),
                    MaxMP = table.Column<uint>(type: "int unsigned", nullable: false),
                    CurHP = table.Column<uint>(type: "int unsigned", nullable: false),
                    CurMP = table.Column<uint>(type: "int unsigned", nullable: false),
                    SStr = table.Column<short>(type: "smallint", nullable: false),
                    SInt = table.Column<short>(type: "smallint", nullable: false),
                    SDex = table.Column<short>(type: "smallint", nullable: false),
                    SCon = table.Column<short>(type: "smallint", nullable: false),
                    WMaster = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    FMaster = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    SMaster = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    TMaster = table.Column<ushort>(type: "smallint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterStatus_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAffect_CharacterId",
                table: "CharacterAffect",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterBag_CharacterId",
                table: "CharacterBag",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEquip_CharacterId",
                table: "CharacterEquip",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterLastPosition_CharacterId",
                table: "CharacterLastPosition",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountId",
                table: "Character",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStatus_CharacterId",
                table: "CharacterStatus",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAffect");

            migrationBuilder.DropTable(
                name: "CharacterBag");

            migrationBuilder.DropTable(
                name: "CharacterEquip");

            migrationBuilder.DropTable(
                name: "CharacterLastPosition");

            migrationBuilder.DropTable(
                name: "CharacterStatus");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
