using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobotBloger.Infrastrucute.Data.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RobotBloger");

            migrationBuilder.CreateTable(
                name: "BlogTypes",
                schema: "RobotBloger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                schema: "RobotBloger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    SmallPhoto = table.Column<string>(type: "text", nullable: false),
                    BigPhoto = table.Column<string>(type: "text", nullable: false),
                    AltTag = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    RelaseTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    BlogTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogTypes_BlogTypeId",
                        column: x => x.BlogTypeId,
                        principalSchema: "RobotBloger",
                        principalTable: "BlogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogTypeId",
                schema: "RobotBloger",
                table: "Blogs",
                column: "BlogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs",
                schema: "RobotBloger");

            migrationBuilder.DropTable(
                name: "BlogTypes",
                schema: "RobotBloger");
        }
    }
}
