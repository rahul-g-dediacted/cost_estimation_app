using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreClient.Migrations
{
    public partial class Add1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssemblyCatelogEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CatalogName = table.Column<string>(type: "text", nullable: true),
                    ReleaseId = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    Href = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyCatelogEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssemblyCatelogEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyCatelogEntity_ReleaseEntity_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "ReleaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyCatelogEntity_LocationId",
                table: "AssemblyCatelogEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyCatelogEntity_ReleaseId",
                table: "AssemblyCatelogEntity",
                column: "ReleaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyCatelogEntity");
        }
    }
}
