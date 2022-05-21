﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using innovation_hub.Data;

namespace innovation_hub.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220521151217_AppUserProposalFavorite")]
    partial class AppUserProposalFavorite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("innovation_hub.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Passeword")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("innovation_hub.Models.AppUserCommentVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<bool>("Voted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("AppUserCommentVote");
                });

            modelBuilder.Entity("innovation_hub.Models.AppUserProposal", b =>
                {
                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "ProposalId");

                    b.HasIndex("ProposalId");

                    b.ToTable("AppUserProposals");
                });

            modelBuilder.Entity("innovation_hub.Models.AppUserProposalFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Favorited")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppUserProposalFavorite");
                });

            modelBuilder.Entity("innovation_hub.Models.AppUserProposalVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<bool>("Voted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("AppUserProposalVote");
                });

            modelBuilder.Entity("innovation_hub.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("AppUserNickname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProposalId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("innovation_hub.Models.InterestArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProposalId");

                    b.ToTable("InterestArea");
                });

            modelBuilder.Entity("innovation_hub.Models.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("innovation_hub.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<bool>("Arquived")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Finished")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<bool>("Private")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProposalType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("innovation_hub.Models.AppUserProposal", b =>
                {
                    b.HasOne("innovation_hub.Models.AppUser", null)
                        .WithMany("AppUserProposals")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("innovation_hub.Models.Proposal", null)
                        .WithMany("AppUserProposals")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("innovation_hub.Models.Comment", b =>
                {
                    b.HasOne("innovation_hub.Models.AppUser", null)
                        .WithMany("AppUserComments")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("innovation_hub.Models.Proposal", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("innovation_hub.Models.InterestArea", b =>
                {
                    b.HasOne("innovation_hub.Models.AppUser", null)
                        .WithMany("InterestAreas")
                        .HasForeignKey("AppUserId");

                    b.HasOne("innovation_hub.Models.Proposal", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProposalId");
                });

            modelBuilder.Entity("innovation_hub.Models.Phase", b =>
                {
                    b.HasOne("innovation_hub.Models.Proposal", null)
                        .WithMany("Phases")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("innovation_hub.Models.Proposal", b =>
                {
                    b.HasOne("innovation_hub.Models.AppUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
