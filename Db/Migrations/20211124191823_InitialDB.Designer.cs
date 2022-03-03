﻿// <auto-generated />
using Db.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StarDb.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20211124191823_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StarDb.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("Channel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<short>("CharOnline")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Numeric")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("StarDb.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("AffectInfo")
                        .HasColumnType("int");

                    b.Property<ushort>("CapeInfo")
                        .HasColumnType("smallint unsigned");

                    b.Property<byte>("ChaosPoints")
                        .HasColumnType("tinyint unsigned");

                    b.Property<short>("CityId")
                        .HasColumnType("smallint");

                    b.Property<ushort>("ClassInfo")
                        .HasColumnType("smallint unsigned");

                    b.Property<int>("Critical")
                        .HasColumnType("int");

                    b.Property<byte>("CurrentKill")
                        .HasColumnType("tinyint unsigned");

                    b.Property<ulong>("Exp")
                        .HasColumnType("bigint unsigned");

                    b.Property<uint>("Gold")
                        .HasColumnType("int unsigned");

                    b.Property<ushort>("GuildIndex")
                        .HasColumnType("smallint unsigned");

                    b.Property<uint>("Hold")
                        .HasColumnType("int unsigned");

                    b.Property<ushort>("InvExtra")
                        .HasColumnType("smallint unsigned");

                    b.Property<short>("Item547")
                        .HasColumnType("smallint");

                    b.Property<ulong>("Learn")
                        .HasColumnType("bigint unsigned");

                    b.Property<short>("MagicIncrement")
                        .HasColumnType("smallint");

                    b.Property<short>("MasterPoint")
                        .HasColumnType("smallint");

                    b.Property<ushort>("Merchant")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<short>("QuestInfo")
                        .HasColumnType("smallint");

                    b.Property<int>("ResistFire")
                        .HasColumnType("int");

                    b.Property<int>("ResistHoly")
                        .HasColumnType("int");

                    b.Property<int>("ResistIce")
                        .HasColumnType("int");

                    b.Property<int>("ResistThunder")
                        .HasColumnType("int");

                    b.Property<int>("SaveMana")
                        .HasColumnType("int");

                    b.Property<int>("SkillBar1")
                        .HasColumnType("int");

                    b.Property<int>("SkillBar2")
                        .HasColumnType("int");

                    b.Property<short>("SkillPoint")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusPoint")
                        .HasColumnType("smallint");

                    b.Property<short>("TotalKill")
                        .HasColumnType("smallint");

                    b.Property<string>("Unk1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Unk2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Unk3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Unk4")
                        .HasColumnType("int");

                    b.Property<int>("Unk5")
                        .HasColumnType("int");

                    b.Property<int>("Unk6")
                        .HasColumnType("int");

                    b.Property<int>("Unk7")
                        .HasColumnType("int");

                    b.Property<int>("Unk8")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("StarDb.Models.CharacterAffect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("EfIndex")
                        .HasColumnType("int");

                    b.Property<int>("EfMaster")
                        .HasColumnType("int");

                    b.Property<uint>("EfTime")
                        .HasColumnType("int unsigned");

                    b.Property<ushort>("EfValue")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterAffect");
                });

            modelBuilder.Entity("StarDb.Models.CharacterBag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Ef1")
                        .HasColumnType("int");

                    b.Property<int>("Ef2")
                        .HasColumnType("int");

                    b.Property<int>("Ef3")
                        .HasColumnType("int");

                    b.Property<int>("Efv1")
                        .HasColumnType("int");

                    b.Property<int>("Efv2")
                        .HasColumnType("int");

                    b.Property<int>("Efv3")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterBag");
                });

            modelBuilder.Entity("StarDb.Models.CharacterEquip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Ef1")
                        .HasColumnType("int");

                    b.Property<int>("Ef2")
                        .HasColumnType("int");

                    b.Property<int>("Ef3")
                        .HasColumnType("int");

                    b.Property<int>("Efv1")
                        .HasColumnType("int");

                    b.Property<int>("Efv2")
                        .HasColumnType("int");

                    b.Property<int>("Efv3")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterEquip");
                });

            modelBuilder.Entity("StarDb.Models.CharacterLastPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<short>("X")
                        .HasColumnType("smallint");

                    b.Property<short>("Y")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterLastPosition");
                });

            modelBuilder.Entity("StarDb.Models.CharacterStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<byte>("ChaosRate")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<uint>("CurHP")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("CurMP")
                        .HasColumnType("int unsigned");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<byte>("Direction")
                        .HasColumnType("tinyint unsigned");

                    b.Property<ushort>("FMaster")
                        .HasColumnType("smallint unsigned");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<uint>("MaxHP")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("MaxMP")
                        .HasColumnType("int unsigned");

                    b.Property<byte>("Merchant")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("MobSpeed")
                        .HasColumnType("tinyint unsigned");

                    b.Property<short>("SCon")
                        .HasColumnType("smallint");

                    b.Property<short>("SDex")
                        .HasColumnType("smallint");

                    b.Property<short>("SInt")
                        .HasColumnType("smallint");

                    b.Property<ushort>("SMaster")
                        .HasColumnType("smallint unsigned");

                    b.Property<short>("SStr")
                        .HasColumnType("smallint");

                    b.Property<ushort>("TMaster")
                        .HasColumnType("smallint unsigned");

                    b.Property<ushort>("WMaster")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterStatus");
                });

            modelBuilder.Entity("StarDb.Models.Character", b =>
                {
                    b.HasOne("StarDb.Models.Account", null)
                        .WithMany("Characters")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.CharacterAffect", b =>
                {
                    b.HasOne("StarDb.Models.Character", null)
                        .WithOne("Affect")
                        .HasForeignKey("StarDb.Models.CharacterAffect", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.CharacterBag", b =>
                {
                    b.HasOne("StarDb.Models.Character", null)
                        .WithOne("Bag")
                        .HasForeignKey("StarDb.Models.CharacterBag", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.CharacterEquip", b =>
                {
                    b.HasOne("StarDb.Models.Character", null)
                        .WithOne("Equip")
                        .HasForeignKey("StarDb.Models.CharacterEquip", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.CharacterLastPosition", b =>
                {
                    b.HasOne("StarDb.Models.Character", null)
                        .WithOne("LastPosition")
                        .HasForeignKey("StarDb.Models.CharacterLastPosition", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.CharacterStatus", b =>
                {
                    b.HasOne("StarDb.Models.Character", null)
                        .WithOne("GameStatus")
                        .HasForeignKey("StarDb.Models.CharacterStatus", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarDb.Models.Account", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("StarDb.Models.Character", b =>
                {
                    b.Navigation("Affect")
                        .IsRequired();

                    b.Navigation("Bag");

                    b.Navigation("Equip");

                    b.Navigation("GameStatus");

                    b.Navigation("LastPosition");
                });
#pragma warning restore 612, 618
        }
    }
}
