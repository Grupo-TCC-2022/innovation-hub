﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdeaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentText")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VotesCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("API.Entities.InterestArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InterestAreaName")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("InterestAreas");
                });

            modelBuilder.Entity("API.Entities.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("API.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Archived")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Votes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Proposals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Proposal");
                });

            modelBuilder.Entity("API.Entities.Social", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Socials");
                });

            modelBuilder.Entity("API.Entities.Idea", b =>
                {
                    b.HasBaseType("API.Entities.Proposal");

                    b.HasDiscriminator().HasValue("Idea");
                });

            modelBuilder.Entity("API.Entities.Problem", b =>
                {
                    b.HasBaseType("API.Entities.Proposal");

                    b.HasDiscriminator().HasValue("Problem");
                });

            modelBuilder.Entity("API.Entities.Project", b =>
                {
                    b.HasBaseType("API.Entities.Proposal");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectManagerId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ProjectManagerId");

                    b.HasDiscriminator().HasValue("Project");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.HasOne("API.Entities.Idea", null)
                        .WithMany("TeamMembers")
                        .HasForeignKey("IdeaId");

                    b.HasOne("API.Entities.Project", null)
                        .WithMany("TeamMembers")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("API.Entities.Comment", b =>
                {
                    b.HasOne("API.Entities.Proposal", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProposalId");
                });

            modelBuilder.Entity("API.Entities.InterestArea", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany("InterestAreas")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("API.Entities.Phase", b =>
                {
                    b.HasOne("API.Entities.Project", null)
                        .WithMany("Phases")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("API.Entities.Social", b =>
                {
                    b.HasOne("API.Entities.Project", null)
                        .WithMany("Socials")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("API.Entities.Project", b =>
                {
                    b.HasOne("API.Entities.AppUser", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
