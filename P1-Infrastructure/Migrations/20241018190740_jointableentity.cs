using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class jointableentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultRules",
                columns: table => new
                {
                    ResultsId = table.Column<int>(type: "int", nullable: false),
                    RulesId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultRules", x => new { x.ResultsId, x.RulesId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultRules");
        }
    }
}
