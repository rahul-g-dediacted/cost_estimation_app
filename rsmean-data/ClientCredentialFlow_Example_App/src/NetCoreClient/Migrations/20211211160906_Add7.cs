using System;
using Gordian.DataApi.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreClient.Migrations
{
    public partial class Add7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyCostLineEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssemblyCostLineEntity",
                columns: table => new
                {
                    Idd = table.Column<Guid>(type: "uuid", nullable: false),
                    AssemblyCatelogId = table.Column<string>(type: "text", nullable: true),
                    AssemblyUnitCostLines = table.Column<ReferenceListAssemblyUnitLineComponent>(type: "jsonb", nullable: true),
                    BaseCosts = table.Column<AssemblyLineCostData>(type: "jsonb", nullable: true),
                    CostFactors = table.Column<CostFactorData>(type: "jsonb", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<double>(type: "double precision", nullable: true),
                    Href = table.Column<string>(type: "text", nullable: true),
                    LineNumber = table.Column<string>(type: "text", nullable: true),
                    LocalizedCosts = table.Column<LocalAssemblyLineCostData>(type: "jsonb", nullable: true),
                    LocationId = table.Column<string>(type: "text", nullable: true),
                    ReleaseId = table.Column<string>(type: "text", nullable: true),
                    RsId = table.Column<string>(type: "text", nullable: true),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyCostLineEntity", x => x.Idd);
                    table.ForeignKey(
                        name: "FK_AssemblyCostLineEntity_AssemblyCatelogEntity_AssemblyCatelo~",
                        column: x => x.AssemblyCatelogId,
                        principalTable: "AssemblyCatelogEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyCostLineEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyCostLineEntity_ReleaseEntity_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "ReleaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyCostLineEntity_AssemblyCatelogId",
                table: "AssemblyCostLineEntity",
                column: "AssemblyCatelogId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyCostLineEntity_LocationId",
                table: "AssemblyCostLineEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyCostLineEntity_ReleaseId",
                table: "AssemblyCostLineEntity",
                column: "ReleaseId");
        }
    }
}
