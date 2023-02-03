using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkDemos.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shot", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Breed = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DogShot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: false),
                    Administered = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogShot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogShot_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogShot_Shot_ShotId",
                        column: x => x.ShotId,
                        principalTable: "Shot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "City", "Name", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "Millersvile", "Saving Grace Animal Rescue", "MD", "21108" },
                    { 2, "Waldorf", "Last Chance Animal Rescue", "MD", "20603" }
                });

            migrationBuilder.InsertData(
                table: "Shot",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bordetella" },
                    { 2, "Canine Distemper" },
                    { 3, "Canine Hepatitis" },
                    { 4, "Heartworm" },
                    { 5, "Kennel Cough" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "AgencyId", "Breed", "Name", "Received" },
                values: new object[,]
                {
                    { 1, 5, 1, "Pug", "Pickles", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, "Pitty Mix", "Fluffy", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 8, 1, "Poodle", "Cheeky", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 2, "Hound", "Dan", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 7, 2, "Labrador", "Charlie", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DogShot",
                columns: new[] { "Id", "Administered", "DogId", "ShotId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 3, 10, 58, 13, 69, DateTimeKind.Local).AddTicks(6329), 1, 1 },
                    { 2, new DateTime(2023, 2, 3, 10, 58, 13, 69, DateTimeKind.Local).AddTicks(6402), 1, 2 },
                    { 3, new DateTime(2023, 2, 3, 10, 58, 13, 69, DateTimeKind.Local).AddTicks(6403), 1, 3 },
                    { 4, new DateTime(2023, 2, 3, 10, 58, 13, 69, DateTimeKind.Local).AddTicks(6405), 2, 2 },
                    { 5, new DateTime(2023, 2, 3, 10, 58, 13, 69, DateTimeKind.Local).AddTicks(6406), 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AgencyId",
                table: "Dogs",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShot_DogId",
                table: "DogShot",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogShot_ShotId",
                table: "DogShot",
                column: "ShotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogShot");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Shot");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
