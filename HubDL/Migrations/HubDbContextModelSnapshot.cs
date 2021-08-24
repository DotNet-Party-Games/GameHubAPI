﻿// <auto-generated />
using HubDL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HubDL.Migrations
{
    [DbContext(typeof(HubDbContext))]
    partial class HubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HubEntities.Database.ChatConnection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatConnections");
                });

            modelBuilder.Entity("HubEntities.Database.Leaderboard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Leaderboards");
                });

            modelBuilder.Entity("HubEntities.Database.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeamOwner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("HubEntities.Database.TeamJoinRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TeamJoinRequests");
                });

            modelBuilder.Entity("HubEntities.Database.TeamLeaderboard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("TeamLeaderboards");
                });

            modelBuilder.Entity("HubEntities.Database.TeamScore", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("TeamLeaderboardId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamLeaderboardId");

                    b.ToTable("TeamScores");
                });

            modelBuilder.Entity("HubEntities.Database.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HubEntities.Database.UserScore", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LeaderboardId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeaderboardId");

                    b.ToTable("UserScores");
                });

            modelBuilder.Entity("HubEntities.Database.ChatConnection", b =>
                {
                    b.HasOne("HubEntities.Database.User", "User")
                        .WithMany("Connections")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HubEntities.Database.TeamJoinRequest", b =>
                {
                    b.HasOne("HubEntities.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HubEntities.Database.TeamScore", b =>
                {
                    b.HasOne("HubEntities.Database.TeamLeaderboard", null)
                        .WithMany("Scores")
                        .HasForeignKey("TeamLeaderboardId");
                });

            modelBuilder.Entity("HubEntities.Database.User", b =>
                {
                    b.HasOne("HubEntities.Database.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HubEntities.Database.UserScore", b =>
                {
                    b.HasOne("HubEntities.Database.Leaderboard", null)
                        .WithMany("Scores")
                        .HasForeignKey("LeaderboardId");
                });

            modelBuilder.Entity("HubEntities.Database.Leaderboard", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("HubEntities.Database.Team", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HubEntities.Database.TeamLeaderboard", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("HubEntities.Database.User", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
