using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WattWise.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMeterUsageToMeterReading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterUsage_MeterUsageStatus_MeterUsageStatusId",
                table: "MeterUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterUsage_Meter_MeterId",
                table: "MeterUsage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterUsage",
                table: "MeterUsage");

            migrationBuilder.RenameTable(
                name: "MeterUsage",
                newName: "MeterReading");

            migrationBuilder.RenameIndex(
                name: "IX_MeterUsage_MeterUsageStatusId",
                table: "MeterReading",
                newName: "IX_MeterReading_MeterUsageStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterUsage_MeterId",
                table: "MeterReading",
                newName: "IX_MeterReading_MeterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterReading",
                table: "MeterReading",
                column: "MeterReadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReading_MeterUsageStatus_MeterUsageStatusId",
                table: "MeterReading",
                column: "MeterUsageStatusId",
                principalTable: "MeterUsageStatus",
                principalColumn: "MeterUsageStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReading_Meter_MeterId",
                table: "MeterReading",
                column: "MeterId",
                principalTable: "Meter",
                principalColumn: "MeterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReading_MeterUsageStatus_MeterUsageStatusId",
                table: "MeterReading");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReading_Meter_MeterId",
                table: "MeterReading");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterReading",
                table: "MeterReading");

            migrationBuilder.RenameTable(
                name: "MeterReading",
                newName: "MeterUsage");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReading_MeterUsageStatusId",
                table: "MeterUsage",
                newName: "IX_MeterUsage_MeterUsageStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReading_MeterId",
                table: "MeterUsage",
                newName: "IX_MeterUsage_MeterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterUsage",
                table: "MeterUsage",
                column: "MeterReadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterUsage_MeterUsageStatus_MeterUsageStatusId",
                table: "MeterUsage",
                column: "MeterUsageStatusId",
                principalTable: "MeterUsageStatus",
                principalColumn: "MeterUsageStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterUsage_Meter_MeterId",
                table: "MeterUsage",
                column: "MeterId",
                principalTable: "Meter",
                principalColumn: "MeterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
