using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class addInBoundEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_WMS_INBOUND",
                columns: table => new
                {
                    InBoundId = table.Column<string>(nullable: false),
                    Navicert = table.Column<string>(nullable: true),
                    ContractNo = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    Consignsor = table.Column<string>(nullable: true),
                    InType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    BillId = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    BoundType = table.Column<string>(nullable: true),
                    TaskNoticeId = table.Column<string>(nullable: true),
                    ShipToId = table.Column<string>(nullable: true),
                    ShipFrom = table.Column<string>(nullable: true),
                    VehicleLicense = table.Column<string>(nullable: true),
                    VehicleMan = table.Column<string>(nullable: true),
                    VehiclePhone = table.Column<string>(nullable: true),
                    NoticeDate = table.Column<DateTime>(nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_INBOUND", x => x.InBoundId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_WMS_INBOUND");
        }
    }
}
