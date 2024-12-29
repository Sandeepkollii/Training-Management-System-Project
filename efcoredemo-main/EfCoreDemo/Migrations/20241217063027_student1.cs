using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class student1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchCode",
                table: "tblStudent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_BatchCode",
                table: "tblStudent",
                column: "BatchCode");

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudent_Batches_BatchCode",
                table: "tblStudent",
                column: "BatchCode",
                principalTable: "Batches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblStudent_Batches_BatchCode",
                table: "tblStudent");

            migrationBuilder.DropIndex(
                name: "IX_tblStudent_BatchCode",
                table: "tblStudent");

            migrationBuilder.DropColumn(
                name: "BatchCode",
                table: "tblStudent");
        }
    }
}
