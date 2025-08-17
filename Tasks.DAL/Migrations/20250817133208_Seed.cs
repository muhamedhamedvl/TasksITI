using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specialization",
                table: "Instructors",
                newName: "Specialization");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "FirstName" },
                values: new object[] { "Expert in C#", "Ali" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "FirstName", "LastName" },
                values: new object[] { "Frontend Developer", "Sara", "Ahmed" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "IsActive" },
                values: new object[] { "Full Stack Developer", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Instructors",
                newName: "specialization");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "FirstName" },
                values: new object[] { "Senior .NET Developer with 10 years of experience.", "Ahmed" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "FirstName", "LastName" },
                values: new object[] { "Data Science specialist and AI researcher.", "Mona", "Ali" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "IsActive" },
                values: new object[] { "Cloud computing and DevOps engineer.", false });
        }
    }
}
