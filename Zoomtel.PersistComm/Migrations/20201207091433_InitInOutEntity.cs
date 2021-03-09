using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class InitInOutEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_WMS_INBOUNDLINE",
                columns: table => new
                {
                    InboundDetailId = table.Column<string>(nullable: false),
                    InboundId = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    ItemQty = table.Column<int>(nullable: false),
                    Consignsor = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AboxQty = table.Column<int>(nullable: false),
                    LockQty = table.Column<int>(nullable: false),
                    OtherQty = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    BdpCigcode = table.Column<string>(nullable: true),
                    PkBoxQty = table.Column<int>(nullable: false),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    IsValid = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    TaskQty = table.Column<int>(nullable: false),
                    WmsTaskNoticeItemId = table.Column<string>(nullable: true),
                    BoxIdentifier = table.Column<string>(nullable: true),
                    WmsTaskNoticeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_INBOUNDLINE", x => x.InboundDetailId);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_INBOUNDTASK",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InboundDetailId = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    LockQty = table.Column<int>(nullable: false),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    TaskQty = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ActQty = table.Column<int>(nullable: false),
                    IsDeal = table.Column<int>(nullable: false),
                    DeviceNo = table.Column<string>(nullable: true),
                    InboundType = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_INBOUNDTASK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_OUTBOUND",
                columns: table => new
                {
                    OutBoundId = table.Column<string>(nullable: false),
                    Navicert = table.Column<string>(nullable: true),
                    ContractNo = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    Consignsor = table.Column<string>(nullable: true),
                    OutBoundType = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    BoundType = table.Column<string>(nullable: true),
                    TaskNoticeId = table.Column<string>(nullable: true),
                    ShipToId = table.Column<string>(nullable: true),
                    ShipTo = table.Column<string>(nullable: true),
                    VehicleLicense = table.Column<string>(nullable: true),
                    VehicleMan = table.Column<string>(nullable: true),
                    VehiclePhone = table.Column<string>(nullable: true),
                    NoticeDate = table.Column<DateTime>(nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DelStatus = table.Column<int>(nullable: false),
                    VehicleNo = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OutTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_OUTBOUND", x => x.OutBoundId);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_OUTBOUNDLINE",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OutboundId = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    ItemQty = table.Column<int>(nullable: false),
                    Consignsor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ActQty = table.Column<int>(nullable: false),
                    LockQty = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    TruckNo = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    OkQty = table.Column<int>(nullable: false),
                    WmsTaskNoticeItemId = table.Column<string>(nullable: true),
                    BoxIdentifier = table.Column<string>(nullable: true),
                    WmsTaskNoticeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_OUTBOUNDLINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_OUTBOUNDTASK",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OutboundDetailId = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    OkQty = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    LockQty = table.Column<int>(nullable: false),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    TaskQty = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ActQty = table.Column<int>(nullable: false),
                    IsDeal = table.Column<int>(nullable: false),
                    DeviceNo = table.Column<string>(nullable: true),
                    OutType = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_OUTBOUNDTASK", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_WMS_INBOUNDLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_INBOUNDTASK");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUND");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUNDLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUNDTASK");
        }
    }
}
