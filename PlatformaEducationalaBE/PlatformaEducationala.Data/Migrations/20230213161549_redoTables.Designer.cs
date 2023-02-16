﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlatformaEducationala.Data.Context;

#nullable disable

namespace PlatformaEducationala.Data.Migrations
{
    [DbContext(typeof(PlatformDBContext))]
    [Migration("20230213161549_redoTables")]
    partial class redoTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TecherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TecherId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Xml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.StudentGroup", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Grade", b =>
                {
                    b.HasOne("PlatformaEducationala.Core.Entities.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("TecherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Group", b =>
                {
                    b.HasOne("PlatformaEducationala.Core.Entities.Teacher", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Project", b =>
                {
                    b.HasOne("PlatformaEducationala.Core.Entities.Grade", "Grade")
                        .WithMany("Projects")
                        .HasForeignKey("GradeId");

                    b.HasOne("PlatformaEducationala.Core.Entities.Student", "Student")
                        .WithMany("Projects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.StudentGroup", b =>
                {
                    b.HasOne("PlatformaEducationala.Core.Entities.Group", "Group")
                        .WithMany("StudentGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlatformaEducationala.Core.Entities.Student", "Student")
                        .WithMany("StudentGroups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Grade", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Group", b =>
                {
                    b.Navigation("StudentGroups");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Student", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("StudentGroups");
                });

            modelBuilder.Entity("PlatformaEducationala.Core.Entities.Teacher", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
