// <auto-generated />
using System;
using DojoTactics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DojoTactics.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211223061826_2Migration")]
    partial class _2Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DojoTactics.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MatchWinner")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("StatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MatchId");

                    b.HasIndex("StatId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DojoTactics.Models.Social", b =>
                {
                    b.Property<int>("SocialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SocialId");

                    b.HasIndex("FriendId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("DojoTactics.Models.Stat", b =>
                {
                    b.Property<int>("StatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("StatId");

                    b.HasIndex("UserId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("DojoTactics.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.HasIndex("MatchId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DojoTactics.Models.Match", b =>
                {
                    b.HasOne("DojoTactics.Models.Stat", null)
                        .WithMany("MatchHistory")
                        .HasForeignKey("StatId");
                });

            modelBuilder.Entity("DojoTactics.Models.Social", b =>
                {
                    b.HasOne("DojoTactics.Models.User", "FriendUser")
                        .WithMany("FriendsList")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DojoTactics.Models.Stat", b =>
                {
                    b.HasOne("DojoTactics.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DojoTactics.Models.User", b =>
                {
                    b.HasOne("DojoTactics.Models.Match", null)
                        .WithMany("Players")
                        .HasForeignKey("MatchId");
                });
#pragma warning restore 612, 618
        }
    }
}
