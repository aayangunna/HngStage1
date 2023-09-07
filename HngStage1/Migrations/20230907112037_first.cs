using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HngStage1.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtcTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Track = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubRepoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
