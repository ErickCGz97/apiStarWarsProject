﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiStarWarsProject.Context;

#nullable disable

namespace apiStarWarsProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250125232416_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apiStarWarsProject.ArmyDivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArmyDivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Army Division", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.CloneTrooper", b =>
                {
                    b.Property<string>("CloneTrooperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CloneTrooperName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrooperArmyDivisionId")
                        .HasColumnType("int");

                    b.Property<int>("TrooperRankId")
                        .HasColumnType("int");

                    b.Property<int>("TrooperStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CloneTrooperId");

                    b.HasIndex("TrooperArmyDivisionId");

                    b.HasIndex("TrooperRankId");

                    b.HasIndex("TrooperStatusId");

                    b.ToTable("Clone Trooper", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.Jedi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmyDivisionJedi")
                        .HasColumnType("int");

                    b.Property<string>("JediName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JediRankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmyDivisionJedi");

                    b.HasIndex("JediRankId");

                    b.ToTable("Jedis", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.JediRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("JediRankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jedi Rank", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.TrooperRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RankTrooperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trooper Rank", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.TrooperStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trooper Status", (string)null);
                });

            modelBuilder.Entity("apiStarWarsProject.CloneTrooper", b =>
                {
                    b.HasOne("apiStarWarsProject.ArmyDivision", "TrooperArmyDivisionReference")
                        .WithMany("cloneTroopersArmyDivisionCollection")
                        .HasForeignKey("TrooperArmyDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiStarWarsProject.TrooperRank", "TrooperRankReference")
                        .WithMany("cloneTroopersRanksCollection")
                        .HasForeignKey("TrooperRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiStarWarsProject.TrooperStatus", "TrooperStatusReference")
                        .WithMany("cloneTroopersStatusCollection")
                        .HasForeignKey("TrooperStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrooperArmyDivisionReference");

                    b.Navigation("TrooperRankReference");

                    b.Navigation("TrooperStatusReference");
                });

            modelBuilder.Entity("apiStarWarsProject.Jedi", b =>
                {
                    b.HasOne("apiStarWarsProject.ArmyDivision", "ArmyDivisionJediReference")
                        .WithMany("jediArmyDivisionCollection")
                        .HasForeignKey("ArmyDivisionJedi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiStarWarsProject.JediRank", "JediRankReference")
                        .WithMany("JedisCollection")
                        .HasForeignKey("JediRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArmyDivisionJediReference");

                    b.Navigation("JediRankReference");
                });

            modelBuilder.Entity("apiStarWarsProject.ArmyDivision", b =>
                {
                    b.Navigation("cloneTroopersArmyDivisionCollection");

                    b.Navigation("jediArmyDivisionCollection");
                });

            modelBuilder.Entity("apiStarWarsProject.JediRank", b =>
                {
                    b.Navigation("JedisCollection");
                });

            modelBuilder.Entity("apiStarWarsProject.TrooperRank", b =>
                {
                    b.Navigation("cloneTroopersRanksCollection");
                });

            modelBuilder.Entity("apiStarWarsProject.TrooperStatus", b =>
                {
                    b.Navigation("cloneTroopersStatusCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
