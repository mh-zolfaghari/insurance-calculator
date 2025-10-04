using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageDefinition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Minimum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Maximum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverageItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverageItems_CoverageDefinition_CoverageDefinitionId",
                        column: x => x.CoverageDefinitionId,
                        principalTable: "CoverageDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverageItems_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverageDefinition_Name",
                table: "CoverageDefinition",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoverageItems_CoverageDefinitionId",
                table: "CoverageItems",
                column: "CoverageDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageItems_InsuranceRequestId_CoverageDefinitionId",
                table: "CoverageItems",
                columns: new[] { "InsuranceRequestId", "CoverageDefinitionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_UserId",
                table: "InsuranceRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverageItems");

            migrationBuilder.DropTable(
                name: "CoverageDefinition");

            migrationBuilder.DropTable(
                name: "InsuranceRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
