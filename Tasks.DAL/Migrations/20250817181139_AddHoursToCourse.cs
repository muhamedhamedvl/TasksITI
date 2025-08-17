﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddHoursToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");
        }
    }
}
