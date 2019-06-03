using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoWebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ToDoTime = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ToDoPrioritiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_ToDoPriorities_ToDoPrioritiesId",
                        column: x => x.ToDoPrioritiesId,
                        principalTable: "ToDoPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDoPriorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Low" });

            migrationBuilder.InsertData(
                table: "ToDoPriorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Normal" });

            migrationBuilder.InsertData(
                table: "ToDoPriorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "High" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Status", "ToDoPrioritiesId", "ToDoTime", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2019, 6, 3, 13, 46, 45, 612, DateTimeKind.Local), "Meeting at X place with Y people.", "Meeting", 0, 1, new DateTime(2019, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Status", "ToDoPrioritiesId", "ToDoTime", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2019, 6, 3, 13, 46, 45, 612, DateTimeKind.Local), "Watch the new episode of X.", "New episode", 0, 2, new DateTime(2019, 6, 9, 22, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Status", "ToDoPrioritiesId", "ToDoTime", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2019, 6, 3, 13, 46, 45, 610, DateTimeKind.Local), "Today is the last day to check the status of X task.", "Check task status", 0, 3, new DateTime(2019, 6, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoPrioritiesId",
                table: "ToDos",
                column: "ToDoPrioritiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "ToDoPriorities");
        }
    }
}
