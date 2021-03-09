using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class AddJobEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_WMS_JOB",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    JobDesc = table.Column<string>(nullable: true),
                    ClassFullName = table.Column<string>(nullable: true),
                    JobTrigger = table.Column<string>(nullable: true),
                    JobTriggerPara = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ResponseSVRName = table.Column<string>(nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    MessageCode = table.Column<string>(nullable: true),
                    MessageText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WMS_JOB", x => x.JobId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_WMS_JOB");
        }
    }
}
