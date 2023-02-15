﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230215075739_StudentExam")]
    partial class StudentExam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"), 1L, 1);

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("date");

                    b.Property<string>("LessonCode")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<decimal>("Score")
                        .HasColumnType("numeric(1,0)");

                    b.Property<decimal>("StudentId")
                        .HasColumnType("numeric(5,0)");

                    b.HasKey("ExamId");

                    b.HasIndex("LessonCode");

                    b.HasIndex("StudentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.Property<string>("LessonCode")
                        .HasColumnType("char(3)");

                    b.Property<decimal>("Class")
                        .HasColumnType("numeric(2,0)");

                    b.Property<string>("LessonTitle")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TeacherSurname")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("LessonCode");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<decimal>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(5,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("StudentId"), 1L, 1);

                    b.Property<decimal>("Class")
                        .HasColumnType("numeric(2,0)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Entities.Exam", b =>
                {
                    b.HasOne("Domain.Entities.Lesson", "Lesson")
                        .WithMany("Exams")
                        .HasForeignKey("LessonCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}