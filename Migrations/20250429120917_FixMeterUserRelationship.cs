using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WattWise.Migrations
{
    /// <inheritdoc />
    public partial class FixMeterUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meter_AspNetUsers_UserId1",
                table: "Meter");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Meter",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meter_UserId1",
                table: "Meter",
                newName: "IX_Meter_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_AspNetUsers_ApplicationUserId",
                table: "Meter",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meter_AspNetUsers_ApplicationUserId",
                table: "Meter");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Meter",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Meter_ApplicationUserId",
                table: "Meter",
                newName: "IX_Meter_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_AspNetUsers_UserId1",
                table: "Meter",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
