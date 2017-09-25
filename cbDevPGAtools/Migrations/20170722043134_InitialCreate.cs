using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cbDevPGAtools.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DKT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DKT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GOLFER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DkTourneyID = table.Column<int>(nullable: false),
                    Exposure = table.Column<double>(nullable: false),
                    GameInfo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Playerid = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    YearCreated = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOLFER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GOLFER_DKT_DkTourneyID",
                        column: x => x.DkTourneyID,
                        principalTable: "DKT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GOLFER_DkTourneyID",
                table: "GOLFER",
                column: "DkTourneyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GOLFER");

            migrationBuilder.DropTable(
                name: "DKT");
        }
    }
}
