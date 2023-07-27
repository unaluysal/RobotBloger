using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobotBloger.Infrastrucute.Data.Migrations
{
    public partial class t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaticWords",
                schema: "RobotBloger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BlogTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticWords_BlogTypes_BlogTypeId",
                        column: x => x.BlogTypeId,
                        principalSchema: "RobotBloger",
                        principalTable: "BlogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaticWords_BlogTypeId",
                schema: "RobotBloger",
                table: "StaticWords",
                column: "BlogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticWords",
                schema: "RobotBloger");
        }
    }
}
