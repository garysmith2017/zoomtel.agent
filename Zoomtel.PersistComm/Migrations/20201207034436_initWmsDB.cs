using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class initWmsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INF_EQUIPMENTINFO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    WmsDeviceId = table.Column<string>(nullable: true),
                    WmsPositionId = table.Column<string>(nullable: true),
                    DeviceStatus = table.Column<string>(nullable: true),
                    DeviceJobId = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    TuTypr = table.Column<string>(nullable: true),
                    CurrentMode = table.Column<string>(nullable: true),
                    RequestMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INF_EQUIPMENTINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INF_EQUIPMENTREQUEST",
                columns: table => new
                {
                    WmsPositionid = table.Column<string>(nullable: false),
                    WmsDeviceid = table.Column<string>(nullable: true),
                    RequestType = table.Column<int>(nullable: false),
                    PalletNo = table.Column<string>(nullable: true),
                    JobId = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    RequestQty = table.Column<string>(nullable: true),
                    EnterDate = table.Column<DateTime>(nullable: false),
                    RespondDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InboundNo = table.Column<int>(nullable: false),
                    TuType = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<string>(nullable: true),
                    EnterBy = table.Column<string>(nullable: true),
                    RespondBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INF_EQUIPMENTREQUEST", x => x.WmsPositionid);
                });

            migrationBuilder.CreateTable(
                name: "INF_JOBDOWNLOAD",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    WmsJobId = table.Column<string>(nullable: true),
                    JobType = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    PlanQty = table.Column<int>(nullable: false),
                    StackType = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    PalletNo = table.Column<string>(nullable: true),
                    TuType = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    RespondTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    InputType = table.Column<int>(nullable: false),
                    FullCount = table.Column<int>(nullable: false),
                    UnStackMode = table.Column<int>(nullable: false),
                    TaskNo = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    IsScan = table.Column<string>(nullable: true),
                    ActQty = table.Column<int>(nullable: false),
                    MachineNo = table.Column<string>(nullable: true),
                    PreJobId = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<string>(nullable: true),
                    MaxDelayTime = table.Column<int>(nullable: false),
                    CurrentMode = table.Column<string>(nullable: true),
                    RequestMode = table.Column<string>(nullable: true),
                    ResponseBy = table.Column<string>(nullable: true),
                    ResponseCount = table.Column<int>(nullable: false),
                    ResponseMsg = table.Column<string>(nullable: true),
                    PlatForm = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsBind = table.Column<string>(nullable: true),
                    ForceFlag = table.Column<string>(nullable: true),
                    TransferFlag = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    IsWrap = table.Column<string>(nullable: true),
                    SortNum = table.Column<int>(nullable: false),
                    EXTAttr1 = table.Column<string>(nullable: true),
                    EXTAttr2 = table.Column<string>(nullable: true),
                    EXTAttr3 = table.Column<string>(nullable: true),
                    EXTAttr4 = table.Column<string>(nullable: true),
                    EXTAttr5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INF_JOBDOWNLOAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INF_JOBFEEDBACK",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WmsJobid = table.Column<string>(nullable: true),
                    FeedbackStatus = table.Column<int>(nullable: false),
                    ErrorCode = table.Column<string>(nullable: true),
                    EnterDate = table.Column<DateTime>(nullable: false),
                    RespondDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDeal = table.Column<string>(nullable: true),
                    PlanQty = table.Column<int>(nullable: false),
                    ActQty = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<string>(nullable: true),
                    EnterBy = table.Column<string>(nullable: true),
                    RespondBy = table.Column<string>(nullable: true),
                    RespondCount = table.Column<int>(nullable: false),
                    RespondMsg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INF_JOBFEEDBACK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_AREASTOCKINFO_DETAIL",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ThroughNo = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    Consignor = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    IsLocked = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_AREASTOCKINFO_DETAIL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_ATSCELL",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LanewayNo = table.Column<string>(nullable: true),
                    CellNo = table.Column<string>(nullable: true),
                    CellName = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    WorkStatus = table.Column<int>(nullable: false),
                    Col = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    CellType = table.Column<string>(nullable: true),
                    CellLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_ATSCELL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_ATSCELLINFO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CellNo = table.Column<string>(nullable: true),
                    Dismantle = table.Column<int>(nullable: false),
                    PalletNo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    InBoundId = table.Column<string>(nullable: true),
                    Consignor = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    ImpTime = table.Column<DateTime>(nullable: false),
                    StackType = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    IsBind = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    BatchCode = table.Column<string>(nullable: true),
                    IsBindMsg = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsScatter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_ATSCELLINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_ATSCELLINFO_DETAIL",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CellNo = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    RequestQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_ATSCELLINFO_DETAIL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_BARCODELIST",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StackTaskId = table.Column<string>(nullable: true),
                    EntryTaskId = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    CodeSeq = table.Column<int>(nullable: false),
                    EntryNum = table.Column<int>(nullable: false),
                    StackNum = table.Column<int>(nullable: false),
                    EXTAttr1 = table.Column<string>(nullable: true),
                    EXTAttr2 = table.Column<string>(nullable: true),
                    EXTAttr3 = table.Column<string>(nullable: true),
                    EXTAttr4 = table.Column<string>(nullable: true),
                    EXTAttr5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_BARCODELIST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_CONSIGNOR",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_CONSIGNOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_DEVICESTATUS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeviceNo = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    MaxTaskNum = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    StationNo = table.Column<string>(nullable: true),
                    DeviceStatus = table.Column<int>(nullable: false),
                    BusinessType = table.Column<int>(nullable: false),
                    ThrougNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_DEVICESTATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_INBOUND",
                columns: table => new
                {
                    InBoundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "T_WMS_INBOUNDLINE",
                columns: table => new
                {
                    InboundDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InboundId = table.Column<int>(nullable: false),
                    CigaretteName = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    ItemQty = table.Column<int>(nullable: false),
                    Consignsor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InboundDetailId = table.Column<int>(nullable: false),
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
                name: "T_WMS_INVENTORY",
                columns: table => new
                {
                    InventroyId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    InventoryType = table.Column<string>(nullable: true),
                    Consignor = table.Column<string>(nullable: true),
                    Qty = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_INVENTORY", x => x.InventroyId);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_INVENTORYLINE",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    InventoryId = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    ItemQty = table.Column<int>(nullable: false),
                    InventoryType = table.Column<string>(nullable: true),
                    AreaNo = table.Column<string>(nullable: true),
                    ThroughNo = table.Column<string>(nullable: true),
                    Consignor = table.Column<string>(nullable: true),
                    InitQty = table.Column<int>(nullable: false),
                    InQty = table.Column<int>(nullable: false),
                    OutQty = table.Column<int>(nullable: false),
                    EndQty = table.Column<int>(nullable: false),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_INVENTORYLINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_ITEM",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    DCNo = table.Column<string>(nullable: true),
                    ShipperId = table.Column<string>(nullable: true),
                    ItemNo = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Spec = table.Column<string>(nullable: true),
                    ABCCode = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<double>(nullable: false),
                    ShipType = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<string>(nullable: true),
                    ProduceArea = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    BaseUomId = table.Column<string>(nullable: true),
                    DefaultUomId = table.Column<string>(nullable: true),
                    StorageCondition = table.Column<string>(nullable: true),
                    IsLotCtrl = table.Column<int>(nullable: false),
                    ShelfLife = table.Column<int>(nullable: false),
                    ShelfLifeType = table.Column<string>(nullable: true),
                    PalletRatio = table.Column<double>(nullable: false),
                    DelStatus = table.Column<string>(nullable: true),
                    CatId = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    PackBarCode = table.Column<string>(nullable: true),
                    ItemKind = table.Column<string>(nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    HSize = table.Column<double>(nullable: false),
                    TSize = table.Column<double>(nullable: false),
                    JSize = table.Column<double>(nullable: false),
                    WSize = table.Column<double>(nullable: false),
                    XSize = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    FullCountUp = table.Column<int>(nullable: false),
                    FullCountDown = table.Column<int>(nullable: false),
                    UnStackMode = table.Column<string>(nullable: true),
                    CanScan = table.Column<string>(nullable: true),
                    StackType = table.Column<string>(nullable: true),
                    SecStackType = table.Column<string>(nullable: true),
                    JTSize = table.Column<double>(nullable: false),
                    WZSize = table.Column<double>(nullable: false),
                    OutType = table.Column<string>(nullable: true),
                    DoubleTake = table.Column<string>(nullable: true),
                    ILength = table.Column<double>(nullable: false),
                    IWidth = table.Column<double>(nullable: false),
                    IHeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_ITEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_OUTBOUND",
                columns: table => new
                {
                    OutBoundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutboundId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_T_WMS_OUTBOUNDLINE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_OUTBOUNDTASK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutboundDetailId = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "T_WMS_SOURCEBOUNDNOTICE",
                columns: table => new
                {
                    WmsTaskNoticeId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    MaterialType = table.Column<string>(nullable: true),
                    TaskType = table.Column<string>(nullable: true),
                    BusType = table.Column<string>(nullable: true),
                    NoticeDate = table.Column<DateTime>(nullable: false),
                    NoticeNo = table.Column<string>(nullable: true),
                    ContractNo = table.Column<string>(nullable: true),
                    ShipFrom = table.Column<string>(nullable: true),
                    ShipFromId = table.Column<string>(nullable: true),
                    BuildLocDesc = table.Column<string>(nullable: true),
                    BuildLocId = table.Column<string>(nullable: true),
                    ShipTo = table.Column<string>(nullable: true),
                    ShipToId = table.Column<string>(nullable: true),
                    ShipToInv = table.Column<string>(nullable: true),
                    ShipToInvId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Uom = table.Column<string>(nullable: true),
                    SecondQty = table.Column<int>(nullable: false),
                    SecondUom = table.Column<string>(nullable: true),
                    Carrier = table.Column<string>(nullable: true),
                    VehicleLicense = table.Column<string>(nullable: true),
                    VehicleMan = table.Column<string>(nullable: true),
                    VehiclePhone = table.Column<string>(nullable: true),
                    TransportLicense = table.Column<string>(nullable: true),
                    EquipmentNo = table.Column<string>(nullable: true),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    QuickFlag = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_SOURCEBOUNDNOTICE", x => x.WmsTaskNoticeId);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_SOURCEBOUNDNOTICE_LINE",
                columns: table => new
                {
                    NoticeLineId = table.Column<string>(nullable: false),
                    WmsTaskNoticeId = table.Column<string>(nullable: true),
                    LineNum = table.Column<string>(nullable: true),
                    ItemNo = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    YearOf = table.Column<string>(nullable: true),
                    OriginPlace = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    ReversionNum = table.Column<string>(nullable: true),
                    BoxIdentifier = table.Column<string>(nullable: true),
                    ProdIdentifier = table.Column<string>(nullable: true),
                    Spec = table.Column<string>(nullable: true),
                    BuildLocId = table.Column<string>(nullable: true),
                    BuildLocDesc = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Uom = table.Column<string>(nullable: true),
                    SecondQty = table.Column<string>(nullable: true),
                    SecondUom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_SOURCEBOUNDNOTICE_LINE", x => x.NoticeLineId);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_STATIONINFO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StationNo = table.Column<string>(nullable: true),
                    StationDesc = table.Column<string>(nullable: true),
                    StationType = table.Column<string>(nullable: true),
                    ControlNo = table.Column<string>(nullable: true),
                    VStationNo = table.Column<string>(nullable: true),
                    RelateNo = table.Column<string>(nullable: true),
                    TechNo = table.Column<string>(nullable: true),
                    BufferNo = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    StationCheckNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_STATIONINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_STORAGEAREA",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AreaCode = table.Column<string>(nullable: true),
                    AreaName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_STORAGEAREA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_TASKAPPLY",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    WmsJobId = table.Column<string>(nullable: true),
                    JobType = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Target = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    PlanQty = table.Column<int>(nullable: false),
                    StackType = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    PalletNo = table.Column<string>(nullable: true),
                    TuType = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    RespondTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    InputType = table.Column<int>(nullable: false),
                    FullCount = table.Column<int>(nullable: false),
                    UnStackMode = table.Column<int>(nullable: false),
                    TaskNo = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    IsScan = table.Column<string>(nullable: true),
                    ActQty = table.Column<int>(nullable: false),
                    MachineNo = table.Column<string>(nullable: true),
                    PreJobId = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<string>(nullable: true),
                    MaxDelayTime = table.Column<int>(nullable: false),
                    CurrentMode = table.Column<string>(nullable: true),
                    RequestMode = table.Column<string>(nullable: true),
                    ResponseBy = table.Column<string>(nullable: true),
                    ResponseCount = table.Column<int>(nullable: false),
                    ResponseMsg = table.Column<string>(nullable: true),
                    PlatForm = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsBind = table.Column<string>(nullable: true),
                    ForceFlag = table.Column<string>(nullable: true),
                    TransferFlag = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    IsWrap = table.Column<string>(nullable: true),
                    SortNum = table.Column<int>(nullable: false),
                    EXTAttr1 = table.Column<string>(nullable: true),
                    EXTAttr2 = table.Column<string>(nullable: true),
                    EXTAttr3 = table.Column<string>(nullable: true),
                    EXTAttr4 = table.Column<string>(nullable: true),
                    EXTAttr5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_TASKAPPLY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_THROUGH",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LineNum = table.Column<string>(nullable: true),
                    ThrougNo = table.Column<string>(nullable: true),
                    ThroughDesc = table.Column<string>(nullable: true),
                    ActCount = table.Column<int>(nullable: false),
                    MachineSeq = table.Column<int>(nullable: false),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CIgaretteName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Mantissa = table.Column<int>(nullable: false),
                    CigaretteType = table.Column<string>(nullable: true),
                    ReplenishLine = table.Column<string>(nullable: true),
                    TransportationLine = table.Column<int>(nullable: false),
                    LastMantissa = table.Column<int>(nullable: false),
                    AreaNo = table.Column<string>(nullable: true),
                    GroupNo = table.Column<string>(nullable: true),
                    Threshold = table.Column<int>(nullable: false),
                    BoxCount = table.Column<int>(nullable: false),
                    MantissaLess = table.Column<string>(nullable: true),
                    CleanUp = table.Column<string>(nullable: true),
                    CleanThreshold = table.Column<int>(nullable: false),
                    Seq = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_THROUGH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_TRANSFER",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    SourceAreaNo = table.Column<string>(nullable: true),
                    SourceAreaName = table.Column<string>(nullable: true),
                    TargetAreaNo = table.Column<string>(nullable: true),
                    TargetAreaName = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    BarQty = table.Column<int>(nullable: false),
                    TransferType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DelStatus = table.Column<int>(nullable: false),
                    OutCheckId = table.Column<string>(nullable: true),
                    OutCheckName = table.Column<string>(nullable: true),
                    OutCheckTime = table.Column<string>(nullable: true),
                    ReceiveCheckId = table.Column<string>(nullable: true),
                    ReceiveCheckName = table.Column<string>(nullable: true),
                    ReceiveCheckTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_TRANSFER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_TRANSFERLINE",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    ThroughNo = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    BarQty = table.Column<int>(nullable: false),
                    TargetThroughNo = table.Column<string>(nullable: true),
                    SourceAreaNo = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_TRANSFERLINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_WMS_TRANSFERLIST",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    AreaNo = table.Column<string>(nullable: true),
                    CellNo = table.Column<string>(nullable: true),
                    BoxQty = table.Column<int>(nullable: false),
                    BarQty = table.Column<int>(nullable: false),
                    InOutType = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(nullable: true),
                    CigaretteCode = table.Column<string>(nullable: true),
                    CigaretteName = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    CigaretteType = table.Column<string>(nullable: true),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    GroupNo = table.Column<string>(nullable: true),
                    OrderNo = table.Column<string>(nullable: true),
                    SpecItem = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_TRANSFERLIST", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INF_EQUIPMENTINFO");

            migrationBuilder.DropTable(
                name: "INF_EQUIPMENTREQUEST");

            migrationBuilder.DropTable(
                name: "INF_JOBDOWNLOAD");

            migrationBuilder.DropTable(
                name: "INF_JOBFEEDBACK");

            migrationBuilder.DropTable(
                name: "T_WMS_AREASTOCKINFO_DETAIL");

            migrationBuilder.DropTable(
                name: "T_WMS_ATSCELL");

            migrationBuilder.DropTable(
                name: "T_WMS_ATSCELLINFO");

            migrationBuilder.DropTable(
                name: "T_WMS_ATSCELLINFO_DETAIL");

            migrationBuilder.DropTable(
                name: "T_WMS_BARCODELIST");

            migrationBuilder.DropTable(
                name: "T_WMS_CONSIGNOR");

            migrationBuilder.DropTable(
                name: "T_WMS_DEVICESTATUS");

            migrationBuilder.DropTable(
                name: "T_WMS_INBOUND");

            migrationBuilder.DropTable(
                name: "T_WMS_INBOUNDLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_INBOUNDTASK");

            migrationBuilder.DropTable(
                name: "T_WMS_INVENTORY");

            migrationBuilder.DropTable(
                name: "T_WMS_INVENTORYLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_ITEM");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUND");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUNDLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_OUTBOUNDTASK");

            migrationBuilder.DropTable(
                name: "T_WMS_SOURCEBOUNDNOTICE");

            migrationBuilder.DropTable(
                name: "T_WMS_SOURCEBOUNDNOTICE_LINE");

            migrationBuilder.DropTable(
                name: "T_WMS_STATIONINFO");

            migrationBuilder.DropTable(
                name: "T_WMS_STORAGEAREA");

            migrationBuilder.DropTable(
                name: "T_WMS_TASKAPPLY");

            migrationBuilder.DropTable(
                name: "T_WMS_THROUGH");

            migrationBuilder.DropTable(
                name: "T_WMS_TRANSFER");

            migrationBuilder.DropTable(
                name: "T_WMS_TRANSFERLINE");

            migrationBuilder.DropTable(
                name: "T_WMS_TRANSFERLIST");
        }
    }
}
