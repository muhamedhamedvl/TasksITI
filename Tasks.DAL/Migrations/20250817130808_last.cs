using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tasks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "FirstName", "IsActive", "LastName", "specialization" },
                values: new object[,]
                {
                    { 1, "Senior .NET Developer with 10 years of experience.", "Ahmed", true, "Hassan", 0 },
                    { 2, "Data Science specialist and AI researcher.", "Mona", true, "Ali", 0 },
                    { 3, "Cloud computing and DevOps engineer.", "Omar", false, "Khaled", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
