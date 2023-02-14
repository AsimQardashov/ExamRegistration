﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamProgram.Migrations
{
    /// <inheritdoc />
    public partial class ExamDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    LessonCode = table.Column<string>(type: "char(3)", nullable: false),
                    LessonName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Class = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    TeacherName = table.Column<string>(type: "varchar(20)", nullable: false),
                    TeacherSurname = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.LessonCode);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<decimal>(type: "numeric(5,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "varchar(30)", nullable: false),
                    StudentSurname = table.Column<string>(type: "varchar(30)", nullable: false),
                    Class = table.Column<decimal>(type: "numeric(2,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonCode = table.Column<string>(type: "char(3)", nullable: false),
                    StudentId = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    Score = table.Column<decimal>(type: "numeric(1,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Courses_LessonCode",
                        column: x => x.LessonCode,
                        principalTable: "Courses",
                        principalColumn: "LessonCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonCode",
                table: "Exams",
                column: "LessonCode");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                table: "Exams",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
