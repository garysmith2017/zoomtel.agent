using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoomtel.PersistComm.Migrations
{
    public partial class UpdateATSCellInfoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InBoundId",
                table: "T_WMS_ATSCELLINFO",
                newName: "BillNo");

            migrationBuilder.RenameColumn(
                name: "ImpTime",
                table: "T_WMS_ATSCELLINFO",
                newName: "InBoundTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InBoundTime",
                table: "T_WMS_ATSCELLINFO",
                newName: "ImpTime");

            migrationBuilder.RenameColumn(
                name: "BillNo",
                table: "T_WMS_ATSCELLINFO",
                newName: "InBoundId");
        }
    }
}
