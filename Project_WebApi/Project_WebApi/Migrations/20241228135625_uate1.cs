using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class uate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmentStatus",
                table: "Enrollments",
                newName: "EnrollmenStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmenStatus",
                table: "Enrollments",
                newName: "EnrollmentStatus");
        }
    }
}
