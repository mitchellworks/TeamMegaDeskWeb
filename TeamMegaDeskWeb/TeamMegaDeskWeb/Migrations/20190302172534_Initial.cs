using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamMegaDeskWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Drawers = table.Column<int>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    RushDays = table.Column<int>(nullable: false),
                    QuoteAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");
        }
    }
}
