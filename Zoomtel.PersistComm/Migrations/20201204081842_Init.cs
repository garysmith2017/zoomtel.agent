using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_QUARTZ_TASK",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    TaskCode = table.Column<string>(nullable: true),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TriggerType = table.Column<int>(nullable: false),
                    Cron = table.Column<string>(nullable: true),
                    IntervalInSeconds = table.Column<int>(nullable: false),
                    RepeatCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_QUARTZ_TASK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_QUARTZ_TASKGROUP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupCode = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_QUARTZ_TASKGROUP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_QUARTZ_TASKLOG",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Msg = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_QUARTZ_TASKLOG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_ACCOUNT",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 30, nullable: true),
                    LoginPwd = table.Column<string>(maxLength: 100, nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    PassSalt = table.Column<string>(nullable: true),
                    LoginCount = table.Column<int>(nullable: false),
                    LastIp = table.Column<string>(nullable: true),
                    LastUserAgent = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_ACCOUNT", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_ACCOUNTROLE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_ACCOUNTROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_AUDITINFO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Uid = table.Column<Guid>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    ControllerDesc = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    ActionDesc = table.Column<string>(nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<long>(nullable: false),
                    BrowserInfo = table.Column<string>(maxLength: 500, nullable: true),
                    IP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_AUDITINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_BASETYPEINFO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeCode = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    TypeContent = table.Column<string>(nullable: true),
                    TypeFlag = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    DelStatus = table.Column<string>(nullable: true),
                    Seq = table.Column<string>(nullable: true),
                    EXTAttr1 = table.Column<string>(nullable: true),
                    EXTAttr2 = table.Column<string>(nullable: true),
                    EXTAttr3 = table.Column<string>(nullable: true),
                    EXTAttr4 = table.Column<string>(nullable: true),
                    EXTAttr5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_BASETYPEINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_MENUS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    Fid = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 150, nullable: true),
                    ModuleCode = table.Column<string>(maxLength: 150, nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Seq = table.Column<int>(nullable: false),
                    Target = table.Column<string>(maxLength: 20, nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_MENUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_ROLEMENUS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_ROLEMENUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_ROLEPERMISSION",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_ROLEPERMISSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SYS_ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SYS_ROLES", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_QUARTZ_TASK");

            migrationBuilder.DropTable(
                name: "T_QUARTZ_TASKGROUP");

            migrationBuilder.DropTable(
                name: "T_QUARTZ_TASKLOG");

            migrationBuilder.DropTable(
                name: "T_SYS_ACCOUNT");

            migrationBuilder.DropTable(
                name: "T_SYS_ACCOUNTROLE");

            migrationBuilder.DropTable(
                name: "T_SYS_AUDITINFO");

            migrationBuilder.DropTable(
                name: "T_SYS_BASETYPEINFO");

            migrationBuilder.DropTable(
                name: "T_SYS_MENUS");

            migrationBuilder.DropTable(
                name: "T_SYS_ROLEMENUS");

            migrationBuilder.DropTable(
                name: "T_SYS_ROLEPERMISSION");

            migrationBuilder.DropTable(
                name: "T_SYS_ROLES");
        }
    }
}
