using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class AddAreaStockInfoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionDate",
                table: "T_WMS_AREASTOCKINFO_DETAIL",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "T_WMS_AREASTOCKINFO_DETAIL",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "T_WMS_AREASTOCKINFO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ThroughNo = table.Column<string>(nullable: true),
                    Dismantle = table.Column<int>(nullable: true),
                    PalletNo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Consignor = table.Column<string>(nullable: true),
                    InBoundTime = table.Column<DateTime>(nullable: true),
                    StackType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_AREASTOCKINFO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_WMS_AREASTOCKINFO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionDate",
                table: "T_WMS_AREASTOCKINFO_DETAIL",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "T_WMS_AREASTOCKINFO_DETAIL",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
